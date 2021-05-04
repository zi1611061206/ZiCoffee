using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Collections;
using System.Data.SqlClient;
using System.Net;
using System.Media;
using System.IO;
using Zi.DataTransferLayer.DTOs;
using Zi.ZiCoffee.Engines.Converter;
using Zi.ZiCoffee.GUIs.CustomControls;
using Zi.DataAccessLayer.DAOs;
using Zi.DataTransferLayer.Enums;
using Zi.DataAccessLayer.DAOs.Join;
using DataTransferLayer.Enums;
using Zi.ZiCoffee.Engines.TempleSetting;

namespace Zi.ZiCoffee.GUIs
{
    public partial class FormMain : Form
    {
        #region FormMove
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Attributes
        public Account CurrentAccount { get; set; }
        public Employee CurrentEmployee { get; set; }
        public string SoundTrackPath { get; set; }
        public Stream StreamOpen { get; set; }
        public Stream StreamClick { get; set; }
        public NumberFormatInfo LocalFormat { get; set; }
        public int CurrentTabIndex { get; set; } //Khu vực đang được hiển thị & sử dụng, mặc định = 0 là tất cả
        public TempleSetting Temple { get; set; }
        #endregion

        public FormMain(Account account, Employee employee)
        {
            InitializeComponent();

            Thread thread = new Thread(new ThreadStart(RunSplash));
            thread.Start();

            this.CurrentAccount = account;
            this.CurrentEmployee = employee;
            ChangeAccount(account, employee);
        }

        private void RunSplash()
        {
            int splashId = Properties.Settings.Default.SplashId;
            int after = splashId;
            switch (splashId)
            {
                case 1:
                    Application.Run(new FormSplash());
                    after++;
                    break;
                case 2:
                    Application.Run(new FormSplash2());
                    after++;
                    break;
                case 3:
                    Application.Run(new FormSplash3());
                    after = 1;
                    break;
                default:
                    break;
            }
            Properties.Settings.Default.SplashId = after;
        }

        #region Form Loaders
        private void ChangeAccount(Account account, Employee employee)
        {
            if (employee.PositionId == 1)
            {
                cbtnManagerment.Show();
            }
            else
            {
                cbtnManagerment.Hide();
            }
            cbtnAccount.ZiBtnItem.Text = account.Username;
            cbtnAccount.ZiRpicIcon.Image = DataTypeConverter.Instance.ConvertByteArrayToImage(employee.Avatar);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Temple = new TempleSetting();
            LocalFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            LocalFormat.CurrencySymbol = Temple.CurrencySymbol;
            LocalFormat.CurrencyPositivePattern = 3;
            LocalFormat.CurrencyDecimalDigits = 0;

            if (Temple.IsGreeting)
            {
                SayWelcome();
            }

            timerLoadTable.Start();
            CurrentTabIndex = 0;
            LoadSetting();
            LoadController();

            pnlOptions.Hide();
            pnlShortcutDropdown.Hide();
            picCollapse.Hide();
            picExtend.Show();
            btnPay.Enabled = cbtnSubPay.Enabled = false;

            Size size = cbtnAccount.Size;
            size.Width = 179;
            cbtnAccount.Size = size;
        }

        private void LoadController()
        {
            LoadBody();
            LoadFooter();
        }

        private void LoadFooter()
        {
            lbCountTable.Text = "Tổng bàn: " + CountTable();
            lbCountFullTable.Text = "Đang sử dụng: " + CountUsingTable();
            lbCountTempTable.Text = "Trống: " + CountTempTable();
            lbPercent.Text = string.Format("Tỷ lệ: {0} %", CalculatePercent());
        }

        private int CountTable()
        {
            return TableImpl.Instance.CountAllTable();
        }

        private int CountUsingTable()
        {
            return TableImpl.Instance.CountAllTableByStatus(TableStatus.NotAvailable);
        }

        private int CountTempTable()
        {
            return TableImpl.Instance.CountAllTableByStatus(TableStatus.Available);
        }

        private double CalculatePercent()
        {
            double percent = (double)CountUsingTable() / (double)CountTable() * 100;
            return Math.Round(percent, 2);
        }

        private void LoadBody()
        {
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                SizeMode = TabSizeMode.Fixed
            };

            TabPage tpAll = new TabPage
            {
                Text = "Tất cả",
                Tag = 0
            };
            tabControl.TabPages.Add(tpAll);
            tpAll.BackColor = Properties.Settings.Default.ContentBack;
            tpAll.ForeColor = Properties.Settings.Default.ContentFore;

            DataTable areaList = AreaImpl.Instance.GetAllArea();
            foreach (DataRow row in areaList.Rows)
            {
                Area area = new Area(row);
                TabPage tpArea = new TabPage
                {
                    Text = "Khu vực " + area.AreaName,
                    Tag = area.AreaId,
                    BackColor = Properties.Settings.Default.ContentBack,
                    ForeColor = Properties.Settings.Default.ContentFore
                };
                tabControl.TabPages.Add(tpArea);
            }

            tabControl.SelectTab(CurrentTabIndex);
            tabControl.Selecting += TcArea_Selecting;
            LoadCurrentTab(tabControl.TabPages[CurrentTabIndex]);

            pnlMap.Controls.Clear();
            pnlMap.Controls.Add(tabControl);
        }

        private void TcArea_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage tpArea = (sender as TabControl).SelectedTab;
            CurrentTabIndex = (sender as TabControl).TabPages.IndexOf(tpArea);
            LoadCurrentTab(tpArea);
        }

        private void LoadCurrentTab(TabPage curentTabPage)
        {
            FlowLayoutPanel flpnTable = new FlowLayoutPanel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                BackColor = Properties.Settings.Default.ContentBack,
                ForeColor = Properties.Settings.Default.ContentFore
            };
            flpnTable.Controls.Clear();
            curentTabPage.Controls.Add(flpnTable);

            int areaId = int.Parse(curentTabPage.Tag.ToString());
            DataTable tableList;
            if (areaId == 0)
            {
                tableList = TableImpl.Instance.GetAllTable();
            }
            else
            {
                tableList = TableImpl.Instance.GetAllTableOfArea(areaId);
            }

            foreach (DataRow row in tableList.Rows)
            {
                Table table = new Table(row);
                ConfigureTable(table, flpnTable);
            }
        }

        private void ConfigureTable(Table table, FlowLayoutPanel currentContainer)
        {
            string textButton = table.TableName + Environment.NewLine;
            string textTooltip = table.TableName + " hiện đang ";
            Color statusColor = Temple.TableItemTempBack;
            switch (table.UsedStatus)
            {
                case TableStatus.Available:
                    textButton += "Trống";
                    textTooltip += "trống";
                    break;
                case TableStatus.NotAvailable:
                    textButton += "Đang sử dụng";
                    textTooltip += "được sử dụng";
                    statusColor = Temple.TableItemUsingBack;
                    break;
                default: break;
            }
            ItemCornerButton btnTable = new ItemCornerButton()
            {
                Width = Temple.TableItemWidth,
                Height = Temple.TableItemHeigh,
                Text = textButton,
                BackColor = statusColor,
                ForeColor = Temple.TableItemFore,
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                Tag = table
            };
            btnTable.FlatAppearance.BorderSize = 0;
            toolTipForButton.SetToolTip(btnTable, textTooltip);

            btnTable.MouseDown += BtnTable_MouseDown;
            btnTable.MouseDown += AllButton_MouseDown;
            btnTable.ContextMenuStrip = cmsOptionsTable;
            currentContainer.Controls.Add(btnTable);
        }

        private void BtnTable_MouseDown(object sender, MouseEventArgs e)
        {
            Table selectedTable = ((sender as ItemCornerButton).Tag as Table);
            string areaName = AreaImpl.Instance.GetAreaById(selectedTable.AreaId).AreaName;

            lbTableSelected.Text = "Bàn được chọn: " + selectedTable.TableName + " - khu vực " + areaName;
            lbTableSelected.ForeColor = Properties.Settings.Default.SuccessFore;
            lsvBill.Tag = selectedTable;
                
            LoadBill(selectedTable);

            if (e.Button == MouseButtons.Left)
            {
                if (selectedTable.UsedStatus != TableStatus.Available)
                {
                    PicExtend_Click(this, new EventArgs());
                }
            }
        }

        private void LoadBill(Table table)
        {
            lsvBill.Items.Clear();
            if(table.UsedStatus == TableStatus.Available)
            {
                return;
            }    
            Bill curentBill = BillAndOrderNoteImpl.Instance.GetBillOfCurrentTable(table.TableId, BillStatus.UnPaid);
            DataTable billDetail = BillDetailImpl.Instance.GetAllBillDetailOfBill(curentBill.BillId);
            int countLine = 0;
            foreach (DataRow row in billDetail.Rows)
            {
                BillDetail detail = new BillDetail(row);
                Service service = ServiceImpl.Instance.GetServiceById(detail.ServiceId);
                ListViewItem listViewItem = new ListViewItem(service.ServiceName);
                listViewItem.SubItems.Add(detail.Amount.ToString());
                listViewItem.SubItems.Add(service.Price.ToString("n0", LocalFormat));
                listViewItem.SubItems.Add(detail.Total.ToString("n0", LocalFormat));
                lsvBill.Items.Add(listViewItem);
                countLine++;
                if (countLine % 2 == 0)
                    listViewItem.BackColor = Properties.Settings.Default.MainBack;
                else
                    listViewItem.BackColor = Properties.Settings.Default.HighlightEffectBack;
            }
            if(lsvBill.Items.Count > 0)
            {
                btnPay.Enabled = cbtnSubPay.Enabled = true;
            }
            else
            {
                btnPay.Enabled = cbtnSubPay.Enabled = false;
            }
        }

        private void AllButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && StreamClick != null)
            {
                SoundPlayer sound = new SoundPlayer();
                StreamClick.Position = 0;
                sound.Stream = null;
                sound.Stream = StreamClick;
                sound.Play();
            }
        }

        private void PicTableReload_Click(object sender, EventArgs e)
        {
            LoadBody();
        }

        private void LoadSetting()
        {
            // Language settings
            SettingLanguage();
            // Theme settings
            SettingTheme();
            // Default text settings
            SettingText();
            // Audio settings
            SettingAudio();
        }

        private void SettingAudio()
        {
            // Âm thanh khởi tạo
            if (Temple.IsAppearance)
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

            // Âm thanh Click chuột
            if (Temple.IsClick)
            {
                StreamClick = Properties.Resources.clickOK;
            }
            else
            {
                StreamClick = null;
            }

            // Âm thanh nền
            if (Temple.IsSoundTrack)
            {
                string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                SoundTrackPath = string.Format("{0}Resources\\{1}", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")), "AnhTaBoEmRoiSoundtrack.wav");
            }
            else
            {
                SoundTrackPath = null;
            }

            if (SoundTrackPath != null)
            {
                wmpSoundTrack.Ctlcontrols.pause();
                wmpSoundTrack.URL = SoundTrackPath;
                wmpSoundTrack.settings.setMode("loop", true);
                wmpSoundTrack.Ctlcontrols.play();
            }
            else
            {
                wmpSoundTrack.Ctlcontrols.stop();
            }
        }

        private void SettingText()
        {
            lbTitle.Text = Properties.Resources.ProgramNameDefault;
            lbVersion.Text = Properties.Resources.VersionDefault;
            lbCopyright.Text = Properties.Resources.CopyrightDefault;
        }

        private void SettingTheme()
        {
            // Backcolor
            (this as Form).BackColor = Properties.Settings.Default.MainBack;
            pnlNavBar.BackColor = Properties.Settings.Default.MainBack;
            pnlHeader.BackColor
                = pnlFooter.BackColor
                = Properties.Settings.Default.HFBack;
            pnlMapTool.BackColor
                = pnlBill.BackColor
                = pnlMap.BackColor
                = pnlOptions.BackColor
                = pnlOrder.BackColor
                = Properties.Settings.Default.ContentBack;

            lsvBill.BackColor = Properties.Settings.Default.ContentBack;

            pnlWinState.BackColor = Properties.Settings.Default.WinStateBack;

            btnAdd.BackColor
                = btnPay.BackColor
                = btnGatherTable.BackColor
                = btnMoveTable.BackColor
                = Properties.Settings.Default.ButtonBackBorder;

            picCollapse.BackColor
                = picExtend.BackColor
                = picTableReload.BackColor
                = Properties.Settings.Default.ButtonBackNoBorder;

            // ForeColor
            lbTitle.ForeColor
                = lbCountTable.ForeColor
                = lbCountTempTable.ForeColor
                = lbCountFullTable.ForeColor
                = lbPercent.ForeColor
                = lbVersion.ForeColor
                = lbCopyright.ForeColor
                = Properties.Settings.Default.MainFore;

            cbtnSetting.ForeColor
                = cbtnShortcutKey.ForeColor
                = cbtnSubAdd.ForeColor
                = cbtnSubPay.ForeColor
                = cbtnAccount.ForeColor
                = cbtnManagerment.ForeColor
                = Properties.Settings.Default.MainFore;

            btnAdd.ForeColor
                = btnPay.ForeColor
                = btnGatherTable.ForeColor
                = btnMoveTable.ForeColor
                = Properties.Settings.Default.ButtonForeBorder;

            lsvBill.ForeColor = Properties.Settings.Default.ContentFore;
        }

        private void SettingLanguage()
        {
            string cultureName = Temple.CultureName;
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            ResourceManager rm = new ResourceManager("Zi.ZiCoffee.Engines.Lang.ResourceLang", typeof(FormMain).Assembly);
        }

        private void SayWelcome()
        {
            string vocative;
            if (CurrentEmployee.Sex==GenderType.Male)
            {
                if (CurrentEmployee.PositionId == 1)
                {
                    vocative = "Hi Sir!";
                }
                else
                {
                    vocative = "Hello Mr. " + CurrentAccount.Username + "!";
                }
            }
            else
            {
                if (CurrentEmployee.PositionId == 1)
                {
                    vocative = "Hi Madam!";
                }
                else
                {
                    vocative = "Hello Ms. " + CurrentAccount.Username + "!";
                }
            }

            SpeechSynthesizer speaker = new SpeechSynthesizer
            {
                Volume = Properties.Settings.Default.SpeakerVolumn,
                Rate = Properties.Settings.Default.SpeakerRate
            };
            speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
            speaker.Speak(vocative + Properties.Settings.Default.Welcome);
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
            else if (pic.Name.Equals("picMaximize") || pic.Name.Equals("picNormal"))
            {
                pic.BackColor = Properties.Settings.Default.MaximizeBack;
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

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            //Áp dụng di chuyển form cho pnlTitle
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CbtnManagerment_ZiMouseHover(object sender, EventArgs e)
        {
            (sender as CustomSquareIconButton).BackColor = Properties.Settings.Default.ButtonBackNavHover;
        }

        private void CbtnManagerment_ZiMouseLeave(object sender, EventArgs e)
        {
            (sender as CustomSquareIconButton).BackColor = Color.Transparent;
        }

        private void CbtnShortcutKey_ZiClick(object sender, EventArgs e)
        {
            if (pnlShortcutDropdown.Visible == true)
            {
                pnlShortcutDropdown.Visible = false;
            }
            else
            {
                pnlShortcutDropdown.Visible = true;
            }
        }

        private void CbtnAccount_ZiClick(object sender, EventArgs e)
        {
            if (cmsAccountDropDown.Visible == false)
            {
                cmsAccountDropDown.Show(cbtnAccount, 0, cbtnAccount.Height);
            }
            else
            {
                cmsAccountDropDown.Visible = false;
            }
        }

        private void CbtnAccount_ZiMouseHover(object sender, EventArgs e)
        {
            (sender as CustomRoundIconButton).BackColor = Properties.Settings.Default.ButtonBackBlueHover;
        }

        private void CbtnAccount_ZiMouseLeave(object sender, EventArgs e)
        {
            (sender as CustomRoundIconButton).BackColor = Color.Transparent;
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            wmpSoundTrack.Ctlcontrols.stop();
            Application.Exit();
        }

        private void PicMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picMaximize.Visible = false;
            picNormal.Visible = true;
        }

        private void PicNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picMaximize.Visible = true;
            picNormal.Visible = false;
        }

        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PicCollapse_Click(object sender, EventArgs e)
        {
            pnlOptions.Hide();
            picExtend.Visible = true;
            picCollapse.Visible = false;
        }

        private void PicExtend_Click(object sender, EventArgs e)
        {
            pnlOptions.Show();
            picExtend.Visible = false;
            picCollapse.Visible = true;
        }
        #endregion

        private void ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (FormProfile f = new FormProfile(CurrentAccount, CurrentEmployee))
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.Location = (this as Form).Location;
                    formBackground.Size = (this as Form).Size;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .80d;
                    formBackground.BackColor = Properties.Settings.Default.MainBack;
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

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wmpSoundTrack.Ctlcontrols.stop();
            this.Close();
        }

        private void CbtnSetting_ZiClick(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (FormSetting f = new FormSetting())
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.Location = (this as Form).Location;
                    formBackground.Size = (this as Form).Size;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .80d;
                    formBackground.BackColor = Properties.Settings.Default.MainBack;
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
                LoadBody();
            }
        }

        private void OrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (FormOrder f = new FormOrder(lsvBill.Tag as Table, CurrentAccount))
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.Location = (this as Form).Location;
                    formBackground.Size = (this as Form).Size;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .80d;
                    formBackground.BackColor = Properties.Settings.Default.MainBack;
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
                LoadBody();
                Table table = TableImpl.Instance.GetTableById((lsvBill.Tag as Table).TableId);
                LoadBill(table);
            }
        }
    }
}
