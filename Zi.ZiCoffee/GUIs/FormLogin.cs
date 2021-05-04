using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Resources;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.DataAccessLayer.DAOs;
using Zi.DataTransferLayer.DTOs;
using Zi.ZiCoffee.Engines.TempleSetting;
using Zi.ZiCoffee.Engines.Theme;
using Zi.ZiCoffee.Engines.Validations;

namespace Zi.ZiCoffee.GUIs
{
    public partial class FormLogin : Form
    {
        #region Form Corner
        //Bo cong các góc của form
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

        #region Form Move
        //Giữ và di chuyển form trên màn hình
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Current Theme Icon
        public Image UsernameIcon { get; set; }
        public Image PasswordIcon { get; set; }
        public Image ShowPasswordIcon { get; set; }
        public Image HidePasswordIcon { get; set; }
        public TempleSetting Temple { get; set; }
        #endregion

        #region Attributes
        public Stream StreamInit { get; set; } //Đầu vào cho âm thanh khởi tạo form
        public Stream StreamClick { get; set; } //Đầu vào cho âm thanh click
        #endregion

        public FormLogin()
        {
            InitializeComponent();
        }

        #region Form Loaders
        private void FormLogin_Load(object sender, EventArgs e)
        {
            //Áp dụng bo góc cho form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            Temple = new TempleSetting();
            LoadSetting();
            lbUsernameValidator.Visible = false;
            lbPasswordValidator.Visible = false;
        }

        private void LoadSetting()
        {
            // Language settings
            SettingLanguage();
            // Theme settings
            SettingTheme();
            // Audio settings
            SettingAudio();
        }

        private void SettingTheme()
        {
            if(Temple.IsDarkTheme)
            {
                new DarkTheme().SetTheme();
                picUsername.Image = UsernameIcon = Properties.Resources.ZiWhiteUser;
                picPassword.Image = PasswordIcon = Properties.Resources.ZiWhiteLock;
                picShowPassword.Image = ShowPasswordIcon = Properties.Resources.ZiWhiteShowPass;
                HidePasswordIcon = Properties.Resources.ZiWhiteHidePass;
            }
            else if(Temple.IsLightTheme)
            {
                new LightTheme().SetTheme();
                picUsername.Image = UsernameIcon = Properties.Resources.ZiBlackUser;
                picPassword.Image = PasswordIcon = Properties.Resources.ZiBlackLock;
                picShowPassword.Image = ShowPasswordIcon = Properties.Resources.ZiBlackShowPass;
                HidePasswordIcon = Properties.Resources.ZiBlackHidePass;
            }

            // Backcolor
            (this as Form).BackColor
                = txbUsername.BackColor
                = txbPassword.BackColor
                = Properties.Settings.Default.MainBack;
            btnLogin.BackColor = Properties.Settings.Default.ButtonBackNoBorder;
            btnExit.BackColor = Properties.Settings.Default.ButtonBackBorder;

            pnlLine1.BackColor
                = pnlLine2.BackColor
                = Properties.Settings.Default.MainFore;

            pnlWinState.BackColor = Properties.Settings.Default.WinStateBack;

            // ForeColor
            txbPassword.ForeColor
                = txbUsername.ForeColor
                = Properties.Settings.Default.MainFore;

            lbPasswordValidator.ForeColor
                = lbUsernameValidator.ForeColor
                = Properties.Settings.Default.ErrorFore;

            btnLogin.ForeColor = Properties.Settings.Default.ButtonForeNoBorder;
            btnExit.ForeColor = Properties.Settings.Default.ButtonForeBorder; 
        }

        private void SettingAudio()
        {
            if (Temple.IsAppearance)
            {
                StreamInit = Properties.Resources.open;
            }
            else
            {
                StreamInit = null;
            }

            if (Temple.IsClick)
            {
                StreamClick = Properties.Resources.clickOK;
            }
            else
            {
                StreamClick = null;
            }

            if (StreamInit != null)
            {
                SoundPlayer sound = new SoundPlayer
                {
                    Stream = StreamInit
                };
                sound.Play();
            }
        }

        private void SettingLanguage()
        {
            string cultureName = Temple.CultureName; 
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            ResourceManager rm = new ResourceManager("Zi.ZiCoffee.Engines.Lang.ResourceLang", typeof(FormLogin).Assembly);
        }
        #endregion

        #region Effect Event
        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PicMinimize_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Name.Equals("picMinimize"))
            {
                pic.BackColor = Properties.Settings.Default.MinimizeBack;
            }
            else if(pic.Name.Equals("picClose"))
            {
                pic.BackColor = Properties.Settings.Default.CloseBack;
            }
        }

        private void PicMinimize_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.BackColor = Color.Transparent;
        }

        private void TxbUsername_Click(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Name.Equals("txbUsername"))
            {
                txbUsername.SelectAll();
                lbUsernameValidator.Visible = false;

                picUsername.Image = Properties.Resources.login;
                txbUsername.ForeColor = Properties.Settings.Default.HighlightEffectBack;
                pnlLine1.BackColor = Properties.Settings.Default.HighlightEffectBack;
                picUsername.Image = Properties.Resources.ZiEffectUser;

                picPassword.Image = Properties.Resources.password1;
                txbPassword.ForeColor = Properties.Settings.Default.MainFore;
                pnlLine2.BackColor = Properties.Settings.Default.MainFore;
                picPassword.Image = PasswordIcon;
            }
            else if(txb.Name.Equals("txbPassword"))
            {
                txbPassword.Clear();
                lbPasswordValidator.Visible = false;

                picUsername.Image = Properties.Resources.login1;
                txbUsername.ForeColor = Properties.Settings.Default.MainFore;
                pnlLine1.BackColor = Properties.Settings.Default.MainFore;
                picUsername.Image = UsernameIcon;

                picPassword.Image = Properties.Resources.password;
                txbPassword.ForeColor = Properties.Settings.Default.HighlightEffectBack;
                pnlLine2.BackColor = Properties.Settings.Default.HighlightEffectBack;
                picPassword.Image = Properties.Resources.ZiEffectLock;
            }
        }

        private void PnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            //Áp dụng di chuyển form cho pnlTitle
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Properties.Settings.Default.ButtonBackNoBorder;
            btnExit.ForeColor = Properties.Settings.Default.ButtonForeNoBorder;
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Properties.Settings.Default.ButtonBackBorder;
            btnExit.ForeColor = Properties.Settings.Default.ButtonForeBorder;
        }

        private void PicShowPassword_Click(object sender, EventArgs e)
        {
            if(txbPassword.UseSystemPasswordChar == true)
            {
                txbPassword.UseSystemPasswordChar = false;
                picShowPassword.Image = HidePasswordIcon;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
                picShowPassword.Image = ShowPasswordIcon;
            }
        }
        #endregion

        #region Exit
        private void BtnExit_Click(object sender, EventArgs e)
        {
            PicClose_Click(this, new EventArgs());
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (Temple.IsBye)
                {
                    SayBye();
                }
                Application.Exit();
            }
            else
                return;
        }

        private void SayBye()
        {
            SpeechSynthesizer speaker = new SpeechSynthesizer
            {
                Volume = Properties.Settings.Default.SpeakerVolumn
            };
            speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child);
            speaker.Rate = Properties.Settings.Default.SpeakerRate;
            string str = Properties.Settings.Default.Goodbye;
            speaker.Speak(str);
        }
        #endregion

        #region Login
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbPassword.Text.Trim();
            if (!LoginValidator.Instance.IsValid(this, username, password))
            {
                return;
            }
            Account account = AccountImpl.Instance.GetAccountByUsername(username);
            Employee employee = EmployeeImpl.Instance.GetEmployeeById(account.EmployeeId);
            AccessSuccess(account, employee);
        }

        private void AccessSuccess(Account account, Employee employee)
        {
            FormMain f = new FormMain(account, employee);
            this.Hide();
            f.ShowDialog();
            try
            {
                txbPassword.Clear();
                txbPassword.UseSystemPasswordChar = true;
                picShowPassword.Image = ShowPasswordIcon;
                LoadSetting();
                this.Show();
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
}
