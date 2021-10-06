using Zi.LinqSqlLayer.DAOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.SalesModule.GUIs;

namespace Zi.SalesModule.Validators
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
            form.lbUsernameError.Text = string.Empty;
            form.lbPasswordError.Text = string.Empty;
            return CheckBlank(form, username, password) && CheckValidInfo(form, username, password);
        }

        private bool CheckValidInfo(FormLogin form, string username, string password)
        {
            bool allCondition = true;

            //UserFilter filter = new UserFilter();
            //filter.Username = username;
            //var user = UserService.Instance.GetUsers(filter);
            //if (user.Result != null)
            //{
            //    form.lbUsernameError.Text = "Tài khoản này không tồn tại";
            //    allCondition = false;
            //}
            //if (!UserService.Instance.CheckPassword(username, password).Result)
            //{
            //    form.lbPasswordError.Text = "Mật khẩu không đúng";
            //    allCondition = false;
            //}
            return allCondition;
        }

        private bool CheckBlank(FormLogin form, string username, string password)
        {
            bool allCondition = true;
            if (string.IsNullOrEmpty(username))
            {
                form.lbUsernameError.Text = "Không thể để trống";
                allCondition = false;
            }
            if (string.IsNullOrEmpty(password))
            {
                form.lbPasswordError.Text = "Không thể để trống";
                allCondition = false;
            }
            return allCondition;
        }
    }
}
