using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Resources;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DAOs;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.SalesModule.Validators;

namespace Zi.SalesModule.GUIs
{
    public partial class FormLogin : Form
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

        #region Attribites
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public Stream InitStream { get; set; }
        public Stream ClickStream { get; set; }
        #endregion

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Apply Rounded Corners for form
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            LoadIcon();
            LoadSetting();
            ActiveControl = txbUsernameInput;
            txbUsernameInput.GotFocus += TxbInput_Focus;
            txbPasswordInput.GotFocus += TxbInput_Focus;
            txbUsernameInput.LostFocus += TxbInput_UnFocus;
            txbPasswordInput.LostFocus += TxbInput_UnFocus;
        }

        private void TxbInput_UnFocus(object sender, EventArgs e)
        {
            var txb = sender as TextBox;
            TurnOffHighLight(txb);
        }

        private void TurnOffHighLight(TextBox txb)
        {
            if (txb.Name.Equals("txbPasswordInput"))
            {
                ipicPasswordStartIcon.IconColor = Properties.Settings.Default.BaseIconColor;
                pnlPasswordBorderLeft.BackColor
                    = pnlPasswordBorderBottom.BackColor
                    = pnlPasswordBorderRight.BackColor
                    = pnlPasswordBorderTop.BackColor
                    = Properties.Settings.Default.BaseBorderColor;
            }
            else if (txb.Name.Equals("txbUsernameInput"))
            {
                ipicUsernameStartIcon.IconColor = Properties.Settings.Default.BaseIconColor;
                pnlUsernameBorderLeft.BackColor
                    = pnlUsernameBorderBottom.BackColor
                    = pnlUsernameBorderRight.BackColor
                    = pnlUsernameBorderTop.BackColor
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
            if (txb.Name.Equals("txbUsernameInput"))
            {
                txb.SelectAll();
                lbUsernameError.Text = string.Empty;
                ipicUsernameStartIcon.IconColor = Properties.Settings.Default.BaseHoverColor;
                pnlUsernameBorderLeft.BackColor
                    = pnlUsernameBorderBottom.BackColor
                    = pnlUsernameBorderRight.BackColor
                    = pnlUsernameBorderTop.BackColor
                    = Properties.Settings.Default.BaseHoverColor;
            }
            else if (txb.Name.Equals("txbPasswordInput"))
            {
                txb.Clear();
                lbPasswordError.Text = string.Empty;
                ipicPasswordStartIcon.IconColor = Properties.Settings.Default.BaseHoverColor;
                pnlPasswordBorderLeft.BackColor
                    = pnlPasswordBorderBottom.BackColor
                    = pnlPasswordBorderRight.BackColor
                    = pnlPasswordBorderTop.BackColor
                    = Properties.Settings.Default.BaseHoverColor;
            }
        }

        private void LoadSetting()
        {
            SetStaticText();
            SetColor();
            SetAudio();
        }

        private void SetColor()
        {
            // Body Header Footer
            BackColor
                = txbUsernameInput.BackColor
                = txbPasswordInput.BackColor
                = Properties.Settings.Default.BodyBackColor;
            // Icon
            ipicClose.IconColor
                = ipicMinimize.IconColor
                = ipicFacebookIcon.IconColor
                = ipicGoogleIcon.IconColor
                = ipicUsernameStartIcon.IconColor
                = ipicUsernameEndIcon.IconColor
                = ipicPasswordStartIcon.IconColor
                = ipicPasswordEndIcon.IconColor
                = Properties.Settings.Default.BaseIconColor;
            // Button (Border + Text)
            ibtnLogin.ForeColor
                = ibtnExit.ForeColor
                = Properties.Settings.Default.BaseBorderColor;
            // Text
            txbUsernameInput.ForeColor
                = txbPasswordInput.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            lbCopyright.ForeColor = Properties.Settings.Default.BlurTextColor;
            // TextBox Border
            pnlUsernameBorderLeft.BackColor
                = pnlPasswordBorderLeft.BackColor
                = pnlUsernameBorderBottom.BackColor
                = pnlPasswordBorderBottom.BackColor
                = pnlUsernameBorderTop.BackColor
                = pnlPasswordBorderTop.BackColor
                = pnlUsernameBorderRight.BackColor
                = pnlPasswordBorderRight.BackColor
                = Properties.Settings.Default.BaseBorderColor;
        }

        private void SetAudio()
        {
            if (Properties.Settings.Default.AllowInitSound)
            {
                InitStream = Properties.Resources.Init;
            }
            else
            {
                InitStream = null;
            }

            if (Properties.Settings.Default.AllowClickSound)
            {
                ClickStream = Properties.Resources.Click;
            }
            else
            {
                ClickStream = null;
            }

            if (InitStream != null)
            {
                SoundPlayer sound = new SoundPlayer
                {
                    Stream = InitStream
                };
                sound.Play();
            }
        }

        private void SetStaticText()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.LoginResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormLogin).Assembly);
            
            txbUsernameInput.Text = InterfaceRm.GetString("TxtUsername", Culture);
            txbPasswordInput.Text = InterfaceRm.GetString("TxtPassword", Culture);
            ibtnLogin.Text = InterfaceRm.GetString("BtnLogin", Culture);
            ibtnExit.Text = InterfaceRm.GetString("BtnExit", Culture);
            lbCopyright.Text = InterfaceRm.GetString("LbCopyright", Culture);
        }

        private void LoadIcon()
        {
            ipicClose.IconChar = IconChar.WindowClose;
            ipicMinimize.IconChar = IconChar.MinusSquare;
            ipicFacebookIcon.IconChar = IconChar.Facebook;
            ipicGoogleIcon.IconChar = IconChar.Google;
            ipicUsernameStartIcon.IconChar = IconChar.User;
            ipicPasswordStartIcon.IconChar = IconChar.Lock;
            ipicPasswordEndIcon.IconChar = IconChar.Eye;
        }

        private void PnlTop_MouseDown(object sender, MouseEventArgs e)
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
                case "ipicGoogleIcon":
                    ipic.IconColor = Color.FromArgb(255, 0, 0);
                    break;
                case "ipicFacebookIcon":
                    ipic.IconColor = Color.FromArgb(24, 119, 242);
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

        private void IpicPasswordEndIcon_Click(object sender, EventArgs e)
        {
            string txt = txbPasswordInput.Text;
            if (txbPasswordInput.UseSystemPasswordChar == true)
            {
                txbPasswordInput.UseSystemPasswordChar = false;
                ipicPasswordEndIcon.IconChar = IconChar.EyeSlash;
            }
            else
            {
                txbPasswordInput.UseSystemPasswordChar = true;
                ipicPasswordEndIcon.IconChar = IconChar.Eye;
            }
            txbPasswordInput.Text = txt;
        }

        private void IpicMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void IpicClose_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void IbtnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            string msgExit = InterfaceRm.GetString("MsgExit", Culture);
            string titleAlert = InterfaceRm.GetString("TitleAlert", Culture);
            if (MessageBox.Show(msgExit, titleAlert, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (Properties.Settings.Default.AllowSayBye)
                {
                    SayBye();
                }
                Application.Exit();
            }
            else return;
        }

        private void SayBye()
        {
            SpeechSynthesizer speaker = new SpeechSynthesizer
            {
                Volume = Properties.Settings.Default.VoiceBotVolumn,
                Rate = Properties.Settings.Default.VoiceBotSpeakerRate
            };
            speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child);
            speaker.Speak(InterfaceRm.GetString("SentenceBye", Culture));
        }

        private void IbtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string username = txbUsernameInput.Text.Trim();
            string password = txbPasswordInput.Text.Trim();
            if (!LoginValidator.Instance.IsValid(this, username, password))
            {
                return;
            }
            UserFilter filter = new UserFilter();
            filter.Username = username;
            var user = ((Paginator<UserModel>)UserService.Instance.Read(filter, CultureName).Item2).Item[0];
            AccessSuccess(user);
        }

        private void AccessSuccess(UserModel user)
        {
            FormCashier f = new FormCashier(user);
            Hide();
            f.ShowDialog();
            try
            {
                txbPasswordInput.Clear();
                txbPasswordInput.UseSystemPasswordChar = true;
                ipicPasswordEndIcon.IconChar = IconChar.Eye;
                LoadSetting();
                Show();
            }
            catch
            {
                return;
            }
        }

        private void AllButton_MouseDown(object sender, MouseEventArgs e)
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

        private void Ibtn_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = Properties.Settings.Default.BaseHoverColor;
        }

        private void Ibtn_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = Properties.Settings.Default.BaseBorderColor;
        }
    }
}
