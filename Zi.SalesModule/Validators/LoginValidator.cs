using System;
using System.Globalization;
using System.Resources;
using Zi.LinqSqlLayer.DAOs;
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
        public string CultureName { get; set; }
        public ResourceManager ValidateRm { get; set; }
        public CultureInfo Culture { get; set; }
        private LoginValidator() 
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ValidateResource";
            ValidateRm = new ResourceManager(BaseName, typeof(LoginValidator).Assembly);
        }
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
            Tuple<bool, object> existedUsername = UserService.Instance.ExistedUsername(username, CultureName);
            if (!existedUsername.Item1)
            {
                form.lbUsernameError.Text = existedUsername.Item2.ToString();
                allCondition = false;
                return allCondition;
            }
            Tuple<bool, object> matchedPassword = UserService.Instance.MatchedPassword(username, password, CultureName);
            if (!matchedPassword.Item1)
            {
                form.lbPasswordError.Text = matchedPassword.Item2.ToString();
                allCondition = false;
            }
            return allCondition;
        }

        private bool CheckBlank(FormLogin form, string username, string password)
        {
            bool allCondition = true;
            if (string.IsNullOrEmpty(username))
            {
                form.lbUsernameError.Text = ValidateRm.GetString("NotBlank", Culture);
                allCondition = false;
            }
            if (string.IsNullOrEmpty(password))
            {
                form.lbPasswordError.Text = ValidateRm.GetString("NotBlank", Culture);
                allCondition = false;
            }
            return allCondition;
        }
    }
}
