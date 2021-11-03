using FontAwesome.Sharp;
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
using Zi.SalesModule.CustomControls;
using Zi.Utilities.Enumerators;

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
        public BillModel CurrentBill { get; set; }
        public List<BillDetailModel> CurrentBillDetails { get; set; }
        public AreaModel AreaContainTable { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public Stream InitStream { get; set; }
        public Stream ClickStream { get; set; }
        public string SoundtrackPath { get; set; }
        public bool OnResizeMode { get; set; }
        public NumberFormatInfo LocalFormat { get; set; }
        public string ErrorTitle { get; set; }
        public string WarningTitle { get; set; }
        public int AlertTimer { get; set; }
        #endregion

        #region DI
        private readonly RoleService _roleService;
        private readonly AreaService _areaService;
        private readonly TableService _tableService;
        private readonly BillService _billService;
        private readonly BillDetailService _billDetailService;
        private readonly UserRoleService _userRoleService;
        private readonly ProductService _productService;
        #endregion

        public FormCashier(UserModel user)
        {
            InitializeComponent();
            CurrentUser = user;
            _roleService = RoleService.Instance;
            _areaService = AreaService.Instance;
            _tableService = TableService.Instance;
            _billService = BillService.Instance;
            _billDetailService = BillDetailService.Instance;
            _userRoleService = UserRoleService.Instance;
            _productService = ProductService.Instance;
        }

        #region Initial
        private void FormCashier_Load(object sender, EventArgs e)
        {
            // Init Attributes
            CurrentTable = new TableModel();
            CurrentArea = new AreaModel();
            CurrentBill = new BillModel();
            CurrentBillDetails = new List<BillDetailModel>();
            AreaContainTable = new AreaModel();
            OnResizeMode = false;

            DrawRoundedCorner();
            LoadIcon();
            LoadSetting();
            ChangeAccount(CurrentUser);
            LoadFooter();
            SetToolState();

            pnlNavigationBar.Width = pnlNavigationBar.MinimumSize.Width;
            AlertTimer = Properties.Settings.Default.AlertTimer;
        }

        private void DrawRoundedCorner()
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

        private void LoadSetting()
        {
            SetCulture();
            SetCurrencyFormat();
            SetStaticText();
            SetColor();
            SetAudio();
            LoadAreaList();
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.CashierResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormCashier).Assembly);
        }

        private void SetCurrencyFormat()
        {
            LocalFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            LocalFormat.CurrencySymbol = InterfaceRm.GetString("CurrencySymbol", Culture);
            LocalFormat.CurrencyPositivePattern = 3;
            LocalFormat.CurrencyDecimalDigits = 0;
        }

        private void SetStaticText()
        {
            ErrorTitle = InterfaceRm.GetString("ErrorTitle", Culture);
            WarningTitle = InterfaceRm.GetString("WarningTitle", Culture);

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

            tableViewToolStripMenuItem.Text = InterfaceRm.GetString("TtViewBill", Culture);
            tableCheckOutToolStripMenuItem.Text = InterfaceRm.GetString("TtCheckOut", Culture);
            tableLockToolStripMenuItem.Text = InterfaceRm.GetString("TtLockTable", Culture);
            tableMergeToolStripMenuItem.Text = InterfaceRm.GetString("TtMergeWith", Culture);
            tableMoveToolStripMenuItem.Text = InterfaceRm.GetString("TtMoveTo", Culture);
            tableOrderToolStripMenuItem.Text = InterfaceRm.GetString("TtOrder", Culture);

            lsvBillDetail.Columns[0].Text = InterfaceRm.GetString("ColumnHeaderProduct", Culture);
            lsvBillDetail.Columns[1].Text = InterfaceRm.GetString("ColumnHeaderQuantity", Culture);
            lsvBillDetail.Columns[2].Text = InterfaceRm.GetString("ColumnHeaderPrice", Culture);
            lsvBillDetail.Columns[3].Text = InterfaceRm.GetString("ColumnHeaderPromotion", Culture);
            lsvBillDetail.Columns[4].Text = InterfaceRm.GetString("ColumnHeaderIntoMoney", Culture);
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
            pnlToolBar.BackColor = Properties.Settings.Default.RightSideBarBackColor;
            // Body
            pnlBill.BackColor = Properties.Settings.Default.BodyBackColor;
            fpnlAreaList.BackColor
                = fpnlTableList.BackColor
                = Properties.Settings.Default.BodyBackColor;
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
            // Label
            lbTitle.ForeColor = Properties.Settings.Default.BaseTextColor;
            lbTotalTable.ForeColor
                = lbVersion.ForeColor
                = lbCopyright.ForeColor
                = Properties.Settings.Default.BlurTextColor;
            lbReadyTable.ForeColor = Properties.Settings.Default.SuccessTextColor;
            lbUsingTable.ForeColor = Properties.Settings.Default.ErrorTextColor;
            lbPending.ForeColor = Properties.Settings.Default.WarningTextColor;
            lbReadyPercent.ForeColor = Properties.Settings.Default.InfoTextColor;
            // ListView
            lsvBillDetail.BackColor = Properties.Settings.Default.BodyBackColor;
            lsvBillDetail.ForeColor = Properties.Settings.Default.BaseTextColor;
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
            var userRoleReader = _userRoleService.Read(userRoleFilter, cultureName);
            var roleId = (userRoleReader.Item2 as Paginator<UserRoleModel>).Item[0].RoleId.ToString();

            RoleFilter roleFilter = new RoleFilter
            {
                RoleId = Guid.Parse(roleId)
            };
            var roleReader = _roleService.Read(roleFilter, cultureName);
            var currentRole = (roleReader.Item2 as Paginator<RoleModel>).Item[0];
            return currentRole;
        }

        private void LoadFooter()
        {
            var tableCounter = _tableService.CountTable();
            var readyPercent = tableCounter.Item2 * 100 / tableCounter.Item1;
            lbTotalTable.Text = InterfaceRm.GetString("LbTotalTable", Culture) + ": " + tableCounter.Item1;
            lbReadyTable.Text = InterfaceRm.GetString("LbReadyTable", Culture) + ": " + tableCounter.Item2;
            lbUsingTable.Text = InterfaceRm.GetString("LbUsingTable", Culture) + ": " + tableCounter.Item3;
            lbPending.Text = InterfaceRm.GetString("LbPendingTable", Culture) + ": " + tableCounter.Item4;
            lbReadyPercent.Text = InterfaceRm.GetString("LbReadyPercent", Culture) + ": " + readyPercent + "%";
        }

        private void LoadAreaList()
        {
            fpnlAreaList.Controls.Clear();

            int counterAll = _tableService.CountAll();
            AreaItem btnAllArea = new AreaItem(new AreaModel(), counterAll);
            btnAllArea.MouseHover += BtnArea_MouseHover;
            btnAllArea.MouseLeave += BtnArea_MouseLeave;
            btnAllArea.MouseDown += AllBtn_MouseDown;
            btnAllArea.Click += BtnArea_Click;
            CurrentArea = btnAllArea.Tag as AreaModel;
            fpnlAreaList.Controls.Add(btnAllArea);

            AreaFilter areaFilter = new AreaFilter();
            var areaReader = _areaService.Read(areaFilter, CultureName);
            if (!areaReader.Item1)
            {
                fpnlAreaList.Controls.Add(new Label()
                {
                    Text = areaReader.Item2.ToString(),
                    ForeColor = Properties.Settings.Default.ErrorTextColor,
                    Font = new Font("Arial", 9, FontStyle.Italic)
                });
                return;
            }
            List<AreaModel> areaList = (areaReader.Item2 as Paginator<AreaModel>).Item;

            foreach (AreaModel item in areaList)
            {
                int counter = _tableService.CountByArea(item.AreaId);
                AreaItem btnArea = new AreaItem(item, counter);
                btnArea.MouseHover += BtnArea_MouseHover;
                btnArea.MouseLeave += BtnArea_MouseLeave;
                btnArea.MouseDown += AllBtn_MouseDown;
                btnArea.Click += BtnArea_Click;
                fpnlAreaList.Controls.Add(btnArea);
            }

            LoadTableList();
            fpnlAreaList.Invalidate(fpnlAreaList.Region);
        }

        private void BtnArea_MouseHover(object sender, EventArgs e)
        {
            AreaItem btn = sender as AreaItem;
            btn.ForeColor = Properties.Settings.Default.BaseHoverColor;

            string id = (btn.Tag as AreaModel).AreaId.ToString();
            if (id.ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                foreach (Control child in fpnlAreaList.Controls)
                {
                    if (child is AreaItem)
                    {
                        AreaItem btnChild = child as AreaItem;
                        btnChild.ForeColor = Properties.Settings.Default.BaseHoverColor;
                    }
                }
            }
            else
            {
                foreach (Control child in fpnlAreaList.Controls)
                {
                    if (child is AreaItem)
                    {
                        AreaItem btnChild = child as AreaItem;
                        AreaModel model = btnChild.Tag as AreaModel;
                        if (!string.IsNullOrEmpty(model.ParentId) && model.ParentId.ToLower().Equals(id.ToLower()))
                        {
                            btnChild.ForeColor = Properties.Settings.Default.BaseHoverColor;
                        }
                    }
                }
            }
        }

        private void BtnArea_MouseLeave(object sender, EventArgs e)
        {
            AreaItem btn = sender as AreaItem;
            btn.ForeColor = Properties.Settings.Default.BaseTextColor;

            string id = (btn.Tag as AreaModel).AreaId.ToString();
            if (id.ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                foreach (Control child in fpnlAreaList.Controls)
                {
                    if (child is AreaItem)
                    {
                        AreaItem btnChild = child as AreaItem;
                        btnChild.ForeColor = Properties.Settings.Default.BaseTextColor;
                    }
                }
            }
            else
            {
                foreach (Control child in fpnlAreaList.Controls)
                {
                    if (child is AreaItem)
                    {
                        AreaItem btnChild = child as AreaItem;
                        AreaModel model = btnChild.Tag as AreaModel;
                        if (!string.IsNullOrEmpty(model.ParentId) && model.ParentId.ToLower().Equals(id.ToLower()))
                        {
                            btnChild.ForeColor = Properties.Settings.Default.BaseTextColor;
                        }
                    }
                }
            }
        }

        private void BtnArea_Click(object sender, EventArgs e)
        {
            AreaItem btnArea = sender as AreaItem;
            CurrentArea = btnArea.Tag as AreaModel;
            LoadTableListByArea();
        }

        private void LoadTableListByArea()
        {
            List<AreaModel> areaBrowseList = new List<AreaModel>();

            if (CurrentArea.AreaId.CompareTo(Guid.Empty) != 0)
            {
                areaBrowseList.Add(CurrentArea);
                AreaFilter areaFilter = new AreaFilter
                {
                    ParentId = CurrentArea.AreaId.ToString()
                };
                var areaReader = _areaService.Read(areaFilter, CultureName);
                if (areaReader.Item1)
                {
                    areaBrowseList.AddRange((areaReader.Item2 as Paginator<AreaModel>).Item);
                }
            }

            if (areaBrowseList.Count > 0)
            {
                LoadTableList(areaBrowseList);
            }
            else
            {
                LoadTableList();
            }
        }

        private void LoadTableList(List<AreaModel> areaBrowseList = null)
        {
            List<TableModel> tableList = new List<TableModel>();
            TableFilter tableFilter = new TableFilter();
            if (areaBrowseList != null)
            {
                tableList = GetTablesByAreas(tableFilter, tableList, areaBrowseList);
            }
            else
            {
                tableList = GetAllTables(tableFilter, tableList);
            }

            DrawTableItems(tableList);
        }

        private List<TableModel> GetTablesByAreas(TableFilter tableFilter, List<TableModel> tableList, List<AreaModel> areaBrowseList)
        {
            foreach (AreaModel item in areaBrowseList)
            {
                tableFilter.AreaId = item.AreaId;
                var tableReader = _tableService.Read(tableFilter, CultureName);
                if (!tableReader.Item1)
                {
                    continue;
                }
                else
                {
                    tableList.AddRange((tableReader.Item2 as Paginator<TableModel>).Item);
                }
            }
            return tableList;
        }

        private List<TableModel> GetAllTables(TableFilter tableFilter, List<TableModel> tableList)
        {
            var tableReader = _tableService.Read(tableFilter, CultureName);
            if (tableReader.Item1)
            {
                tableList.AddRange((tableReader.Item2 as Paginator<TableModel>).Item);
            }
            return tableList;
        }

        private void DrawTableItems(List<TableModel> tableList)
        {
            fpnlTableList.Controls.Clear();
            if (tableList.Count <= 0)
            {
                fpnlTableList.Controls.Add(new Label()
                {
                    Text = InterfaceRm.GetString("MsgNotFound", Culture),
                    ForeColor = Properties.Settings.Default.ErrorTextColor,
                    AutoSize = true,
                    Font = new Font("Arial", 9, FontStyle.Italic)
                });
            }
            else
            {
                foreach (TableModel item in tableList)
                {
                    BillModel bill = GetBill(item);
                    TableItem btnTable = new TableItem(item, bill.CreatedDate);
                    btnTable.MouseDown += AllBtn_MouseDown;
                    btnTable.MouseDown += BtnTable_MouseDown;
                    btnTable.MouseHover += BtnTable_MouseHover;
                    btnTable.MouseLeave += BtnTable_MouseLeave;
                    btnTable.ContextMenuStrip = cmsTableDropDown;
                    fpnlTableList.Controls.Add(btnTable);
                }
            }
            fpnlTableList.Invalidate(fpnlTableList.Region);
        }

        private void BtnTable_MouseDown(object sender, MouseEventArgs e)
        {
            TableItem btnTable = sender as TableItem;
            CurrentTable = btnTable.Tag as TableModel;
            ChangeItemColorToSelected(sender);

            AreaFilter filter = new AreaFilter()
            {
                AreaId = CurrentTable.AreaId
            };
            var areaReader = _areaService.Read(filter, CultureName);
            if (areaReader.Item1)
            {
                AreaContainTable = (areaReader.Item2 as Paginator<AreaModel>).Item[0];
            }

            lbCurrentTable.Invalidate(lbCurrentTable.Region);
            LoadBill();
        }

        private void ChangeItemColorToSelected(object sender)
        {
            foreach (Control item in fpnlTableList.Controls)
            {
                if (item is TableItem && item != sender)
                {
                    (item as TableItem).BackColor = Properties.Settings.Default.BaseItemColor;
                }
            }
            (sender as TableItem).BackColor = Properties.Settings.Default.ItemSelectedColor;
        }

        private void BtnTable_MouseHover(object sender, EventArgs e)
        {
            ChangeItemColorToHover(sender);
        }

        private void ChangeItemColorToHover(object sender)
        {
            TableItem item = sender as TableItem;
            if ((item.Tag as TableModel).TableId.CompareTo(CurrentTable.TableId) != 0)
            {
                item.BackColor = Properties.Settings.Default.ItemHoverColor;
            }
        }

        private void BtnTable_MouseLeave(object sender, EventArgs e)
        {
            ChangeItemColorToBase(sender);
        }

        private void ChangeItemColorToBase(object sender)
        {
            TableItem item = sender as TableItem;
            if ((item.Tag as TableModel).TableId.CompareTo(CurrentTable.TableId) != 0)
            {
                item.BackColor = Properties.Settings.Default.BaseItemColor;
            }
        }

        private void LoadBill()
        {
            lsvBillDetail.Items.Clear();

            if (CurrentTable.Status.CompareTo(TableStatus.Using) != 0)
            {
                CurrentBill = new BillModel();
                CurrentBillDetails = new List<BillDetailModel>();
                SetToolState();
                return;
            }

            BillModel bill = GetBill(CurrentTable);
            CurrentBill = bill;
            if (bill != null)
            {
                BillDetailFilter billDetailFilter = new BillDetailFilter()
                {
                    BillId = bill.BillId
                };
                var billDetailReader = _billDetailService.Read(billDetailFilter, CultureName);
                if (billDetailReader.Item1)
                {
                    List<BillDetailModel> billDetails = (billDetailReader.Item2 as Paginator<BillDetailModel>).Item;
                    CurrentBillDetails = billDetails;
                    foreach (BillDetailModel billDetail in billDetails)
                    {
                        LoadBillDetails(billDetail);
                    }
                }
                else
                {
                    CurrentBillDetails = new List<BillDetailModel>();
                }

                SetToolState();
            }
        }

        private BillModel GetBill(TableModel table)
        {
            BillFilter billFilter = new BillFilter()
            {
                TableId = table.TableId,
                Status = BillStatus.UnPay
            };
            var billReader = _billService.Read(billFilter, CultureName);
            if (billReader.Item1)
            {
                BillModel bill = (billReader.Item2 as Paginator<BillModel>).Item[0];
                return bill;
            }
            return new BillModel();
        }

        private void LoadBillDetails(BillDetailModel billDetail)
        {
            ProductFilter productFilter = new ProductFilter()
            {
                ProductId = billDetail.ProductId
            };
            var productReader = _productService.Read(productFilter, CultureName);
            if (productReader.Item1)
            {
                ProductModel product = (productReader.Item2 as Paginator<ProductModel>).Item[0];
                ListViewItem listViewItem = new ListViewItem(product.Name);
                listViewItem.SubItems.Add(billDetail.Quantity.ToString());
                listViewItem.SubItems.Add(product.Price.ToString("n0", LocalFormat));
                listViewItem.SubItems.Add(billDetail.PromotionValue.ToString());
                listViewItem.SubItems.Add(billDetail.IntoMoney.ToString("n0", LocalFormat));
                lsvBillDetail.Items.Add(listViewItem);
                if (listViewItem.Index % 2 == 0)
                {
                    listViewItem.ForeColor = Properties.Settings.Default.BaseHoverColor;
                }
                else
                {
                    listViewItem.ForeColor = Properties.Settings.Default.BaseTextColor;
                }
            }
        }

        private void SetToolState()
        {
            if (lsvBillDetail.Items.Count > 0)
            {
                viewBillToolStripMenuItem.Enabled
                    = tableViewToolStripMenuItem.Enabled = true;
                ipicCheckOut.Visible
                    = checkOutToolStripMenuItem.Enabled
                    = tableCheckOutToolStripMenuItem.Enabled
                    = true;
                ipicMoveTable.Visible
                    = moveTableToolStripMenuItem.Enabled
                    = tableMoveToolStripMenuItem.Enabled
                    = true;
                ipicMergeTable.Visible
                    = mergeTableToolStripMenuItem.Enabled
                    = tableMergeToolStripMenuItem.Enabled
                    = true;
                ipicLockTable.Visible
                    = lockTableToolStripMenuItem.Enabled
                    = tableLockToolStripMenuItem.Enabled
                    = false;
            }
            else
            {
                viewBillToolStripMenuItem.Enabled
                    = tableViewToolStripMenuItem.Enabled = false;
                ipicCheckOut.Visible
                    = checkOutToolStripMenuItem.Enabled
                    = tableCheckOutToolStripMenuItem.Enabled
                    = false;
                ipicMoveTable.Visible
                    = moveTableToolStripMenuItem.Enabled
                    = tableMoveToolStripMenuItem.Enabled
                    = false;
                ipicMergeTable.Visible
                    = mergeTableToolStripMenuItem.Enabled
                    = tableMergeToolStripMenuItem.Enabled
                    = false;
                ipicLockTable.Visible
                    = lockTableToolStripMenuItem.Enabled
                    = tableLockToolStripMenuItem.Enabled
                    = CurrentTable.TableId.CompareTo(Guid.Empty) != 0;
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

        private void PnlRoundedCorner_SizeChanged(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            pnl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, 20, 20));
        }

        private void FpnlRoundedCorner_SizeChanged(object sender, EventArgs e)
        {
            FlowLayoutPanel fpnl = sender as FlowLayoutPanel;
            fpnl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, fpnl.Width, fpnl.Height, 20, 20));
            fpnl.Invalidate(fpnl.Region);
        }
        #endregion

        #region Effects - Windows state switch & Log out
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

        private void IbtnLogOut_Click(object sender, EventArgs e)
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

        private void PnlResizeBill_MouseMove(object sender, MouseEventArgs e)
        {
            ResizeBillPanel();
        }

        private void ResizeBillPanel()
        {
            if (OnResizeMode)
            {
                int x = PointToClient(Cursor.Position).X;
                pnlBill.Show();
                pnlBill.Width = Width - pnlToolBar.Width - x;
                if (pnlBill.Width <= 0)
                {
                    pnlBill.Hide();
                }
            }
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

        private void PnlResizeDivideBody_MouseMove(object sender, MouseEventArgs e)
        {
            ResizeDivideBody();
        }

        private void ResizeDivideBody()
        {
            int y = pnlBody.PointToClient(Cursor.Position).Y;
            float halfHeight = pnlBody.Height / 2;
            float quarterHeight = halfHeight / 2;
            if (OnResizeMode && y < Math.Floor(halfHeight) && y > Math.Floor(quarterHeight))
            {
                fpnlAreaList.Height = y;
            }
        }
        #endregion

        #region Effects - Draw vertical label
        private void LbCurrentTable_Paint(object sender, PaintEventArgs e)
        {
            Label lb = sender as Label;
            Brush brush;
            e.Graphics.TranslateTransform(30, 10);
            e.Graphics.RotateTransform(90);
            if (CurrentTable.TableId.CompareTo(Guid.Empty) != 0)
            {
                brush = new SolidBrush(Properties.Settings.Default.SuccessTextColor);
                e.Graphics.DrawString(InterfaceRm.GetString("LbCurrentTable", Culture) + ": " + CurrentTable.Name + " (" + AreaContainTable.Name + ")", lb.Font, brush, 0, 0);
            }
            else
            {
                brush = new SolidBrush(Properties.Settings.Default.WarningTextColor);
                e.Graphics.DrawString(InterfaceRm.GetString("LbNoneCurrentTable", Culture), lb.Font, brush, 0, 0);
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
            ChangeButtonColorToHover(sender);
        }

        private void PicAvatar_MouseHover(object sender, EventArgs e)
        {
            ChangeButtonColorToHover(ibtnAccount);
        }

        private void ChangeButtonColorToHover(object sender)
        {
            IconButton ibtn = sender as IconButton;
            ibtn.BackColor = Properties.Settings.Default.BodyBackColor;
            ibtn.ForeColor = Properties.Settings.Default.BaseHoverColor;
            ibtn.IconColor = Properties.Settings.Default.BaseHoverColor;
        }

        private void BtnNav_MouseLeave(object sender, EventArgs e)
        {
            ChangeButtonColorToBase(sender);
        }

        private void PicAvatar_MouseLeave(object sender, EventArgs e)
        {
            ChangeButtonColorToBase(ibtnAccount);
        }

        private void ChangeButtonColorToBase(object sender)
        {
            IconButton ibtn = sender as IconButton;
            ibtn.BackColor = Color.Transparent;
            ibtn.ForeColor = Properties.Settings.Default.BaseTextColor;
            ibtn.IconColor = Properties.Settings.Default.BaseTextColor;
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

        #region Effects - Extend/Collapse navigation bar
        private void IbtnToggle_Click(object sender, EventArgs e)
        {
            ExtendOrCollapseNavigationBar();
        }

        private void ExtendOrCollapseNavigationBar()
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
        #endregion

        #region Effects - Draw rounded border for Avatar PictureBox
        private void PicAvatar_Paint(object sender, PaintEventArgs e)
        {
            var pic = sender as PictureBox;
            int x = pic.Location.X;
            int y = pic.Location.Y;
            int w = pic.Width;
            int h = pic.Height;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Brush brush = new SolidBrush(Properties.Settings.Default.BaseBorderColor);
            Pen pen = new Pen(brush)
            {
                Width = 7
            };
            e.Graphics.DrawEllipse(pen, x - 5, y, w - 3, h - 3);
            //e.Graphics.FillEllipse(Brushes.White, x, y, w, h);
        }
        #endregion

        #region Effects - Auto resize column width of ListView
        private void LsvBillDetail_SizeChanged(object sender, EventArgs e)
        {
            AutoColumnWidth();
        }

        private void AutoColumnWidth()
        {
            lsvBillDetail.Columns[1].Width = 50;
            lsvBillDetail.Columns[2].Width = 100;
            lsvBillDetail.Columns[3].Width = 100;
            lsvBillDetail.Columns[4].Width = 100;
            lsvBillDetail.Columns[0].Width = lsvBillDetail.Width - (100 + 100 + 100 + 50);
        }
        #endregion

        #region Effects - Show/Hide account option panel
        private void IbtnAccount_Click(object sender, EventArgs e)
        {
            ShowOrHideAccountOptions();
        }

        private void ShowOrHideAccountOptions()
        {
            int x = pnlAccountGroup.Location.X;
            int y = pnlAccountGroup.Location.Y - pnlAccountChilren.Height;
            pnlAccountChilren.Location = new Point(x, y);
            pnlAccountChilren.Visible = !pnlAccountChilren.Visible;
        }
        #endregion

        #region Effects - Drop Shadow
        private void FpnlAreaList_Paint(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            Pen pen = new Pen(Properties.Settings.Default.DropShadowColor);
            using (pen)
            {
                foreach (Control btn in panel.Controls)
                {
                    int depth = Properties.Settings.Default.DropShadowDepth;
                    if (btn is IconButton)
                    {
                        int w = btn.Width;
                        int h = btn.Height;
                        // Draw Bottom Shadow
                        Point bottomLeftPoint = new Point(btn.Location.X + depth, btn.Location.Y + h);
                        for (var i = 0; i < depth; i++)
                        {
                            e.Graphics.DrawLine(
                                pen,
                                bottomLeftPoint.X,
                                bottomLeftPoint.Y,
                                bottomLeftPoint.X + w,
                                bottomLeftPoint.Y);
                            bottomLeftPoint.Y++;
                        }
                        // Draw Right Shadow
                        Point topRightPoint = new Point(btn.Location.X + w, btn.Location.Y + depth);
                        for (var i = 0; i < depth; i++)
                        {
                            e.Graphics.DrawLine(
                                pen,
                                topRightPoint.X,
                                topRightPoint.Y,
                                topRightPoint.X,
                                topRightPoint.Y + h);
                            topRightPoint.X++;
                        }
                    }
                }
            }
        }

        private void FpnlTableList_Paint(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            Pen pen = new Pen(Properties.Settings.Default.DropShadowColor);
            using (pen)
            {
                foreach (Control btn in panel.Controls)
                {
                    int depth = Properties.Settings.Default.DropShadowDepth;
                    if (btn is RoundedIconButton)
                    {
                        int w = btn.Width;
                        int h = btn.Height;
                        int cornerRadius = Properties.Settings.Default.CornerRadius;
                        using (GraphicsPath path = RoundedRect(new Rectangle(btn.Location.X + depth, btn.Location.Y + depth, w, h), cornerRadius))
                        {
                            e.Graphics.FillPath(new SolidBrush(Properties.Settings.Default.DropShadowColor), path);
                        }
                    }
                }
            }
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        #endregion

        #region Load ReadyTable and UsingTable for 2 ContextMenuStrips to drop down
        private void CmsTableDropDown_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadReadyTableDropDownItems(tableMoveToolStripMenuItem);
            LoadUsingTableDropDownItems(tableMergeToolStripMenuItem);
        }

        private void CmsShortcutKeyDropDown_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadReadyTableDropDownItems(moveTableToolStripMenuItem);
            LoadUsingTableDropDownItems(mergeTableToolStripMenuItem);
        }

        private void LoadReadyTableDropDownItems(ToolStripMenuItem parentsItem)
        {
            parentsItem.DropDownItems.Clear();
            TableFilter filter = new TableFilter()
            {
                Status = TableStatus.Ready
            };
            var reader = _tableService.Read(filter, CultureName);

            if (reader.Item1)
            {
                List<TableModel> readyTableList = (reader.Item2 as Paginator<TableModel>).Item;
                if (readyTableList.Count > 0)
                {
                    foreach (TableModel item in readyTableList)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                        {
                            Text = item.Name,
                            Tag = item,
                            ForeColor = Properties.Settings.Default.SuccessTextColor
                        };
                        toolStripMenuItem.Click += MoveToReadyTable_Click;
                        parentsItem.DropDownItems.Add(toolStripMenuItem);
                    }
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                    {
                        Text = InterfaceRm.GetString("MsgNotFound", Culture),
                        ForeColor = Properties.Settings.Default.ErrorTextColor
                    };
                    parentsItem.DropDownItems.Add(toolStripMenuItem);
                }
            }
        }

        private void LoadUsingTableDropDownItems(ToolStripMenuItem parentsItem)
        {
            parentsItem.DropDownItems.Clear();
            TableFilter filter = new TableFilter()
            {
                Status = TableStatus.Using
            };
            var reader = _tableService.Read(filter, CultureName);
            if (reader.Item1)
            {
                List<TableModel> usingTableList = (reader.Item2 as Paginator<TableModel>).Item;
                if (usingTableList.Count > 1)
                {
                    foreach (TableModel item in usingTableList)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                        {
                            Text = item.Name,
                            Tag = item,
                            ForeColor = Properties.Settings.Default.ErrorTextColor
                        };

                        if ((toolStripMenuItem.Tag as TableModel).TableId.CompareTo(CurrentTable.TableId) == 0)
                        {
                            toolStripMenuItem.Visible = false;
                        }

                        toolStripMenuItem.Click += MergeWithUsingTable_Click;
                        parentsItem.DropDownItems.Add(toolStripMenuItem);
                    }
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                    {
                        Text = InterfaceRm.GetString("MsgNotFound", Culture),
                        ForeColor = Properties.Settings.Default.ErrorTextColor
                    };
                    parentsItem.DropDownItems.Add(toolStripMenuItem);
                }
            }
        }
        #endregion

        #region Setting
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
        #endregion

        #region Checkout
        private void IpicCheckOut_Click(object sender, EventArgs e)
        {
            OpenFormCheckOut();
        }

        private void OpenFormCheckOut()
        {
            if (CurrentTable.TableId.CompareTo(Guid.Empty) == 0)
            {
                string msg = InterfaceRm.GetString("MsgNoSelectedTable", Culture);
                FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, AlertTimer, new Tuple<Point, Size>(Location, Size));
                return;
            }
            else if (CurrentTable.Status.CompareTo(TableStatus.Using) != 0)
            {
                string msg = InterfaceRm.GetString("MsgCannotCheckOut", Culture);
                FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, AlertTimer, new Tuple<Point, Size>(Location, Size));
                return;
            }

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
                ReLoadTable();
                LoadFooter();
            }
        }
        #endregion

        #region Order
        private void IpicOrder_Click(object sender, EventArgs e)
        {
            OpenFormOrder();
        }

        private void OpenFormOrder()
        {
            if (CurrentTable.TableId.CompareTo(Guid.Empty) == 0)
            {
                string msg = InterfaceRm.GetString("MsgNoSelectedTable", Culture);
                FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, AlertTimer, new Tuple<Point, Size>(Location, Size));
                return;
            }
            else if (CurrentTable.Status.CompareTo(TableStatus.Pending) == 0)
            {
                string msg = InterfaceRm.GetString("MsgCannotOrder", Culture);
                FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, AlertTimer, new Tuple<Point, Size>(Location, Size));
                return;
            }

            try
            {
                FormOrder f = new FormOrder(CurrentTable, CurrentUser, CurrentBill, CurrentBillDetails);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ReLoadTable();
                LoadFooter();
            }
        }
        #endregion

        #region Move table
        private void IpicMoveTable_Click(object sender, EventArgs e)
        {
            ShowMoveOptions();
        }

        private void ShowMoveOptions()
        {
            LoadReadyTableList();
            if (CurrentTable.TableId.CompareTo(Guid.Empty) == 0)
            {
                string msg = InterfaceRm.GetString("MsgNoSelectedTable", Culture);
                FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, AlertTimer, new Tuple<Point, Size>(Location, Size));
            }
            else
            {
                Point ptLowerLeft = new Point(0, ipicMoveTable.Height);
                ptLowerLeft = ipicMoveTable.PointToScreen(ptLowerLeft);
                cmsReadyTableList.Show(ptLowerLeft);
            }
        }

        private void LoadReadyTableList()
        {
            cmsReadyTableList.Items.Clear();
            TableFilter filter = new TableFilter()
            {
                Status = TableStatus.Ready
            };
            var reader = _tableService.Read(filter, CultureName);

            if (reader.Item1)
            {
                List<TableModel> readyTableList = (reader.Item2 as Paginator<TableModel>).Item;
                if (readyTableList.Count > 0)
                {
                    foreach (TableModel item in readyTableList)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                        {
                            Text = item.Name,
                            Tag = item,
                            ForeColor = Properties.Settings.Default.SuccessTextColor
                        };
                        toolStripMenuItem.Click += MoveToReadyTable_Click;
                        cmsReadyTableList.Items.Add(toolStripMenuItem);
                    }
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                    {
                        Text = InterfaceRm.GetString("MsgNotFound", Culture),
                        ForeColor = Properties.Settings.Default.ErrorTextColor
                    };
                    cmsReadyTableList.Items.Add(toolStripMenuItem);
                }
            }
        }

        private void MoveToReadyTable_Click(object sender, EventArgs e)
        {
            MoveTable(sender);
        }

        private void MoveTable(object sender)
        {
            // Before
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            TableModel destinationTable = item.Tag as TableModel;
            destinationTable.Status = TableStatus.Using;
            string msgConfirm = InterfaceRm.GetString("MsgMoveConfirm1", Culture) + " "
                + CurrentTable.Name + " "
                + InterfaceRm.GetString("MsgMoveConfirm2", Culture) + " "
                + destinationTable.Name + "?";
            DialogResult result = FormMessageBox.Show(msgConfirm, string.Empty, CustomMessageBoxIcon.Question, CustomMessageBoxButton.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            CurrentTable.Status = TableStatus.Ready;
            CurrentBill.TableId = destinationTable.TableId;
            // Update data
            MoveTableSaveChanged(destinationTable);
            // After
            ReLoadTable();
            string msgSuccess = InterfaceRm.GetString("MsgMoveSuccess", Culture);
            FormMessageBox.Show(msgSuccess, string.Empty, CustomMessageBoxIcon.Success, AlertTimer, new Tuple<Point, Size>(Location, Size));
        }

        private void MoveTableSaveChanged(TableModel destinationTable)
        {
            var updater1 = _billService.Update(CurrentBill, CultureName);
            if (!updater1.Item1)
            {
                FormMessageBox.Show(updater1.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
            var updater2 = _tableService.Update(CurrentTable, CultureName);
            if (!updater2.Item1)
            {
                FormMessageBox.Show(updater2.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
            var updater3 = _tableService.Update(destinationTable, CultureName);
            if (!updater3.Item1)
            {
                FormMessageBox.Show(updater3.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
        }
        #endregion

        #region Merge table
        private void IpicMergeTable_Click(object sender, EventArgs e)
        {
            ShowMergeOptions();
        }

        private void ShowMergeOptions()
        {
            LoadUsingTableList();
            if (CurrentTable.TableId.CompareTo(Guid.Empty) == 0)
            {
                string msg = InterfaceRm.GetString("MsgNoSelectedTable", Culture);
                FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, AlertTimer, new Tuple<Point, Size>(Location, Size));
            }
            else
            {
                Point ptLowerLeft = new Point(0, ipicMergeTable.Height);
                ptLowerLeft = ipicMergeTable.PointToScreen(ptLowerLeft);
                cmsUsingTableList.Show(ptLowerLeft);
            }
        }

        private void LoadUsingTableList()
        {
            cmsUsingTableList.Items.Clear();
            TableFilter filter = new TableFilter()
            {
                Status = TableStatus.Using
            };
            var reader = _tableService.Read(filter, CultureName);
            if (reader.Item1)
            {
                List<TableModel> usingTableList = (reader.Item2 as Paginator<TableModel>).Item;
                if (usingTableList.Count > 1)
                {
                    foreach (TableModel item in usingTableList)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                        {
                            Text = item.Name,
                            Tag = item,
                            ForeColor = Properties.Settings.Default.ErrorTextColor
                        };

                        if ((toolStripMenuItem.Tag as TableModel).TableId.CompareTo(CurrentTable.TableId) == 0)
                        {
                            toolStripMenuItem.Visible = false;
                        }

                        toolStripMenuItem.Click += MergeWithUsingTable_Click;
                        cmsUsingTableList.Items.Add(toolStripMenuItem);
                    }
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                    {
                        Text = InterfaceRm.GetString("MsgNotFound", Culture),
                        ForeColor = Properties.Settings.Default.ErrorTextColor
                    };
                    cmsUsingTableList.Items.Add(toolStripMenuItem);
                }
            }
        }

        private void MergeWithUsingTable_Click(object sender, EventArgs e)
        {
            MergeTable(sender);
        }

        private void MergeTable(object sender)
        {
            // Before
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            TableModel destinationTable = item.Tag as TableModel;
            string msgConfirm = InterfaceRm.GetString("MsgMergeConfirm1", Culture) + " "
                + CurrentTable.Name + " "
                + InterfaceRm.GetString("MsgMergeConfirm2", Culture) + " "
                + destinationTable.Name + "?";
            DialogResult result = FormMessageBox.Show(msgConfirm, string.Empty, CustomMessageBoxIcon.Question, CustomMessageBoxButton.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            BillFilter destinationBillFilter = new BillFilter()
            {
                TableId = destinationTable.TableId,
                Status = BillStatus.UnPay
            };
            var destinationBillReader = _billService.Read(destinationBillFilter, CultureName);
            if (!destinationBillReader.Item1)
            {
                FormMessageBox.Show(destinationBillReader.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
            BillModel destinationBill = (destinationBillReader.Item2 as Paginator<BillModel>).Item[0];

            BillDetailFilter destinationBillDetailFilter = new BillDetailFilter()
            {
                BillId = destinationBill.BillId
            };
            var destinationBillDetailReader = _billDetailService.Read(destinationBillDetailFilter, CultureName);
            if (!destinationBillDetailReader.Item1)
            {
                FormMessageBox.Show(destinationBillDetailReader.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
            List<BillDetailModel> destinationBillDetail = (destinationBillDetailReader.Item2 as Paginator<BillDetailModel>).Item;

            List<BillDetailModel> notMatchList = new List<BillDetailModel>();
            foreach (BillDetailModel source in CurrentBillDetails)
            {
                bool isMatched = false;
                foreach (BillDetailModel destination in destinationBillDetail)
                {
                    if (source.ProductId.CompareTo(destination.ProductId) == 0)
                    {
                        destination.Quantity += source.Quantity;
                        isMatched = true;
                        if (source.PromotionValue == destination.PromotionValue)
                        {
                            destination.IntoMoney += source.IntoMoney;
                        }
                        else
                        {
                            ProductFilter filter = new ProductFilter()
                            {
                                ProductId = source.ProductId
                            };
                            var product = (_productService.Read(filter, CultureName).Item2 as Paginator<ProductModel>).Item[0];
                            string msg = InterfaceRm.GetString("MsgMerge1", Culture) + " " + product.Name + " "
                                + InterfaceRm.GetString("MsgMerge2", Culture) + " " + CurrentTable.Name + @" & " + destinationTable.Name + " "
                                + InterfaceRm.GetString("MsgMerge3", Culture)
                                + Environment.NewLine
                                + " - " + CurrentTable.Name + " - " + source.PromotionValue + "% " + InterfaceRm.GetString("MsgMerge4", Culture)
                                + Environment.NewLine
                                + " - " + destinationTable.Name + " - " + destination.PromotionValue + "% " + InterfaceRm.GetString("MsgMerge5", Culture)
                                + Environment.NewLine
                                + " - " + InterfaceRm.GetString("MsgMerge6", Culture)
                                + Environment.NewLine
                                + InterfaceRm.GetString("MsgMerge7", Culture);

                            DialogResult pickResult = FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, CustomMessageBoxButton.YesNoCancel);
                            if (pickResult == DialogResult.Yes)
                            {
                                destination.PromotionValue = source.PromotionValue;
                                float promotionPrice = product.Price * (100 - source.PromotionValue) / 100;
                                destination.IntoMoney = promotionPrice * destination.Quantity;
                            }
                            else if (pickResult == DialogResult.No)
                            {
                                destination.PromotionValue = destination.PromotionValue;
                                float promotionPrice = product.Price * (100 - destination.PromotionValue) / 100;
                                destination.IntoMoney = promotionPrice * destination.Quantity;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                if (!isMatched)
                {
                    source.BillId = destinationBill.BillId;
                    notMatchList.Add(source);
                }
            }
            destinationBill.Total = CalculateDestinationBillTotal(destinationBillDetail);
            CurrentTable.Status = TableStatus.Ready;

            // Update
            UpdateBillDetailInDestination(destinationBillDetail);
            CreateBillDetailInDestination(notMatchList);
            UpdateBillTotalInDestination(destinationBill);
            DeleteBillInOrigin();
            UpdateTableStatusInOrigin();

            // After
            ReLoadTable();
            LoadFooter();
            string msgSuccess = InterfaceRm.GetString("MsgMergeSuccess", Culture);
            FormMessageBox.Show(msgSuccess, string.Empty, CustomMessageBoxIcon.Success, AlertTimer, new Tuple<Point, Size>(Location, Size));
        }

        private float CalculateDestinationBillTotal(List<BillDetailModel> destinationBillDetail)
        {
            float total = 0;
            foreach (BillDetailModel item in destinationBillDetail)
            {
                total += item.IntoMoney;
            }
            return total;
        }

        private void UpdateBillDetailInDestination(List<BillDetailModel> destinationBillDetail)
        {
            foreach (BillDetailModel detailItem in destinationBillDetail)
            {
                var updater2 = _billDetailService.Update(detailItem, CultureName);
                if (!updater2.Item1)
                {
                    FormMessageBox.Show(updater2.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                    return;
                }
            }
        }

        private void CreateBillDetailInDestination(List<BillDetailModel> notMatchList)
        {
            foreach (BillDetailModel detailItem in notMatchList)
            {
                var creator = _billDetailService.Create(detailItem, CultureName);
                if (!creator.Item1)
                {
                    FormMessageBox.Show(creator.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                    return;
                }
            }
        }

        private void UpdateBillTotalInDestination(BillModel destinationBill)
        {
            var updater3 = _billService.Update(destinationBill, CultureName);
            if (!updater3.Item1)
            {
                FormMessageBox.Show(updater3.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
        }

        private void DeleteBillInOrigin()
        {
            var deleter = _billService.Delete(CurrentBill.BillId, CultureName);
            if (!deleter.Item1)
            {
                FormMessageBox.Show(deleter.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
        }

        private void UpdateTableStatusInOrigin()
        {
            var updater1 = _tableService.Update(CurrentTable, CultureName);
            if (!updater1.Item1)
            {
                FormMessageBox.Show(updater1.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
        }
        #endregion

        #region Reload table
        private void IpicLoadTable_Click(object sender, EventArgs e)
        {
            ReLoadTable();
        }

        private void ReLoadTable()
        {
            CurrentTable = new TableModel();
            AreaContainTable = new AreaModel();
            LoadTableList();
            CurrentBill = new BillModel();
            CurrentBillDetails = new List<BillDetailModel>();
            lsvBillDetail.Items.Clear();
            lbCurrentTable.Invalidate(lbCurrentTable.Region);
        }
        #endregion

        #region View Bill
        private void IpicViewBill_Click(object sender, EventArgs e)
        {
            ShowOrHideBillPanel();
        }

        private void ShowOrHideBillPanel()
        {
            if (pnlBill.Visible)
            {
                pnlBill.Size = pnlBill.MinimumSize;
                pnlBill.Hide();
            }
            else
            {
                pnlBill.Size = pnlBill.MaximumSize;
                double w = pnlBill.Width * 2 / 3;
                pnlBill.Width = (int)w;
                pnlBill.Show();
            }
        }
        #endregion

        #region Profile
        private void IbtnProfile_Click(object sender, EventArgs e)
        {
            OpenFormProfile();
        }

        private void OpenFormProfile()
        {
            //Form formBackground = new Form();
            try
            {
                using (FormProfile f = new FormProfile(CurrentUser, CurrentRole))
                {
                    //formBackground.StartPosition = FormStartPosition.Manual;
                    //formBackground.Location = Location;
                    //formBackground.Size = Size;
                    //formBackground.FormBorderStyle = FormBorderStyle.None;
                    //formBackground.Opacity = .80d;
                    //formBackground.BackColor = Properties.Settings.Default.BodyBackColor;
                    //formBackground.TopMost = true;
                    //formBackground.ShowInTaskbar = false;
                    //formBackground.Show();

                    //f.Owner = formBackground;
                    f.ShowDialog();
                    //formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //formBackground.Dispose();
            }
        }
        #endregion

        #region Lock table
        private void IpicLockTable_Click(object sender, EventArgs e)
        {
            LockTable();
        }

        private void LockTable()
        {
            // Before
            TableModel model = CurrentTable;
            if (model.Status.CompareTo(TableStatus.Ready) == 0)
            {
                model.Status = TableStatus.Pending;
            }
            else if (model.Status.CompareTo(TableStatus.Pending) == 0)
            {
                model.Status = TableStatus.Ready;
            }
            // Update data
            LockTableSaveChanged(model);
            // After
            ReLoadTable();
        }

        private void LockTableSaveChanged(TableModel model)
        {
            var updater = _tableService.Update(model, CultureName);
            if (!updater.Item1)
            {
                FormMessageBox.Show(updater.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return;
            }
        }
        #endregion

        #region Shortcut key
        private void FormCashier_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Alt | Keys.P:
                    OpenFormProfile();
                    break;
                case Keys.Alt | Keys.C:
                    OpenFormCheckOut();
                    break;
                case Keys.Alt | Keys.R:
                    ReLoadTable();
                    break;
                case Keys.Alt | Keys.L:
                    LockTable();
                    break;
                case Keys.Alt | Keys.M:
                    MaximizeSwitch();
                    break;
                case Keys.Alt | Keys.W:
                    ShowMergeOptions();
                    break;
                case Keys.Alt | Keys.N:
                    MinimizeSwitch();
                    break;
                case Keys.Alt | Keys.Q:
                    ShowMoveOptions();
                    break;
                case Keys.Alt | Keys.O:
                    OpenFormOrder();
                    break;
                case Keys.Alt | Keys.S:
                    OpenFormSetting();
                    break;
                case Keys.Alt | Keys.V:
                    ShowOrHideBillPanel();
                    break;
                default: break;
            }
        }

        private void IbtnShortcutKey_Click(object sender, EventArgs e)
        {
            ShowShortcutKeyContextMenuStrip();
        }

        private void ShowShortcutKeyContextMenuStrip()
        {
            cmsShortcutKeyDropDown.Show(ibtnShortcutKey, 0, ibtnShortcutKey.Height);
        }

        private void ShortcutEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenShortcutEditor();
        }

        private void OpenShortcutEditor()
        {
            string msg = InterfaceRm.GetString("MsgNotAvailable", Culture);
            FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Information, AlertTimer, new Tuple<Point, Size>(Location, Size));
        }
        #endregion
    }
}
