using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DAOs;

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

        #region Setting
        public Color BackgroundColor { get; set; } = Color.FromArgb(10, 25, 47);
        public Color TextColor { get; set; } = Color.FromArgb(255, 255, 255);
        public Color IconColor { get; set; } = Color.FromArgb(79, 202, 178);
        public Color BorderColor { get; set; } = Color.FromArgb(79, 202, 178);
        public Color BaseHoverColor { get; set; } = Color.FromArgb(135, 208, 250);
        public string ExitingMsg { get; set; } = "Are you sure you want to exit the program?";
        public string AlertMsgTitle { get; set; } = "Alert";
        public string Goodbye { get; set; } = "Goodbye, see you again.";
        public bool AllowSayBye { get; set; } = true;
        public int VoiceBotVolumn { get; set; } = 100;
        public int VoiceBotSpeakerRate { get; set; } = 0;
        #endregion

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Apply Rounded Corners for form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            LoadIcon();
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
                    ipic.IconColor = Color.FromArgb(255, 0, 0);
                    break;
                case "ipicGoogleIcon":
                    ipic.IconColor = Color.FromArgb(255, 0, 0);
                    break;
                case "ipicFacebookIcon":
                    ipic.IconColor = Color.FromArgb(24, 119, 242);
                    break;
                default:
                    ipic.IconColor = BaseHoverColor;
                    break;
            }
        }

        private void Ipic_MouseLeave(object sender, EventArgs e)
        {
            var ipic = sender as IconPictureBox;
            ipic.IconColor = IconColor;
        }

        private void ipicPasswordEndIcon_Click(object sender, EventArgs e)
        {
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
        }

        private void TxbInput_Click(object sender, EventArgs e)
        {
            var txb = sender as TextBox;
            if (txb.Name.Equals("txbUsernameInput"))
            {
                txb.SelectAll();
                lbUsernameError.Text = string.Empty;
                ipicUsernameStartIcon.IconColor = BaseHoverColor;
                pnlUsernameBorderLeft.BackColor
                    = pnlUsernameBorderBottom.BackColor
                    = pnlUsernameBorderRight.BackColor
                    = pnlUsernameBorderTop.BackColor
                    = BaseHoverColor;

                ipicPasswordStartIcon.IconColor = IconColor;
                pnlPasswordBorderLeft.BackColor
                    = pnlPasswordBorderBottom.BackColor
                    = pnlPasswordBorderRight.BackColor
                    = pnlPasswordBorderTop.BackColor
                    = BorderColor;
            }
            else if(txb.Name.Equals("txbPasswordInput"))
            {
                txb.Clear();
                lbPasswordError.Text = string.Empty;
                ipicPasswordStartIcon.IconColor = BaseHoverColor;
                pnlPasswordBorderLeft.BackColor
                    = pnlPasswordBorderBottom.BackColor
                    = pnlPasswordBorderRight.BackColor
                    = pnlPasswordBorderTop.BackColor
                    = BaseHoverColor;

                ipicUsernameStartIcon.IconColor = IconColor;
                pnlUsernameBorderLeft.BackColor
                    = pnlUsernameBorderBottom.BackColor
                    = pnlUsernameBorderRight.BackColor
                    = pnlUsernameBorderTop.BackColor
                    = BorderColor;
            }
        }

        private void ipicMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ipicClose_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void ibtnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            if (MessageBox.Show(ExitingMsg, AlertMsgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (AllowSayBye)
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
                Volume = VoiceBotVolumn,
                Rate = VoiceBotSpeakerRate
            };
            speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child);
            speaker.Speak(Goodbye);
        }

        private void ibtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string username = txbUsernameInput.Text.Trim();
            string password = txbPasswordInput.Text.Trim();
            //if (!LoginValidator.Instance.IsValid(this, username, password))
            //{
            //    return;
            //}
            //Account account = AccountImpl.Instance.GetAccountByUsername(username);
            //Employee employee = EmployeeImpl.Instance.GetEmployeeById(account.EmployeeId);
            //AccessSuccess(account, employee);
            Tuple<bool, object> a = UserService.Instance.CheckPassword(username, password, "en-US");
            MessageBox.Show(a.Item2.ToString());
        }

        //private void AccessSuccess(Account account, Employee employee)
        //{
        //    FormMain f = new FormMain(account, employee);
        //    this.Hide();
        //    f.ShowDialog();
        //    try
        //    {
        //        txbPassword.Clear();
        //        txbPassword.UseSystemPasswordChar = true;
        //        picShowPassword.Image = ShowPasswordIcon;
        //        LoadSetting();
        //        this.Show();
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //}
    }
}
