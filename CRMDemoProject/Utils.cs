using CRMDemoProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRMDemoProject
{
    public class Utils
    {
        const string _txtFilePath = @"C:\Users\akindev\Desktop\Records\";

        public static void LoadComboBox(ComboBox comboBox, List<string> values)
        {
            comboBox.Items.Add("Seçiniz");

            for (int i = 0; i < values.Count; i++)
            {
                comboBox.Items.Add(values[i]);
            }

            comboBox.SelectedIndex = 0;
        }

        public static void LoadListBox(ListBox listBox, List<string> values)
        {
            listBox.Items.Add("Seçiniz");

            for (int i = 0; i < values.Count; i++)
            {
                listBox.Items.Add(values[i]);
            }
            listBox.SelectedIndex = 0;
        }

        public static void LoadPictureBox(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = openFileDialog.OpenFile())
                    {
                        pictureBox.Image = Image.FromStream(stream);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        //public static void LoadlistBox(ListBox listBox, List<string> values)
        //{
        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        listBox.Items.Add(values[i]);
        //    }
        //}

        public static List<object> EnumToListObj(Type enumType)
        {
            List<object> typeList = new List<object>();

            foreach (var name in Enum.GetNames(enumType))
            {
                typeList.Add(name);
            }

            return typeList;
        }

        public static List<string> EnumToList(Type enumType)
        {
            List<string> typeList = new List<string>();

            foreach (var name in Enum.GetNames(enumType))
            {
                typeList.Add(name);
            }

            return typeList;
        }

        public static void WriteToTextFile(string fileName, string txtValue)
        {
            bool exists = Directory.Exists(_txtFilePath);

            if (!exists)
                Directory.CreateDirectory(_txtFilePath);

            string fullPath = string.Format(@"{0}{1}", _txtFilePath, fileName);

            bool fileExists = File.Exists(fullPath);

            if (!fileExists)
            {
                //File.Create(fullPath);
                using (File.Create(fullPath))
                {
                };

                using (StreamWriter sw = new StreamWriter(fullPath, append: true))
                {
                    sw.WriteLine(txtValue);
                }
            }
        }

        //public static IEnumerable<Control> GetAll(Control control, Type type)
        //{
        //    var controls = control.Controls.Cast<Control>();

        //    return controls.SelectMany(ctrl => GetAll(ctrl, type))
        //                              .Concat(controls)
        //                              .Where(c => c.GetType() == type);
        //}

        public static IEnumerable<Control> GetAllValidationsControl(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllValidationsControl(ctrl))
                                      .Concat(controls)
                                      .Where(c =>
                                      c.GetType() == typeof(TextBox) ||
                                      c.GetType() == typeof(RadioButton) ||
                                      c.GetType() == typeof(CheckBox) ||
                                      c.GetType() == typeof(ComboBox) ||
                                      c.GetType() == typeof(RichTextBox) ||
                                      c.GetType() == typeof(PictureBox) ||
                                      c.GetType() == typeof(ListView));
        }

        public static IEnumerable<Control> GetAllComboBox(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllValidationsControl(ctrl))
                                      .Concat(controls)
                                      .Where(c =>
                                      c.GetType() == typeof(ComboBox));
        }
        public static bool CheckSize(object formObj, int minSize, int maxSize)
        {
            if (formObj is TextBox)
            {
                TextBox textBox = (TextBox)formObj;

                if (textBox.Text.Length < minSize)
                {
                    return false;
                }
                else if (textBox.Text.Length > maxSize)
                {
                    return false;
                }
            }

            if (formObj is RichTextBox)
            {
                RichTextBox richTextBox = (RichTextBox)formObj;

                if (richTextBox.Text.Length < minSize)
                {
                    return false;
                }
                else if (richTextBox.Text.Length > maxSize)
                {
                    return false;
                }
            }

            return true;
        }

        public static string SendGmail(
            string appUser,
            string appPassword,
            string from,
            string to,
            string subject,
            string body)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(appUser, appPassword),
                    EnableSsl = true,
                };

                MailMessage message = new MailMessage
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                message.To.Add(to);

                smtpClient.Send(message);

                return "OK";

            }
            catch (Exception ex)
            {
                string fileName = "StudentRecordsMailError.txt";
                Utils.WriteToTextFile(_txtFilePath, ex.StackTrace);

                return ex.Message;
            }
        }

        //public static string GenerateHtmlTable(JObject jsonObject)
        //{
        //    StringBuilder html = new StringBuilder();

        //    // Start table
        //    html.Append("<table border='1'>");

        //    // Add data rows for ContactInformation
        //    JArray contactInformation = (JArray)jsonObject["ContactInformation"];
        //    html.Append("<tr><th colspan='3'>Contact Information</th></tr>");
        //    html.Append("<tr><th>Contact Type</th><th>Detail Type</th><th>Value</th></tr>");
        //    foreach (var contactInfo in contactInformation)
        //    {
        //        html.Append("<tr>");
        //        html.AppendFormat("<td>{0}</td>", contactInfo["Type"]);
        //        html.AppendFormat("<td>{0}</td>", contactInfo["DetailType"]);
        //        html.AppendFormat("<td>{0}</td>", contactInfo["Value"]);
        //        html.Append("</tr>");
        //    }

        //    // Add data rows for PersonInfo
        //    JObject personInfo = (JObject)jsonObject["PersonInfo"];
        //    html.Append("<tr><th colspan='3'>Person Information</th></tr>");
        //    foreach (var property in personInfo)
        //    {
        //        html.Append("<tr>");
        //        html.AppendFormat("<td>{0}</td>", property.Key);
        //        html.AppendFormat("<td colspan='2'>{0}</td>", property.Value);
        //        html.Append("</tr>");
        //    }

        //    // End table
        //    html.Append("</table>");

        //    return html.ToString();
        //}

        // 🔹 Form verilerini HTML formatına dönüştürme metodu
        public static string GenerateHtmlTable(StudentInfo studentInfo)
        {
            StringBuilder html = new StringBuilder();

            // 📌 Tablonun başlangıcı
            html.Append("<table border='1'>");

            // 🔹 Kişisel Bilgiler Bölümü
            html.Append("<tr><th colspan='2'>Kişisel Bilgiler</th></tr>");
            html.AppendFormat("<tr><td>TC Kimlik No</td><td>{0}</td></tr>", studentInfo.PersonInfo.IdNumber);
            html.AppendFormat("<tr><td>Ad</td><td>{0}</td></tr>", studentInfo.PersonInfo.Name);
            html.AppendFormat("<tr><td>Soyad</td><td>{0}</td></tr>", studentInfo.PersonInfo.Surname);
            html.AppendFormat("<tr><td>Doğum Tarihi</td><td>{0}</td></tr>", studentInfo.PersonInfo.DateOfBirth.ToShortDateString());
            html.AppendFormat("<tr><td>Ana Dil</td><td>{0}</td></tr>", studentInfo.PersonInfo.MainLanguage);
            html.AppendFormat("<tr><td>Yabancı Dil</td><td>{0}</td></tr>", studentInfo.PersonInfo.ForeignLanguage);
            html.AppendFormat("<tr><td>Cinsiyet</td><td>{0}</td></tr>", studentInfo.PersonInfo.Gender);
            html.AppendFormat("<tr><td>Seviye</td><td>{0}</td></tr>", studentInfo.PersonInfo.Level);
            html.AppendFormat("<tr><td>Açıklama</td><td>{0}</td></tr>", studentInfo.PersonInfo.Description);

            // 🔹 İletişim Bilgileri Bölümü
            html.Append("<tr><th colspan='3'>İletişim Bilgileri</th></tr>");
            html.Append("<tr><th>Tür</th><th>Detay</th><th>Değer</th></tr>");
            foreach (var contact in studentInfo.ContactInformation)
            {
                html.Append("<tr>");
                html.AppendFormat("<td>{0}</td>", contact.Type);
                html.AppendFormat("<td>{0}</td>", contact.DetailType);
                html.AppendFormat("<td>{0}</td>", contact.Value);
                html.Append("</tr>");
            }

            // 📌 Tablonun bitişi
            html.Append("</table>");

            return html.ToString();
        }

    }
}


