using System;
using System.Globalization;
using System.Resources;
using Zi.LinqSqlLayer.DAOs;
using Zi.SalesModule.CustomControls;
using Zi.SalesModule.GUIs;

namespace Zi.SalesModule.Validators
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
        #endregion

        #region Attributes
        public string CultureName { get; set; }
        public ResourceManager ValidateRm { get; set; }
        public CultureInfo Culture { get; set; }
        private CharactersCollection CharactersCollection { get; set; }
        private string Username { get; set; }
        private string OldPassword { get; set; }
        private string NewPassword { get; set; }
        private string ConfirmPassword { get; set; }
        #endregion

        #region DI
        private readonly UserService _userService;
        #endregion

        private ChangePasswordValidator()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ValidateResource";
            ValidateRm = new ResourceManager(BaseName, typeof(ChangePasswordValidator).Assembly);

            _userService = UserService.Instance;
        }

        public bool IsValid(FormProfile form,
            string username,
            string oldPassword,
            string newPassword,
            string confirmPassword)
        {
            Username = username;
            OldPassword = oldPassword;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;

            form.lbOldPasswordError.Text = string.Empty;
            form.lbNewPasswordError.Text = string.Empty;
            form.lbConfirmPasswordError.Text = string.Empty;

            CharactersCollection = new CharactersCollection();

            return IsNotBlank(form)
                && IsOldPasswordMatched(form)
                && IsNewPasswordCorrectRequest(form)
                && IsConfirmPasswordMatched(form);
        }

        private bool IsNotBlank(FormProfile form)
        {
            bool allCondition = true;
            if (string.IsNullOrEmpty(OldPassword))
            {
                form.lbOldPasswordError.Text = ValidateRm.GetString("NotBlank", Culture);
                allCondition = false;
            }
            if (string.IsNullOrEmpty(NewPassword))
            {
                form.lbNewPasswordError.Text = ValidateRm.GetString("NotBlank", Culture);
                allCondition = false;
            }
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                form.lbConfirmPasswordError.Text = ValidateRm.GetString("NotBlank", Culture);
                allCondition = false;
            }
            return allCondition;
        }

        private bool IsOldPasswordMatched(FormProfile form)
        {
            var checker = _userService.MatchedPassword(Username, OldPassword, CultureName);
            if (!checker.Item1)
            {
                form.lbOldPasswordError.Text = checker.Item2.ToString();
                return false;
            }
            return true;
        }

        private bool IsNewPasswordCorrectRequest(FormProfile form)
        {
            return HasMinimumLength(form)
                && HasAtLeastOneLowerCaseChar(form)
                && HasAtLeastOneUpperCaseChar(form)
                && HasAtLeastOneNumericChar(form)
                && HasAtLeastOneCommonSpecialChar(form)
                && HasNoUnicodeChar(form)
                && IsDifferenceOldPassword(form);
        }

        private bool IsDifferenceOldPassword(FormProfile form)
        {
            if (NewPassword.Equals(OldPassword))
            {
                form.lbNewPasswordError.Text = ValidateRm.GetString("SameAsOldPassword", Culture);
                return false;
            }
            return true;
        }

        private bool HasNoUnicodeChar(FormProfile form)
        {
            bool hasNoUnicodeChar = true;
            foreach (char c in NewPassword)
            {
                if (CharactersCollection.UnicodeChars.Contains(c.ToString()))
                {
                    hasNoUnicodeChar = false;
                    break;
                }
            }
            if (!hasNoUnicodeChar)
            {
                form.lbNewPasswordError.Text = ValidateRm.GetString("NoUnicodeChar", Culture) + Environment.NewLine;
            }
            return hasNoUnicodeChar;
        }

        private bool HasAtLeastOneCommonSpecialChar(FormProfile form)
        {
            bool hasAtLeastOneCommonSpecialChar = false;
            foreach (char c in NewPassword)
            {
                if (CharactersCollection.CommonSpecialChars.Contains(c.ToString()))
                {
                    hasAtLeastOneCommonSpecialChar = true;
                    break;
                }
            }
            if (!hasAtLeastOneCommonSpecialChar)
            {
                form.lbNewPasswordError.Text = ValidateRm.GetString("AtLeastOneCommonSpecialChar", Culture)
                    + ": "
                    + CharactersCollection.CommonSpecialChars
                    + Environment.NewLine;
            }
            return hasAtLeastOneCommonSpecialChar;
        }

        private bool HasAtLeastOneNumericChar(FormProfile form)
        {
            bool hasAtLeastOneNumericChar = false;
            foreach (char c in NewPassword)
            {
                if (CharactersCollection.NumericChars.Contains(c.ToString()))
                {
                    hasAtLeastOneNumericChar = true;
                    break;
                }
            }
            if (!hasAtLeastOneNumericChar)
            {
                form.lbNewPasswordError.Text = ValidateRm.GetString("AtLeastOneNumericChar", Culture) + Environment.NewLine;
            }
            return hasAtLeastOneNumericChar;
        }

        private bool HasAtLeastOneUpperCaseChar(FormProfile form)
        {
            bool hasAtLeastOneUpperCaseChar = false;
            foreach (char c in NewPassword)
            {
                if (CharactersCollection.UpperLatinChars.Contains(c.ToString()))
                {
                    hasAtLeastOneUpperCaseChar = true;
                    break;
                }
            }
            if (!hasAtLeastOneUpperCaseChar)
            {
                form.lbNewPasswordError.Text = ValidateRm.GetString("AtLeastOneUpperCaseChar", Culture) + Environment.NewLine;
            }
            return hasAtLeastOneUpperCaseChar;
        }

        private bool HasAtLeastOneLowerCaseChar(FormProfile form)
        {
            bool hasAtLeastOneLowerCaseChar = false;
            foreach (char c in NewPassword)
            {
                if (CharactersCollection.LowerLatinChars.Contains(c.ToString()))
                {
                    hasAtLeastOneLowerCaseChar = true;
                    break;
                }
            }
            if (!hasAtLeastOneLowerCaseChar)
            {
                form.lbNewPasswordError.Text = ValidateRm.GetString("AtLeastOneLowerCaseChar", Culture) + Environment.NewLine;
            }
            return hasAtLeastOneLowerCaseChar;
        }

        private bool HasMinimumLength(FormProfile form)
        {
            int minLength = 8;
            int passwordLength = NewPassword.Length;
            if (passwordLength < minLength)
            {
                form.lbNewPasswordError.Text = ValidateRm.GetString("MinLength", Culture) + ": " + minLength;
                return false;
            }
            return true;
        }

        private bool IsConfirmPasswordMatched(FormProfile form)
        {
            if (!ConfirmPassword.Equals(NewPassword))
            {
                form.lbConfirmPasswordError.Text = ValidateRm.GetString("ConfirmPasswordNotMatched", Culture);
                return false;
            }
            return true;
        }
    }
}
