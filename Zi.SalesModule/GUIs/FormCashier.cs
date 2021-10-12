﻿using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Media;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DAOs;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Convertors;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;

namespace Zi.SalesModule.GUIs
{
    public partial class FormCashier : Form
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
        public UserModel CurrentUser { get; set; }
        public RoleModel CurrentRole { get; set; }
        public TableModel CurrentTable { get; set; }
        public AreaModel CurrentArea { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public Stream InitStream { get; set; }
        public Stream ClickStream { get; set; }
        public string SoundtrackPath { get; set; }
        public bool OnResizeMode { get; set; }
        #endregion

        public FormCashier(UserModel user)
        {
            InitializeComponent();
            CurrentUser = user;
            CurrentTable = new TableModel()
            {
                TableId = Guid.Empty
            };
            CurrentArea = new AreaModel()
            {
                AreaId = Guid.Empty
            };
            ChangeAccount(CurrentUser);
            OnResizeMode = false;
        }

        private void ChangeAccount(UserModel currentUser)
        {
            CurrentRole = GetCurrentRole(currentUser);
            if (CurrentRole.AccessLevel.CompareTo(AccessLevels.Manager) >= 0)
            {
                ibtnManager.Enabled = true;
            }
            else
            {
                ibtnManager.Enabled = false;
            }
            ibtnAccount.Text = currentUser.DisplayName;
            picAvatar.Image = DataTypeConvertor.Instance.GetImageFromBytes(currentUser.Avatar);
            ttNote.SetToolTip(picAvatar, currentUser.Username);
        }

        private RoleModel GetCurrentRole(UserModel currentUser)
        {
            string cultureName = Properties.Settings.Default.CultureName;
            UserRoleFilter userRoleFilter = new UserRoleFilter
            {
                UserId = currentUser.UserId
            };
            var userRoleReader = UserRoleService.Instance.Read(userRoleFilter, cultureName);
            var roleId = (userRoleReader.Item2 as Paginator<UserRoleModel>).Item[0].RoleId.ToString();

            RoleFilter roleFilter = new RoleFilter
            {
                RoleId = Guid.Parse(roleId)
            };
            var roleReader = RoleService.Instance.Read(roleFilter, cultureName);
            var currentRole = (roleReader.Item2 as Paginator<RoleModel>).Item[0];
            return currentRole;
        }

        private void FormCashier_Load(object sender, EventArgs e)
        {
            // Apply Rounded Corners for form
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlResizeNav.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeNav.Width, pnlResizeNav.Height, 20, 20));
            pnlResizeBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeBill.Width, pnlResizeBill.Height, 20, 20));
            pnlResizeDivideBody.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeDivideBody.Width, pnlResizeDivideBody.Height, 20, 20));
            fpnlAreaList.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, fpnlAreaList.Width, fpnlAreaList.Height, 20, 20));
            fpnlTableList.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, fpnlTableList.Width, fpnlTableList.Height, 20, 20));
            pnlBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBill.Width, pnlBill.Height, 20, 20));
            picAvatar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, picAvatar.Width, picAvatar.Height, 50, 50));
            pnlNavigationBar.Width = pnlNavigationBar.MinimumSize.Width;
            LoadIcon();
            LoadSetting();
        }

        private void LoadSetting()
        {
            SetStaticText();
            SetColor();
            SetAudio();
            LoadFooter();
            LoadBody();
        }

        private void LoadBody()
        {
            fpnlAreaList.Controls.Clear();
            AreaFilter areaFilter = new AreaFilter();
            var areaReader = AreaService.Instance.Read(areaFilter, Properties.Settings.Default.CultureName).Item2 as Paginator<AreaModel>;
            List<AreaModel> areaList = areaReader.Item;
            foreach (AreaModel item in areaList)
            {
                if (string.IsNullOrEmpty(item.ParentId))
                {
                    Button btnArea = new Button()
                    {
                        Width = 200,
                        Height = 100,
                        FlatStyle = FlatStyle.Flat,
                        Text = item.Name
                    };
                    fpnlAreaList.Controls.Add(btnArea);
                }
            }
        }

        private void LoadFooter()
        {
            var tableCounter = TableService.Instance.CountTable();
            var readyPercent = tableCounter.Item2 * 100 / tableCounter.Item1;
            lbTotalTable.Text = InterfaceRm.GetString("LbTotalTable", Culture) + ": " + tableCounter.Item1;
            lbReadyTable.Text = InterfaceRm.GetString("LbReadyTable", Culture) + ": " + tableCounter.Item2;
            lbUsingTable.Text = InterfaceRm.GetString("LbUsingTable", Culture) + ": " + tableCounter.Item3;
            lbPending.Text = InterfaceRm.GetString("LbPendingTable", Culture) + ": " + tableCounter.Item4;
            lbReadyPercent.Text = InterfaceRm.GetString("LbReadyPercent", Culture) + ": " + readyPercent + "%";
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

            // Soundtrack
            if (Properties.Settings.Default.AllowSoundtrack)
            {
                string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                string soundtrackFileName = Properties.Settings.Default.SoundtrackFileName;
                SoundtrackPath = string.Format("{0}Resources\\{1}", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")), soundtrackFileName);
            }
            else
            {
                SoundtrackPath = null;
            }

            if (SoundtrackPath != null)
            {
                axWindowsMediaPlayerSoundtrack.Ctlcontrols.pause();
                axWindowsMediaPlayerSoundtrack.URL = SoundtrackPath;
                axWindowsMediaPlayerSoundtrack.settings.setMode("loop", true);
                axWindowsMediaPlayerSoundtrack.Ctlcontrols.play();
            }
            else
            {
                axWindowsMediaPlayerSoundtrack.Ctlcontrols.stop();
            }
        }

        private void SetColor()
        {
            // Header
            pnlTitleBar.BackColor = Properties.Settings.Default.HeaderBackColor;
            // Footer
            pnlFooterBar.BackColor = Properties.Settings.Default.FooterBackColor;
            // Side bar
            pnlNavigationBar.BackColor = Properties.Settings.Default.LeftSideBarBackColor;
            pnlToolBar.BackColor
                = pnlBill.BackColor
                = Properties.Settings.Default.RightSideBarBackColor;
            // Body
            BackColor = Properties.Settings.Default.LeftSideBarBackColor;
            pnlBill.BackColor = Properties.Settings.Default.BodyBackColor;
            fpnlAreaList.BackColor
                = fpnlTableList.BackColor = Properties.Settings.Default.BodyBackColor;
            // Icon
            ipicClose.IconColor
                = ipicMinimize.IconColor
                = ipicMaximize.IconColor
                = Properties.Settings.Default.BaseIconColor;
            ipicViewBill.IconColor
                = ipicOrder.IconColor
                = ipicCheckOut.IconColor
                = ipicLoadTable.IconColor
                = ipicMoveTable.IconColor
                = ipicMergeTable.IconColor
                = ipicLockTable.IconColor
                = ipicSetting.IconColor
                = Properties.Settings.Default.BaseIconColor;
            // Button
            ibtnAccount.ForeColor
                = ibtnManager.ForeColor
                = ibtnShortcutKey.ForeColor
                = ibtnToggle.ForeColor
                = ibtnProfile.ForeColor
                = ibtnLogOut.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            ibtnAccount.IconColor
                = ibtnManager.IconColor
                = ibtnShortcutKey.IconColor
                = ibtnToggle.IconColor
                = ibtnProfile.IconColor
                = ibtnLogOut.IconColor
                = Properties.Settings.Default.BaseTextColor;
            // Text
            lbTitle.ForeColor = Properties.Settings.Default.BaseTextColor;
            lbTotalTable.ForeColor
                = lbVersion.ForeColor
                = lbCopyright.ForeColor
                = Properties.Settings.Default.BlurTextColor;
            lbReadyTable.ForeColor = Properties.Settings.Default.SuccessTextColor;
            lbUsingTable.ForeColor = Properties.Settings.Default.ErrorTextColor;
            lbPending.ForeColor = Properties.Settings.Default.WarningTextColor;
            lbReadyPercent.ForeColor = Properties.Settings.Default.InfoTextColor;
        }

        private void SetStaticText()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.CashierResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormCashier).Assembly);

            lbTitle.Text = InterfaceRm.GetString("LbTitle", Culture);
            lbVersion.Text = InterfaceRm.GetString("LbVersion", Culture);
            lbCopyright.Text = InterfaceRm.GetString("LbCopyright", Culture);

            ibtnManager.Text = InterfaceRm.GetString("BtnManager", Culture);
            ibtnShortcutKey.Text = InterfaceRm.GetString("BtnShortcutKey", Culture);
            ibtnProfile.Text = InterfaceRm.GetString("BtnProfile", Culture);
            ibtnLogOut.Text = InterfaceRm.GetString("BtnLogOut", Culture);

            ttNote.SetToolTip(ipicClose, InterfaceRm.GetString("TtClose", Culture));
            ttNote.SetToolTip(ipicMaximize, InterfaceRm.GetString("TtMaximize", Culture));
            ttNote.SetToolTip(ipicMinimize, InterfaceRm.GetString("TtMinimize", Culture));

            ttNote.SetToolTip(ipicViewBill, InterfaceRm.GetString("TtViewBill", Culture));
            ttNote.SetToolTip(ipicOrder, InterfaceRm.GetString("TtOrder", Culture));
            ttNote.SetToolTip(ipicCheckOut, InterfaceRm.GetString("TtCheckOut", Culture));
            ttNote.SetToolTip(ipicLoadTable, InterfaceRm.GetString("TtLoadTable", Culture));
            ttNote.SetToolTip(ipicMoveTable, InterfaceRm.GetString("TtMoveTable", Culture));
            ttNote.SetToolTip(ipicMergeTable, InterfaceRm.GetString("TtMergeTable", Culture));
            ttNote.SetToolTip(ipicLockTable, InterfaceRm.GetString("TtLockTable", Culture));
            ttNote.SetToolTip(ipicSetting, InterfaceRm.GetString("TtSetting", Culture));

            ttNote.SetToolTip(ibtnManager, InterfaceRm.GetString("BtnManager", Culture));
            ttNote.SetToolTip(ibtnShortcutKey, InterfaceRm.GetString("BtnShortcutKey", Culture));
            ttNote.SetToolTip(ibtnToggle, InterfaceRm.GetString("BtnToggle", Culture));
            ttNote.SetToolTip(ibtnProfile, InterfaceRm.GetString("BtnProfile", Culture));
            ttNote.SetToolTip(ibtnLogOut, InterfaceRm.GetString("BtnLogOut", Culture));

            viewBillToolStripMenuItem.Text = InterfaceRm.GetString("TtViewBill", Culture);
            orderToolStripMenuItem.Text = InterfaceRm.GetString("TtOrder", Culture);
            checkOutToolStripMenuItem.Text = InterfaceRm.GetString("TtCheckOut", Culture);
            tableToolStripMenuItem.Text = InterfaceRm.GetString("CmsTable", Culture);
            settingToolStripMenuItem.Text = InterfaceRm.GetString("TtSetting", Culture);
            profileToolStripMenuItem.Text = InterfaceRm.GetString("BtnProfile", Culture);
            shortcutEditorToolStripMenuItem.Text = InterfaceRm.GetString("CmsShortcutEditor", Culture);
            loadTableToolStripMenuItem.Text = InterfaceRm.GetString("TtLoadTable", Culture);
            moveTableToolStripMenuItem.Text = InterfaceRm.GetString("TtMoveTable", Culture);
            mergeTableToolStripMenuItem.Text = InterfaceRm.GetString("TtMergeTable", Culture);
            lockTableToolStripMenuItem.Text = InterfaceRm.GetString("TtLockTable", Culture);

        }

        private void LoadIcon()
        {
            ipicClose.IconChar = IconChar.WindowClose;
            ipicMaximize.IconChar = IconChar.WindowMaximize;
            ipicMinimize.IconChar = IconChar.MinusSquare;

            ipicViewBill.IconChar = IconChar.FileInvoiceDollar;
            ipicOrder.IconChar = IconChar.ConciergeBell;
            ipicCheckOut.IconChar = IconChar.HandHoldingUsd;
            ipicLoadTable.IconChar = IconChar.RedoAlt;
            ipicMoveTable.IconChar = IconChar.ObjectUngroup;
            ipicMergeTable.IconChar = IconChar.ObjectGroup;
            ipicLockTable.IconChar = IconChar.Lock;
            ipicSetting.IconChar = IconChar.UserCog;

            ibtnManager.IconChar = IconChar.UserTie;
            ibtnShortcutKey.IconChar = IconChar.Keyboard;
            ibtnToggle.IconChar = IconChar.Bars;
            ibtnLogOut.IconChar = IconChar.SignOutAlt;
            ibtnProfile.IconChar = IconChar.IdBadge;
            ibtnAccount.IconChar = IconChar.AngleUp;
        }

        private void FormCashier_SizeChanged(object sender, EventArgs e)
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

        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            // Apply form move for pnlTop
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void IpicMinimize_Click(object sender, EventArgs e)
        {
            MinimizeSwitch();
        }

        private void MinimizeSwitch()
        {
            WindowState = FormWindowState.Minimized;
        }

        private void IpicClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            axWindowsMediaPlayerSoundtrack.Ctlcontrols.stop();
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

        private void PnlResize_MouseHover(object sender, EventArgs e)
        {
            (sender as Panel).BackColor = Color.DarkGray;
        }

        private void PnlResize_MouseLeave(object sender, EventArgs e)
        {
            (sender as Panel).BackColor = Color.Transparent;
        }

        private void LbCurrentTable_Paint(object sender, PaintEventArgs e)
        {
            Label lb = sender as Label;
            Brush brush;
            e.Graphics.TranslateTransform(30, 170);
            e.Graphics.RotateTransform(90);
            if (CurrentTable.TableId.CompareTo(Guid.Empty) != 0)
            {
                brush = new SolidBrush(Properties.Settings.Default.SuccessTextColor);
                e.Graphics.DrawString(InterfaceRm.GetString("LbCurrentTable", Culture) + ": " + CurrentArea.Name + "-" + CurrentTable.Name, lb.Font, brush, 0, 0);
            }
            else
            {
                brush = new SolidBrush(Properties.Settings.Default.WarningTextColor);
                e.Graphics.DrawString(InterfaceRm.GetString("LbNoneCurrentTable", Culture), lb.Font, brush, 0, 0);
            }
        }

        private void Ipic_MouseHover(object sender, EventArgs e)
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
                case "ipicMinimize":
                    ipic.IconColor = Properties.Settings.Default.InfoTextColor;
                    break;
                case "ipicCheckOut":
                    ipic.IconColor = Color.Yellow;
                    break;
                case "ipicOrder":
                    ipic.IconColor = Color.FromArgb(97, 247, 10);
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

        private void BtnNav_MouseHover(object sender, EventArgs e)
        {
            IconButton ibtn = sender as IconButton;
            ibtn.BackColor = Properties.Settings.Default.BodyBackColor;
            ibtn.ForeColor = Properties.Settings.Default.BaseHoverColor;
            ibtn.IconColor = Properties.Settings.Default.BaseHoverColor;
        }

        private void BtnNav_MouseLeave(object sender, EventArgs e)
        {
            IconButton ibtn = sender as IconButton;
            ibtn.BackColor = Color.Transparent;
            ibtn.ForeColor = Properties.Settings.Default.BaseTextColor;
            ibtn.IconColor = Properties.Settings.Default.BaseTextColor;
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

        private void IbtnToggle_MouseHover(object sender, EventArgs e)
        {
            IconButton ibtn = sender as IconButton;
            ibtn.IconColor = Properties.Settings.Default.BaseHoverColor;
        }

        private void IbtnToggle_MouseLeave(object sender, EventArgs e)
        {
            IconButton ibtn = sender as IconButton;
            ibtn.IconColor = Properties.Settings.Default.BaseTextColor;
        }

        private void IbtnToggle_Click(object sender, EventArgs e)
        {
            if (pnlNavigationBar.Width == pnlNavigationBar.MinimumSize.Width)
            {
                pnlNavigationBar.Width = pnlNavigationBar.MaximumSize.Width;
            }
            else
            {
                pnlNavigationBar.Width = pnlNavigationBar.MinimumSize.Width;
            }
        }

        private void PnlRoundedCorner_SizeChanged(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            pnl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, 20, 20));
        }

        private void IpicViewBill_Click(object sender, EventArgs e)
        {
            ShowBillPanel();
        }

        private void ShowBillPanel()
        {
            pnlBill.Visible = !pnlBill.Visible;
        }

        private void IbtnShortcutKey_Click(object sender, EventArgs e)
        {
            cmsShortcutKeyDropDown.Show(ibtnShortcutKey, 0, ibtnShortcutKey.Height);
        }

        private void PicAvatar_Paint(object sender, PaintEventArgs e)
        {
            var pic = sender as PictureBox;
            int x = pic.Location.X;
            int y = pic.Location.Y;
            int w = pic.Width;
            int h = pic.Height;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Brush brush = new SolidBrush(Properties.Settings.Default.BaseBorderColor);
            Pen pen = new Pen(brush);
            pen.Width = 7;
            e.Graphics.DrawEllipse(pen, x - 5, y, w - 3, h - 3);
            //e.Graphics.FillEllipse(Brushes.White, x, y, w, h);
        }

        private void IbtnAccount_Click(object sender, EventArgs e)
        {
            int x = pnlAccountGroup.Location.X;
            int y = pnlAccountGroup.Location.Y - pnlAccountChilren.Height;
            pnlAccountChilren.Location = new Point(x, y);
            pnlAccountChilren.Visible = !pnlAccountChilren.Visible;
        }

        private void PicAvatar_MouseHover(object sender, EventArgs e)
        {
            ibtnAccount.BackColor = Properties.Settings.Default.BodyBackColor;
            ibtnAccount.ForeColor = Properties.Settings.Default.BaseHoverColor;
            ibtnAccount.IconColor = Properties.Settings.Default.BaseHoverColor;
        }

        private void PicAvatar_MouseLeave(object sender, EventArgs e)
        {
            ibtnAccount.BackColor = Color.Transparent;
            ibtnAccount.ForeColor = Properties.Settings.Default.BaseTextColor;
            ibtnAccount.IconColor = Properties.Settings.Default.BaseTextColor;
        }

        private void PnlResize_MouseDown(object sender, MouseEventArgs e)
        {
            OnResizeMode = !OnResizeMode;
        }

        private void PnlResize_MouseUp(object sender, MouseEventArgs e)
        {
            OnResizeMode = !OnResizeMode;
        }

        private void PnlResizeBill_MouseMove(object sender, MouseEventArgs e)
        {
            if (OnResizeMode)
            {
                pnlBill.Width = Width - PointToClient(Cursor.Position).X;
            }
        }

        private void PnlResizeNav_MouseMove(object sender, MouseEventArgs e)
        {
            if (OnResizeMode)
            {
                pnlNavigationBar.Width = PointToClient(Cursor.Position).X;
            }
        }

        private void FormCashier_KeyDown(object sender, KeyEventArgs e)
        {
            // Set Shortcut Keys
            if (e.Alt && e.KeyCode == Keys.P)
            {
                OpenFormProfile();
                return;
            }
            if (e.Alt && e.KeyCode == Keys.C)
            {
                OpenFormCheckOut();
                return;
            }
            if (e.Alt && e.KeyCode == Keys.R)
            {
                //ipicLoadTable
                return;
            }
            if (e.Alt && e.KeyCode == Keys.L)
            {
                //ipicLockTable
                return;
            }
            if (e.Alt && e.KeyCode == Keys.M)
            {
                MaximizeSwitch();
                return;
            }
            if (e.Alt && e.KeyCode == Keys.W)
            {
                //ipicMergeTable
                return;
            }
            if (e.Alt && e.KeyCode == Keys.N)
            {
                MinimizeSwitch();
                return;
            }
            if (e.Alt && e.KeyCode == Keys.Q)
            {
                //ipicMoveTable
                return;
            }
            if (e.Alt && e.KeyCode == Keys.O)
            {
                OpenFormOrder();
                return;
            }
            if (e.Alt && e.KeyCode == Keys.S)
            {
                OpenFormSetting();
                return;
            }
            if (e.Alt && e.KeyCode == Keys.V)
            {
                ShowBillPanel();
                return;
            }
        }

        private void IbtnLogOut_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void IbtnProfile_Click(object sender, EventArgs e)
        {
            OpenFormProfile();
        }

        private void OpenFormProfile()
        {
            Form formBackground = new Form();
            try
            {
                using (FormProfile f = new FormProfile(CurrentUser, CurrentRole))
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.Location = Location;
                    formBackground.Size = Size;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .80d;
                    formBackground.BackColor = Properties.Settings.Default.BodyBackColor;
                    formBackground.TopMost = true;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    f.Owner = formBackground;
                    f.ShowDialog();
                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private void IpicSetting_Click(object sender, EventArgs e)
        {
            OpenFormSetting();
        }

        private void OpenFormSetting()
        {
            Form formBackground = new Form();
            try
            {
                using (FormSetting f = new FormSetting())
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.Location = Location;
                    formBackground.Size = Size;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .80d;
                    formBackground.BackColor = Properties.Settings.Default.BodyBackColor;
                    formBackground.TopMost = true;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    f.Owner = formBackground;
                    f.ShowDialog();
                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
                LoadSetting();
                //LoadBody();
            }
        }

        private void IpicCheckOut_Click(object sender, EventArgs e)
        {
            OpenFormCheckOut();
        }

        private void OpenFormCheckOut()
        {
            Form formBackground = new Form();
            try
            {
                using (FormCheckOut f = new FormCheckOut(CurrentTable, CurrentUser))
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.Location = Location;
                    formBackground.Size = Size;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .80d;
                    formBackground.BackColor = Properties.Settings.Default.BodyBackColor;
                    formBackground.TopMost = true;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    f.Owner = formBackground;
                    f.ShowDialog();
                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
                //LoadBody();
                //Table table = TableImpl.Instance.GetTableById((lsvBill.Tag as Table).TableId);
                //LoadBill(table);
            }
        }

        private void IpicOrder_Click(object sender, EventArgs e)
        {
            OpenFormOrder();
        }

        private void OpenFormOrder()
        {
            Form formBackground = new Form();
            try
            {
                using (FormOrder f = new FormOrder(CurrentTable, CurrentUser))
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.Location = Location;
                    formBackground.Size = Size;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .80d;
                    formBackground.BackColor = Properties.Settings.Default.BodyBackColor;
                    formBackground.TopMost = true;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    f.Owner = formBackground;
                    f.ShowDialog();
                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
                //LoadBody();
                //Table table = TableImpl.Instance.GetTableById((lsvBill.Tag as Table).TableId);
                //LoadBill(table);
            }
        }

        private void pnlResizeDivideBody_MouseMove(object sender, MouseEventArgs e)
        {
            int y = pnlBody.PointToClient(Cursor.Position).Y;
            float halfHeight = pnlBody.Height / 2;
            float quarterHeight = halfHeight / 2;
            if (OnResizeMode && y < Math.Floor(halfHeight) && y > Math.Floor(quarterHeight))
            {
                fpnlAreaList.Height = y;
            }
        }
    }
}
