using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CRMDemoProject.Frm_Personal;

namespace CRMDemoProject
{
    public static class ValidationUtils
    {
        public static bool ValidateForm(Control form, CheckBox cb_SendMail = null, bool skipInfoMailCheck = false)
        {
            var formControls = GetAllValidationsControl(form);
            string databaseType = "MsSqlConnection"; // veya "PostgreSqlConnection"
            var validationRules = SQLUtils.GetValidationRulesFromDb(databaseType);
            bool isInfoMailValid = true;

            foreach (var formObj in formControls)
            {
                if (validationRules.TryGetValue(formObj.Name, out var rule))
                {
                    switch (formObj)
                    {
                        case TextBox txtBox:
                            if (txtBox.Name == "tb_InfoMail")
                            {
                                if (cb_SendMail != null && cb_SendMail.Checked)
                                {
                                    if (string.IsNullOrWhiteSpace(txtBox.Text))
                                    {
                                        isInfoMailValid = false;
                                    }
                                }
                            }
                            else
                            {
                                if (rule.Required && string.IsNullOrWhiteSpace(txtBox.Text))
                                {
                                    MessageUtils.ShowRequiredFieldMessage(txtBox.Tag?.ToString());
                                    txtBox.Focus();
                                    return false;
                                }
                                if (rule.MinLength.HasValue && txtBox.Text.Length < rule.MinLength)
                                {
                                    MessageUtils.ShowMinLengthMessage(txtBox.Tag?.ToString(), rule.MinLength.Value);
                                    txtBox.Focus();
                                    return false;
                                }
                                if (rule.MaxLength.HasValue && txtBox.Text.Length > rule.MaxLength)
                                {
                                    MessageUtils.ShowMaxLengthMessage(txtBox.Tag?.ToString(), rule.MaxLength.Value);
                                    txtBox.Focus();
                                    return false;
                                }
                                if (!string.IsNullOrEmpty(rule.RegexPattern) && !Regex.IsMatch(txtBox.Text, rule.RegexPattern))
                                {
                                    MessageUtils.ShowInvalidFormatMessage(txtBox.Tag?.ToString());
                                    txtBox.Focus();
                                    return false;
                                }
                            }
                            break;

                        case ComboBox comboBox:
                            if (rule.Required && (comboBox.SelectedIndex == 0 || comboBox.SelectedItem == null))
                            {
                                MessageUtils.ShowRequiredFieldMessage(comboBox.Tag?.ToString());
                                comboBox.Focus();
                                return false;
                            }
                            break;

                        case DateTimePicker dtp:
                            if (dtp.Name == "dtp_DateOfBirth")
                            {
                                if (!ValidateDTP.DateOfBirthDate(dtp.Value))
                                {
                                    MessageUtils.ShowInvalidAgeMessage(dtp.Tag?.ToString());
                                    dtp.Focus();
                                    return false;
                                }
                            }
                            break;
                    }
                }
            }

            if (!skipInfoMailCheck && cb_SendMail != null)
            {
                if (cb_SendMail.Checked && !isInfoMailValid)
                {
                    MessageUtils.ShowEmailRequiredMessage();
                    return false;
                }
            }

            return true;
        }

        // Formdaki tüm kontrolleri al
        private static List<Control> GetAllValidationsControl(Control parent)
        {
            var controls = new List<Control>();
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox || control is ComboBox || control is DateTimePicker)
                    controls.Add(control);

                if (control.HasChildren)
                    controls.AddRange(GetAllValidationsControl(control));
            }
            return controls;
        }
    }
}
