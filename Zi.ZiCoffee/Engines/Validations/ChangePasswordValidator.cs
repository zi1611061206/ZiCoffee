using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.DAOs;
using Zi.ZiCoffee.GUIs;

namespace Zi.ZiCoffee.Engines.Validations
{
    public class ChangePasswordValidator
    {
        #region Instance
        private static ChangePasswordValidator instance;
        public static ChangePasswordValidator Instance
        {
            get { if (instance == null) instance = new ChangePasswordValidator(); return instance; }
            private set { instance = value; }
        }
        private ChangePasswordValidator() { }
        #endregion

        public bool IsValid(FormProfile form, string username, string oldPass, string newPass, string reEnter)
        {
            form.ctxbOldPass.ZiValidate.Visible = false;
            form.ctxbNewPass.ZiValidate.Visible = false;
            form.ctxbReEnter.ZiValidate.Visible = false;

            string latinLowerChar = "abcdefghijklmnopqrstuvwxyz";
            string latinUpperChar = latinLowerChar.ToUpper();
            string numChar = "0123456789";
            string unicodeChar = "aàảãáạăằẳẵắặâầẩẫấậAÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬdđDĐeèẻẽéẹêềểễếệEÈẺẼÉẸÊỀỂỄẾỆiìỉĩíịIÌỈĨÍỊoòỏõóọôồổỗốộơờởỡớợOÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢuùủũúụưừửữứựUÙỦŨÚỤƯỪỬỮỨỰyỳỷỹýỵYỲỶỸÝỴ";
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,[]*+:@^`~";

            return
                CheckBlank(form, oldPass, newPass, reEnter)
                && CheckValidInfo(form, username, oldPass)
                && CheckLength(form, newPass)
                && CheckUnicodeChar(form, newPass, unicodeChar)
                && CheckNumChar(form, newPass, numChar)
                && CheckUpperChar(form, newPass, latinUpperChar)
                && CheckLowerChar(form, newPass, latinLowerChar)
                && CheckSpecialChar(form, newPass, specialChar)
                && CheckPasswordMatch(form, newPass, reEnter);
        }

        private bool CheckPasswordMatch(FormProfile form, string newPass, string reEnter)
        {
            if (!newPass.Equals(reEnter))
            {
                form.ctxbReEnter.ZiValidate.Text = "Mật khẩu xác nhận không khớp";
                form.ctxbReEnter.ZiValidate.Visible = true;
                return false;
            }
            return true;
        }

        private bool CheckUnicodeChar(FormProfile form, string newPass, string unicodeChar)
        {
            foreach (char c in newPass.ToCharArray())
            {
                if (unicodeChar.Contains(c))
                {
                    form.ctxbNewPass.ZiValidate.Text = "Không thế chứa kí tự có dấu (unicode)";
                    form.ctxbNewPass.ZiValidate.Visible = true;
                    return false;
                }
            }
            return true;
        }

        private bool CheckSpecialChar(FormProfile form, string newPass, string specialChar)
        {
            foreach (char c in newPass.ToCharArray())
            {
                if (specialChar.Contains(c))
                {
                    return true;
                }
            }
            form.ctxbNewPass.ZiValidate.Text = "Cần tối thiểu 1 kí tự đặc biệt";
            form.ctxbNewPass.ZiValidate.Visible = true;
            return false;
        }

        private bool CheckNumChar(FormProfile form, string newPass, string numChar)
        {
            foreach (char c in newPass.ToCharArray())
            {
                if (numChar.Contains(c))
                {
                    return true;
                }
            }
            form.ctxbNewPass.ZiValidate.Text = "Cần tối thiểu 1 chữ số";
            form.ctxbNewPass.ZiValidate.Visible = true;
            return false;
        }

        private bool CheckUpperChar(FormProfile form, string newPass, string latinUpperChar)
        {
            foreach (char c in newPass.ToCharArray())
            {
                if (latinUpperChar.Contains(c))
                {
                    return true;
                }
            }
            form.ctxbNewPass.ZiValidate.Text = "Cần tối thiểu 1 chữ cái in hoa";
            form.ctxbNewPass.ZiValidate.Visible = true;
            return false;
        }

        private bool CheckLowerChar(FormProfile form, string newPass, string latinLowerChar)
        {
            foreach(char c in newPass.ToCharArray())
            {
                if (latinLowerChar.Contains(c))
                {
                    return true;
                }
            }
            form.ctxbNewPass.ZiValidate.Text = "Cần tối thiểu 1 chữ cái thường";
            form.ctxbNewPass.ZiValidate.Visible = true;
            return false;
        }

        private bool CheckLength(FormProfile form, string newPass)
        {
            bool allCondition = true;
            if (newPass.Length < 8)
            {
                form.ctxbNewPass.ZiValidate.Text = "Tối thiểu 8 kí tự";
                form.ctxbNewPass.ZiValidate.Visible = true;
                allCondition = false;
            }
            return allCondition;
        }

        private bool CheckValidInfo(FormProfile form, string username, string oldPass)
        {
            bool allCondition = true;
            if (!AccountImpl.Instance.CheckPassword(username, oldPass))
            {
                form.ctxbOldPass.ZiValidate.Text = "Mật khẩu cũ không chính xác";
                form.ctxbOldPass.ZiValidate.Visible = true;
                allCondition = false;
            }
            return allCondition; 
        }

        private bool CheckBlank(FormProfile form, string oldPass, string newPass, string reEnter)
        {
            bool allCondition = true;
            if (String.IsNullOrEmpty(oldPass))
            {
                form.ctxbOldPass.ZiValidate.Text = "Không thể để trống";
                form.ctxbOldPass.ZiValidate.Visible = true;
                allCondition = false;
            }
            if (String.IsNullOrEmpty(newPass))
            {
                form.ctxbNewPass.ZiValidate.Text = "Không thể để trống";
                form.ctxbNewPass.ZiValidate.Visible = true;
                allCondition = false;
            }
            if (String.IsNullOrEmpty(reEnter))
            {
                form.ctxbReEnter.ZiValidate.Text = "Không thể để trống";
                form.ctxbReEnter.ZiValidate.Visible = true;
                allCondition = false;
            }
            return allCondition;
        }
    }
}
