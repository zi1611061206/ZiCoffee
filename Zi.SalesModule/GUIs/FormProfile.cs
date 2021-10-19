using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Convertors;
using Zi.LinqSqlLayer.Enumerators;

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

        public FormProfile(UserModel currentUser, RoleModel currentRole)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            CurrentRole = currentRole;
            OnResizeMode = false;
            AlertTimer = Properties.Settings.Default.AlertTimer;
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            DrawRoundedCorner();
            LoadIcon();
            LoadSetting();
            LoadContent();
            txbOldPassword.GotFocus += TxbInput_Focus;
            txbOldPassword.LostFocus += TxbInput_UnFocus;
            txbNewPassword.GotFocus += TxbInput_Focus;
            txbNewPassword.LostFocus += TxbInput_UnFocus;
            txbConfirmPassword.GotFocus += TxbInput_Focus;
            txbConfirmPassword.LostFocus += TxbInput_UnFocus;
        }

        private void LoadContent()
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
            else if(CurrentUser.Gender.CompareTo(Genders.Female) == 0)
            {
                txbGender.Text = InterfaceRm.GetString("Female", Culture);
            }
            else
            {
                txbGender.Text = InterfaceRm.GetString("Other", Culture);
            }
            picAvatar.Image = DataTypeConvertor.Instance.GetImageFromBytes(CurrentUser.Avatar);
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

        private void LoadSetting()
        {
            SetCulture();
            SetStaticText();
            SetColor();
            SetAudio();
        }

        private void SetStaticText()
        {
            ErrorTitle = InterfaceRm.GetString("ErrorTitle", Culture);
            WarningTitle = InterfaceRm.GetString("WarningTitle", Culture);

            ttNote.SetToolTip(ipicClose, InterfaceRm.GetString("IpicClose", Culture));
            ttNote.SetToolTip(ipicMinimize, InterfaceRm.GetString("IpicMinimize", Culture));
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
            BackColor = Properties.Settings.Default.LeftSideBarBackColor;

            pnlInfo.BackColor 
                = pnlInfoDetail.BackColor
                = pnlChangePassword.BackColor
                = Properties.Settings.Default.BodyBackColor;
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

            ibtnClose.ForeColor
                = ibtnSave.ForeColor
                = Properties.Settings.Default.BaseBorderColor;

            ipicClose.IconColor
                = ipicMinimize.IconColor
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

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ProfileResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormProfile).Assembly);
            DateTimeFormat = (new CultureInfo(CultureName)).DateTimeFormat;
        }

        private void LoadIcon()
        {
            ipicClose.IconChar = IconChar.WindowClose;
            ipicMinimize.IconChar = IconChar.MinusSquare;

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

        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            // Apply form move for pnlTop
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Ipic_MouseHover(object sender, EventArgs e)
        {
            var ipic = sender as IconPictureBox;
            switch (ipic.Name)
            {
                case "ipicClose":
                    ipic.IconColor = Properties.Settings.Default.ErrorTextColor;
                    break;
                case "ipicMinimize":
                    ipic.IconColor = Properties.Settings.Default.InfoTextColor;
                    break;
                default:
                    ipic.IconColor = Properties.Settings.Default.BaseHoverColor;
                    break;
            }
        }

        private void Ipic_MouseLeave(object sender, EventArgs e)
        {
            var ipic = sender as IconPictureBox;
            ipic.IconColor = Properties.Settings.Default.BaseIconColor;
        }

        private void PnlResize_MouseHover(object sender, EventArgs e)
        {
            (sender as Panel).BackColor = Color.DarkGray;
        }

        private void PnlResize_MouseLeave(object sender, EventArgs e)
        {
            (sender as Panel).BackColor = Color.Transparent;
        }

        private void AllBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ClickStream != null)
            {
                SoundPlayer sound = new SoundPlayer();
                ClickStream.Position = 0;
                sound.Stream = null;
                sound.Stream = ClickStream;
                sound.Play();
            }
        }

        private void PnlRoundedCorner_SizeChanged(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            pnl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, 20, 20));
            AutoSizing();
        }

        private void AutoSizing()
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

        private void PnlResize_MouseDown(object sender, MouseEventArgs e)
        {
            OnResizeMode = !OnResizeMode;
        }

        private void PnlResize_MouseUp(object sender, MouseEventArgs e)
        {
            OnResizeMode = !OnResizeMode;
        }

        private void PnlResizeLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (OnResizeMode)
            {
                pnlInfo.Width = PointToClient(Cursor.Position).X;
            }
        }

        private void PnlResizeRight_MouseMove(object sender, MouseEventArgs e)
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

        private void IpicShowHidePassword_Click(object sender, EventArgs e)
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

        private void IpicClose_Click(object sender, EventArgs e)
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

        private void IpicChangePassword_Click(object sender, EventArgs e)
        {
            ShowChangePasswordPanel();
        }

        private void ShowChangePasswordPanel()
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
            }
        }

        private void IpicSalaryTable_Click(object sender, EventArgs e)
        {
            string msg = InterfaceRm.GetString("MsgNotAvailable", Culture);
            FormMessageBox.Show(msg, string.Empty, MessageBoxIcon.Information, AlertTimer);
        }

        private void IpicWorkCalendar_Click(object sender, EventArgs e)
        {
            string msg = InterfaceRm.GetString("MsgNotAvailable", Culture);
            FormMessageBox.Show(msg, string.Empty, MessageBoxIcon.Information, AlertTimer);
        }

        private void IbtnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void IbtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
