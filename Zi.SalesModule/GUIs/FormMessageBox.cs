using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zi.SalesModule.GUIs
{
    public partial class FormMessageBox : Form
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

        #region Static
        static FormMessageBox formMessageBox;
        static DialogResult result;
        #endregion

        public FormMessageBox()
        {
            InitializeComponent();
            // Apply Rounded Corners for form
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            LoadSetting();
        }

        #region Load
        private void AutoSizing()
        {
            Size = new Size(Width, pnlTitle.Height + lbContent.Height);
            int x = (pnlIcon.Width - ipicMessageStatus.Width) / 2;
            int y = (pnlIcon.Height - ipicMessageStatus.Height) / 2;
            ipicMessageStatus.Location = new Point(x, y);
            x = (pnlOptions.Width - ipicButton1.Width) / 2;
            y = (pnlOptions.Height - ipicButton1.Height) / 2;
            ipicButton1.Dock = ipicButton2.Dock = ipicButton3.Dock = DockStyle.None;
            ipicButton1.Location = new Point(x, y - ipicMessageStatus.Height);
            ipicButton2.Location = new Point(x, y);
            ipicButton3.Location = new Point(x, y + ipicMessageStatus.Height);
        }

        private void LoadSetting()
        {
            SetCulture();
            SetColor();
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.MessageBoxResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormCashier).Assembly);
        }

        private void SetColor()
        {
            // BackColor
            BackColor = Properties.Settings.Default.MsgBackColor;

            // ForeColor
            lbTitle.ForeColor
                = lbContent.ForeColor
                = Properties.Settings.Default.BaseTextColor;
        }
        #endregion

        #region MessageBox Configuration
        private static void SetMessageBoxTitle(string caption)
        {
            if (string.IsNullOrEmpty(caption))
            {
                formMessageBox.lbTitle.Text = formMessageBox.InterfaceRm.GetString("Alert", formMessageBox.Culture);
            }
            else
            {
                formMessageBox.lbTitle.Text = caption;
            }
        }

        private static void SetMessageBoxContent(string text)
        {
            formMessageBox.lbContent.Text = text;
            formMessageBox.AutoSizing();
        }

        private static void SetMessageBoxIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error: // hand, stop, error = 16
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.Bug;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.ErrorTextColor;
                    break;
                case MessageBoxIcon.Question: // question = 32
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.Question;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.InfoTextColor;
                    break;
                case MessageBoxIcon.Warning: // warning, exclamation = 48
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.ExclamationTriangle;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.WarningTextColor;
                    break;
                case MessageBoxIcon.Information: // asterisk, information = 64
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.Info;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.InfoTextColor;
                    break;
                default:
                    formMessageBox.pnlIcon.Visible = false;
                    formMessageBox.ipicMessageStatus.Visible = false;
                    break;
            }
        }

        private static void SetMessageBoxButton(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.YesNo:
                    formMessageBox.pnlOptions.Visible = true;
                    formMessageBox.ipicButton1.Visible = true;
                    formMessageBox.ipicButton1.IconChar = IconChar.Check;
                    formMessageBox.ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    formMessageBox.ipicButton1.Tag = DialogResult.Yes;
                    formMessageBox.ipicButton2.Visible = true;
                    formMessageBox.ipicButton2.IconChar = IconChar.Ban;
                    formMessageBox.ipicButton2.IconColor = Properties.Settings.Default.ErrorTextColor;
                    formMessageBox.ipicButton2.Tag = DialogResult.No;
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton1, 
                        formMessageBox.InterfaceRm.GetString("Yes", formMessageBox.Culture));
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton2,
                        formMessageBox.InterfaceRm.GetString("No", formMessageBox.Culture));
                    break;
                case MessageBoxButtons.YesNoCancel:
                    formMessageBox.pnlOptions.Visible = true;
                    formMessageBox.ipicButton1.Visible = true;
                    formMessageBox.ipicButton1.IconChar = IconChar.Check;
                    formMessageBox.ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    formMessageBox.ipicButton1.Tag = DialogResult.Yes;
                    formMessageBox.ipicButton2.Visible = true;
                    formMessageBox.ipicButton2.IconChar = IconChar.Ban;
                    formMessageBox.ipicButton2.IconColor = Properties.Settings.Default.WarningTextColor;
                    formMessageBox.ipicButton2.Tag = DialogResult.No;
                    formMessageBox.ipicButton3.Visible = true;
                    formMessageBox.ipicButton3.IconChar = IconChar.Times;
                    formMessageBox.ipicButton3.IconColor = Properties.Settings.Default.ErrorTextColor;
                    formMessageBox.ipicButton3.Tag = DialogResult.Cancel;
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton1,
                        formMessageBox.InterfaceRm.GetString("Yes", formMessageBox.Culture));
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton2,
                        formMessageBox.InterfaceRm.GetString("No", formMessageBox.Culture));
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton3,
                        formMessageBox.InterfaceRm.GetString("Cancel", formMessageBox.Culture));
                    break;
                case MessageBoxButtons.OKCancel:
                    formMessageBox.pnlOptions.Visible = true;
                    formMessageBox.ipicButton1.Visible = true;
                    formMessageBox.ipicButton1.IconChar = IconChar.Check;
                    formMessageBox.ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    formMessageBox.ipicButton1.Tag = DialogResult.OK;
                    formMessageBox.ipicButton3.Visible = true;
                    formMessageBox.ipicButton3.IconChar = IconChar.Times;
                    formMessageBox.ipicButton3.IconColor = Properties.Settings.Default.ErrorTextColor;
                    formMessageBox.ipicButton3.Tag = DialogResult.Cancel;
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton1,
                        formMessageBox.InterfaceRm.GetString("OK", formMessageBox.Culture));
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton3,
                        formMessageBox.InterfaceRm.GetString("Cancel", formMessageBox.Culture));
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    formMessageBox.pnlOptions.Visible = true;
                    formMessageBox.ipicButton1.Visible = true;
                    formMessageBox.ipicButton1.IconChar = IconChar.Circle;
                    formMessageBox.ipicButton1.IconColor = Properties.Settings.Default.BaseTextColor;
                    formMessageBox.ipicButton1.Tag = DialogResult.Abort;
                    formMessageBox.ipicButton2.Visible = true;
                    formMessageBox.ipicButton2.IconChar = IconChar.SyncAlt;
                    formMessageBox.ipicButton2.IconColor = Properties.Settings.Default.BaseTextColor;
                    formMessageBox.ipicButton2.Tag = DialogResult.Retry;
                    formMessageBox.ipicButton3.Visible = true;
                    formMessageBox.ipicButton3.IconChar = IconChar.LowVision;
                    formMessageBox.ipicButton3.IconColor = Properties.Settings.Default.BaseTextColor;
                    formMessageBox.ipicButton3.Tag = DialogResult.Ignore;
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton1,
                        formMessageBox.InterfaceRm.GetString("Abort", formMessageBox.Culture));
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton2,
                        formMessageBox.InterfaceRm.GetString("Retry", formMessageBox.Culture));
                    formMessageBox.ttNote.SetToolTip(formMessageBox.ipicButton3,
                        formMessageBox.InterfaceRm.GetString("Ignore", formMessageBox.Culture));
                    break;
                default:
                    formMessageBox.pnlOptions.Visible = true;
                    formMessageBox.ipicButton1.Visible = true;
                    formMessageBox.ipicButton1.IconChar = IconChar.Check;
                    formMessageBox.ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    formMessageBox.ipicButton1.Tag = DialogResult.OK;
                    break;
            }
        }

        private static void SetMessageBoxTimer(int miliSeconds)
        {
            if(miliSeconds > 0)
            {
                formMessageBox.timerAppearence.Interval = miliSeconds;
                formMessageBox.timerAppearence.Start();
            }
        }
        #endregion

        #region Show Methods
        public static DialogResult Show(string text, int timer = 0)
        {
            formMessageBox = new FormMessageBox();
            SetMessageBoxTitle(string.Empty);
            SetMessageBoxContent(text);
            SetMessageBoxIcon(MessageBoxIcon.None);
            SetMessageBoxButton(MessageBoxButtons.OK);
            SetMessageBoxTimer(timer);
            formMessageBox.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, int timer = 0)
        {
            formMessageBox = new FormMessageBox();
            SetMessageBoxTitle(caption);
            SetMessageBoxContent(text);
            SetMessageBoxIcon(MessageBoxIcon.None);
            SetMessageBoxButton(MessageBoxButtons.OK);
            SetMessageBoxTimer(timer);
            formMessageBox.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, MessageBoxIcon icon, int timer = 0)
        {
            formMessageBox = new FormMessageBox();
            SetMessageBoxTitle(caption);
            SetMessageBoxContent(text);
            SetMessageBoxIcon(icon);
            SetMessageBoxButton(MessageBoxButtons.OK);
            SetMessageBoxTimer(timer);
            formMessageBox.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, MessageBoxIcon icon, MessageBoxButtons buttons, int timer = 0)
        {
            formMessageBox = new FormMessageBox();
            SetMessageBoxTitle(caption);
            SetMessageBoxContent(text);
            SetMessageBoxIcon(icon);
            SetMessageBoxButton(buttons);
            SetMessageBoxTimer(timer);
            formMessageBox.ShowDialog();
            return result;
        }

        private static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool displayHelpButton)
        {
            return DialogResult.Yes;
        }
        #endregion

        #region Show Methods With Owner
        private static DialogResult Show(IWin32Window owner, string text)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return DialogResult.Yes;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return DialogResult.Yes;
        }
        #endregion

        #region Events
        private void LbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            // Apply form move for pnlTop
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void TimerAppearence_Tick(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            formMessageBox.Dispose();
            formMessageBox.timerAppearence.Stop();
        }

        private void IpicButton_Click(object sender, EventArgs e)
        {
            IconPictureBox ipic = sender as IconPictureBox;
            try
            {
                result = (DialogResult)ipic.Tag;
            }
            catch
            {
                result = DialogResult.Cancel;
            }
            formMessageBox.Dispose();
        }
        #endregion
    }
}
