using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.DAOs;
using Zi.ZiCoffee.GUIs;

namespace Zi.ZiCoffee.Engines.Validations
{
    public class LoginValidator
    {
        #region Instance
        private static LoginValidator instance;
        public static LoginValidator Instance
        {
            get { if (instance == null) instance = new LoginValidator(); return instance; }
            private set { instance = value; }
        }
        private LoginValidator() { }
        #endregion

        public bool IsValid(FormLogin form, string username, string password)
        {
            form.lbUsernameValidator.Visible = false;
            form.lbPasswordValidator.Visible = false;
            return CheckBlank(form, username, password) && CheckValidInfo(form, username, password);
        }

        private bool CheckValidInfo(FormLogin form, string username, string password)
        {
            bool allCondition = true;
            if (!AccountImpl.Instance.CheckAccount(username))
            {
                form.lbUsernameValidator.Text = "Tài khoản này không tồn tại";
                form.lbUsernameValidator.Visible = true;
                allCondition = false;
            }
            if (!AccountImpl.Instance.CheckPassword(username, password))
            {
                form.lbPasswordValidator.Text = "Mật khẩu không đúng";
                form.lbPasswordValidator.Visible = true;
                allCondition = false;
            }
            return allCondition; 
        }

        private bool CheckBlank(FormLogin form, string username, string password)
        {
            bool allCondition = true;
            if (String.IsNullOrEmpty(username))
            {
                form.lbUsernameValidator.Text = "Không thể để trống";
                form.lbUsernameValidator.Visible = true;
                allCondition = false;
            }
            if (String.IsNullOrEmpty(password))
            {
                form.lbPasswordValidator.Text = "Không thể để trống";
                form.lbPasswordValidator.Visible = true;
                allCondition = false;
            }
            return allCondition;
        }
    }
}
