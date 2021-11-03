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
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.SalesModule.CustomControls;
using Zi.Utilities.Enumerators;

namespace Zi.SalesModule.GUIs
{
    public partial class FormOrder : Form
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
        public TableModel CurrentTable { get; set; }
        public UserModel CurrentUser { get; set; }
        public BillModel CurrentBill { get; set; }
        public List<BillDetailModel> CurrentBillDetails { get; set; }
        public CategoryModel CurrentCategory { get; set; }
        public ProductModel CurrentProduct { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public Stream InitStream { get; set; }
        public Stream ClickStream { get; set; }
        public bool OnResizeMode { get; set; }
        public NumberFormatInfo LocalFormat { get; set; }
        public string ErrorTitle { get; set; }
        public string WarningTitle { get; set; }
        public int AlertTimer { get; set; }
        #endregion

        #region DI
        private readonly TableService _tableService;
        private readonly BillService _billService;
        private readonly BillDetailService _billDetailService;
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        #endregion

        public FormOrder(TableModel currentTable,
            UserModel currentUser,
            BillModel currentBill,
            List<BillDetailModel> currentBillDetails)
        {
            InitializeComponent();
            CurrentTable = currentTable;
            CurrentUser = currentUser;
            CurrentBill = currentBill;
            CurrentBillDetails = currentBillDetails;

            _tableService = TableService.Instance;
            _billService = BillService.Instance;
            _billDetailService = BillDetailService.Instance;
            _categoryService = CategoryService.Instance;
            _productService = ProductService.Instance;
        }

        #region Initial
        private void FormOrder_Load(object sender, EventArgs e)
        {
            CurrentCategory = new CategoryModel()
            {
                CategoryId = Guid.Empty
            };
            CurrentProduct = new ProductModel()
            {
                ProductId = Guid.Empty
            };
            OnResizeMode = false;

            DrawRoundedCorner();
            LoadIcon();
            LoadSetting();

            ActiveControl = txbSearch;
            AlertTimer = Properties.Settings.Default.AlertTimer;
        }

        private void DrawRoundedCorner()
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            fpnlCategory.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, fpnlCategory.Width, fpnlCategory.Height, 20, 20));
            fpnlProduct.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, fpnlProduct.Width, fpnlProduct.Height, 20, 20));
            pnlBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBill.Width, pnlBill.Height, 20, 20));

            pnlResizeLeft.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeLeft.Width, pnlResizeLeft.Height, 20, 20));
            pnlResizeRight.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeRight.Width, pnlResizeRight.Height, 20, 20));
        }

        private void LoadIcon()
        {
            ipicClose.IconChar = IconChar.WindowClose;
            ipicMaximize.IconChar = IconChar.WindowMaximize;

            ipicUp.IconChar = IconChar.Plus;
            ipicDown.IconChar = IconChar.Minus;
            ipicViewCart.IconChar = IconChar.ShoppingCart;
        }

        private void LoadSetting()
        {
            SetCulture();
            SetCurrencyFormat();
            SetStaticText();
            SetColor();
            SetAudio();
            LoadCategoryList();
            LoadBill();
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.OrderResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormOrder).Assembly);
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

            lbTitle.Text = InterfaceRm.GetString("LbTitle", Culture) + " - " + CurrentTable.Name;

            ibtnSave.Text = InterfaceRm.GetString("IbtnSave", Culture);
            ibtnCancel.Text = InterfaceRm.GetString("IbtnCancel", Culture);

            ttNote.SetToolTip(ipicClose, InterfaceRm.GetString("IpicClose", Culture));
            ttNote.SetToolTip(ipicMaximize, InterfaceRm.GetString("IpicMaximize", Culture));
            ttNote.SetToolTip(ipicUp, InterfaceRm.GetString("IpicUp", Culture));
            ttNote.SetToolTip(ipicDown, InterfaceRm.GetString("IpicDown", Culture));
            ttNote.SetToolTip(ipicViewCart, InterfaceRm.GetString("IpicViewCart", Culture));

            lsvBillDetail.Columns[0].Text = InterfaceRm.GetString("ColumnHeaderProduct", Culture);
            lsvBillDetail.Columns[1].Text = InterfaceRm.GetString("ColumnHeaderQuantity", Culture);
            lsvBillDetail.Columns[2].Text = InterfaceRm.GetString("ColumnHeaderPrice", Culture);
            lsvBillDetail.Columns[3].Text = InterfaceRm.GetString("ColumnHeaderPromotion", Culture);
            lsvBillDetail.Columns[4].Text = InterfaceRm.GetString("ColumnHeaderIntoMoney", Culture);

            txbSearch.Text = InterfaceRm.GetString("TxbSearch", Culture);
        }

        private void SetColor()
        {
            BackColor = Properties.Settings.Default.BaseBackColor;
            // Header
            pnlTitleBar.BackColor = Properties.Settings.Default.HeaderBackColor;
            // Footer
            pnlFooterBar.BackColor = Properties.Settings.Default.FooterBackColor;
            // Side bar
            pnlLeft.BackColor = Properties.Settings.Default.LeftSideBarBackColor;
            pnlRight.BackColor = Properties.Settings.Default.RightSideBarBackColor;
            // Body
            pnlBill.BackColor = Properties.Settings.Default.BodyBackColor;
            fpnlCategory.BackColor
                = fpnlProduct.BackColor
                = Properties.Settings.Default.BodyBackColor;
            // Icon
            ipicClose.IconColor
                = ipicMaximize.IconColor
                = Properties.Settings.Default.BaseIconColor;
            ipicUp.IconColor
                = ipicDown.IconColor
                = ipicViewCart.IconColor
                = Properties.Settings.Default.BaseIconColor;
            // Button
            ibtnSave.ForeColor
                = ibtnCancel.ForeColor
                = Properties.Settings.Default.BaseBorderColor;
            // Label
            lbTitle.ForeColor = Properties.Settings.Default.BaseTextColor;
            lbCartAmount.ForeColor = Properties.Settings.Default.BaseTextColor;
            lbCartAmount.BackColor = Properties.Settings.Default.ErrorTextColor;
            // TextBox
            txbTotal.ForeColor = Properties.Settings.Default.ErrorTextColor;
            txbSearch.ForeColor = Properties.Settings.Default.BaseTextColor;
            txbTotal.BackColor
                = txbSearch.BackColor
                = Properties.Settings.Default.BodyBackColor;
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
        }

        private void LoadCategoryList()
        {
            fpnlCategory.Controls.Clear();

            int counterAll = _productService.CountAll();
            CategoryItem btnAllCategory = new CategoryItem(new CategoryModel(), counterAll);
            btnAllCategory.MouseHover += BtnCategory_MouseHover;
            btnAllCategory.MouseLeave += BtnCategory_MouseLeave;
            btnAllCategory.MouseDown += AllBtn_MouseDown;
            btnAllCategory.Click += BtnCategory_Click;
            fpnlCategory.Controls.Add(btnAllCategory);
            CurrentCategory = btnAllCategory.Tag as CategoryModel;

            CategoryFilter categoryFilter = new CategoryFilter();
            var categoryReader = _categoryService.Read(categoryFilter, CultureName);
            if (!categoryReader.Item1)
            {
                fpnlCategory.Controls.Add(new Label()
                {
                    Text = categoryReader.Item2.ToString(),
                    ForeColor = Properties.Settings.Default.ErrorTextColor,
                    Font = new Font("Arial", 9, FontStyle.Italic)
                });
                return;
            }
            List<CategoryModel> categoryList = (categoryReader.Item2 as Paginator<CategoryModel>).Item;

            foreach (CategoryModel item in categoryList)
            {
                int counter = _productService.CountByCategory(item.CategoryId);
                CategoryItem btnCategory = new CategoryItem(item, counter);
                btnCategory.MouseHover += BtnCategory_MouseHover;
                btnCategory.MouseLeave += BtnCategory_MouseLeave;
                btnCategory.MouseDown += AllBtn_MouseDown;
                btnCategory.Click += BtnCategory_Click;
                fpnlCategory.Controls.Add(btnCategory);
            }

            LoadProductList(new ProductFilter());
            fpnlCategory.Invalidate(fpnlCategory.Region);
        }

        private void BtnCategory_MouseHover(object sender, EventArgs e)
        {
            CategoryItem btn = sender as CategoryItem;
            btn.ForeColor = Properties.Settings.Default.BaseHoverColor;

            string id = (btn.Tag as CategoryModel).CategoryId.ToString();
            if (id.ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                foreach (Control child in fpnlCategory.Controls)
                {
                    if (child is CategoryItem)
                    {
                        CategoryItem btnChild = child as CategoryItem;
                        btnChild.ForeColor = Properties.Settings.Default.BaseHoverColor;
                    }
                }
            }
            else
            {
                foreach (Control child in fpnlCategory.Controls)
                {
                    if (child is CategoryItem)
                    {
                        CategoryItem btnChild = child as CategoryItem;
                        CategoryModel model = btnChild.Tag as CategoryModel;
                        if (!string.IsNullOrEmpty(model.ParentId) && model.ParentId.ToLower().Equals(id.ToLower()))
                        {
                            btnChild.ForeColor = Properties.Settings.Default.BaseHoverColor;
                        }
                    }
                }
            }
        }

        private void BtnCategory_MouseLeave(object sender, EventArgs e)
        {
            CategoryItem btn = sender as CategoryItem;
            btn.ForeColor = Properties.Settings.Default.BaseTextColor;

            string id = (btn.Tag as CategoryModel).CategoryId.ToString();
            if (id.ToLower().Equals(Guid.Empty.ToString().ToLower()))
            {
                foreach (Control child in fpnlCategory.Controls)
                {
                    if (child is CategoryItem)
                    {
                        CategoryItem btnChild = child as CategoryItem;
                        btnChild.ForeColor = Properties.Settings.Default.BaseTextColor;
                    }
                }
            }
            else
            {
                foreach (Control child in fpnlCategory.Controls)
                {
                    if (child is CategoryItem)
                    {
                        CategoryItem btnChild = child as CategoryItem;
                        CategoryModel model = btnChild.Tag as CategoryModel;
                        if (!string.IsNullOrEmpty(model.ParentId) && model.ParentId.ToLower().Equals(id.ToLower()))
                        {
                            btnChild.ForeColor = Properties.Settings.Default.BaseTextColor;
                        }
                    }
                }
            }
        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            CategoryItem btnCategory = sender as CategoryItem;
            CurrentCategory = btnCategory.Tag as CategoryModel;
            LoadProductListByCategory();
        }

        private void LoadProductListByCategory(ProductFilter productFilter = null)
        {
            List<CategoryModel> categoryBrowseList = new List<CategoryModel>();

            if (CurrentCategory.CategoryId.CompareTo(Guid.Empty) != 0)
            {
                categoryBrowseList.Add(CurrentCategory);
                CategoryFilter categoryFilter = new CategoryFilter
                {
                    ParentId = CurrentCategory.CategoryId.ToString()
                };
                var categoryReader = _categoryService.Read(categoryFilter, CultureName);
                if (categoryReader.Item1)
                {
                    categoryBrowseList.AddRange((categoryReader.Item2 as Paginator<CategoryModel>).Item);
                }
            }

            if (productFilter == null)
            {
                productFilter = new ProductFilter();
            }

            if (categoryBrowseList.Count > 0)
            {
                LoadProductList(productFilter, categoryBrowseList);
            }
            else
            {
                LoadProductList(productFilter);
            }
        }

        private void LoadProductList(ProductFilter productFilter, List<CategoryModel> categoryBrowseList = null)
        {
            List<ProductModel> productList = new List<ProductModel>();
            if (categoryBrowseList != null)
            {
                productList = GetProductsByCategories(productFilter, productList, categoryBrowseList);
            }
            else
            {
                productList = GetAllProducts(productFilter, productList);
            }

            DrawProductItems(productList);
        }

        private List<ProductModel> GetProductsByCategories(ProductFilter productFilter, List<ProductModel> productList, List<CategoryModel> categoryBrowseList)
        {
            foreach (CategoryModel item in categoryBrowseList)
            {
                productFilter.CategoryId = item.CategoryId;
                var productReader = _productService.Read(productFilter, CultureName);
                if (!productReader.Item1)
                {
                    continue;
                }
                else
                {
                    productList.AddRange((productReader.Item2 as Paginator<ProductModel>).Item);
                }
            }
            return productList;
        }

        private List<ProductModel> GetAllProducts(ProductFilter productFilter, List<ProductModel> productList)
        {
            var productReader = _productService.Read(productFilter, CultureName);
            if (productReader.Item1)
            {
                productList.AddRange((productReader.Item2 as Paginator<ProductModel>).Item);
            }
            return productList;
        }

        private void DrawProductItems(List<ProductModel> productList)
        {
            fpnlProduct.Controls.Clear();
            if (productList.Count <= 0)
            {
                fpnlProduct.Controls.Add(new Label()
                {
                    Text = InterfaceRm.GetString("MsgNotFound", Culture),
                    ForeColor = Properties.Settings.Default.ErrorTextColor,
                    AutoSize = true,
                    Font = new Font("Arial", 9, FontStyle.Italic)
                });
            }
            else
            {
                foreach (ProductModel item in productList)
                {
                    ProductItem btnProduct = new ProductItem(item)
                    {
                        Size = Properties.Settings.Default.HorizontalProductItemSize
                    };
                    btnProduct.ZiMouseDown += AllBtn_MouseDown;
                    btnProduct.ZiClick += BtnProduct_ZiClick;
                    btnProduct.ZiMouseHover += BtnProduct_ZiMouseHover;
                    btnProduct.ZiMouseLeave += BtnProduct_ZiMouseLeave;
                    btnProduct.ZiMouseLeave += BtnProduct_ZiMouseLeave;
                    btnProduct.ZiKeyDown += BtnProduct_ZiKeyDown;
                    fpnlProduct.Controls.Add(btnProduct);
                }
            }
            fpnlProduct.Invalidate(fpnlProduct.Region);
        }

        private void BtnProduct_ZiClick(object sender, EventArgs e)
        {
            ProductItem btnProduct = sender as ProductItem;
            CurrentProduct = btnProduct.Tag as ProductModel;
            ChangeItemColorToSelected(sender);
        }

        private void ChangeItemColorToSelected(object sender)
        {
            foreach (Control item in fpnlProduct.Controls)
            {
                if (item is ProductItem && item != sender)
                {
                    (item as ProductItem).BackColor = Properties.Settings.Default.BaseItemColor;
                }
            }
            (sender as ProductItem).BackColor = Properties.Settings.Default.ItemSelectedColor;
        }

        private void BtnProduct_ZiMouseHover(object sender, EventArgs e)
        {
            ChangeItemColorToHover(sender);
        }

        private void ChangeItemColorToHover(object sender)
        {
            ProductItem item = sender as ProductItem;
            if ((item.Tag as ProductModel).ProductId.CompareTo(CurrentProduct.ProductId) != 0)
            {
                item.BackColor = Properties.Settings.Default.ItemHoverColor;
            }
        }

        private void BtnProduct_ZiMouseLeave(object sender, EventArgs e)
        {
            ChangeItemColorToBase(sender);
        }

        private void ChangeItemColorToBase(object sender)
        {
            ProductItem item = sender as ProductItem;
            if ((item.Tag as ProductModel).ProductId.CompareTo(CurrentProduct.ProductId) != 0)
            {
                item.BackColor = Properties.Settings.Default.BaseItemColor;
            }
        }

        private void BtnProduct_ZiKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Add:
                    IncreaseOrder();
                    break;
                case Keys.Subtract:
                    DecreaseOrder();
                    break;
                case Keys.Alt | Keys.V:
                    ShowOrHideCartPanel();
                    break;
                case Keys.Escape:
                    CloseForm();
                    break;
                default: break;
            }
        }

        private void LoadBill()
        {
            lsvBillDetail.Items.Clear();

            float total = 0;
            int qty = 0;
            foreach (BillDetailModel billDetail in CurrentBillDetails)
            {
                LoadBillDetails(billDetail);
                total += billDetail.IntoMoney;
                qty += billDetail.Quantity;
            }
            txbTotal.Text = total.ToString("n0", LocalFormat) + " " + InterfaceRm.GetString("CurrencySymbol", Culture);
            if (qty < 100)
            {
                lbCartAmount.Text = qty.ToString();
            }
            else
            {
                lbCartAmount.Text = "99+";
            }
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
                listViewItem.Tag = product;
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
        private void FormOrder_SizeChanged(object sender, EventArgs e)
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

        #region Effects - Windows state switch & Close
        private void IpicClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void IbtnCancel_Click(object sender, EventArgs e)
        {
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

        private void PnlResizeRight_MouseMove(object sender, MouseEventArgs e)
        {
            ResizeRightPanel();
        }

        private void ResizeRightPanel()
        {
            if (OnResizeMode)
            {
                int x = PointToClient(Cursor.Position).X;
                pnlBill.Show();
                pnlBill.Width = Width - pnlRight.Width - x;
                if (pnlBill.Width <= 0)
                {
                    pnlBill.Hide();
                }
            }
        }

        private void PnlResizeLeft_MouseMove(object sender, MouseEventArgs e)
        {
            ResizeLeftPanel();
        }

        private void ResizeLeftPanel()
        {
            if (OnResizeMode)
            {
                fpnlCategory.Width = PointToClient(Cursor.Position).X - pnlLeft.Width;
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
                case "ipicUp":
                    ipic.IconColor = Properties.Settings.Default.SuccessTextColor;
                    break;
                case "ipicDown":
                    ipic.IconColor = Properties.Settings.Default.ErrorTextColor;
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

        #region Effects - Drop Shadow
        private void FpnlCategoryList_Paint(object sender, PaintEventArgs e)
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

        private void FpnlProductList_Paint(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            Pen pen = new Pen(Properties.Settings.Default.DropShadowColor);
            using (pen)
            {
                foreach (Control btn in panel.Controls)
                {
                    int depth = Properties.Settings.Default.DropShadowDepth;
                    if (btn is ProductItem)
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

        #region Increase order
        private void IpicUp_Click(object sender, EventArgs e)
        {
            IncreaseOrder();
        }

        private void IncreaseOrder()
        {
            // Check if any products have been selected
            if (CurrentProduct.ProductId.CompareTo(Guid.Empty) == 0)
            {
                string msg = InterfaceRm.GetString("MsgNoSelectedProduct", Culture);
                FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, AlertTimer, new Tuple<Point, Size>(Location, Size));
                return;
            }

            // Check if the table already has an invoice
            if (CurrentBill.BillId.CompareTo(Guid.Empty) == 0)
            {
                CurrentBill = new BillModel(CurrentUser.UserId, CurrentTable.TableId);
            }

            // Calculate the money of a product unit
            float promotionPrice = CurrentProduct.Price;
            if (CurrentProduct.PromotionValue > 0)
            {
                promotionPrice = CurrentProduct.Price * (100 - CurrentProduct.PromotionValue) / 100;
            }

            // If product already exists in invoice details, increment quantity by 1 unit, re-calculate & update to IntoMoney and bill total
            foreach (BillDetailModel item in CurrentBillDetails)
            {
                if (item.ProductId.CompareTo(CurrentProduct.ProductId) == 0)
                {
                    item.Quantity++;
                    item.IntoMoney = promotionPrice * item.Quantity;
                    item.PromotionValue = CurrentProduct.PromotionValue;
                    CalculateBillTotal();
                    LoadBill();
                    return;
                }
            }

            // Else, add a new invoice detail (quantity = 1, IntoMoney, PromotionValue)
            CurrentBillDetails.Add(new BillDetailModel(CurrentBill.BillId, CurrentProduct.ProductId)
            {
                IntoMoney = promotionPrice,
                PromotionValue = CurrentProduct.PromotionValue
            });
            CalculateBillTotal();
            LoadBill();
        }
        #endregion

        #region Decrease order
        private void IpicDown_Click(object sender, EventArgs e)
        {
            DecreaseOrder();
        }

        private void DecreaseOrder()
        {
            // Check if any products have been selected
            if (CurrentProduct.ProductId.CompareTo(Guid.Empty) == 0)
            {
                string msg = InterfaceRm.GetString("MsgNoSelectedProduct", Culture);
                FormMessageBox.Show(msg, WarningTitle, CustomMessageBoxIcon.Warning, AlertTimer, new Tuple<Point, Size>(Location, Size));
                return;
            }

            // Calculate the money of a product unit
            float promotionPrice = CurrentProduct.Price;
            if (CurrentProduct.PromotionValue > 0)
            {
                promotionPrice = CurrentProduct.Price * (100 - CurrentProduct.PromotionValue) / 100;
            }

            // If product already exists in invoice details, decrement quantity by 1 unit, update to IntoMoney and bill total
            foreach (BillDetailModel item in CurrentBillDetails)
            {
                if (item.ProductId.CompareTo(CurrentProduct.ProductId) == 0)
                {
                    if (item.Quantity == 1)
                    {
                        CurrentBillDetails.Remove(item);
                    }
                    else if (item.PromotionValue == CurrentProduct.PromotionValue)
                    {
                        item.Quantity--;
                        item.IntoMoney -= promotionPrice;
                    }
                    else
                    {
                        item.Quantity--;
                        item.IntoMoney -= item.IntoMoney / (item.Quantity + 1);
                    }
                    CalculateBillTotal();
                    LoadBill();
                    return;
                }
            }
        }

        private void CalculateBillTotal()
        {
            float total = 0;
            foreach (BillDetailModel item in CurrentBillDetails)
            {
                total += item.IntoMoney;
            }
            CurrentBill.Total = total;
        }
        #endregion

        #region View cart
        private void IpicViewCart_Click(object sender, EventArgs e)
        {
            ShowOrHideCartPanel();
        }

        private void ShowOrHideCartPanel()
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

        #region Confirm save change
        private void IbtnSave_Click(object sender, EventArgs e)
        {
            SaveOrder();
        }

        private void SaveOrder()
        {
            string msg = InterfaceRm.GetString("MsgSaveConfirmation", Culture);
            DialogResult result = FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Question, CustomMessageBoxButton.YesNo);
            if (result == DialogResult.Yes)
            {
                if (CurrentTable.Status.CompareTo(TableStatus.Using) == 0)
                {
                    _billDetailService.DeleteOnBill(CurrentBill.BillId, CultureName);
                    if (CurrentBillDetails.Count <= 0)
                    {
                        _billService.Delete(CurrentBill.BillId, CultureName);
                        CurrentTable.Status = TableStatus.Ready;
                        _tableService.Update(CurrentTable, CultureName);
                    }
                    else
                    {
                        _billService.Update(CurrentBill, CultureName);
                        foreach (BillDetailModel item in CurrentBillDetails)
                        {
                            _billDetailService.Create(item, CultureName);
                        }
                    }
                }
                else
                {
                    if (CurrentBillDetails.Count > 0)
                    {
                        _billService.Create(CurrentBill, CultureName);
                        CurrentTable.Status = TableStatus.Using;
                        _tableService.Update(CurrentTable, CultureName);
                        foreach (BillDetailModel item in CurrentBillDetails)
                        {
                            _billDetailService.Create(item, CultureName);
                        }
                    }
                }
                CloseForm();
            }
            else
            {
                return;
            }
        }
        #endregion

        #region Set selected product in bill details
        private void LsvBillDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedProduct(sender);
        }

        private void SetSelectedProduct(object sender)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = listView.SelectedItems[0];
                CurrentProduct = listViewItem.Tag as ProductModel;
                FindToProductItem();
            }
        }

        private void FindToProductItem()
        {
            foreach (Control item in fpnlProduct.Controls)
            {
                if (item is ProductItem)
                {
                    ProductItem productItem = item as ProductItem;
                    if ((productItem.Tag as ProductModel).ProductId.CompareTo(CurrentProduct.ProductId) == 0)
                    {
                        ChangeItemColorToSelected(item);
                        Point point = fpnlProduct.PointToClient(productItem.Location);
                        fpnlProduct.AutoScrollPosition = point;
                    }
                }
            }
        }
        #endregion

        #region Search product
        private void TxbSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Clear();
        }

        private void TxbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ProductFilter filter = new ProductFilter()
                {
                    Keyword = txbSearch.Text
                };
                LoadProductListByCategory(filter);

                RoundedLabel tag = new RoundedLabel()
                {
                    Text = txbSearch.Text,
                    BackColor = Properties.Settings.Default.BodyBackColor,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                tag.Click += Tag_Click;
                fpnlSearchTag.Controls.Add(tag);

                txbSearch.Clear();
            }
        }

        private void Tag_Click(object sender, EventArgs e)
        {
            RoundedLabel tag = sender as RoundedLabel;
            txbSearch.Text = tag.Text;
        }
        #endregion

        #region Delete bill details by delete key
        private void LsvBillDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteBillDetailItem();
            }
        }

        private void DeleteBillDetailItem()
        {
            if (lsvBillDetail.SelectedItems.Count > 0)
            {
                try
                {
                    BillDetailModel billDetail = new BillDetailModel();
                    foreach (BillDetailModel item in CurrentBillDetails)
                    {
                        if (item.BillId.CompareTo(CurrentBill.BillId) == 0 && item.ProductId.CompareTo(CurrentProduct.ProductId) == 0)
                        {
                            CurrentBillDetails.Remove(item);
                            break;
                        }
                    }
                    CalculateBillTotal();
                    LoadBill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        #endregion
    }
}
