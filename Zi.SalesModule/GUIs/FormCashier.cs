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
        public AreaModel AreaContainTable { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public Stream InitStream { get; set; }
        public Stream ClickStream { get; set; }
        public string SoundtrackPath { get; set; }
        public bool OnResizeMode { get; set; }
        public NumberFormatInfo LocalFormat { get; set; }
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
            SetCulture();
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
            SetToolState();
        }

        private void LoadSetting()
        {
            SetCulture();
            SetCurrencyFormat();
            SetStaticText();
            SetColor();
            SetAudio();
            LoadFooter();
            LoadAreaList();
            LoadReadyTableList();
            LoadUsingTableList();
        }

        private void LoadUsingTableList()
        {
            cmsUsingTableList.Items.Clear();
            TableFilter filter = new TableFilter()
            {
                Status = TableStatus.Using
            };
            var reader = TableService.Instance.Read(filter, CultureName);
            if (reader.Item1)
            {
                List<TableModel> usingTableList = (reader.Item2 as Paginator<TableModel>).Item;
                if (usingTableList.Count > 1)
                {
                    foreach (TableModel item in usingTableList)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Text = item.Name;
                        toolStripMenuItem.Tag = item;
                        toolStripMenuItem.ForeColor = Properties.Settings.Default.ErrorTextColor;
                        toolStripMenuItem.Click += MergeWithToolStripMenuItem_Click;
                        cmsUsingTableList.Items.Add(toolStripMenuItem);
                    }
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                    toolStripMenuItem.Text = InterfaceRm.GetString("MsgNotFound", Culture);
                    toolStripMenuItem.ForeColor = Properties.Settings.Default.ErrorTextColor;
                    cmsUsingTableList.Items.Add(toolStripMenuItem);
                }
            }
        }

        private void MergeWithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Code
        }

        private void LoadReadyTableList()
        {
            cmsReadyTableList.Items.Clear();
            TableFilter filter = new TableFilter()
            {
                Status = TableStatus.Ready
            };
            var reader = TableService.Instance.Read(filter, CultureName);
            if (reader.Item1)
            {
                List<TableModel> readyTableList = (reader.Item2 as Paginator<TableModel>).Item;
                if (readyTableList.Count > 0)
                {
                    foreach (TableModel item in readyTableList)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Text = item.Name;
                        toolStripMenuItem.Tag = item;
                        toolStripMenuItem.ForeColor = Properties.Settings.Default.SuccessTextColor;
                        toolStripMenuItem.Click += MoveToToolStripMenuItem_Click;
                        cmsReadyTableList.Items.Add(toolStripMenuItem);
                    }
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                    toolStripMenuItem.Text = InterfaceRm.GetString("MsgNotFound", Culture);
                    toolStripMenuItem.ForeColor = Properties.Settings.Default.ErrorTextColor;
                    cmsReadyTableList.Items.Add(toolStripMenuItem);
                }
            }
        }

        private void MoveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Code
        }

        private void LoadAreaList()
        {
            fpnlAreaList.Controls.Clear();
            IconButton btnAllArea = new IconButton()
            {
                Size = Properties.Settings.Default.AreaItemSize,
                FlatStyle = FlatStyle.Flat,
                Text = InterfaceRm.GetString("BtnAllArea", Culture),
                ForeColor = Properties.Settings.Default.BaseTextColor,
                BackColor = Properties.Settings.Default.ItemBackColor,
                Margin = new Padding(10, 10, 10, 10),
                Tag = new AreaModel()
            };
            btnAllArea.FlatAppearance.BorderSize = 0;
            btnAllArea.MouseHover += BtnArea_MouseHover;
            btnAllArea.MouseLeave += BtnArea_MouseLeave;
            btnAllArea.MouseDown += AllBtn_MouseDown;
            btnAllArea.Click += BtnArea_Click;
            fpnlAreaList.Controls.Add(btnAllArea);
            CurrentArea = btnAllArea.Tag as AreaModel;

            AreaFilter areaFilter = new AreaFilter();
            var areaReader = AreaService.Instance.Read(areaFilter, CultureName);
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
                IconButton btnArea = new IconButton()
                {
                    Size = Properties.Settings.Default.AreaItemSize,
                    FlatStyle = FlatStyle.Flat,
                    Text = InterfaceRm.GetString("BtnArea", Culture) + " " + item.Name,
                    ForeColor = Properties.Settings.Default.BaseTextColor,
                    BackColor = Properties.Settings.Default.ItemBackColor,
                    Margin = new Padding(10, 10, 10, 10),
                    Tag = item
                };
                btnArea.FlatAppearance.BorderSize = 0;
                btnArea.MouseHover += BtnArea_MouseHover;
                btnArea.MouseLeave += BtnArea_MouseLeave;
                btnArea.MouseDown += AllBtn_MouseDown;
                btnArea.Click += BtnArea_Click;
                fpnlAreaList.Controls.Add(btnArea);
            }
            LoadTableList();
            fpnlAreaList.Invalidate(fpnlAreaList.Region);
        }

        private void BtnArea_Click(object sender, EventArgs e)
        {
            Button btnArea = sender as Button;
            CurrentArea = btnArea.Tag as AreaModel;
            LoadTableList();
        }

        private void LoadTableList()
        {
            fpnlTableList.Controls.Clear();
            Color usingColor = Properties.Settings.Default.ErrorTextColor;
            Color pendingColor = Properties.Settings.Default.WarningTextColor;
            Color readyColor = Properties.Settings.Default.SuccessTextColor;

            List<AreaModel> areaBrowseList = new List<AreaModel>();
            if (CurrentArea.AreaId.CompareTo(Guid.Empty) == 0)
            {
                AreaFilter areaFilter = new AreaFilter();
                var areaReader = AreaService.Instance.Read(areaFilter, CultureName);
                if (areaReader.Item1)
                {
                    areaBrowseList.AddRange((areaReader.Item2 as Paginator<AreaModel>).Item);
                }
            }
            else
            {
                areaBrowseList.Add(CurrentArea);
                AreaFilter areaFilter = new AreaFilter();
                areaFilter.ParentId = CurrentArea.AreaId.ToString();
                var areaReader = AreaService.Instance.Read(areaFilter, CultureName);
                if (areaReader.Item1)
                {
                    areaBrowseList.AddRange((areaReader.Item2 as Paginator<AreaModel>).Item);
                }
            }
            if (areaBrowseList.Count <= 0)
            {
                fpnlTableList.Controls.Add(new Label()
                {
                    Text = InterfaceRm.GetString("MsgNotFound", Culture),
                    ForeColor = Properties.Settings.Default.ErrorTextColor,
                    Font = new Font("Arial", 9, FontStyle.Italic)
                });
                return;
            }

            List<TableModel> tableList = new List<TableModel>();
            foreach (AreaModel item in areaBrowseList)
            {
                TableFilter tableFilter = new TableFilter()
                {
                    AreaId = item.AreaId
                };
                var tableReader = TableService.Instance.Read(tableFilter, CultureName);
                if (!tableReader.Item1)
                {
                    continue;
                }
                else
                {
                    tableList.AddRange((tableReader.Item2 as Paginator<TableModel>).Item);
                }
            }
            if (tableList.Count <= 0)
            {
                fpnlTableList.Controls.Add(new Label()
                {
                    Text = "Not Found",
                    ForeColor = Properties.Settings.Default.ErrorTextColor,
                    Font = new Font("Arial", 9, FontStyle.Italic)
                });
                return;
            }

            foreach (TableModel item in tableList)
            {
                IconButton btnTable = new IconButton()
                {
                    Size = Properties.Settings.Default.TableItemSize,
                    FlatStyle = FlatStyle.Flat,
                    Text = InterfaceRm.GetString("BtnTable", Culture) + " " + item.Name,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    IconChar = IconChar.Chair,
                    TextImageRelation = TextImageRelation.ImageAboveText,
                    BackColor = Properties.Settings.Default.ItemBackColor,
                    Margin = new Padding(10, 10, 10, 10),
                    Tag = item
                };
                btnTable.FlatAppearance.BorderSize = 0;
                if (item.Status.CompareTo(TableStatus.Using) == 0)
                {
                    btnTable.ForeColor = usingColor;
                    btnTable.IconColor = usingColor;
                    btnTable.Text += Environment.NewLine + InterfaceRm.GetString("LbUsingTable", Culture);
                }
                else if (item.Status.CompareTo(TableStatus.Pending) == 0)
                {
                    btnTable.ForeColor = pendingColor;
                    btnTable.IconColor = pendingColor;
                    btnTable.Text += Environment.NewLine + InterfaceRm.GetString("LbPendingTable", Culture);
                }
                else
                {
                    btnTable.ForeColor = readyColor;
                    btnTable.IconColor = readyColor;
                    btnTable.Text += Environment.NewLine + InterfaceRm.GetString("LbReadyTable", Culture);
                }
                btnTable.MouseDown += AllBtn_MouseDown;
                btnTable.MouseDown += BtnTable_MouseDown;
                btnTable.ContextMenuStrip = cmsTableDropDown;
                fpnlTableList.Controls.Add(btnTable);
                fpnlTableList.Invalidate(fpnlTableList.Region);
            }
        }

        private void BtnTable_MouseDown(object sender, MouseEventArgs e)
        {
            IconButton btnTable = sender as IconButton;
            CurrentTable = btnTable.Tag as TableModel;
            AreaFilter filter = new AreaFilter()
            {
                AreaId = CurrentTable.AreaId
            };
            var areaReader = AreaService.Instance.Read(filter, CultureName);
            if (areaReader.Item1)
            {
                AreaContainTable = (areaReader.Item2 as Paginator<AreaModel>).Item[0];
            }
            lbCurrentTable.Invalidate(lbCurrentTable.Region);
            LoadBillList();
        }

        private void LoadBillList()
        {
            lsvBillDetail.Items.Clear();

            if (CurrentTable.Status.CompareTo(TableStatus.Using) != 0)
            {
                SetToolState();
                return;
            }

            BillFilter billFilter = new BillFilter()
            {
                TableId = CurrentTable.TableId,
                Status = BillStatus.UnPay
            };
            var billReader = BillService.Instance.Read(billFilter, CultureName);
            if (billReader.Item1)
            {
                BillModel bill = (billReader.Item2 as Paginator<BillModel>).Item[0];

                BillDetailFilter billDetailFilter = new BillDetailFilter()
                {
                    BillId = bill.BillId
                };
                var billDetailReader = BillDetailService.Instance.Read(billDetailFilter, CultureName);
                if (billDetailReader.Item1)
                {
                    int lineCounter = 0;
                    List<BillDetailModel> billDetails = (billDetailReader.Item2 as Paginator<BillDetailModel>).Item;
                    foreach (BillDetailModel billDetail in billDetails)
                    {
                        ProductFilter productFilter = new ProductFilter()
                        {
                            ProductId = billDetail.ProductId
                        };
                        var productReader = ProductService.Instance.Read(productFilter, CultureName);
                        if (productReader.Item1)
                        {
                            ProductModel product = (productReader.Item2 as Paginator<ProductModel>).Item[0];
                            ListViewItem listViewItem = new ListViewItem(product.Name);
                            listViewItem.SubItems.Add(billDetail.Quantity.ToString());
                            listViewItem.SubItems.Add(product.Price.ToString("n0", LocalFormat));
                            listViewItem.SubItems.Add(billDetail.IntoMoney.ToString("n0", LocalFormat));
                            lsvBillDetail.Items.Add(listViewItem);
                            lineCounter++;
                            if (lineCounter % 2 == 0)
                            {
                                listViewItem.ForeColor = Properties.Settings.Default.BaseHoverColor;
                            }
                            else
                            {
                                listViewItem.ForeColor = Properties.Settings.Default.BaseTextColor;
                            }
                        }
                    }
                }

                SetToolState();
            }
        }

        private void SetToolState()
        {
            if (lsvBillDetail.Items.Count > 0)
            {
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
                    = true;
            }
        }

        private void BtnArea_MouseLeave(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;
            btn.ForeColor = Properties.Settings.Default.BaseTextColor;

            string id = (btn.Tag as AreaModel).AreaId.ToString();
            if (id.ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                foreach (Control child in fpnlAreaList.Controls)
                {
                    if (child is Button)
                    {
                        Button btnChild = child as Button;
                        btnChild.ForeColor = Properties.Settings.Default.BaseTextColor;
                    }
                }
            }
            else
            {
                foreach (Control child in fpnlAreaList.Controls)
                {
                    if (child is IconButton)
                    {
                        IconButton btnChild = child as IconButton;
                        AreaModel model = btnChild.Tag as AreaModel;
                        if (!string.IsNullOrEmpty(model.ParentId) && model.ParentId.ToLower().Equals(id.ToLower()))
                        {
                            btnChild.ForeColor = Properties.Settings.Default.BaseTextColor;
                        }
                    }
                }
            }
        }

        private void BtnArea_MouseHover(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;
            btn.ForeColor = Properties.Settings.Default.BaseHoverColor;

            string id = (btn.Tag as AreaModel).AreaId.ToString();
            if (id.ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                foreach (Control child in fpnlAreaList.Controls)
                {
                    if (child is IconButton)
                    {
                        IconButton btnChild = child as IconButton;
                        btnChild.ForeColor = Properties.Settings.Default.BaseHoverColor;
                    }
                }
            }
            else
            {
                foreach (Control child in fpnlAreaList.Controls)
                {
                    if (child is IconButton)
                    {
                        IconButton btnChild = child as IconButton;
                        AreaModel model = btnChild.Tag as AreaModel;
                        if (!string.IsNullOrEmpty(model.ParentId) && model.ParentId.ToLower().Equals(id.ToLower()))
                        {
                            btnChild.ForeColor = Properties.Settings.Default.BaseHoverColor;
                        }
                    }
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
            // ListView
            lsvBillDetail.BackColor = Properties.Settings.Default.BodyBackColor;
            lsvBillDetail.ForeColor = Properties.Settings.Default.BaseHoverColor;
        }

        private void SetStaticText()
        {
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

            tableCheckOutToolStripMenuItem.Text = InterfaceRm.GetString("TtCheckOut", Culture);
            tableLockToolStripMenuItem.Text = InterfaceRm.GetString("TtLockTable", Culture);
            tableMergeToolStripMenuItem.Text = InterfaceRm.GetString("TtMergeWith", Culture);
            tableMoveToolStripMenuItem.Text = InterfaceRm.GetString("TtMoveTo", Culture);
            tableOrderToolStripMenuItem.Text = InterfaceRm.GetString("TtOrder", Culture);

            lsvBillDetail.Columns[0].Text = InterfaceRm.GetString("ColumnHeaderProduct", Culture);
            lsvBillDetail.Columns[1].Text = InterfaceRm.GetString("ColumnHeaderQuantity", Culture);
            lsvBillDetail.Columns[2].Text = InterfaceRm.GetString("ColumnHeaderPrice", Culture);
            lsvBillDetail.Columns[3].Text = InterfaceRm.GetString("ColumnHeaderIntoMoney", Culture);
        }

        private void SetCurrencyFormat()
        {
            LocalFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            LocalFormat.CurrencySymbol = InterfaceRm.GetString("CurrencySymbol", Culture);
            LocalFormat.CurrencyPositivePattern = 3;
            LocalFormat.CurrencyDecimalDigits = 0;
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.CashierResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormCashier).Assembly);
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
            if (pnlBill.Visible)
            {
                pnlBill.Size = pnlBill.MinimumSize;
                pnlBill.Visible = false;
            }
            else
            {
                pnlBill.Size = pnlBill.MaximumSize;
                double w = pnlBill.Width * 2 / 3;
                pnlBill.Width = (int)w;
                pnlBill.Visible = true;
            }
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
                int x = PointToClient(Cursor.Position).X;
                pnlBill.Visible = true;
                pnlBill.Width = Width - pnlToolBar.Width - x;
                if (pnlBill.Width <= 0)
                {
                    pnlBill.Visible = false;
                }
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
            if (CurrentTable.TableId.CompareTo(Guid.Empty) == 0)
            {
                // Show Message
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
            if (CurrentTable.TableId.CompareTo(Guid.Empty) == 0)
            {
                // Show Message
                return;
            }
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

        private void PnlResizeDivideBody_MouseMove(object sender, MouseEventArgs e)
        {
            int y = pnlBody.PointToClient(Cursor.Position).Y;
            float halfHeight = pnlBody.Height / 2;
            float quarterHeight = halfHeight / 2;
            if (OnResizeMode && y < Math.Floor(halfHeight) && y > Math.Floor(quarterHeight))
            {
                fpnlAreaList.Height = y;
            }
        }

        private void LsvBillDetail_SizeChanged(object sender, EventArgs e)
        {
            lsvBillDetail.Columns[1].Width = 50;
            lsvBillDetail.Columns[2].Width = 100;
            lsvBillDetail.Columns[3].Width = 100;
            lsvBillDetail.Columns[0].Width = lsvBillDetail.Width - (100 + 100 + 50);
        }

        private void IpicMoveTable_Click(object sender, EventArgs e)
        {
            ShowMoveOptions();
        }

        private void ShowMoveOptions()
        {
            LoadReadyTableList();
            if (CurrentTable == null)
            {
                // Show Message
            }
            else
            {
                Point ptLowerLeft = new Point(0, ipicMoveTable.Height);
                ptLowerLeft = ipicMoveTable.PointToScreen(ptLowerLeft);
                cmsReadyTableList.Show(ptLowerLeft);
            }
        }

        private void IpicMergeTable_Click(object sender, EventArgs e)
        {
            ShowMergeOptions();
        }

        private void ShowMergeOptions()
        {
            cmsUsingTableList.Items.Clear();
            LoadUsingTableList();
            if (CurrentTable == null)
            {
                // Show Message
            }
            else
            {
                Point ptLowerLeft = new Point(0, ipicMergeTable.Height);
                ptLowerLeft = ipicMergeTable.PointToScreen(ptLowerLeft);
                cmsUsingTableList.Show(ptLowerLeft);
            }
        }

        private void IpicLoadTable_Click(object sender, EventArgs e)
        {
            ReLoadTable();
        }

        private void ReLoadTable()
        {
            CurrentArea = AreaContainTable = new AreaModel();
            CurrentTable = new TableModel();
            LoadAreaList();
            LoadTableList();
            lsvBillDetail.Items.Clear();
            lbCurrentTable.Invalidate(lbCurrentTable.Region);
        }

        private void CmsTableDropDown_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadReadyTableDropDownItems();
            LoadUsingTableDropDownItems();
        }

        private void LoadUsingTableDropDownItems()
        {
            tableMergeToolStripMenuItem.DropDownItems.Clear();
            TableFilter filter = new TableFilter()
            {
                Status = TableStatus.Using
            };
            var reader = TableService.Instance.Read(filter, CultureName);
            if (reader.Item1)
            {
                List<TableModel> usingTableList = (reader.Item2 as Paginator<TableModel>).Item;
                if (usingTableList.Count > 1)
                {
                    foreach (TableModel item in usingTableList)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Text = item.Name;
                        toolStripMenuItem.Tag = item;
                        toolStripMenuItem.ForeColor = Properties.Settings.Default.ErrorTextColor;
                        toolStripMenuItem.Click += MergeWithToolStripMenuItem_Click;
                        tableMergeToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                    }
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                    toolStripMenuItem.Text = InterfaceRm.GetString("MsgNotFound", Culture);
                    toolStripMenuItem.ForeColor = Properties.Settings.Default.ErrorTextColor;
                    tableMergeToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                }
            }
        }

        private void LoadReadyTableDropDownItems()
        {
            tableMoveToolStripMenuItem.DropDownItems.Clear();
            TableFilter filter = new TableFilter()
            {
                Status = TableStatus.Ready
            };
            var reader = TableService.Instance.Read(filter, CultureName);
            if (reader.Item1)
            {
                List<TableModel> readyTableList = (reader.Item2 as Paginator<TableModel>).Item;
                if (readyTableList.Count > 0)
                {
                    foreach (TableModel item in readyTableList)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Text = item.Name;
                        toolStripMenuItem.Tag = item;
                        toolStripMenuItem.ForeColor = Properties.Settings.Default.SuccessTextColor;
                        toolStripMenuItem.Click += MoveToToolStripMenuItem_Click;
                        tableMoveToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                    }
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                    toolStripMenuItem.Text = InterfaceRm.GetString("MsgNotFound", Culture);
                    toolStripMenuItem.ForeColor = Properties.Settings.Default.ErrorTextColor;
                    tableMoveToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                }
            }
        }

        private void IpicLockTable_Click(object sender, EventArgs e)
        {
            LockTable();
        }

        private void LockTable()
        {
            TableModel model = CurrentTable;
            if (model.Status.CompareTo(TableStatus.Ready) == 0)
            {
                model.Status = TableStatus.Pending;
            }
            else if (model.Status.CompareTo(TableStatus.Pending) == 0)
            {
                model.Status = TableStatus.Ready;
            }
            TableService.Instance.Update(model, CultureName);
            CurrentTable = new TableModel();
            AreaContainTable = new AreaModel();
            LoadTableList();
            lbCurrentTable.Invalidate(lbCurrentTable.Region);
        }

        private void TableLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockTable();
        }

        private void TableOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormOrder();
        }

        private void TableCheckOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormCheckOut();
        }

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
                    if (btn is IconButton)
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

        private void viewBillToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void shortcutEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moveTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mergeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lockTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
