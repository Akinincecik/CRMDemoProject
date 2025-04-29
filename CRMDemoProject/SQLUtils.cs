
using CRMDemoProject.Helper.RabbitMQ;
using CRMDemoProject.Helper.Security;
using CRMDemoProject.ServiceReference1;
using Dapper;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CRMDemoProject
{
    public class SQLUtils
    {
        public static class DatabaseHelper
        {
            private static readonly Dictionary<string, Func<string, IDbConnection>> _connectionFactories =
                new Dictionary<string, Func<string, IDbConnection>>
                {
                    { "MsSqlConnection", connStr => new SqlConnection(connStr) },
                    { "PostgreSqlConnection", connStr => new NpgsqlConnection(connStr) }
                };

            public static string GetConnectionString(string databaseType)
            {
                if (string.IsNullOrWhiteSpace(databaseType))
                    throw new ArgumentException("Veritabanı tipi boş olamaz.", nameof(databaseType));

                // Bağlantı dizesini al
                string encryptedConnectionString = ConfigurationManager.ConnectionStrings[databaseType]?.ConnectionString;
                if (string.IsNullOrEmpty(encryptedConnectionString))
                    throw new Exception($"Bağlantı dizesi bulunamadı: {databaseType}");

                // Şifre çözme işlemi
                try
                {
                    return SecurityHelper.Decrypt(encryptedConnectionString);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Bağlantı dizesi çözülemedi: {ex.Message}");
                }
            }

            public static IDbConnection CreateConnection(string databaseType)
            {
                if (!_connectionFactories.TryGetValue(databaseType, out var connectionFactory))
                    throw new ArgumentException($"Geçersiz veritabanı tipi: {databaseType}");

                return connectionFactory(GetConnectionString(databaseType));
            }

            public static void ManageConnectionState(IDbConnection connection, bool open)
            {
                if (connection == null) throw new ArgumentNullException(nameof(connection));

                try
                {
                    if (open && connection.State != ConnectionState.Open)
                        connection.Open();
                    else if (!open && connection.State != ConnectionState.Closed)
                        connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Bağlantı yönetimi hatası: {ex.Message}");
                }
            }
        }


        public static Dictionary<string, ValidationRule> GetValidationRulesFromDb(string databaseType)
        {
            var rules = new Dictionary<string, ValidationRule>();

            using (var conn = DatabaseHelper.CreateConnection(databaseType)) // IDbConnection döndürüyor
            {
                conn.Open();

                string query = "EXEC GetValidationRules"; // Stored Procedure çağrısı

                var result = conn.Query<dynamic>(query).ToList();

                foreach (var row in result)
                {
                    var rule = new ValidationRule
                    {
                        MinLength = row.MinLength,
                        MaxLength = row.MaxLength,
                        Required = row.Required,
                        RegexPattern = row.RegexPattern
                    };

                    rules.Add(row.ControlName.ToString(), rule);
                }
            }
            return rules;
        }

        public static class QueryHelper
        {
            // 📌 Öğrenci ekleme sorgusunu alma
            public static string GetInsertStudentQuery(string databaseType)
            {
                if (databaseType == "MsSqlConnection")
                {

                    return "InsertStudent"; // Stored Procedure adı
                }
                else if (databaseType == "PostgreSqlConnection")
                {

                    return @"INSERT INTO studentinformations 
                        (fullname, fullsurname, dateofbirth, mainlanguage, 
                        foreignlanguage, foreignlanguagelevel, description, 
                        phonenumber, email, adress, picturepath) 
                        VALUES (:FullName, :FullSurName, :DateOfBirth, :Mainlanguage, 
                        :ForeignLanguage, :ForeignLanguageLevel, :Description, 
                        :PhoneNumber, :Email, :Adress, :PicturePath) 
                        RETURNING id;";

                    //return "insertstudent";
                }
                else
                {
                    throw new ArgumentException("Geçersiz veritabanı tipi.");
                }
            }

            // E-posta ekleme SQL sorgusunu alma
            public static string GetInsertEmailQuery(string databaseType)
            {
                if (databaseType == "MsSqlConnection")
                {
                    return "InsertEmail"; // Stored Procedure adı
                }
                else if (databaseType == "PostgreSqlConnection")
                {
                    return @"INSERT INTO emails 
                    (recipient, subject, body, state, created_at, sent_at, jsondata, htmldata) 
                    VALUES (@Recipient, @Subject, @Body, @State, @CreatedAt, @SentAt, @JsonData::jsonb, @HtmlData)";

                    //return "insertemail";

                }
                else
                {
                    throw new ArgumentException("Geçersiz veritabanı tipi.");
                }
            }
        }

        public static class AccountRepository
        {
            // Kullanıcı girişini doğrulama
            public static DataTable Login(string username, string password)
            {
                string queryString = @"SELECT FullName, UserName, Password 
                               FROM [Student_Records].[dbo].[Account] 
                               WHERE username = @username AND password = @password";

                using (var con = DatabaseHelper.CreateConnection("MsSqlConnection"))
                {
                    // 📌 Bağlantıyı açıyoruz
                    //DatabaseHelper.DBOpen(con);
                    DatabaseHelper.ManageConnectionState(con, true);

                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = queryString;
                        cmd.Parameters.Add(CreateParameter(cmd, "@username", username));
                        cmd.Parameters.Add(CreateParameter(cmd, "@password", password));

                        return DatabaseExecutor.ExecuteCommand(cmd, con);
                    }
                }
            }
        }

        public static class DatabaseExecutor
        {
            public static DataTable ExecuteCommand(IDbCommand cmd, IDbConnection con)
            {
                // Bağlantıyı kontrol et ve aç
                if (con.State != ConnectionState.Open)
                {
                    con.Open();  // Bağlantı açılmamışsa, açıyoruz
                }

                using (cmd)
                {
                    cmd.Connection = con;  // Komutun bağlantısını ayarla

                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }
            }

            public static int ExecuteInsertQuery(string databaseType, string query, Dictionary<string, object> parameters)
            {
                object returnId = ExecuteScalar(databaseType, query, parameters); // 🔥 Burada ExecuteScalar çağrılıyor

                if (returnId != null && int.TryParse(returnId.ToString(), out int id))
                {
                    Console.WriteLine($"✅ Yeni Kayıt ID: {id}");
                    return id;
                }
                else
                {
                    Console.WriteLine("❌ Kayıt Başarısız veya ID NULL Döndü!");
                    return 0;
                }
            }
            public static object ExecuteScalar(string databaseType, string query, Dictionary<string, object> parameters)
            {
                if (string.IsNullOrWhiteSpace(databaseType)) throw new ArgumentException("Veritabanı tipi boş olamaz.", nameof(databaseType));
                if (string.IsNullOrWhiteSpace(query)) throw new ArgumentException("Sorgu boş olamaz.", nameof(query));
                if (parameters == null) throw new ArgumentNullException(nameof(parameters));

                using (var con = DatabaseHelper.CreateConnection(databaseType))
                {
                    //DatabaseHelper.DBOpen(con);
                    DatabaseHelper.ManageConnectionState(con, true);
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = GetCommandType(databaseType);

                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(CreateParameter(cmd, param.Key, param.Value));
                        }

                        object result = cmd.ExecuteScalar();
                        //DatabaseHelper.DBClose(con);
                        DatabaseHelper.ManageConnectionState(con, false);
                        return result;
                    }
                }
            }

            private static CommandType GetCommandType(string databaseType)
            {
                return databaseType == "MsSqlConnection" ? CommandType.StoredProcedure : CommandType.Text;
            }

            //📌 Parametre oluşturma metodu(Eksik olan metod tamamlandı)
            public static IDbDataParameter CreateParameter(IDbCommand cmd, string paramName, object paramValue)
            {
                var param = cmd.CreateParameter();
                param.ParameterName = paramName;
                param.Value = paramValue ?? DBNull.Value; // Eğer değer null ise, DBNull.Value olarak ayarla
                return param;
            }
        }

        public static class StudentRepository
        {
            public static int InsertStudentInformation(string databaseType, Dictionary<string, object> parameters)
            {
                string query = QueryHelper.GetInsertStudentQuery(databaseType);

                object result = DatabaseExecutor.ExecuteScalar(databaseType, query, parameters);

                if (result != null && int.TryParse(result.ToString(), out int insertedId))
                {
                    //Console.WriteLine($"✅ Yeni öğrenci eklendi! ID: {insertedId}");
                    return insertedId;
                }

                Console.WriteLine("❌ Öğrenci eklenirken hata oluştu.");
                return -1;
            }
        }

        public static class EmailRepository
        {
            public static void InsertEmailInformation(string databaseType, Dictionary<string, object> parameters)
            {
                if (!parameters.ContainsKey("@HtmlData"))
                {
                    parameters["@HtmlData"] = DBNull.Value;
                }

                string query = QueryHelper.GetInsertEmailQuery(databaseType);
                int insertedId = DatabaseExecutor.ExecuteInsertQuery(databaseType, query, parameters);

                if (insertedId > 0)
                {
                    parameters["@EmailId"] = insertedId; // 🔑 EmailId parametrelerine ekleyelim
                    Console.WriteLine($"📌 Email Veritabanına Kaydedildi: {parameters["@Recipient"]}");

                    Console.WriteLine($"📧 Kuyruğa Mail Gönderiliyor: EmailId: {insertedId}");
                }
                else
                {
                    Console.WriteLine("❌ Email kaydedilemedi.");
                }
            }
        }

        // 📌 Parametre oluşturma
        private static IDbDataParameter CreateParameter(IDbCommand cmd, string paramName, object value)
        {
            if (cmd is SqlCommand)
            {
                return new SqlParameter(paramName, value ?? DBNull.Value);
            }
            else if (cmd is NpgsqlCommand)
            {
                return new NpgsqlParameter(paramName, value ?? DBNull.Value);
            }
            else
            {
                throw new ArgumentException("Geçersiz veritabanı komut türü.");
            }
        }

        public static DataTable GetTypes(string typeName)
        {

            string queryString = @"SELECT * FROM [Student_Records].[dbo].[Types] 
                                    WHERE IsActive = 1
                                    and TypeName = @TypeName
                                    Order by SortBy";


            using (var con = DatabaseHelper.CreateConnection("MsSqlConnection"))
            {
                //DatabaseHelper.DBOpen(con);
                DatabaseHelper.ManageConnectionState(con, true);
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = queryString;
                    cmd.Parameters.Add(CreateParameter(cmd, "@TypeName", typeName));
                    var result = DatabaseExecutor.ExecuteCommand(cmd, con);
                    //DatabaseHelper.DBClose(con);
                    DatabaseHelper.ManageConnectionState(con, false);

                    return result;
                }

            }
        }

        public static class DapperTest
        {
            public static void TestDapperQuery(string databaseType)
            {
                using (var connection = DatabaseHelper.CreateConnection(databaseType))
                {
                    connection.Open();
                    var result = connection.Query("SELECT TOP 1 * FROM Student_Records.dbo.Account").FirstOrDefault();

                    Console.WriteLine($"Sonuç: {JsonConvert.SerializeObject(result, Formatting.Indented)}");
                }
            }
        }

    }
}
