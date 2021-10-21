using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Zi.SalesModule.CustomControls;

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
            DrawRoundedCorner();
            LoadSetting();
        }

        #region Initial
        private void DrawRoundedCorner()
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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
            InterfaceRm = new ResourceManager(BaseName, typeof(FormMessageBox).Assembly);
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

        #region Effects - Move form by drag and drop
        private void LbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            DragAndDropForm();
        }

        private void DragAndDropForm()
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Effects - Auto resize form by content
        private void AutoSizing()
        {
            Size = new Size(Width, pnlTitle.Height + lbContent.Height);
            int x = (pnlIcon.Width - ipicMessageStatus.Width) / 2;
            int y = (pnlIcon.Height - ipicMessageStatus.Height) / 2;
            ipicMessageStatus.Location = new Point(x, y);
            x = (pnlOptions.Width - ipicButton1.Width) / 2;
            y = (pnlOptions.Height - ipicButton1.Height) / 2;
            ipicButton1.Location = new Point(x, y - ipicMessageStatus.Height);
            ipicButton2.Location = new Point(x, y);
            ipicButton3.Location = new Point(x, y + ipicMessageStatus.Height);
        }
        #endregion

        #region Show Methods
        public static DialogResult Show(string text, int timer = 0)
        {
            formMessageBox = new FormMessageBox();
            SetMessageBoxTitle(string.Empty);
            SetMessageBoxContent(text);
            SetMessageBoxIcon(CustomMessageBoxIcon.None);
            SetMessageBoxButton(CustomMessageBoxButton.None);
            SetMessageBoxTimer(timer);
            formMessageBox.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, int timer = 0)
        {
            formMessageBox = new FormMessageBox();
            SetMessageBoxTitle(caption);
            SetMessageBoxContent(text);
            SetMessageBoxIcon(CustomMessageBoxIcon.None);
            SetMessageBoxButton(CustomMessageBoxButton.None);
            SetMessageBoxTimer(timer);
            formMessageBox.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, int timer = 0)
        {
            formMessageBox = new FormMessageBox();
            SetMessageBoxTitle(caption);
            SetMessageBoxContent(text);
            SetMessageBoxIcon(icon);
            SetMessageBoxButton(CustomMessageBoxButton.None);
            SetMessageBoxTimer(timer);
            formMessageBox.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, CustomMessageBoxButton buttons, int timer = 0)
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

        private static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool displayHelpButton)
        {
            return DialogResult.Cancel;
        }
        #endregion

        #region Show Methods With Owner
        private static DialogResult Show(IWin32Window owner, string text)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return DialogResult.Cancel;
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return DialogResult.Cancel;
        }
        #endregion

        #region MessageBox Configurations
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

        private static void SetMessageBoxIcon(CustomMessageBoxIcon icon)
        {
            switch (icon)
            {
                case CustomMessageBoxIcon.Error: // hand, stop, error = 16
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.Bug;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.ErrorTextColor;
                    break;
                case CustomMessageBoxIcon.Question: // question = 32
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.Question;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.InfoTextColor;
                    break;
                case CustomMessageBoxIcon.Warning: // warning, exclamation = 48
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.ExclamationTriangle;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.WarningTextColor;
                    break;
                case CustomMessageBoxIcon.Information: // asterisk, information = 64
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.Info;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.InfoTextColor;
                    break;
                case CustomMessageBoxIcon.Success: // success = 80
                    formMessageBox.pnlIcon.Visible = true;
                    formMessageBox.ipicMessageStatus.Visible = true;
                    formMessageBox.ipicMessageStatus.IconChar = IconChar.CheckCircle;
                    formMessageBox.ipicMessageStatus.IconColor = Properties.Settings.Default.SuccessTextColor;
                    break;
                default:
                    formMessageBox.pnlIcon.Visible = false;
                    formMessageBox.ipicMessageStatus.Visible = false;
                    break;
            }
        }

        private static void SetMessageBoxButton(CustomMessageBoxButton buttons)
        {
            switch (buttons)
            {
                case CustomMessageBoxButton.YesNo:
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
                case CustomMessageBoxButton.YesNoCancel:
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
                case CustomMessageBoxButton.OKCancel:
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
                case CustomMessageBoxButton.AbortRetryIgnore:
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
                case CustomMessageBoxButton.OK:
                    formMessageBox.pnlOptions.Visible = true;
                    formMessageBox.ipicButton1.Visible = true;
                    formMessageBox.ipicButton1.IconChar = IconChar.Check;
                    formMessageBox.ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    formMessageBox.ipicButton1.Tag = DialogResult.OK;
                    break;
                default:
                    formMessageBox.pnlOptions.Visible = false;
                    break;
            }
        }

        private static void SetMessageBoxTimer(int miliSeconds)
        {
            if (miliSeconds > 0)
            {
                formMessageBox.timerAppearence.Interval = miliSeconds;
                formMessageBox.timerAppearence.Start();
            }
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
            formMessageBox.timerAppearence.Stop();
        }
        #endregion
    }
}
