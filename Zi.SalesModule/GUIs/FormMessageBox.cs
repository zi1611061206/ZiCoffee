using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Zi.Utilities.Enumerators;

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
        public int StopPointX { get; set; }
        #endregion

        #region Instance
        private static FormMessageBox form;
        private static DialogResult result;
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
        public void AutoSizing()
        {
            Size = new Size(Width, pnlTitle.Height + lbContent.Height);
        }

        public void AutoLocating()
        {
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

        #region Effects - Redraw rounded corner when size changed
        private void FormMessageBox_SizeChanged(object sender, EventArgs e)
        {
            DrawRoundedCorner();
        }
        #endregion

        #region Effects - Set value for result when an option is selected
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
            Close();
            timerDispose.Stop();
        }
        #endregion

        #region Effects - Dispose form after a period of time
        private void TimerDispose_Tick(object sender, EventArgs e)
        {
            timerAnimationHide.Start();
        }
        #endregion

        #region Effects - Animation show
        private void TimerAnimationShow_Tick(object sender, EventArgs e)
        {
            int x = Location.X;
            int y = Location.Y;
            if (x < StopPointX)
            {
                x += 5;
                Location = new Point(x, y);
            }
            else
            {
                timerAnimationShow.Stop();
            }
        }
        #endregion

        #region Effects - Animation Hide
        private void TimerAnimationHide_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0)
            {
                Opacity -= .02;
            }
            else
            {
                result = DialogResult.Cancel;
                timerAnimationHide.Stop();
                timerDispose.Stop();
                Dispose();
            }
        }
        #endregion

        #region Show methods
        public static DialogResult Show(string text, int timer = 0, Tuple<Point, Size> owner = null)
        {
            form = new FormMessageBox();
            form.SetMessageBoxTitle(string.Empty);
            form.SetMessageBoxContent(text);
            form.SetMessageBoxIcon(CustomMessageBoxIcon.None);
            form.SetMessageBoxButton(CustomMessageBoxButton.None);
            form.SetMessageBoxTimer(timer);
            form.SetAppearenceLocation(owner);
            form.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, int timer = 0, Tuple<Point, Size> owner = null)
        {
            form = new FormMessageBox();
            form.SetMessageBoxTitle(caption);
            form.SetMessageBoxContent(text);
            form.SetMessageBoxIcon(CustomMessageBoxIcon.None);
            form.SetMessageBoxButton(CustomMessageBoxButton.None);
            form.SetMessageBoxTimer(timer);
            form.SetAppearenceLocation(owner);
            form.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, int timer = 0, Tuple<Point, Size> owner = null)
        {
            form = new FormMessageBox();
            form.SetMessageBoxTitle(caption);
            form.SetMessageBoxContent(text);
            form.SetMessageBoxIcon(icon);
            form.SetMessageBoxButton(CustomMessageBoxButton.None);
            form.SetMessageBoxTimer(timer);
            form.SetAppearenceLocation(owner);
            form.ShowDialog();
            return result;
        }

        public static DialogResult Show(string text, string caption, CustomMessageBoxIcon icon, CustomMessageBoxButton buttons, int timer = 0, Tuple<Point, Size> owner = null)
        {
            form = new FormMessageBox();
            form.SetMessageBoxTitle(caption);
            form.SetMessageBoxContent(text);
            form.SetMessageBoxIcon(icon);
            form.SetMessageBoxButton(buttons);
            form.SetMessageBoxTimer(timer);
            form.SetAppearenceLocation(owner);
            form.ShowDialog();
            return result;
        }
        #endregion

        #region MessageBox Configurations
        private void SetMessageBoxTitle(string caption)
        {
            if (string.IsNullOrEmpty(caption))
            {
                lbTitle.Text = InterfaceRm.GetString("Alert", Culture);
            }
            else
            {
                lbTitle.Text = caption;
            }
        }

        private void SetMessageBoxContent(string text)
        {
            lbContent.Text = text;
            AutoSizing();
            AutoLocating();
        }

        private void SetMessageBoxIcon(CustomMessageBoxIcon icon)
        {
            switch (icon)
            {
                case CustomMessageBoxIcon.Error: // hand, stop, error = 16
                    pnlIcon.Visible = true;
                    ipicMessageStatus.Visible = true;
                    ipicMessageStatus.IconChar = IconChar.Bug;
                    ipicMessageStatus.IconColor = Properties.Settings.Default.ErrorTextColor;
                    break;
                case CustomMessageBoxIcon.Question: // question = 32
                    pnlIcon.Visible = true;
                    ipicMessageStatus.Visible = true;
                    ipicMessageStatus.IconChar = IconChar.Question;
                    ipicMessageStatus.IconColor = Properties.Settings.Default.InfoTextColor;
                    break;
                case CustomMessageBoxIcon.Warning: // warning, exclamation = 48
                    pnlIcon.Visible = true;
                    ipicMessageStatus.Visible = true;
                    ipicMessageStatus.IconChar = IconChar.ExclamationTriangle;
                    ipicMessageStatus.IconColor = Properties.Settings.Default.WarningTextColor;
                    break;
                case CustomMessageBoxIcon.Information: // asterisk, information = 64
                    pnlIcon.Visible = true;
                    ipicMessageStatus.Visible = true;
                    ipicMessageStatus.IconChar = IconChar.Info;
                    ipicMessageStatus.IconColor = Properties.Settings.Default.InfoTextColor;
                    break;
                case CustomMessageBoxIcon.Success: // success = 80
                    pnlIcon.Visible = true;
                    ipicMessageStatus.Visible = true;
                    ipicMessageStatus.IconChar = IconChar.CheckCircle;
                    ipicMessageStatus.IconColor = Properties.Settings.Default.SuccessTextColor;
                    break;
                default:
                    pnlIcon.Visible = false;
                    ipicMessageStatus.Visible = false;
                    break;
            }
            form.SetAppearenceAudio(icon);
        }

        private void SetAppearenceAudio(CustomMessageBoxIcon icon)
        {
            if (Properties.Settings.Default.AllowInitSound)
            {
                switch (icon)
                {
                    case CustomMessageBoxIcon.Error:
                        InitStream = Properties.Resources.Cartoon_Boing_01;
                        break;
                    case CustomMessageBoxIcon.Question:
                        InitStream = Properties.Resources.Synth_Speedbump_Fast_01;
                        break;
                    case CustomMessageBoxIcon.Warning:
                        InitStream = Properties.Resources.Toy_Train_Whistle_01;
                        break;
                    case CustomMessageBoxIcon.Information:
                        InitStream = Properties.Resources.Synth_Pop_Small_01;
                        break;
                    case CustomMessageBoxIcon.Success:
                        InitStream = Properties.Resources.Bell_Ding_01;
                        break;
                    default:
                        InitStream = Properties.Resources.Synth_Appear_01;
                        break;
                }
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
        }

        private void SetMessageBoxButton(CustomMessageBoxButton buttons)
        {
            switch (buttons)
            {
                case CustomMessageBoxButton.YesNo:
                    pnlOptions.Visible = true;
                    ipicButton1.Visible = true;
                    ipicButton1.IconChar = IconChar.Check;
                    ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    ipicButton1.Tag = DialogResult.Yes;
                    ipicButton2.Visible = true;
                    ipicButton2.IconChar = IconChar.Ban;
                    ipicButton2.IconColor = Properties.Settings.Default.ErrorTextColor;
                    ipicButton2.Tag = DialogResult.No;
                    ttNote.SetToolTip(ipicButton1,
                        InterfaceRm.GetString("Yes", Culture));
                    ttNote.SetToolTip(ipicButton2,
                        InterfaceRm.GetString("No", Culture));
                    break;
                case CustomMessageBoxButton.YesNoCancel:
                    pnlOptions.Visible = true;
                    ipicButton1.Visible = true;
                    ipicButton1.IconChar = IconChar.Check;
                    ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    ipicButton1.Tag = DialogResult.Yes;
                    ipicButton2.Visible = true;
                    ipicButton2.IconChar = IconChar.Ban;
                    ipicButton2.IconColor = Properties.Settings.Default.WarningTextColor;
                    ipicButton2.Tag = DialogResult.No;
                    ipicButton3.Visible = true;
                    ipicButton3.IconChar = IconChar.Times;
                    ipicButton3.IconColor = Properties.Settings.Default.ErrorTextColor;
                    ipicButton3.Tag = DialogResult.Cancel;
                    ttNote.SetToolTip(ipicButton1,
                        InterfaceRm.GetString("Yes", Culture));
                    ttNote.SetToolTip(ipicButton2,
                        InterfaceRm.GetString("No", Culture));
                    ttNote.SetToolTip(ipicButton3,
                        InterfaceRm.GetString("Cancel", Culture));
                    break;
                case CustomMessageBoxButton.OKCancel:
                    pnlOptions.Visible = true;
                    ipicButton1.Visible = true;
                    ipicButton1.IconChar = IconChar.Check;
                    ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    ipicButton1.Tag = DialogResult.OK;
                    ipicButton3.Visible = true;
                    ipicButton3.IconChar = IconChar.Times;
                    ipicButton3.IconColor = Properties.Settings.Default.ErrorTextColor;
                    ipicButton3.Tag = DialogResult.Cancel;
                    ttNote.SetToolTip(ipicButton1,
                        InterfaceRm.GetString("OK", Culture));
                    ttNote.SetToolTip(ipicButton3,
                        InterfaceRm.GetString("Cancel", Culture));
                    break;
                case CustomMessageBoxButton.AbortRetryIgnore:
                    pnlOptions.Visible = true;
                    ipicButton1.Visible = true;
                    ipicButton1.IconChar = IconChar.Circle;
                    ipicButton1.IconColor = Properties.Settings.Default.BaseTextColor;
                    ipicButton1.Tag = DialogResult.Abort;
                    ipicButton2.Visible = true;
                    ipicButton2.IconChar = IconChar.SyncAlt;
                    ipicButton2.IconColor = Properties.Settings.Default.BaseTextColor;
                    ipicButton2.Tag = DialogResult.Retry;
                    ipicButton3.Visible = true;
                    ipicButton3.IconChar = IconChar.LowVision;
                    ipicButton3.IconColor = Properties.Settings.Default.BaseTextColor;
                    ipicButton3.Tag = DialogResult.Ignore;
                    ttNote.SetToolTip(ipicButton1,
                        InterfaceRm.GetString("Abort", Culture));
                    ttNote.SetToolTip(ipicButton2,
                        InterfaceRm.GetString("Retry", Culture));
                    ttNote.SetToolTip(ipicButton3,
                        InterfaceRm.GetString("Ignore", Culture));
                    break;
                case CustomMessageBoxButton.OK:
                    pnlOptions.Visible = true;
                    ipicButton1.Visible = true;
                    ipicButton1.IconChar = IconChar.Check;
                    ipicButton1.IconColor = Properties.Settings.Default.SuccessTextColor;
                    ipicButton1.Tag = DialogResult.OK;
                    break;
                default:
                    pnlOptions.Visible = false;
                    break;
            }
        }

        private void SetMessageBoxTimer(int miliSeconds)
        {
            if (miliSeconds > 0)
            {
                timerDispose.Interval = miliSeconds;
                timerDispose.Start();
            }
        }

        private void SetAppearenceLocation(Tuple<Point, Size> owner)
        {
            if (owner != null)
            {
                Point ownerPoint = owner.Item1;
                Size ownerSize = owner.Item2;

                int x = ownerPoint.X + ownerSize.Width - 90 - Width;
                int y = ownerPoint.Y + ownerSize.Height - 70 - Height;

                StartPosition = FormStartPosition.Manual;
                Location = new Point(x - 100, y);
                StopPointX = x;
                timerAnimationShow.Start();
            }
        }
        #endregion
    }
}
