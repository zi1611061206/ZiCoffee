using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DAOs;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Convertors;
using Zi.SalesModule.Validators;
using Zi.Utilities.Enumerators;

namespace Zi.SalesModule.GUIs
{
    public partial class FormProfile : Form
    {
        #region Form Round Corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        #endregion

        #region Form Move (Keep and move form on screen)
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Attributes
        public UserModel CurrentUser { get; set; }
        public RoleModel CurrentRole { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public DateTimeFormatInfo DateTimeFormat { get; set; }
        public Stream InitStream { get; set; }
        public Stream ClickStream { get; set; }
        public bool OnResizeMode { get; set; }
        public string ErrorTitle { get; set; }
        public string WarningTitle { get; set; }
        public int AlertTimer { get; set; }
        #endregion

        #region DI
        private readonly UserService _userService;
        #endregion

        public FormProfile(UserModel currentUser, RoleModel currentRole)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            CurrentRole = currentRole;
            _userService = UserService.Instance;
        }

        #region Initial
        private void FormProfile_Load(object sender, EventArgs e)
        {
            DrawRoundedCorner();
            LoadIcon();
            LoadSetting();
            LoadInformation();
            OnResizeMode = false;
            AlertTimer = Properties.Settings.Default.AlertTimer;
            txbConfirmPassword.GotFocus += TxbInput_Focus;
            txbConfirmPassword.LostFocus += TxbInput_UnFocus;
            txbNewPassword.GotFocus += TxbInput_Focus;
            txbNewPassword.LostFocus += TxbInput_UnFocus;
            txbOldPassword.GotFocus += TxbInput_Focus;
            txbOldPassword.LostFocus += TxbInput_UnFocus;
        }

        private void DrawRoundedCorner()
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            pnlResizeLeft.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeLeft.Width, pnlResizeLeft.Height, 20, 20));
            pnlResizeRight.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeRight.Width, pnlResizeRight.Height, 20, 20));

            pnlInfo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlInfo.Width, pnlInfo.Height, 20, 20));
            pnlInfoDetail.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlInfoDetail.Width, pnlInfoDetail.Height, 20, 20));
            pnlChangePassword.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlChangePassword.Width, pnlChangePassword.Height, 20, 20));

            picAvatar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, picAvatar.Width, picAvatar.Height, 20, 20));
        }

        private void LoadIcon()
        {
            ipicClose.IconChar = IconChar.WindowClose;

            ipicChangePassword.IconChar = IconChar.Key;
            ipicSalaryTable.IconChar = IconChar.Wallet;
            ipicWorkCalendar.IconChar = IconChar.CalendarAlt;

            ipicOldPasswordStartIcon.IconChar
                = ipicNewPasswordStartIcon.IconChar
                = ipicConfirmPasswordStartIcon.IconChar
                = IconChar.Lock;
            ipicOldPasswordEndIcon.IconChar
                = ipicNewPasswordEndIcon.IconChar
                = ipicConfirmPasswordEndIcon.IconChar
                = IconChar.Eye;

            ipicFullNameIcon.IconChar = IconChar.User;
            ipicPhoneNumberIcon.IconChar = IconChar.MobileAlt;
            ipicEmailIcon.IconChar = IconChar.Envelope;
            ipicDobIcon.IconChar = IconChar.BirthdayCake;
            ipicGenderIcon.IconChar = IconChar.VenusMars;
            ipicCitizenIdIcon.IconChar = IconChar.Passport;
            ipicAddressIcon.IconChar = IconChar.MapMarkerAlt;
        }

        private void LoadSetting()
        {
            SetCulture();
            SetStaticText();
            SetDateTimeFormat();
            SetColor();
            SetAudio();
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ProfileResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormProfile).Assembly);
        }

        private void SetDateTimeFormat()
        {
            DateTimeFormat = (new CultureInfo(CultureName)).DateTimeFormat;
        }

        private void SetStaticText()
        {
            Text = InterfaceRm.GetString("FormText", Culture);

            ErrorTitle = InterfaceRm.GetString("ErrorTitle", Culture);
            WarningTitle = InterfaceRm.GetString("WarningTitle", Culture);

            ttNote.SetToolTip(ipicClose, InterfaceRm.GetString("IpicClose", Culture));
            ttNote.SetToolTip(ipicChangePassword, InterfaceRm.GetString("IpicChangePassword", Culture));
            ttNote.SetToolTip(ipicSalaryTable, InterfaceRm.GetString("IpicSalaryTable", Culture));
            ttNote.SetToolTip(ipicWorkCalendar, InterfaceRm.GetString("IpicWorkCalendar", Culture));
            ttNote.SetToolTip(ipicOldPasswordEndIcon, InterfaceRm.GetString("IpicShowHidePassword", Culture));
            ttNote.SetToolTip(ipicNewPasswordEndIcon, InterfaceRm.GetString("IpicShowHidePassword", Culture));
            ttNote.SetToolTip(ipicConfirmPasswordEndIcon, InterfaceRm.GetString("IpicShowHidePassword", Culture));

            ttNote.SetToolTip(lbUserId, InterfaceRm.GetString("LbUserId", Culture));
            ttNote.SetToolTip(lbUsername, InterfaceRm.GetString("LbUsername", Culture));
            ttNote.SetToolTip(lbDisplayName, InterfaceRm.GetString("LbDisplayName", Culture));
            ttNote.SetToolTip(lbCreatedDate, InterfaceRm.GetString("LbCreatedDate", Culture));
            ttNote.SetToolTip(lbRole, InterfaceRm.GetString("LbRole", Culture));

            lbTitle.Text = InterfaceRm.GetString("Title", Culture);

            lbFullName.Text = InterfaceRm.GetString("LbFullName", Culture);
            lbPhoneNumber.Text = InterfaceRm.GetString("LbPhoneNumber", Culture);
            lbEmail.Text = InterfaceRm.GetString("LbEmail", Culture);
            lbDob.Text = InterfaceRm.GetString("LbDob", Culture);
            lbGender.Text = InterfaceRm.GetString("LbGender", Culture);
            lbCitizenId.Text = InterfaceRm.GetString("LbCitizenId", Culture);
            lbAddress.Text = InterfaceRm.GetString("LbAddress", Culture);

            lbOldPassword.Text = InterfaceRm.GetString("LbOldPassword", Culture);
            lbNewPassword.Text = InterfaceRm.GetString("LbNewPassword", Culture);
            lbConfirmPassword.Text = InterfaceRm.GetString("LbConfirmPassword", Culture);

            ibtnClose.Text = InterfaceRm.GetString("IbtnClose", Culture);
            ibtnSave.Text = InterfaceRm.GetString("IbtnSave", Culture);
        }

        private void SetColor()
        {
            BackColor = Properties.Settings.Default.BaseBackColor;
            // Header
            pnlTitleBar.BackColor = Properties.Settings.Default.HeaderBackColor;
            // Footer
            pnlFooterBar.BackColor = Properties.Settings.Default.FooterBackColor;
            // SideBar
            pnlLeft.BackColor = Properties.Settings.Default.LeftSideBarBackColor;
            pnlRight.BackColor = Properties.Settings.Default.RightSideBarBackColor;
            // Body
            pnlInfo.BackColor
                = pnlInfoDetail.BackColor
                = pnlChangePassword.BackColor
                = Properties.Settings.Default.BodyBackColor;
            // Icon
            ibtnClose.ForeColor
                = ibtnSave.ForeColor
                = Properties.Settings.Default.BaseBorderColor;
            ipicClose.IconColor
                = ipicChangePassword.IconColor
                = ipicSalaryTable.IconColor
                = ipicWorkCalendar.IconColor
                = ipicFullNameIcon.IconColor
                = ipicPhoneNumberIcon.IconColor
                = ipicEmailIcon.IconColor
                = ipicDobIcon.IconColor
                = ipicGenderIcon.IconColor
                = ipicCitizenIdIcon.IconColor
                = ipicAddressIcon.IconColor
                = ipicOldPasswordStartIcon.IconColor
                = ipicOldPasswordEndIcon.IconColor
                = ipicNewPasswordStartIcon.IconColor
                = ipicNewPasswordEndIcon.IconColor
                = ipicConfirmPasswordStartIcon.IconColor
                = ipicConfirmPasswordEndIcon.IconColor
                = Properties.Settings.Default.BaseIconColor;
            // TextBox
            txbAddress.BackColor
                = txbCitizenId.BackColor
                = txbDob.BackColor
                = txbEmail.BackColor
                = txbFullName.BackColor
                = txbPhoneNumber.BackColor
                = txbGender.BackColor
                = txbNewPassword.BackColor
                = txbOldPassword.BackColor
                = txbConfirmPassword.BackColor
                = Properties.Settings.Default.BodyBackColor;
            txbFullName.ForeColor
                = txbPhoneNumber.ForeColor
                = txbEmail.ForeColor
                = txbDob.ForeColor
                = txbGender.ForeColor
                = txbCitizenId.ForeColor
                = txbAddress.ForeColor
                = txbOldPassword.ForeColor
                = txbNewPassword.ForeColor
                = txbConfirmPassword.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            // Label
            lbTitle.ForeColor
                = lbUserId.ForeColor
                = lbUsername.ForeColor
                = lbDisplayName.ForeColor
                = lbCreatedDate.ForeColor
                = lbRole.ForeColor
                = lbFullName.ForeColor
                = lbPhoneNumber.ForeColor
                = lbEmail.ForeColor
                = lbDob.ForeColor
                = lbGender.ForeColor
                = lbCitizenId.ForeColor
                = lbAddress.ForeColor
                = lbOldPassword.ForeColor
                = lbNewPassword.ForeColor
                = lbConfirmPassword.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            // Border
            pnlFullNameBorderBottom.BackColor
                = pnlPhoneNumberBorderBottom.BackColor
                = pnlEmailBorderBottom.BackColor
                = pnlDobBorderBottom.BackColor
                = pnlGenderBorderBottom.BackColor
                = pnlCitizenIdBorderBottom.BackColor
                = pnlAddressBorderBottom.BackColor
                = pnlOldPasswordBorderBottom.BackColor
                = pnlNewPasswordBorderBottom.BackColor
                = pnlConfirmPasswordBorderBottom.BackColor
                = pnlFullNameBorderLeft.BackColor
                = pnlPhoneNumberBorderLeft.BackColor
                = pnlEmailBorderLeft.BackColor
                = pnlDobBorderLeft.BackColor
                = pnlGenderBorderLeft.BackColor
                = pnlCitizenIdBorderLeft.BackColor
                = pnlAddressBorderLeft.BackColor
                = pnlOldPasswordBorderLeft.BackColor
                = pnlNewPasswordBorderLeft.BackColor
                = pnlConfirmPasswordBorderLeft.BackColor
                = Properties.Settings.Default.BaseBorderColor;
        }

        private void SetAudio()
        {
            // Init Sound
            if (Properties.Settings.Default.AllowInitSound)
            {
                InitStream = Properties.Resources.Init;
            }
            else
            {
                InitStream = null;
            }

            if (InitStream != null)
            {
                SoundPlayer sound = new SoundPlayer
                {
                    Stream = InitStream
                };
                sound.Play();
            }

            // Click Sound
            if (Properties.Settings.Default.AllowClickSound)
            {
                ClickStream = Properties.Resources.Click;
            }
            else
            {
                ClickStream = null;
            }
        }

        private void LoadInformation()
        {
            string id = CurrentUser.UserId.ToString().Substring(4, 12);
            lbUserId.Text = "*****" + id + "*****";
            lbUsername.Text = CurrentUser.Username.ToUpper();
            lbDisplayName.Text = CurrentUser.DisplayName;
            lbCreatedDate.Text = CurrentUser.CreatedDate.ToString("d", DateTimeFormat);
            lbRole.Text = CurrentRole.Name;

            txbFullName.Text = CurrentUser.FullName;
            txbPhoneNumber.Text = CurrentUser.PhoneNumber;
            txbEmail.Text = CurrentUser.Email;
            txbDob.Text = CurrentUser.DateOfBirth.ToString("d", DateTimeFormat);
            txbCitizenId.Text = CurrentUser.CitizenId;
            txbAddress.Text = CurrentUser.Address;
            if (CurrentUser.Gender.CompareTo(Genders.Male) == 0)
            {
                txbGender.Text = InterfaceRm.GetString("Male", Culture);
            }
            else if (CurrentUser.Gender.CompareTo(Genders.Female) == 0)
            {
                txbGender.Text = InterfaceRm.GetString("Female", Culture);
            }
            else
            {
                txbGender.Text = InterfaceRm.GetString("Other", Culture);
            }
            picAvatar.Image = DataTypeConvertor.Instance.GetImageFromBytes(CurrentUser.Avatar);
        }
        #endregion

        #region Effects - Turn on/off TextBox focus effects
        private void TxbInput_Focus(object sender, EventArgs e)
        {
            var txb = sender as TextBox;
            TurnOnHighLight(txb);
        }

        private void TurnOnHighLight(TextBox txb)
        {
            if (txb.Name.Equals("txbOldPassword"))
            {
                lbOldPasswordError.Text = string.Empty;
                ipicOldPasswordStartIcon.IconColor = Properties.Settings.Default.BaseHoverColor;
                pnlOldPasswordBorderLeft.BackColor
                    = pnlOldPasswordBorderBottom.BackColor
                    = Properties.Settings.Default.BaseHoverColor;
            }
            else if (txb.Name.Equals("txbNewPassword"))
            {
                lbNewPasswordError.Text = string.Empty;
                ipicNewPasswordStartIcon.IconColor = Properties.Settings.Default.BaseHoverColor;
                pnlNewPasswordBorderLeft.BackColor
                    = pnlNewPasswordBorderBottom.BackColor
                    = Properties.Settings.Default.BaseHoverColor;
            }
            else
            {
                lbConfirmPasswordError.Text = string.Empty;
                ipicConfirmPasswordStartIcon.IconColor = Properties.Settings.Default.BaseHoverColor;
                pnlConfirmPasswordBorderLeft.BackColor
                    = pnlConfirmPasswordBorderBottom.BackColor
                    = Properties.Settings.Default.BaseHoverColor;
            }
        }

        private void TxbInput_UnFocus(object sender, EventArgs e)
        {
            var txb = sender as TextBox;
            TurnOffHighLight(txb);
        }

        private void TurnOffHighLight(TextBox txb)
        {
            if (txb.Name.Equals("txbOldPassword"))
            {
                ipicOldPasswordStartIcon.IconColor = Properties.Settings.Default.BaseBorderColor;
                pnlOldPasswordBorderLeft.BackColor
                    = pnlOldPasswordBorderBottom.BackColor
                    = Properties.Settings.Default.BaseBorderColor;
            }
            else if (txb.Name.Equals("txbNewPassword"))
            {
                ipicNewPasswordStartIcon.IconColor = Properties.Settings.Default.BaseBorderColor;
                pnlNewPasswordBorderLeft.BackColor
                    = pnlNewPasswordBorderBottom.BackColor
                    = Properties.Settings.Default.BaseBorderColor;
            }
            else
            {
                ipicConfirmPasswordStartIcon.IconColor = Properties.Settings.Default.BaseBorderColor;
                pnlConfirmPasswordBorderLeft.BackColor
                    = pnlConfirmPasswordBorderBottom.BackColor
                    = Properties.Settings.Default.BaseBorderColor;
            }
        }
        #endregion

        #region Effects - Move form by drag and drop
        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            DragAndDropForm();
        }

        private void DragAndDropForm()
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Effects - Resize bar
        private void PnlResize_MouseHover(object sender, EventArgs e)
        {
            TurnOnHighLightResizeBar(sender);
        }

        private void TurnOnHighLightResizeBar(object sender)
        {
            (sender as Panel).BackColor = Color.DarkGray;
        }

        private void PnlResize_MouseLeave(object sender, EventArgs e)
        {
            TurnOffHighLightResizeBar(sender);
        }

        private void TurnOffHighLightResizeBar(object sender)
        {
            (sender as Panel).BackColor = Color.Transparent;
        }

        private void PnlResize_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeResizeModeStatus();
        }

        private void PnlResize_MouseUp(object sender, MouseEventArgs e)
        {
            ChangeResizeModeStatus();
        }

        private void ChangeResizeModeStatus()
        {
            OnResizeMode = !OnResizeMode;
        }

        private void PnlResizeLeft_MouseMove(object sender, MouseEventArgs e)
        {
            ResizeInfoPanel();
        }

        private void ResizeInfoPanel()
        {
            if (OnResizeMode)
            {
                pnlInfo.Width = PointToClient(Cursor.Position).X;
            }
        }

        private void PnlResizeRight_MouseMove(object sender, MouseEventArgs e)
        {
            ResizeChangePasswordPanel();
        }

        private void ResizeChangePasswordPanel()
        {
            if (OnResizeMode)
            {
                int x = PointToClient(Cursor.Position).X;
                pnlChangePassword.Show();
                pnlChangePassword.Width = Width - pnlRight.Width - x;
                if (pnlChangePassword.Width <= 0)
                {
                    pnlChangePassword.Hide(); ;
                }
            }
        }
        #endregion

        #region Effects - Play click sound when button is clicked
        private void AllBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ClickStream != null)
            {
                PlayClickSound();
            }
        }

        private void PlayClickSound()
        {
            SoundPlayer sound = new SoundPlayer();
            ClickStream.Position = 0;
            sound.Stream = null;
            sound.Stream = ClickStream;
            sound.Play();
        }
        #endregion

        #region Effects - Re-draw rounded corner when size of sender is changed
        private void PnlRoundedCorner_SizeChanged(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            pnl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, 20, 20));
            if (pnl.Name.Equals("pnlInfo"))
            {
                AutoCentering();
            }
        }

        private void AutoCentering()
        {
            int x = (pnlAvatar.Width - picAvatar.Width) / 2;
            int y = (pnlAvatar.Height - picAvatar.Height) / 2;
            picAvatar.Location = new Point(x, y);
            x = (pnlOptions.Width - ipicChangePassword.Width) / 2;
            y = (pnlOptions.Height - ipicChangePassword.Height) / 2;
            ipicChangePassword.Location = new Point(x - ipicChangePassword.Width, y);
            ipicSalaryTable.Location = new Point(x, y);
            ipicWorkCalendar.Location = new Point(x + ipicChangePassword.Width, y);
        }
        #endregion

        #region Effects - Show/Hide password
        private void IpicShowHidePassword_Click(object sender, EventArgs e)
        {
            ShowOrHidePassword(sender);
        }

        private void ShowOrHidePassword(object sender)
        {
            IconPictureBox ipic = sender as IconPictureBox;
            switch (ipic.Name)
            {
                case "ipicOldPasswordEndIcon":
                    string oldPassword = txbOldPassword.Text;
                    txbOldPassword.UseSystemPasswordChar = !txbOldPassword.UseSystemPasswordChar;
                    ipicOldPasswordEndIcon.IconChar = txbOldPassword.UseSystemPasswordChar ? IconChar.Eye : IconChar.EyeSlash;
                    txbOldPassword.Text = oldPassword;
                    break;
                case "ipicNewPasswordEndIcon":
                    string newPassword = txbNewPassword.Text;
                    txbNewPassword.UseSystemPasswordChar = !txbNewPassword.UseSystemPasswordChar;
                    ipicNewPasswordEndIcon.IconChar = txbNewPassword.UseSystemPasswordChar ? IconChar.Eye : IconChar.EyeSlash;
                    txbNewPassword.Text = newPassword;
                    break;
                default:
                    string confirmPassword = txbConfirmPassword.Text;
                    txbConfirmPassword.UseSystemPasswordChar = !txbConfirmPassword.UseSystemPasswordChar;
                    ipicConfirmPasswordEndIcon.IconChar = txbConfirmPassword.UseSystemPasswordChar ? IconChar.Eye : IconChar.EyeSlash;
                    txbConfirmPassword.Text = confirmPassword;
                    break;
            }
        }
        #endregion

        #region Effects - Windows state switch & Close form
        private void IpicClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void IbtnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            Close();
        }

        private void IpicMinimize_Click(object sender, EventArgs e)
        {
            MinimizeSwitch();
        }

        private void MinimizeSwitch()
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Effects - Show/Hide ChangePassword panel
        private void IpicChangePassword_Click(object sender, EventArgs e)
        {
            ShowOrHideChangePasswordPanel();
        }

        private void ShowOrHideChangePasswordPanel()
        {
            if (pnlChangePassword.Visible)
            {
                pnlChangePassword.Size = pnlChangePassword.MinimumSize;
                pnlChangePassword.Hide();
            }
            else
            {
                pnlChangePassword.Size = pnlChangePassword.MaximumSize;
                double w = pnlChangePassword.Width * 2 / 3;
                pnlChangePassword.Width = (int)w;
                pnlChangePassword.Show();
                ActiveControl = txbOldPassword;
            }
        }
        #endregion

        #region Effects - Change color of icons when mouse hover/leave
        private void Ipic_MouseHover(object sender, EventArgs e)
        {
            ChangeIconColorToHover(sender);
        }

        private void ChangeIconColorToHover(object sender)
        {
            var ipic = sender as IconPictureBox;
            switch (ipic.Name)
            {
                case "ipicClose":
                    ipic.IconColor = Properties.Settings.Default.ErrorTextColor;
                    break;
                default:
                    ipic.IconColor = Properties.Settings.Default.BaseHoverColor;
                    break;
            }
        }

        private void Ipic_MouseLeave(object sender, EventArgs e)
        {
            ChangeIconColorToBase(sender);
        }

        private void ChangeIconColorToBase(object sender)
        {
            var ipic = sender as IconPictureBox;
            ipic.IconColor = Properties.Settings.Default.BaseIconColor;
        }
        #endregion

        #region Effects - Change color of button when mouse hover/leave
        private void Ibtn_MouseHover(object sender, EventArgs e)
        {
            ChangeButtonColorToHover(sender);
        }

        private void ChangeButtonColorToHover(object sender)
        {
            (sender as Button).ForeColor = Properties.Settings.Default.BaseHoverColor;
        }

        private void Ibtn_MouseLeave(object sender, EventArgs e)
        {
            ChangeButtonColorToBase(sender);
        }

        private void ChangeButtonColorToBase(object sender)
        {
            (sender as Button).ForeColor = Properties.Settings.Default.BaseBorderColor;
        }
        #endregion

        #region Effects - Show full text of error label in tooltip
        private void LbError_MouseHover(object sender, EventArgs e)
        {
            ShowFullErrorMessage(sender);
        }

        private void ShowFullErrorMessage(object sender)
        {
            Label lbError = sender as Label;
            ttNote.SetToolTip(lbError, lbError.Text);
        }
        #endregion

        #region Salary table
        private void IpicSalaryTable_Click(object sender, EventArgs e)
        {
            OpenSalaryTable();
        }

        private void OpenSalaryTable()
        {
            string msg = InterfaceRm.GetString("MsgNotAvailable", Culture);
            FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Information, AlertTimer, new Tuple<Point, Size>(Location, Size));
        }
        #endregion

        #region Work calendar
        private void IpicWorkCalendar_Click(object sender, EventArgs e)
        {
            OpenWorkCalendar();
        }

        private void OpenWorkCalendar()
        {
            string msg = InterfaceRm.GetString("MsgNotAvailable", Culture);
            FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Information, AlertTimer, new Tuple<Point, Size>(Location, Size));
        }
        #endregion

        #region Change Password
        private void IbtnSave_Click(object sender, EventArgs e)
        {
            PasswordSaveChanged();
        }

        private void PasswordSaveChanged()
        {
            string oldPassword = txbOldPassword.Text.Trim();
            string newPassword = txbNewPassword.Text.Trim();
            string confirmPassword = txbConfirmPassword.Text.Trim();

            if (!ChangePasswordValidator.Instance.IsValid(this, CurrentUser.Username, oldPassword, newPassword, confirmPassword))
            {
                return;
            }

            var updater = _userService.UpdatePassword(CurrentUser.UserId, newPassword, CultureName);
            if (!updater.Item1)
            {
                FormMessageBox.Show(updater.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
            }
            string msg = InterfaceRm.GetString("MsgChangePasswordSuccess", Culture);
            FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Success, AlertTimer, new Tuple<Point, Size>(Location, Size));
        }
        #endregion
    }
}
