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
using Zi.SalesModule.PartialForms;
using Zi.SalesModule.Settings;
using Zi.Utilities.Enumerators;

namespace Zi.SalesModule.GUIs
{
    public partial class FormSetting : Form
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
        public bool HasChange { get; set; }
        public RoleModel CurrentRole { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public Stream InitStream { get; set; }
        public Stream ClickStream { get; set; }
        public bool OnResizeMode { get; set; }
        public string ErrorTitle { get; set; }
        public string WarningTitle { get; set; }
        public int AlertTimer { get; set; }
        public BackupSetting BackupSetting { get; set; }
        #endregion

        public FormSetting(RoleModel currentRole)
        {
            InitializeComponent();
            CurrentRole = currentRole;
            HasChange = true;
        }

        #region Initial
        private void FormSetting_Load(object sender, EventArgs e)
        {
            OnResizeMode = false;
            BackupSetting = new BackupSetting();

            DrawRoundedCorner();
            LoadIcon();
            LoadSetting();

            AlertTimer = Properties.Settings.Default.AlertTimer;
        }

        private void DrawRoundedCorner()
        {
            // Apply Rounded Corners for form
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            pnlResizeNav.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeNav.Width, pnlResizeNav.Height, 20, 20));
            pnlContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlContent.Width, pnlContent.Height, 20, 20));
        }

        private void LoadIcon()
        {
            ipicClose.IconChar = IconChar.WindowClose;
            ipicMaximize.IconChar = IconChar.WindowMaximize;

            ibtnColor.IconChar = IconChar.Palette;
            ibtnSound.IconChar = IconChar.Music;
            ibtnLanguage.IconChar = IconChar.Language;
            ibtnSize.IconChar = IconChar.RulerCombined ;
            ibtnText.IconChar = IconChar.Paragraph;
            ibtnParameter.IconChar = IconChar.Infinity;
        }

        private void LoadSetting()
        {
            SetCulture();
            SetStaticText();
            SetColor();
            SetAudio();
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.SettingResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormSetting).Assembly);
        }

        private void SetStaticText()
        {
            Text = InterfaceRm.GetString("FormText", Culture);
            ErrorTitle = InterfaceRm.GetString("ErrorTitle", Culture);
            WarningTitle = InterfaceRm.GetString("WarningTitle", Culture);

            lbTitle.Text = InterfaceRm.GetString("LbTitle", Culture);

            ibtnSetDefault.Text = InterfaceRm.GetString("IbtnSetDefault", Culture);
            ibtnSave.Text = InterfaceRm.GetString("IbtnSave", Culture);
            ibtnCancel.Text = InterfaceRm.GetString("IbtnCancel", Culture);

            ibtnColor.Text = InterfaceRm.GetString("IbtnColor", Culture);
            ibtnSound.Text = InterfaceRm.GetString("IbtnSound", Culture);
            ibtnLanguage.Text = InterfaceRm.GetString("IbtnLanguage", Culture);
            ibtnSize.Text = InterfaceRm.GetString("IbtnSize", Culture);
            ibtnText.Text = InterfaceRm.GetString("IbtnText", Culture);
            ibtnParameter.Text = InterfaceRm.GetString("IbtnParameter", Culture);

            ttNote.SetToolTip(ipicClose, InterfaceRm.GetString("TtClose", Culture));
            ttNote.SetToolTip(ipicMaximize, InterfaceRm.GetString("TtMaximize", Culture));

            ttNote.SetToolTip(ibtnColor, InterfaceRm.GetString("IbtnColor", Culture));
            ttNote.SetToolTip(ibtnSound, InterfaceRm.GetString("IbtnSound", Culture));
            ttNote.SetToolTip(ibtnLanguage, InterfaceRm.GetString("IbtnLanguage", Culture));
            ttNote.SetToolTip(ibtnSize, InterfaceRm.GetString("IbtnSize", Culture));
            ttNote.SetToolTip(ibtnText, InterfaceRm.GetString("IbtnText", Culture));
            ttNote.SetToolTip(ibtnParameter, InterfaceRm.GetString("IbtnParameter", Culture));
        }

        private void SetColor()
        {
            BackColor = Properties.Settings.Default.BaseBackColor;
            // Header
            pnlTitleBar.BackColor = Properties.Settings.Default.HeaderBackColor;
            // Footer
            pnlFooterBar.BackColor = Properties.Settings.Default.FooterBackColor;
            // Side bar
            pnlNavigationBar.BackColor = Properties.Settings.Default.LeftSideBarBackColor;
            pnlRight.BackColor = Properties.Settings.Default.RightSideBarBackColor;
            // Body
            pnlContent.BackColor = Properties.Settings.Default.BodyBackColor;
            // Icon
            ipicClose.IconColor
                = ipicMaximize.IconColor
                = Properties.Settings.Default.BaseIconColor;
            // Button
            ibtnColor.ForeColor
                = ibtnSound.ForeColor
                = ibtnLanguage.ForeColor
                = ibtnSize.ForeColor
                = ibtnText.ForeColor
                = ibtnParameter.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            ibtnColor.IconColor
                = ibtnSound.IconColor
                = ibtnLanguage.IconColor
                = ibtnSize.IconColor
                = ibtnText.IconColor
                = ibtnParameter.IconColor
                = Properties.Settings.Default.BaseTextColor;
            ibtnSetDefault.ForeColor
                = ibtnSave.ForeColor
                = ibtnCancel.ForeColor
                = Properties.Settings.Default.BaseBorderColor;
            // Label
            lbTitle.ForeColor = Properties.Settings.Default.BaseTextColor;
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

        #region Effects - Re-draw rounded corner when size of sender is changed 
        private void FormSetting_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
            }
            else
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }
        }

        private void PnlRoundedCorner_SizeChanged(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            pnl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, 20, 20));
        }
        #endregion

        #region Effects - Windows state switch & Log out
        private void IpicClose_Click(object sender, EventArgs e)
        {
            HasChange = false;
            CloseForm();
        }

        private void IbtnCancel_Click(object sender, EventArgs e)
        {
            HasChange = false;
            CloseForm();
        }

        private void CloseForm()
        {
            Close();
        }

        private void IpicMaximize_Click(object sender, EventArgs e)
        {
            MaximizeSwitch();
        }

        private void MaximizeSwitch()
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                ipicMaximize.IconChar = IconChar.WindowRestore;
                ttNote.SetToolTip(ipicMaximize, InterfaceRm.GetString("TtNormal", Culture));
            }
            else
            {
                WindowState = FormWindowState.Normal;
                ipicMaximize.IconChar = IconChar.WindowMaximize;
                ttNote.SetToolTip(ipicMaximize, InterfaceRm.GetString("TtMaximize", Culture));
            }
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

        private void PnlResizeNavigation_MouseMove(object sender, MouseEventArgs e)
        {
            ResizeNavigationBar();
        }

        private void ResizeNavigationBar()
        {
            if (OnResizeMode)
            {
                pnlNavigationBar.Width = PointToClient(Cursor.Position).X;
            }
        }
        #endregion

        #region Effects - Change color of icon when mouse hover/leave
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
                case "ipicMaximize":
                    ipic.IconColor = Properties.Settings.Default.WarningTextColor;
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
        private void BtnNav_MouseHover(object sender, EventArgs e)
        {
            ChangeNavButtonColorToHover(sender);
        }

        private void ChangeNavButtonColorToHover(object sender)
        {
            IconButton ibtn = sender as IconButton;
            ibtn.BackColor = Properties.Settings.Default.BodyBackColor;
            ibtn.ForeColor = Properties.Settings.Default.BaseHoverColor;
            ibtn.IconColor = Properties.Settings.Default.BaseHoverColor;
        }

        private void BtnNav_MouseLeave(object sender, EventArgs e)
        {
            ChangeNavButtonColorToBase(sender);
        }

        private void ChangeNavButtonColorToBase(object sender)
        {
            IconButton ibtn = sender as IconButton;
            ibtn.BackColor = Color.Transparent;
            ibtn.ForeColor = Properties.Settings.Default.BaseTextColor;
            ibtn.IconColor = Properties.Settings.Default.BaseTextColor;
        }

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

        #region LoadContent
        private void IbtnColor_Click(object sender, EventArgs e)
        {
            FormColor f = new FormColor(BackupSetting);
            LoadContent(f);
            BackupSetting = f.BackupSetting;
        }

        private void IbtnSound_Click(object sender, EventArgs e)
        {
            FormSound f = new FormSound(BackupSetting);
            LoadContent(f);
            BackupSetting = f.BackupSetting;
        }

        private void IbtnLanguage_Click(object sender, EventArgs e)
        {
            FormLanguage f = new FormLanguage(BackupSetting);
            LoadContent(f);
            BackupSetting = f.BackupSetting;
        }

        private void IbtnSize_Click(object sender, EventArgs e)
        {
            FormSize f = new FormSize(BackupSetting);
            LoadContent(f);
            BackupSetting = f.BackupSetting;
        }

        private void IbtnText_Click(object sender, EventArgs e)
        {
            FormText f = new FormText(BackupSetting);
            LoadContent(f);
            BackupSetting = f.BackupSetting;
        }

        private void IbtnParameter_Click(object sender, EventArgs e)
        {
            FormParameter f = new FormParameter(BackupSetting);
            LoadContent(f);
            BackupSetting = f.BackupSetting;
        }
        private void LoadContent(object partialForm)
        {
            Form partrial = partialForm as Form;
            partrial.TopLevel = false;
            partrial.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(partrial);
            partrial.Show();
        }
        #endregion

        #region Set to default
        private void IbtnSetDefault_Click(object sender, EventArgs e)
        {
            string msg = InterfaceRm.GetString("MsgSetDefaultConfirm", Culture);
            DialogResult result = FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Question, CustomMessageBoxButton.YesNo);
            if (result == DialogResult.Yes)
            {
                BackupSetting.SetDefault();
                CloseForm();
            }
        }
        #endregion

        #region Save Setting
        private void IbtnSave_Click(object sender, EventArgs e)
        {
            string msg = InterfaceRm.GetString("MsgSaveSettingConfirm", Culture);
            DialogResult result = FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Question, CustomMessageBoxButton.YesNo);
            if (result == DialogResult.Yes)
            {
                BackupSetting.SaveSetting();
                CloseForm();
            }
        }
        #endregion
    }
}
