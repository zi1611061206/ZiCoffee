using DataTransferLayer.Enums;
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
using Zi.DataAccessLayer.DAOs;
using Zi.DataTransferLayer.DTOs;
using Zi.ZiCoffee.Engines.Converter;
using Zi.ZiCoffee.Engines.Validations;

namespace Zi.ZiCoffee.GUIs
{
    public partial class FormProfile : Form
    {
        #region Form Corner
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
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Attributes
        public Stream StreamOpen { get; set; }
        public Stream StreamClick { get; set; }
        public Account CurrentAccount { get; set; }
        public Employee CurrentEmployee { get; set; }
        #endregion

        public FormProfile(Account account, Employee employee)
        {
            InitializeComponent();
            this.CurrentAccount = account;
            this.CurrentEmployee = employee;
        }

        #region Form Loaders
        private void FormProfile_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            
            LoadSetting();
            LoadDetail();

            pnlRight.Hide();

            // Nhằm khắc phục một lỗi ngớ ngẩn chưa rõ nguyên nhân (khả năng đến từ visual): 
            // Không thể xóa được text mặc định và multiline luôn true, dù designer tools đã nhận giá trị
            ctxbOldPass.ZiTextBox.Clear();
            ctxbNewPass.ZiTextBox.Clear();
            ctxbReEnter.ZiTextBox.Clear();
            ctxbOldPass.ZiTextBox.Multiline = false;
            ctxbNewPass.ZiTextBox.Multiline = false;
            ctxbReEnter.ZiTextBox.Multiline = false;
        }

        private void LoadDetail()
        {
            ctxbFullName.ZiTextBox.Text = CurrentEmployee.FirstName + " " + CurrentEmployee.MiddleName + " " + CurrentEmployee.LastName;
            Position position = PositionImpl.Instance.GetPositionById(CurrentEmployee.PositionId);
            ctxbPosition.ZiTextBox.Text = position.PositionName;
            ctxbCitizenId.ZiTextBox.Text = CurrentEmployee.CitizenId;
            ctxbAddress.ZiTextBox.Text = CurrentEmployee.EmployeeAddress;
            ctxbPhone.ZiTextBox.Text = CurrentEmployee.EmployeePhone;
            ctxbGender.ZiTextBox.Text = CurrentEmployee.Sex == GenderType.Male ? "Nam" : "Nữ";
            ctxbDateOfBirth.ZiTextBox.Text = CurrentEmployee.DateOfBirth.ToLongDateString();

            lbBase.Text = "Mã: " + CurrentEmployee.EmployeeId + Environment.NewLine +
                          "Tên người dùng: " + CurrentAccount.Username + Environment.NewLine +
                          "Ngày Lập: " + CurrentAccount.CreatedDate.ToShortDateString();

            cpicAvatar.Image = DataTypeConverter.Instance.ConvertByteArrayToImage(CurrentEmployee.Avatar);
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

        private void SettingAudio()
        {
            if (Properties.Settings.Default.IsAppearance)
            {
                StreamOpen = Properties.Resources.open;
            }
            else
            {
                StreamOpen = null;
            }

            if (StreamOpen != null)
            {
                SoundPlayer sound = new SoundPlayer
                {
                    Stream = StreamOpen
                };
                sound.Play();
            }

            if (Properties.Settings.Default.IsClick)
            {
                StreamClick = Properties.Resources.clickOK;
            }
            else
            {
                StreamClick = null;
            }
        }

        private void SettingTheme()
        {
            // BackColor
            (this as Form).BackColor
                = ctxbAddress.ZiTextBox.BackColor
                = ctxbDateOfBirth.ZiTextBox.BackColor
                = ctxbCitizenId.ZiTextBox.BackColor
                = ctxbFullName.ZiTextBox.BackColor
                = ctxbPhone.ZiTextBox.BackColor
                = ctxbPosition.ZiTextBox.BackColor
                = ctxbGender.ZiTextBox.BackColor

                = ctxbOldPass.ZiTextBox.BackColor
                = ctxbNewPass.ZiTextBox.BackColor
                = ctxbReEnter.ZiTextBox.BackColor
                = Properties.Settings.Default.MainBack;

            pnlWinState.BackColor = Properties.Settings.Default.WinStateBack;

            ctxbAddress.ZiBorderColor
                = ctxbDateOfBirth.ZiBorderColor
                = ctxbCitizenId.ZiBorderColor
                = ctxbFullName.ZiBorderColor
                = ctxbPhone.ZiBorderColor
                = ctxbPosition.ZiBorderColor
                = ctxbGender.ZiBorderColor

                = ctxbOldPass.ZiBorderColor
                = ctxbNewPass.ZiBorderColor
                = ctxbReEnter.ZiBorderColor
                = Properties.Settings.Default.ButtonBackNoBorder;

            btnChangePassword.BackColor = Properties.Settings.Default.ButtonBackNoBorder;
            btnExit.BackColor = Properties.Settings.Default.ButtonBackBorder;
            btnSave.BackColor = Properties.Settings.Default.ButtonBackNoBorder;
            btnCancel.BackColor = Properties.Settings.Default.ButtonBackBorder;

            // ForeColor
            (this as Form).ForeColor
                = ctxbAddress.ZiLabel.ForeColor
                = ctxbDateOfBirth.ZiLabel.ForeColor
                = ctxbCitizenId.ZiLabel.ForeColor
                = ctxbFullName.ZiLabel.ForeColor
                = ctxbPhone.ZiLabel.ForeColor
                = ctxbPosition.ZiLabel.ForeColor
                = ctxbGender.ZiLabel.ForeColor

                = ctxbOldPass.ZiLabel.ForeColor
                = ctxbNewPass.ZiLabel.ForeColor
                = ctxbReEnter.ZiLabel.ForeColor
                = Properties.Settings.Default.MainFore;

            ctxbAddress.ZiTextBox.ForeColor
                = ctxbDateOfBirth.ZiTextBox.ForeColor
                = ctxbCitizenId.ZiTextBox.ForeColor
                = ctxbFullName.ZiTextBox.ForeColor
                = ctxbPhone.ZiTextBox.ForeColor
                = ctxbPosition.ZiTextBox.ForeColor
                = ctxbGender.ZiTextBox.ForeColor
                = Properties.Settings.Default.SuccessFore;

            ctxbOldPass.ZiTextBox.ForeColor
                = ctxbNewPass.ZiTextBox.ForeColor
                = ctxbReEnter.ZiTextBox.ForeColor
                = Properties.Settings.Default.MainFore;

            ctxbOldPass.ZiValidate.ForeColor
                = ctxbNewPass.ZiValidate.ForeColor
                = ctxbReEnter.ZiValidate.ForeColor
                = Properties.Settings.Default.ErrorFore;

            btnChangePassword.ForeColor = Properties.Settings.Default.ButtonForeNoBorder;
            btnExit.ForeColor = Properties.Settings.Default.ButtonForeBorder;
            btnSave.ForeColor = Properties.Settings.Default.ButtonForeNoBorder;
            btnCancel.ForeColor = Properties.Settings.Default.ButtonForeBorder;
        }

        private void SettingLanguage()
        {
            string cultureName = Properties.Settings.Default.CultureName;
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            ResourceManager rm = new ResourceManager("Zi.ZiCoffee.Engines.Lang.ResourceLang", typeof(FormProfile).Assembly);
        }
        #endregion

        #region Effect Event
        private void PicClose_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Name.Equals("picClose"))
            {
                pic.BackColor = Properties.Settings.Default.CloseBack;
            }
            else if (pic.Name.Equals("picMinimize"))
            {
                pic.BackColor = Properties.Settings.Default.MinimizeBack;
            }
        }

        private void PicClose_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.BackColor = Color.Transparent;
        }

        private void BtnExit_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Properties.Settings.Default.ButtonBackNoBorder;
            btn.ForeColor = Properties.Settings.Default.ButtonForeNoBorder;
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Properties.Settings.Default.ButtonBackBorder;
            btn.ForeColor = Properties.Settings.Default.ButtonForeBorder;
        }

        private void PnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            PicClose_Click(this, new EventArgs());
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            ctxbOldPass.ZiTextBox.Clear();
            ctxbNewPass.ZiTextBox.Clear();
            ctxbReEnter.ZiTextBox.Clear();
            lbChangePassResult.Hide();
            pnlRight.Show();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            pnlRight.Hide();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string username = CurrentAccount.Username;
            string oldPass = ctxbOldPass.ZiTextBox.Text.Trim();
            string newPass = ctxbNewPass.ZiTextBox.Text.Trim();
            string reEnter = ctxbReEnter.ZiTextBox.Text.Trim();

            if(ChangePasswordValidator.Instance.IsValid(this, username, oldPass, newPass, reEnter))
            {
                if(AccountImpl.Instance.UpdatePassword(username, newPass))
                {
                    lbChangePassResult.Text = "Thay đổi mật khẩu thành công!";
                    lbChangePassResult.ForeColor = Properties.Settings.Default.SuccessFore;
                    lbChangePassResult.Show();
                }
                else
                {
                    lbChangePassResult.Text = "Thay đổi mật khẩu thất bại! Kiểm tra kết nối máy chủ hoặc gọi hỗ trợ";
                    lbChangePassResult.ForeColor = Properties.Settings.Default.ErrorFore;
                    lbChangePassResult.Show();
                }
            }
        }

        private void PnlRight_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlRight.Visible)
            {
                btnChangePassword.Enabled = false;
            }
            else
            {
                btnChangePassword.Enabled = true;
            }
        }
    }
}
