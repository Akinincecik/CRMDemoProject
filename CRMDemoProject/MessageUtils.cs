using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMDemoProject
{
    public static class MessageUtils
    {
        public static void ShowRequiredFieldMessage(string fieldName)
        {
            MessageBox.Show($"{fieldName} alanı zorunludur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowMinLengthMessage(string fieldName, int minLength)
        {
            MessageBox.Show($"{fieldName} en az {minLength} karakter olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowMaxLengthMessage(string fieldName, int maxLength)
        {
            MessageBox.Show($"{fieldName} en fazla {maxLength} karakter olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInvalidFormatMessage(string fieldName)
        {
            MessageBox.Show($"{fieldName} geçerli bir formatta olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowEmailRequiredMessage()
        {
            MessageBox.Show("Info Mail adresi boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInvalidEmailMessage()
        {
            MessageBox.Show("Geçerli bir e-posta adresi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool ConfirmNoInfoMail()
        {
            return MessageBox.Show("Info Mail gönderilmeyecek, emin misiniz?", "Uyarı",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        public static void ShowInvalidAgeMessage(string fieldName)
        {
            MessageBox.Show($"{fieldName} için yaş aralığı 6 ile 25 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ConfirmMessage(string message)
        {
            return MessageBox.Show(message, "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
