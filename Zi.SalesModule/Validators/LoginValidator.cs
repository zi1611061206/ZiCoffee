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
        #endregion

        #region Attributes
        public string CultureName { get; set; }
        public ResourceManager ValidateRm { get; set; }
        public CultureInfo Culture { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        #endregion

        #region DI
        private readonly UserService _userService;
        #endregion

        private LoginValidator()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ValidateResource";
            ValidateRm = new ResourceManager(BaseName, typeof(LoginValidator).Assembly);

            _userService = UserService.Instance;
        }

        public bool IsValid(FormLogin form, string username, string password)
        {
            Username = username;
            Password = password;

            form.lbUsernameError.Text = string.Empty;
            form.lbPasswordError.Text = string.Empty;

            return IsBlank(form)
                && IsValidInfo(form);
        }

        private bool IsValidInfo(FormLogin form)
        {
            bool allCondition = true;
            Tuple<bool, object> existedUsername = _userService.ExistedUsername(Username, CultureName);
            if (!existedUsername.Item1)
            {
                form.lbUsernameError.Text = existedUsername.Item2.ToString();
                allCondition = false;
                return allCondition;
            }
            Tuple<bool, object> matchedPassword = _userService.MatchedPassword(Username, Password, CultureName);
            if (!matchedPassword.Item1)
            {
                form.lbPasswordError.Text = matchedPassword.Item2.ToString();
                allCondition = false;
            }
            return allCondition;
        }

        private bool IsBlank(FormLogin form)
        {
            bool allCondition = true;
            if (string.IsNullOrEmpty(Username))
            {
                form.lbUsernameError.Text = ValidateRm.GetString("NotBlank", Culture);
                allCondition = false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                form.lbPasswordError.Text = ValidateRm.GetString("NotBlank", Culture);
                allCondition = false;
            }
            return allCondition;
        }
    }
}
