using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static CRMDemoProject.SQLUtils;
using static CRMDemoProject.Utils;

namespace CRMDemoProject
{
    public partial class Frm_Login : Form
    {
        private enum Buttons
        {
            btn_Login,
            btn_Clear,
            btn_Exit
        }

        private enum Validations
        {
            tb_UserName,
            tb_Password,
        }
        public Frm_Login()
        {

            InitializeComponent();

        }

        public bool IsLoginSuccessful { get; private set; } = false;

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Buttons buttons = (Buttons)Enum.Parse(typeof(Buttons), btn.Name);



            switch (buttons)
            {
                //case Buttons.btn_Login:
                //    {

                //        DataTable dt = SQLUtils.AccountRepository.Login(tb_UserName.Text, tb_Password.Text);

                //        if (dt.Rows.Count > 0)
                //        {
                //            Frm_Personal mainForm = new Frm_Personal();
                //            mainForm.Show();

                //            this.Hide();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Username or password is incorrect.");
                //        }

                //        dt.Dispose();
                //    }

                //    //if (!ValidateForm()) 

                //    //return;
                //break;

                case Buttons.btn_Login:
                    {
                        if (!ValidateForm())
                            return;

                        //string databaseType = "MsSqlConnection"; // veya "PostgreSqlConnection"
                        DataTable dt = SQLUtils.AccountRepository.Login(tb_UserName.Text, tb_Password.Text);

                        if (dt.Rows.Count > 0)
                        {
                            Frm_Personal mainForm = new Frm_Personal();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                        }
                        break;
                    }


                case Buttons.btn_Clear:

                    //ClearForm();

                    break;

                case Buttons.btn_Exit:

                    this.Close();

                    break;

            }
        }



        private bool ValidateForm()
        {
            var formControls = GetAllValidationsControl(this);

            bool returnValue = true;

            foreach (var formObj in formControls)
            {
                Validations validations = (Validations)Enum.Parse(typeof(Validations), formObj.Name);
                switch (validations)
                {
                    case Validations.tb_UserName:
                        if (!CheckSize(formObj, 1, 20))
                        {
                            MessageBox.Show(formObj.Tag + " en az 1, en fazla 20 karakter olmalıdır.");
                            formObj.Focus();
                            return false;
                        }
                        break;
                    case Validations.tb_Password:
                        if (!CheckSize(formObj, 1, 20))
                        {
                            MessageBox.Show(formObj.Tag + " en az 1, en fazla 20 karakter olmalıdır.");
                            formObj.Focus();
                            return false;
                        }
                        break;

                }
            }
            return returnValue;
        }

        //private void ClearForm()
        //{
        //    tb_UserName.Clear();
        //    tb_Password.Clear();
        //}

        public static IEnumerable<Control> GetAllValidationsControl(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllValidationsControl(ctrl))
                                      .Concat(controls)
                                      .Where(c =>
                                      c.GetType() == typeof(TextBox) //||
                                      //c.GetType() == typeof(RadioButton) ||
                                      //c.GetType() == typeof(CheckBox) ||
                                      //c.GetType() == typeof(ComboBox) ||
                                      //c.GetType() == typeof(RichTextBox) ||
                                      //c.GetType() == typeof(PictureBox)
                                      );
        }
        private bool CheckSize(object formObj, int minSize, int maxSize)
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
            return true;
        }
    }
}
