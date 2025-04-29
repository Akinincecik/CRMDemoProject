using CRMDemoProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static CRMDemoProject.SQLUtils;
using static CRMDemoProject.Utils;

namespace CRMDemoProject
{
    #region Enums
    internal enum ListViewContactTypes : byte
    {
        Phone,
        Email,
        Adress,
    }

    internal enum ListViewContactPhoneDetailTypes : byte
    {
        Personal,
        Home,
        Work,
        Mobile,
        Bussiness,
    }

    internal enum ListViewContactEmailDetailTypes : byte
    {
        Seçiniz,
        Personal,
        Bussiness,
    }

    internal enum ListViewAdressTypes : byte
    {
        Home,
        Work,
        Other,
    }

    public enum Buttons : byte
    {
        btn_Add,
        btn_Save,
        btn_Load,
        btn_Cancel,
        btn_Clear,
        pb_PictureBox
    }
    #endregion

    public partial class Frm_Personal : Form
    {
        private int lastInsertedStudentId = -1; // 📌 Global değişken olarak tanımla


        public Frm_Personal()
        {
            InitializeComponent();

            LoadUserPicture();

            LoadTypesFromDB("MainLanguage", cmbb_MainLanguage);
            LoadTypesFromDB("ForeignLanguage", lb_ForeignLanguage);
            LoadTypesFromDB("ContactPhoneSubType", cmbb_PhoneTypes);
            LoadTypesFromDB("ContactEmailSubType", cmbb_MailTypes);
            LoadTypesFromDB("ContactAdressSubType", cmbb_AdressTypes);
        }


        private void LoadUserPicture()
        {
            string imagePath = "Resources\\icons8-person-80.png";

            pb_PictureBox.ImageLocation = imagePath;
            pb_PictureBox.Image = Image.FromFile(imagePath);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                LoadPictureBox(pb_PictureBox);
                return;
            }

            if (!(sender is Button btn))
            {
                MessageBox.Show("Invalid sender type.");
                return;
            }

            Buttons buttons = (Buttons)Enum.Parse(typeof(Buttons), btn.Name);

            switch (buttons)
            {
                case Buttons.btn_Add:
                    if (!ValidationUtils.ValidateForm(this, cb_SendMail))
                        return;

                    AddListViewItems();
                    break;

                case Buttons.btn_Save:
                    SaveStudentInformation();


                    break;

                case Buttons.btn_Clear:
                    ClearForm();
                    break;
            }
        }

        private void AddListViewItems()
        {
            AddListView(ListViewContactTypes.Phone, tb_Phone.Text);

            if (cb_EmailIsActive.Checked)
                AddListView(ListViewContactTypes.Email, tb_Email.Text);

            if (cb_AdressIsActive.Checked)
                AddListView(ListViewContactTypes.Adress, rtb_Adress.Text);
        }

        //private void SaveStudentInformation()
        //{
        //    if (!ValidationUtils.ValidateForm(this, cb_SendMail, skipInfoMailCheck: true))
        //        return;

        //    if (!ValidateAndPrepareForm(out var studentParams))
        //        return;

        //    if (!cb_SendMail.Checked && !MessageUtils.ConfirmNoInfoMail())
        //    {
        //        cb_SendMail.Checked = true;
        //        tb_InfoMail.Enabled = true;
        //        tb_InfoMail.Focus();
        //        return;
        //    }

        //    List<string> databases = new List<string> { "MsSqlConnection"/*, "PostgreSqlConnection"*/ };
        //    int lastInsertedId = -1;

        //    foreach (var db in databases)
        //    {
        //        // ✅ Öğrenci verisini fotoğraf ile birlikte her iki veritabanına ekle
        //        int insertedId = StudentRepository.InsertStudentInformation(db, studentParams);

        //        if (db == "MsSqlConnection")
        //        {
        //            lastInsertedId = insertedId; // 📌 MSSQL'deki ID'yi referans al
        //        }

        //        Console.WriteLine($"🌟 Kaydedilen StudentID ({db}): {insertedId}");
        //    }

        //    lastInsertedStudentId = lastInsertedId; // 📌 Global değişkeni güncelle
        //    Console.WriteLine($"🌟 Global StudentID: {lastInsertedStudentId}");

        //    if (cb_SendMail.Checked)
        //    {
        //        if (!ValidateAndPrepareEmail(out var emailParams))
        //            return;

        //        foreach (var db in databases)
        //        {
        //            EmailRepository.InsertEmailInformation(db, emailParams);
        //        }
        //    }

        //    MessageBox.Show("✅ Kayıt işlemi her iki veritabanı için başarılı.");
        //}

        private void SaveStudentInformation()
        {
            if (!ValidationUtils.ValidateForm(this, cb_SendMail, skipInfoMailCheck: true))
                return;

            if (!ValidateAndPrepareForm(out var studentParams))
                return;

            if (!cb_SendMail.Checked && !MessageUtils.ConfirmNoInfoMail())
            {
                cb_SendMail.Checked = true;
                tb_InfoMail.Enabled = true;
                tb_InfoMail.Focus();
                return;
            }

            List<string> databases = new List<string> { "MsSqlConnection" /*, "PostgreSqlConnection"*/ };
            int lastInsertedId = -1;

            foreach (var db in databases)
            {
                // ✅ Öğrenci verisini fotoğraf ile birlikte her iki veritabanına ekle
                int insertedId = StudentRepository.InsertStudentInformation(db, studentParams);

                if (db == "MsSqlConnection")
                {
                    lastInsertedId = insertedId; // MSSQL'deki ID'yi referans al
                }

                Console.WriteLine($"🌟 Kaydedilen StudentID ({db}): {insertedId}");
            }

            lastInsertedStudentId = lastInsertedId; // Global değişkeni güncelle
            Console.WriteLine($"🌟 Global StudentID: {lastInsertedStudentId}");

            if (cb_SendMail.Checked)
            {
                if (!ValidateAndPrepareEmail(out var emailParams))
                    return;

                foreach (var db in databases)
                {
                    EmailRepository.InsertEmailInformation(db, emailParams);
                }
            }

            MessageBox.Show("✅ Kayıt işlemi her iki veritabanı için başarılı.");
        }


        public static byte[] ConvertImageToByteArray(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }


        private bool ValidateAndPrepareForm(out Dictionary<string, object> studentParams)
        {
            studentParams = null;

            if (lv_ContactInformation.Items.Count == 0)
            {
                btn_Add.PerformClick();
            }

            studentParams = new Dictionary<string, object>
            {
                { "FullName", tb_Name.Text },
                { "FullSurName", tb_Surname.Text },
                { "MainLanguage", cmbb_MainLanguage.SelectedItem?.ToString() },
                { "ForeignLanguage", lb_ForeignLanguage.SelectedItem?.ToString() },
                { "Description", rtb_Description.Text },
                { "PhoneNumber", tb_Phone.Text },
                { "Email", tb_Email.Text },
                { "Adress", rtb_Adress.Text },
                { "DateOfBirth", dtp_DateOfBirth.Value },
                { "ForeignLanguageLevel", trb_Level.Value },
                { "PicturePath", ConvertImageToByteArray(pb_PictureBox) } // ✅ Güncellendi
            };

            return true;
        }

        private bool ValidateAndPrepareEmail(out Dictionary<string, object> emailParams)
        {
            emailParams = null;

            if (string.IsNullOrWhiteSpace(tb_InfoMail.Text))
            {
                MessageBox.Show("Lütfen formun iletileceği mail adresini giriniz!");
                tb_InfoMail.Focus();
                return false;
            }

            if (lastInsertedStudentId == -1) // 📌 Eğer öğrenci kaydedilmediyse hata ver
            {
                MessageBox.Show("Öğrenci bilgisi kaydedilmeden mail gönderilemez!");
                return false;
            }

            // Form verilerini JSON formatına çevir
            string jsonData = JsonConvert.SerializeObject(GetFormValues(lastInsertedStudentId)); // 📌 studentId ekledik

            // HTML formatına çevir
            string htmlBody = Utils.GenerateHtmlTable(GetFormValues(lastInsertedStudentId)); // 📌 studentId ekledik

            emailParams = new Dictionary<string, object>
            {
                { "@Recipient", tb_InfoMail.Text },
                { "@Subject", "Öğrenci kayıt bilgi formu" },
                { "@Body", "Test" },
                { "@State", 0 }, // 0: Queued
                { "@CreatedAt", DateTime.Now },
                { "@SentAt", DateTime.Now }, // Gönderilmediği için NULL olarak bırakıyoruz
                { "@JsonData", jsonData }, // Gerçek JSON formatındaki veri
                { "@HtmlData", htmlBody },  // HTML formatındaki veri
            };

            return true;
        }

        public class ValidateDTP
        {
            public static bool DateOfBirthString(string dob) //assumes a valid date string
            {
                DateTime dtDOB = DateTime.Parse(dob);
                return DateOfBirthDate(dtDOB);
            }

            public static bool DateOfBirthDate(DateTime dtDOB) //assumes a valid date
            {
                int age = GetAge(dtDOB);
                if (age < 6 || age > 25) { return false; }
                return true;
            }

            public static int GetAge(DateTime birthDate)
            {
                DateTime today = DateTime.Now;
                int age = today.Year - birthDate.Year;
                if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day)) { age--; }
                return age;
            }

        }

        private StudentInfo GetFormValues(int studentId)
        {
            var studentInfo = new StudentInfo
            {
                PersonInfo = new PersonInfo
                {
                    IdNumber = tb_IdNumber.Text,
                    Name = tb_Name.Text,
                    Surname = tb_Surname.Text,
                    DateOfBirth = dtp_DateOfBirth.Value,
                    MainLanguage = cmbb_MainLanguage.Text,
                    ForeignLanguage = lb_ForeignLanguage.Text,
                    Gender = GetGender(),
                    PicturePath = $"C:\\StudentImages\\student_{studentId}.jpg",
                    Level = trb_Level.Value,
                    Description = rtb_Description.Text
                }
            };

            foreach (ListViewItem itemRow in lv_ContactInformation.Items)
            {
                ListViewItem.ListViewSubItemCollection subItemRow = itemRow.SubItems;
                var contactInfo = new ContactInfo
                {
                    Type = subItemRow[0].Text,
                    DetailType = subItemRow[1].Text,
                    Value = subItemRow[2].Text
                };
                studentInfo.ContactInformation.Add(contactInfo);
            }

            return studentInfo;
        }

        private string GetGender()
        {
            string gender = string.Empty;

            if (rb_Gender_Male.Checked)
            {
                gender = rb_Gender_Male.Text;
            }
            else if (rb_Gender_Female.Checked)
            {
                gender = rb_Gender_Female.Text;
            }

            {
                gender = rb_Gender_NotGiven.Text;
            }

            return gender;
        }

        private List<string> GetListByTypeName(string typeName)
        {
            List<string> types = new List<string>();

            DataTable languageDt = SQLUtils.GetTypes(typeName);

            foreach (DataRow dtRow in languageDt.Rows)
            {
                var mainLanguage = dtRow["Value"].ToString();

                types.Add(mainLanguage);

            }

            return types;
        }

        private void LoadTypesFromDB(string typeName, ComboBox comboBox)
        {
            List<string> types = GetListByTypeName(typeName);

            LoadComboBox(comboBox, types);
        }

        private void LoadTypesFromDB(string typeName, ListBox listBox)
        {
            List<string> types = GetListByTypeName(typeName);

            LoadListBox(lb_ForeignLanguage, types);
        }

        private void AddListView(ListViewContactTypes listViewContactType, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;

            ComboBox comboBox = null;
            Type enumType = null;

            switch (listViewContactType)
            {
                case ListViewContactTypes.Phone:
                    comboBox = cmbb_PhoneTypes;
                    enumType = typeof(ListViewContactPhoneDetailTypes);
                    break;

                case ListViewContactTypes.Email:
                    comboBox = cmbb_MailTypes;
                    enumType = typeof(ListViewContactEmailDetailTypes);
                    break;

                case ListViewContactTypes.Adress:
                    comboBox = cmbb_AdressTypes;
                    enumType = typeof(ListViewAdressTypes);
                    break;

                default:
                    return; // Geçersiz tür için işlemi sonlandır
            }

            if (comboBox == null || comboBox.SelectedItem == null)
                return;

            string selectedItem = comboBox.SelectedItem.ToString();
            object detailType = Enum.Parse(enumType, selectedItem);

            AddListViewRow(listViewContactType.ToString(), detailType.ToString(), value);
        }

        private void AddListViewRow(string contactType, string listViewType, string value)
        {
            string[] arr = new string[3];
            arr[0] = contactType;
            arr[1] = listViewType;
            arr[2] = value;

            ListViewItem item = new ListViewItem(arr);
            lv_ContactInformation.Items.Add(item);
        }

        private void tb_Level_Scroll(object sender, EventArgs e)
        {

            lbl_Level.Text = trb_Level.Value.ToString();

            int value;
            if (Int32.TryParse(lbl_Level.Text, out value))
            {
                if (value <= 3)
                {
                    lbl_Level.ForeColor = Color.Red;
                }
                if (value > 3)
                {
                    lbl_Level.ForeColor = Color.Green;
                }
            }
        }

        private void ClearForm()
        {
            tb_IdNumber.Clear();
            tb_Name.Clear();
            tb_Surname.Clear();
            dtp_DateOfBirth.Text = string.Empty;
            cmbb_MainLanguage.SelectedIndex = 0;
            lb_ForeignLanguage.SelectedIndex = -1;
            trb_Level.Value = 0;
            lbl_Level.Text = "0";
            rtb_Description.Text = string.Empty;
            tb_Phone.Clear();
            tb_Email.Clear();
            rtb_Adress.Clear();
            cmbb_PhoneTypes.SelectedIndex = 0;
            cmbb_MailTypes.SelectedIndex = 0;
            cmbb_AdressTypes.SelectedIndex = 0;
            cb_SendMail.Checked = false;
            lv_ContactInformation.Items.Clear();
        }

        private void cb_SendMail_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_SendMail.Checked)
            {
                tb_InfoMail.Enabled = true;
                tb_InfoMail.Focus();
            }
            else
            {
                tb_InfoMail.Clear();
                tb_InfoMail.Enabled = false;
            }
        }

        private void cb_EmailIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_EmailIsActive.Checked)
            {
                tb_Email.Enabled = true;
                cmbb_MailTypes.Enabled = true;
                tb_Email.Focus();
            }
            else
            {
                tb_Email.Clear();
                cmbb_MailTypes.SelectedIndex = 0;
                tb_Email.Enabled = false;
                cmbb_MailTypes.Enabled = false;
            }
        }
        private void cb_AdressIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AdressIsActive.Checked)
            {
                rtb_Adress.Enabled = true;
                cmbb_AdressTypes.Enabled = true;
                rtb_Adress.Focus();
            }
            else
            {
                rtb_Adress.Clear();
                cmbb_AdressTypes.SelectedIndex = 0;
                rtb_Adress.Enabled = false;
                cmbb_AdressTypes.Enabled = false;
            }
        }
    }
}
