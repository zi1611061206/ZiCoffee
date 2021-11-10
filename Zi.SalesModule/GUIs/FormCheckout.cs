using AForge.Video;
using AForge.Video.DirectShow;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
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
using Zi.Utilities.Constants;
using Zi.Utilities.Enumerators;
using ZXing;

namespace Zi.SalesModule.GUIs
{
    public partial class FormCheckout : Form
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
        public bool IsPaid { get; set; }
        public TableModel CurrentTable { get; set; }
        public BillModel CurrentBill { get; set; }
        public UserModel CurrentUser { get; set; }
        public List<BillDetailModel> CurrentBillDetails { get; set; }
        public List<DiscountDetailModel> CurrentDiscountDetails { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public DateTimeFormatInfo DateTimeFormat { get; set; }
        public Stream InitStream { get; set; }
        public Stream ClickStream { get; set; }
        public Stream ScanStream { get; set; }
        public bool OnResizeMode { get; set; }
        public NumberFormatInfo LocalFormat { get; set; }
        public string ErrorTitle { get; set; }
        public string WarningTitle { get; set; }
        public int AlertTimer { get; set; }
        public float BillTotal { get; set; }
        public float AfterTax { get; set; }
        public float AfterPromotion { get; set; }
        public float LastTotal { get; set; }
        public FilterInfoCollection FilterInfoCollection { get; set; }
        public VideoCaptureDevice VideoCaptureDevice { get; set; }
        #endregion

        #region DI
        private readonly TableService _tableService;
        private readonly BillService _billService;
        private readonly BillDetailService _billDetailService;
        private readonly ProductService _productService;
        private readonly PromotionTypeService _promotionTypeService;
        private readonly PromotionService _promotionService;
        private readonly DiscountDetailService _discountDetailService;
        #endregion

        public FormCheckout(TableModel currentTable,
            BillModel currentBill,
            List<BillDetailModel> currentBillDetails,
            UserModel currentUser)
        {
            InitializeComponent();
            CurrentTable = currentTable;
            CurrentBill = currentBill;
            CurrentUser = currentUser;
            CurrentBillDetails = currentBillDetails;

            _tableService = TableService.Instance;
            _billService = BillService.Instance;
            _billDetailService = BillDetailService.Instance;
            _productService = ProductService.Instance;
            _promotionTypeService = PromotionTypeService.Instance;
            _promotionService = PromotionService.Instance;
            _discountDetailService = DiscountDetailService.Instance;
        }

        #region Initial
        private void FormCheckout_Load(object sender, EventArgs e)
        {
            IsPaid = false;
            CurrentDiscountDetails = new List<DiscountDetailModel>();
            OnResizeMode = false;

            DrawRoundedCorner();
            LoadIcon();
            LoadSetting();
            ApplyAutoPromotion();

            AlertTimer = Properties.Settings.Default.AlertTimer;
        }

        private void DrawRoundedCorner()
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            pnlBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBill.Width, pnlBill.Height, 20, 20));
            pnlHandler.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlHandler.Width, pnlHandler.Height, 20, 20));
            pnlInfo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlInfo.Width, pnlInfo.Height, 20, 20));

            pnlResizeLeft.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeLeft.Width, pnlResizeLeft.Height, 20, 20));
            pnlResizeRight.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeRight.Width, pnlResizeRight.Height, 20, 20));
            pnlResizeTop.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlResizeTop.Width, pnlResizeTop.Height, 20, 20));
        }

        private void LoadIcon()
        {
            ipicClose.IconChar = IconChar.WindowClose;
            ipicMaximize.IconChar = IconChar.WindowMaximize;

            ipicWindowCalculator.IconChar = IconChar.Calculator;
        }

        private void ApplyAutoPromotion()
        {
            PromotionFilter promotionFilter = new PromotionFilter()
            {
                IsActived = PromotionActived.Activated,
                IsAutoApply = PromotionAutoApply.Auto
            };
            var promotionReader = _promotionService.Read(promotionFilter, CultureName);
            if (promotionReader.Item1)
            {
                List<PromotionModel> promotions = (promotionReader.Item2 as Paginator<PromotionModel>).Item;
                foreach (PromotionModel promotion in promotions)
                {
                    if (CheckConditionToAutoApply(promotion))
                    {
                        AddDiscountDetail(promotion);
                    }
                }
            }
        }

        private bool CheckConditionToAutoApply(PromotionModel promotion)
        {
            bool conclude = true;

            if (DateTime.Compare(promotion.StartTime, CurrentBill.CreatedDate) > 0 || DateTime.Compare(promotion.EndTime, CurrentBill.CreatedDate) < 0)
            {
                conclude = false;
            }
            else if (BillTotal < promotion.MinValue)
            {
                conclude = false;
            }
            else if (IsApplyOnce(promotion))
            {
                conclude = false;
            }

            return conclude;
        }

        private void LoadSetting()
        {
            SetCulture();
            SetDateTimeFormat();
            SetCurrencyFormat();
            SetStaticText();
            SetColor();
            SetAudio();
            SetDefaultValue();
            LoadBill();
            LoadManualPromotionList();
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.CheckoutResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormCheckout).Assembly);
        }

        private void SetDateTimeFormat()
        {
            DateTimeFormat = (new CultureInfo(CultureName)).DateTimeFormat;
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
            Text = InterfaceRm.GetString("FormText", Culture);

            ErrorTitle = InterfaceRm.GetString("ErrorTitle", Culture);
            WarningTitle = InterfaceRm.GetString("WarningTitle", Culture);

            lbTitle.Text = InterfaceRm.GetString("LbTitle", Culture) + " - " + CurrentTable.Name;
            lbCustomerMoney.Text = InterfaceRm.GetString("LbCustomerMoney", Culture);
            lbChange.Text = InterfaceRm.GetString("LbChange", Culture);

            ibtnPrintProvisionalInvoice.Text = InterfaceRm.GetString("IbtnPrintProvisionalInvoice", Culture);
            ibtnCheckout.Text = InterfaceRm.GetString("IbtnCheckout", Culture);
            ibtnCancel.Text = InterfaceRm.GetString("IbtnCancel", Culture);

            ibtnScan.Text = InterfaceRm.GetString("IbtnScan", Culture);
            ibtnCheck.Text = InterfaceRm.GetString("IbtnCheck", Culture);

            ttNote.SetToolTip(ipicClose, InterfaceRm.GetString("IpicClose", Culture));
            ttNote.SetToolTip(ipicMaximize, InterfaceRm.GetString("IpicMaximize", Culture));
            ttNote.SetToolTip(ipicWindowCalculator, InterfaceRm.GetString("IpicWindowCalculator", Culture));

            lsvBillDetail.Columns[0].Text = InterfaceRm.GetString("ColumnHeaderProduct", Culture);
            lsvBillDetail.Columns[1].Text = InterfaceRm.GetString("ColumnHeaderQuantity", Culture);
            lsvBillDetail.Columns[2].Text = InterfaceRm.GetString("ColumnHeaderPrice", Culture);
            lsvBillDetail.Columns[3].Text = InterfaceRm.GetString("ColumnHeaderPromotion", Culture);
            lsvBillDetail.Columns[4].Text = InterfaceRm.GetString("ColumnHeaderIntoMoney", Culture);

            lsvDiscountDetail.Columns[0].Text = InterfaceRm.GetString("ColumnHeaderPromotionType", Culture);
            lsvDiscountDetail.Columns[1].Text = InterfaceRm.GetString("ColumnHeaderValue", Culture);
            lsvDiscountDetail.Columns[2].Text = InterfaceRm.GetString("ColumnHeaderMinValue", Culture);
            lsvDiscountDetail.Columns[3].Text = InterfaceRm.GetString("ColumnHeaderAppliedTime", Culture);
            lsvDiscountDetail.Columns[4].Text = InterfaceRm.GetString("ColumnHeaderCode", Culture);

            grbTotal.Text = InterfaceRm.GetString("GrbTotal", Culture);
            grbTax.Text = InterfaceRm.GetString("GrbTax", Culture);
            grbPromotions.Text = InterfaceRm.GetString("GrbPromotions", Culture);
            grbManualPromotions.Text = InterfaceRm.GetString("GrbManualPromotions", Culture);
            grbLastTotal.Text = InterfaceRm.GetString("GrbLastTotal", Culture);
            grbGiveChange.Text = InterfaceRm.GetString("GrbGiveChange", Culture);

            ckbTaxStatus.Text = InterfaceRm.GetString("CkbTaxStatus", Culture);
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
            pnlInfo.BackColor = Properties.Settings.Default.BodyBackColor;
            // Icon
            ipicClose.IconColor
                = ipicMaximize.IconColor
                = Properties.Settings.Default.BaseIconColor;
            ipicWindowCalculator.IconColor = Properties.Settings.Default.BaseIconColor;
            // Button
            ibtnPrintProvisionalInvoice.ForeColor
                = ibtnCheckout.ForeColor
                = ibtnCancel.ForeColor
                = Properties.Settings.Default.BaseBorderColor;
            ibtnScan.ForeColor
                = ibtnCheck.ForeColor
                = Properties.Settings.Default.BaseBorderColor;
            // Label
            lbTitle.ForeColor
                = lbChange.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            // ListView
            lsvBillDetail.BackColor
                = lsvDiscountDetail.BackColor
                = Properties.Settings.Default.BodyBackColor;
            lsvBillDetail.ForeColor
                = lsvDiscountDetail.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            // GroupBox
            grbTotal.ForeColor
                = grbTax.ForeColor
                = grbPromotions.ForeColor
                = grbLastTotal.ForeColor
                = grbGiveChange.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            // Checkbox
            ckbTaxStatus.ForeColor
                = ckbAutoRounding.ForeColor
                = Properties.Settings.Default.BaseTextColor;
            // TextBox
            txbTotal.ForeColor
                = txbAfterTax.ForeColor
                = txbAfterPromotions.ForeColor
                = txbLastTotal.ForeColor
                = txbChange.ForeColor
                = Properties.Settings.Default.ErrorTextColor;
            // NumericUpDown
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

            // Scan Detected Sound
            if (Properties.Settings.Default.AllowScanDetectedSound)
            {
                ScanStream = Properties.Resources.Listening;
            }
            else
            {
                ScanStream = null;
            }
        }

        private void SetDefaultValue()
        {
            float tax = Properties.Settings.Default.DefaultTax;
            nudTax.Value = (decimal)tax;

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(35, 35);
            imageList.Images.Add(Properties.Resources.Discount);
            imageList.Images.Add(Properties.Resources.Voucher);
            imageList.Images.Add(Properties.Resources.Coupon);
            imageList.Images.Add(Properties.Resources.Point);
            imageList.Images.Add(Properties.Resources.Cashback);
            lsvDiscountDetail.SmallImageList = imageList;
            lsvDiscountDetail.LargeImageList = imageList;
        }

        private void LoadBill()
        {
            lsvBillDetail.Items.Clear();

            float total = 0;
            foreach (BillDetailModel billDetail in CurrentBillDetails)
            {
                LoadBillDetails(billDetail);
                total += billDetail.IntoMoney;
            }

            BillTotal = total;
            txbTotal.Text = BillTotal.ToString("n0", LocalFormat);
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

        private void LoadManualPromotionList()
        {
            fpnlManualPromotionList.Controls.Clear();

            PromotionFilter promotionFilter = new PromotionFilter()
            {
                IsActived = PromotionActived.Activated,
                IsAutoApply = PromotionAutoApply.Manual
            };
            var promotionReader = _promotionService.Read(promotionFilter, CultureName);
            if (!promotionReader.Item1)
            {
                fpnlManualPromotionList.Controls.Add(new ErrorLabel(promotionReader.Item2.ToString()));
                return;
            }
            else
            {
                List<PromotionModel> promotions = (promotionReader.Item2 as Paginator<PromotionModel>).Item;
                foreach (PromotionModel promotion in promotions)
                {
                    DrawManualPromotionItem(promotion);
                }
                if (fpnlManualPromotionList.Controls.Count <= 0)
                {
                    fpnlManualPromotionList.Controls.Add(new ErrorLabel(InterfaceRm.GetString("MsgNotFound", Culture)));
                }
            }
        }

        private void DrawManualPromotionItem(PromotionModel promotion)
        {
            PromotionTypeModel promotionType = FindPromotionTypeById(promotion.PromotionTypeId);
            if (promotionType != null && CheckConditionToManualApply(promotion))
            {
                PromotionItem btnPromotion = new PromotionItem(promotion, promotionType)
                {
                    MaximumSize = new Size(fpnlManualPromotionList.Size.Width, 0),
                };
                btnPromotion.MouseDown += AllBtn_MouseDown;
                btnPromotion.Click += BtnPromotion_Click;
                fpnlManualPromotionList.Controls.Add(btnPromotion);
            }
        }

        private bool CheckConditionToManualApply(PromotionModel promotion)
        {
            bool conclude = true;

            if (!string.IsNullOrEmpty(promotion.CodeList))
            {
                conclude = false;
            }
            else if (DateTime.Compare(promotion.StartTime, CurrentBill.CreatedDate) > 0 || DateTime.Compare(promotion.EndTime, CurrentBill.CreatedDate) < 0)
            {
                conclude = false;
            }
            else if (BillTotal < promotion.MinValue)
            {
                conclude = false;
            }
            else if (IsApplyOnce(promotion))
            {
                conclude = false;
            }

            return conclude;
        }

        private void BtnPromotion_Click(object sender, EventArgs e)
        {
            ApplyManualPromotion(sender);
        }

        private void ApplyManualPromotion(object sender)
        {
            PromotionItem btn = sender as PromotionItem;
            PromotionModel promotion = btn.Tag as PromotionModel;
            Tuple<bool, string> result = AddDiscountDetail(promotion);
            if (!result.Item1)
            {
                FormMessageBox.Show(result.Item2, ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
            }
            else
            {
                LoadPromotion();
                LoadManualPromotionList();
                FormMessageBox.Show(result.Item2, string.Empty, CustomMessageBoxIcon.Success, CustomMessageBoxButton.None, AlertTimer, new Tuple<Point, Size>(Location, Size));
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
        private void FormCheckout_SizeChanged(object sender, EventArgs e)
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
            StopDevice();
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
                pnlInfo.Width = Width - pnlRight.Width - x;
                if (pnlInfo.Width <= 0)
                {
                    pnlInfo.Hide();
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
                pnlBill.Width = PointToClient(Cursor.Position).X - pnlLeft.Width;
            }
        }

        private void PnlResizeTop_MouseMove(object sender, MouseEventArgs e)
        {
            ResizeVoucherCouponPanel();
        }

        private void ResizeVoucherCouponPanel()
        {
            int y = pnlHandler.PointToClient(Cursor.Position).Y;
            float halfHeight = pnlHandler.Height / 2;
            float quarterHeight = halfHeight / 2;
            if (OnResizeMode && y < Math.Floor(halfHeight) && y > Math.Floor(quarterHeight))
            {
                grbCouponVoucher.Height = y;
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
            AutoColumnWidthBillDetail();
        }

        private void AutoColumnWidthBillDetail()
        {
            lsvBillDetail.Columns[1].Width = 50;
            lsvBillDetail.Columns[2].Width = 100;
            lsvBillDetail.Columns[3].Width = 100;
            lsvBillDetail.Columns[4].Width = 100;
            lsvBillDetail.Columns[0].Width = lsvBillDetail.Width - (100 + 100 + 100 + 50);
        }

        private void LsvDiscountDetail_SizeChanged(object sender, EventArgs e)
        {
            AutoColumnWidthDiscountDetail();
        }

        private void AutoColumnWidthDiscountDetail()
        {
            lsvDiscountDetail.Columns[1].Width = 100;
            lsvDiscountDetail.Columns[2].Width = 100;
            lsvDiscountDetail.Columns[3].Width = 100;
            lsvDiscountDetail.Columns[4].Width = 100;
            lsvDiscountDetail.Columns[0].Width = lsvBillDetail.Width - (100 + 100 + +100 + 100);
        }
        #endregion

        #region Effects - Change view mode for ListView
        private void LsvDiscountDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Alt | Keys.NumPad0:
                    lsvDiscountDetail.View = View.LargeIcon;
                    break;
                case Keys.Alt | Keys.NumPad1:
                    lsvDiscountDetail.View = View.Details;
                    break;
                case Keys.Alt | Keys.NumPad2:
                    lsvDiscountDetail.View = View.SmallIcon;
                    break;
                case Keys.Alt | Keys.NumPad3:
                    lsvDiscountDetail.View = View.List;
                    break;
                case Keys.Alt | Keys.NumPad4:
                    lsvDiscountDetail.View = View.Tile;
                    break;
                case Keys.Delete:
                    DeleteDiscountDetailItem();
                    break;
                default: break;
            }
        }

        private void DeleteDiscountDetailItem()
        {
            if (lsvDiscountDetail.SelectedItems.Count > 0)
            {
                try
                {
                    PromotionModel promotion = lsvDiscountDetail.SelectedItems[0].Tag as PromotionModel;
                    if (promotion.IsAutoApply.CompareTo(PromotionAutoApply.Auto) != 0)
                    {
                        var deleter = _discountDetailService.Delete(CurrentBill.BillId, promotion.PromotionId, CultureName);
                        if (!deleter.Item1)
                        {
                            return;
                        }
                        else
                        {
                            LoadPromotion();
                            LoadManualPromotionList();
                            string msg = InterfaceRm.GetString("MsgSuccessDelete", Culture);
                            FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Success, AlertTimer, new Tuple<Point, Size>(Location, Size));
                        }
                    }
                    else
                    {
                        string msg = InterfaceRm.GetString("MsgAutoApplyError", Culture);
                        FormMessageBox.Show(msg, ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void LsvBillDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Alt | Keys.NumPad0:
                    lsvBillDetail.View = View.LargeIcon;
                    break;
                case Keys.Alt | Keys.NumPad1:
                    lsvBillDetail.View = View.Details;
                    break;
                case Keys.Alt | Keys.NumPad2:
                    lsvBillDetail.View = View.SmallIcon;
                    break;
                case Keys.Alt | Keys.NumPad3:
                    lsvBillDetail.View = View.List;
                    break;
                case Keys.Alt | Keys.NumPad4:
                    lsvBillDetail.View = View.Tile;
                    break;
                default: break;
            }
        }
        #endregion

        #region Effects - Open calculator of window by CMD
        private void IpicWindowCalculator_Click(object sender, EventArgs e)
        {
            OpenWindowCalculator();
        }

        /// <summary>
        /// <para> * How to use CMD in C#</para>
        /// <para> - Library declaration: using System.Diagnostics;</para>
        /// <para> - Process Initialization: Process process = new Process();</para>
        /// <para> - Parameter setting (Ex):</para>
        /// <para> + Set fileName (May be path) of command-line windows program: process.StartInfo.FileName = "cmd.exe";</para>
        /// <para> + Set parammeters for excute: process.StartInfo.Arguments = "{param} {content}";</para>
        /// <para> ++ {param}: /c (Run command and close program)</para>
        /// <para> ++ {param}: /k (Run command and keep program)</para>
        /// <para> ++ {content}: a direct command</para>
        /// <para> ++ {content}: a set of commands - CMD/BAT file path (files containing scripts)</para>
        /// <para> + Allow to use the operating system shell to start the process: process.StartInfo.UseShellExecute = false;</para>
        /// <para> + Allow to start the process in a new window: process.StartInfo.CreateNoWindow = true;</para>
        /// <para> + Allow the textual output is written to the StandardOutput stream: process.StartInfo.RedirectStandardOutput = true;</para>
        /// <para> + Sets the window state to use when the process is started: process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;</para>
        /// <para> - Run the process: process.Start();</para>
        /// <para> - Gets a stream used to read the textual output: Stream data = process.StandardOutput.BaseStream;</para>
        /// </summary>
        private void OpenWindowCalculator()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c start calc";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Tax
        private void TxbTotal_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterTax();
        }

        private void CkbTaxStatus_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAfterTax();
        }

        private void NudTax_ValueChanged(object sender, EventArgs e)
        {
            CalculateAfterTax();
        }

        private void CalculateAfterTax()
        {
            float afterTax = BillTotal;
            if (ckbTaxStatus.Checked)
            {
                afterTax += BillTotal * (float)nudTax.Value / 100;
            }
            AfterTax = afterTax;
            txbAfterTax.Text = afterTax.ToString("n0", LocalFormat);
        }
        #endregion

        #region Voucher / Coupon
        private void IbtnScan_Click(object sender, EventArgs e)
        {
            SettingCamera();
            pnlScan.Show();
            RunVideoCaptureDevice();
        }

        private void SettingCamera()
        {
            cbCameraDevice.Items.Clear();
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in FilterInfoCollection)
            {
                cbCameraDevice.Items.Add(device.Name);
            }
            cbCameraDevice.SelectedIndex = 0;
        }

        private void CbCameraDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunVideoCaptureDevice();
        }

        private void RunVideoCaptureDevice()
        {
            VideoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[cbCameraDevice.SelectedIndex].MonikerString);
            VideoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            VideoCaptureDevice.Start();
            timerCameraFrame.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            picFrame.Image = bitmap;
        }

        private void TimerCameraFrame_Tick(object sender, EventArgs e)
        {
            ScanBarcode();
        }

        private void ScanBarcode()
        {
            if (picFrame.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)picFrame.Image);
                if (result != null)
                {
                    txbCode.Text = result.ToString();
                    PlayScanDetectedSound();
                    timerCameraFrame.Stop();
                    StopDevice();
                    pnlScan.Hide();
                }
            }
        }

        private void PlayScanDetectedSound()
        {
            SoundPlayer sound = new SoundPlayer();
            ScanStream.Position = 0;
            sound.Stream = null;
            sound.Stream = ScanStream;
            sound.Play();
        }

        private void StopDevice()
        {
            if (VideoCaptureDevice != null && VideoCaptureDevice.IsRunning)
            {
                VideoCaptureDevice.Stop();
            }
        }

        private void IbtnCheck_Click(object sender, EventArgs e)
        {
            CheckValidCode();
        }

        private void CheckValidCode()
        {
            if (IsBlankCodeInput())
            {
                return;
            };
            PromotionModel promotion = FindPromotionContainsCode(txbCode.Text);
            if (promotion != null)
            {
                PromotionTypeModel promotionType = FindPromotionTypeById(promotion.PromotionTypeId);
                if (promotionType != null)
                {
                    string msg = "- " + InterfaceRm.GetString("MsgCode1", Culture) + " " + promotionType.Name + Environment.NewLine
                        + "- " + InterfaceRm.GetString("MsgCode2", Culture) + " " + promotion.Description + Environment.NewLine
                        + "- " + InterfaceRm.GetString("MsgCode3", Culture) + " " + promotion.Value + (promotion.IsPercent.CompareTo(PromotionPercent.Percent) == 0 ? "%" : string.Empty) + Environment.NewLine
                        + "- " + InterfaceRm.GetString("MsgCode4", Culture) + " " + promotion.StartTime.ToString("d", DateTimeFormat) + " - " + promotion.EndTime.ToString("d", DateTimeFormat) + Environment.NewLine
                        + "- " + InterfaceRm.GetString("MsgCode5", Culture) + " " + promotion.MinValue + Environment.NewLine
                        + "- " + InterfaceRm.GetString("MsgCode6", Culture) + " " + (promotion.IsActived.CompareTo(PromotionActived.Activated) == 0 ? InterfaceRm.GetString("MsgCode7", Culture) : InterfaceRm.GetString("MsgCode8", Culture)) + Environment.NewLine + Environment.NewLine;

                    Tuple<bool, string> result = CheckConditionToApply(promotion);
                    if (result.Item1)
                    {
                        msg += InterfaceRm.GetString("MsgCode9", Culture).ToUpper();
                        DialogResult pick = FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Success, CustomMessageBoxButton.OKCancel);
                        if (pick == DialogResult.OK)
                        {
                            ApplyPromotionForBill(promotion);
                            txbCode.Clear();
                        }
                    }
                    else
                    {
                        msg += InterfaceRm.GetString("MsgCode10", Culture).ToUpper() + Environment.NewLine
                            + InterfaceRm.GetString("MsgCode11", Culture) + " " + result.Item2;
                        FormMessageBox.Show(msg, ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                    }
                }
            }
        }

        private bool IsBlankCodeInput()
        {
            if (string.IsNullOrEmpty(txbCode.Text))
            {
                string msg = InterfaceRm.GetString("MsgCodeNotBlank", Culture);
                FormMessageBox.Show(msg, ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
                return true;
            }
            return false;
        }

        private PromotionModel FindPromotionContainsCode(string code)
        {
            PromotionFilter promotionFilter = new PromotionFilter()
            {
                Code = code
            };
            var promotionReader = _promotionService.Read(promotionFilter, CultureName);
            if (!promotionReader.Item1)
            {
                string msg = InterfaceRm.GetString("MsgCodeNotExist", Culture);
                FormMessageBox.Show(msg, ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
            }
            else
            {
                return (promotionReader.Item2 as Paginator<PromotionModel>).Item[0];
            }
            return null;
        }

        private PromotionTypeModel FindPromotionTypeById(Guid promotionTypeId)
        {
            PromotionTypeFilter promotionTypeFilter = new PromotionTypeFilter()
            {
                PromotionTypeId = promotionTypeId
            };
            var promotionTypeReader = _promotionTypeService.Read(promotionTypeFilter, CultureName);
            if (promotionTypeReader.Item1)
            {
                return (promotionTypeReader.Item2 as Paginator<PromotionTypeModel>).Item[0];
            }
            return null;
        }

        private Tuple<bool, string> CheckConditionToApply(PromotionModel promotion)
        {
            bool conclude = true;
            string reason = string.Empty;

            if (promotion.IsActived.CompareTo(PromotionActived.Activated) != 0)
            {
                conclude = false;
                reason = InterfaceRm.GetString("MsgCode12", Culture);
            }
            else if (DateTime.Compare(promotion.StartTime, CurrentBill.CreatedDate) > 0 || DateTime.Compare(promotion.EndTime, CurrentBill.CreatedDate) < 0)
            {
                conclude = false;
                reason = InterfaceRm.GetString("MsgCode13", Culture);
            }
            else if (BillTotal < promotion.MinValue)
            {
                conclude = false;
                reason = InterfaceRm.GetString("MsgCode14", Culture);
            }
            else if (IsApplyOnce(promotion))
            {
                conclude = false;
                reason = InterfaceRm.GetString("MsgCode15", Culture);
            }
            else if (IsUsedCode(txbCode.Text))
            {
                conclude = false;
                reason = InterfaceRm.GetString("MsgCode16", Culture);
            }

            return new Tuple<bool, string>(conclude, reason);
        }

        private bool IsUsedCode(string text)
        {
            bool isUsedCode = false;
            DiscountDetailFilter discountDetailFilter = new DiscountDetailFilter()
            {
                Code = text
            };
            var discountDetailReader = _discountDetailService.Read(discountDetailFilter, CultureName);
            if (discountDetailReader.Item1)
            {
                isUsedCode = (discountDetailReader.Item2 as Paginator<DiscountDetailModel>).Item.Count() > 0;
            }
            return isUsedCode;
        }

        private bool IsApplyOnce(PromotionModel promotion)
        {
            bool isAppliedOnce = false;
            DiscountDetailFilter discountDetailFilter = new DiscountDetailFilter()
            {
                BillId = CurrentBill.BillId,
                PromotionId = promotion.PromotionId
            };
            var discountDetailReader = _discountDetailService.Read(discountDetailFilter, CultureName);
            if (discountDetailReader.Item1)
            {
                isAppliedOnce = (discountDetailReader.Item2 as Paginator<DiscountDetailModel>).Item.Count() > 0;
            }
            return isAppliedOnce;
        }

        private void ApplyPromotionForBill(PromotionModel promotion)
        {
            Tuple<bool, string> result = AddDiscountDetail(promotion);
            if (!result.Item1)
            {
                FormMessageBox.Show(result.Item2, ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
            }
            else
            {
                LoadPromotion();
                FormMessageBox.Show(result.Item2, string.Empty, CustomMessageBoxIcon.Success, CustomMessageBoxButton.None, AlertTimer, new Tuple<Point, Size>(Location, Size));
            }
        }

        private Tuple<bool, string> AddDiscountDetail(PromotionModel promotion)
        {
            if (promotion != null)
            {
                DiscountDetailModel discountDetail = new DiscountDetailModel(CurrentBill.BillId, promotion.PromotionId);
                if (!string.IsNullOrEmpty(promotion.CodeList))
                {
                    discountDetail.Code = txbCode.Text;
                }
                var creator = _discountDetailService.Create(discountDetail, CultureName);
                string msg = !creator.Item1 ? creator.Item2.ToString() : InterfaceRm.GetString("MsgSuccessApply", Culture);
                return new Tuple<bool, string>(creator.Item1, msg);
            }
            return new Tuple<bool, string>(false, InterfaceRm.GetString("MsgFailApply", Culture));
        }
        #endregion

        #region Promotion Detail
        private void TxbAfterTax_TextChanged(object sender, EventArgs e)
        {
            LoadPromotion();
        }

        private void LoadPromotion()
        {
            lsvDiscountDetail.Items.Clear();

            float downValueTotal = 0;

            DiscountDetailFilter filter = new DiscountDetailFilter()
            {
                BillId = CurrentBill.BillId
            };
            var reader = _discountDetailService.Read(filter, CultureName);
            if (reader.Item1)
            {
                CurrentDiscountDetails = (reader.Item2 as Paginator<DiscountDetailModel>).Item;
                foreach (DiscountDetailModel discountDetail in CurrentDiscountDetails)
                {
                    Tuple<bool, float> result = LoadDiscountDetails(discountDetail);
                    if (result.Item1)
                    {
                        downValueTotal += AfterTax * result.Item2 / 100;
                    }
                    else
                    {
                        downValueTotal += result.Item2;
                    }
                }
            }

            if (AfterTax <= downValueTotal)
            {
                AfterPromotion = 0;
            }
            else
            {
                AfterPromotion = AfterTax - downValueTotal;
            }
            txbAfterPromotions.Text = AfterPromotion.ToString("n0", LocalFormat);
        }

        private Tuple<bool, float> LoadDiscountDetails(DiscountDetailModel discountDetail)
        {
            PromotionFilter promotionFilter = new PromotionFilter()
            {
                PromotionId = discountDetail.PromotionId
            };
            var promotionReader = _promotionService.Read(promotionFilter, CultureName);
            if (promotionReader.Item1)
            {
                PromotionModel promotion = (promotionReader.Item2 as Paginator<PromotionModel>).Item[0];
                PromotionTypeModel promotionType = FindPromotionTypeById(promotion.PromotionTypeId);
                if (promotionType != null)
                {
                    bool isPercent = promotion.IsPercent.CompareTo(PromotionPercent.Percent) == 0;
                    ListViewItem listViewItem = new ListViewItem(promotionType.Name);
                    listViewItem.SubItems.Add(promotion.Value.ToString("n0", LocalFormat) + (isPercent ? "%" : string.Empty));
                    listViewItem.SubItems.Add(promotion.MinValue.ToString("n0", LocalFormat));
                    listViewItem.SubItems.Add(discountDetail.AppliedTime.ToString("d", DateTimeFormat));
                    listViewItem.SubItems.Add(discountDetail.Code);
                    listViewItem.Tag = promotion;
                    listViewItem.ToolTipText = promotion.Description + Environment.NewLine
                        + "- " + InterfaceRm.GetString("ColumnHeaderValue", Culture) + ": " + promotion.Value.ToString("n0", LocalFormat) + (isPercent ? "%" : string.Empty) + Environment.NewLine
                        + "- " + InterfaceRm.GetString("ColumnHeaderMinValue", Culture) + ": " + promotion.MinValue.ToString("n0", LocalFormat) + Environment.NewLine
                        + "- " + InterfaceRm.GetString("ColumnHeaderAppliedTime", Culture) + ": " + discountDetail.AppliedTime.ToString("d", DateTimeFormat) + Environment.NewLine
                        + "- " + InterfaceRm.GetString("ColumnHeaderCode", Culture) + ": " + discountDetail.Code + Environment.NewLine;
                    if (string.IsNullOrEmpty(promotion.CodeList))
                    {
                        listViewItem.ImageIndex = (int)PromotionTypes.Discount;
                    }
                    else
                    {
                        listViewItem.ImageIndex = (int)PromotionTypes.Voucher;
                    }
                    lsvDiscountDetail.Items.Add(listViewItem);

                    if (listViewItem.Index % 2 == 0)
                    {
                        listViewItem.ForeColor = Properties.Settings.Default.BaseHoverColor;
                    }
                    else
                    {
                        listViewItem.ForeColor = Properties.Settings.Default.BaseTextColor;
                    }

                    return new Tuple<bool, float>(isPercent, promotion.Value);
                }
            }
            return new Tuple<bool, float>(false, 0);
        }
        #endregion

        #region Rounding number
        private void TxbAfterPromotions_TextChanged(object sender, EventArgs e)
        {
            CalculateLastTotal();
        }

        private void CalculateLastTotal()
        {
            float lastTotal = AfterPromotion;
            if (ckbAutoRounding.Checked)
            {
                lastTotal = RoundingNumber(AfterPromotion);
            }
            LastTotal = lastTotal;
            txbLastTotal.Text = lastTotal.ToString("n0", LocalFormat);
        }

        private float RoundingNumber(float number)
        {
            int roundingTo = Properties.Settings.Default.RoundingTo;
            number = (int)number;
            if (ckbAutoRounding.Checked)
            {
                for (int i = 10; i <= roundingTo; i *= 10)
                {
                    int tail = (int)number % i;
                    if (tail >= 5 * i / 10)
                    {
                        number += i - tail;
                    }
                    else
                    {

                        number -= tail;
                    }
                }
            }
            return number;
        }

        private void CkbAutoRounding_CheckedChanged(object sender, EventArgs e)
        {
            CalculateLastTotal();
        }
        #endregion

        #region Give Change
        private void TxbLastTotal_TextChanged(object sender, EventArgs e)
        {
            nudCustomerMoney.Value = (decimal)LastTotal;
        }

        private void NudCustomerMoney_ValueChanged(object sender, EventArgs e)
        {
            float change = (float)nudCustomerMoney.Value - LastTotal;
            txbChange.Text = change.ToString("n0", LocalFormat);
        }
        #endregion

        #region Print Invoice
        private void IbtnPrintProvisionalInvoice_Click(object sender, EventArgs e)
        {
            PrintInvoice();
        }

        private void PrintInvoice()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(InvoiceTemplate_PrintPage);
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        /// <summary>
        /// Thermal receipt paper has two common paper sizes (paper roll height):
        ///  - 57mm (k57) ~ 215 pixel
        ///  - 80mm (k80) ~ 302 pixel
        /// to fit two popular thermal printers on the market, k80 and k58 bill printers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceTemplate_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font1 = new Font("Courier New", 6, FontStyle.Regular);
            Font font2 = new Font("Courier New", 12, FontStyle.Bold);
            Font font3 = new Font("Courier New", 6, FontStyle.Bold);
            StringFormat stringFormatRightAlign = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat stringFormatLeftAlign = new StringFormat() { Alignment = StringAlignment.Near };
            StringFormat stringFormatCenterAlign = new StringFormat() { Alignment = StringAlignment.Center };

            int margin, x, y, offset, lineSpace, pageWidth;
            x = y = margin = offset = lineSpace = 5;
            pageWidth = 215 - 2 * margin;
            int logoSize = 30;
            float columnWidth1 = 100;
            float columnWidth2 = 30;
            float columnWidth3 = pageWidth - columnWidth1 - columnWidth2;

            #region Logo
            graphics.DrawImage(Properties.Resources.zi_logo, (pageWidth - logoSize) / 2, y, logoSize, logoSize);
            offset += logoSize + lineSpace;
            #endregion
            #region Brand Name
            string brandName = Properties.Settings.Default.BrandName.ToUpper();
            float cellHeight = DrawPageStringItem(graphics, brush, font2, brandName, x, y + offset, pageWidth, stringFormatCenterAlign);
            offset += (int)cellHeight + lineSpace;
            #endregion

            #region Cashier's Name
            string cashierName = InterfaceRm.GetString("Cashier", Culture) + ": " + CurrentUser.FullName;
            cellHeight = DrawPageStringItem(graphics, brush, font1, cashierName, x, y + offset, pageWidth, stringFormatCenterAlign);
            offset += (int)cellHeight + lineSpace;
            #endregion

            #region Time To Export
            string time = InterfaceRm.GetString("Time", Culture) + ": " + DateTime.Now.ToString();
            cellHeight = DrawPageStringItem(graphics, brush, font1, time, x, y + offset, pageWidth, stringFormatCenterAlign);
            offset += (int)cellHeight + lineSpace;
            #endregion

            #region Name Of Bill Detail Header Columns
            string headerColumnProduct = InterfaceRm.GetString("Product", Culture);
            string headerColumnQuantity = InterfaceRm.GetString("Quantity", Culture);
            string headerColumnIntoMoney = InterfaceRm.GetString("IntoMoney", Culture);
            float cellHeight1 = DrawPageStringItem(graphics, brush, font1, headerColumnProduct, x, y + offset, columnWidth1, stringFormatLeftAlign);
            float cellHeight2 = DrawPageStringItem(graphics, brush, font1, headerColumnQuantity, x + columnWidth1, y + offset, columnWidth2, stringFormatCenterAlign);
            float cellHeight3 = DrawPageStringItem(graphics, brush, font1, headerColumnIntoMoney, x + columnWidth1 + columnWidth2, y + offset, columnWidth3, stringFormatRightAlign);
            offset += (int)Math.Max(Math.Max(cellHeight1, cellHeight2), cellHeight3) + lineSpace;
            #endregion

            #region Divide Line
            graphics.DrawLine(new Pen(brush), x, y + offset, x + pageWidth, y + offset);
            offset += lineSpace;
            #endregion

            #region Bill Detail Rows
            foreach (ListViewItem item in lsvBillDetail.Items)
            {
                string product = item.Text + Environment.NewLine + item.SubItems[2].Text;
                if (!item.SubItems[3].Text.Equals("0"))
                {
                    product += Environment.NewLine + "(-" + item.SubItems[3].Text + "%)";
                }
                string quantity = item.SubItems[1].Text;
                string intoMoney = item.SubItems[4].Text;

                cellHeight1 = DrawPageStringItem(graphics, brush, font1, product, x, y + offset, columnWidth1, stringFormatLeftAlign);
                cellHeight2 = DrawPageStringItem(graphics, brush, font1, quantity, x + columnWidth1, y + offset, columnWidth2, stringFormatCenterAlign);
                cellHeight3 = DrawPageStringItem(graphics, brush, font1, intoMoney, x + columnWidth1 + columnWidth2, y + offset, columnWidth3, stringFormatRightAlign);

                offset += (int)Math.Max(Math.Max(cellHeight1, cellHeight2), cellHeight3) + lineSpace;
            }
            #endregion

            #region Divide Line
            graphics.DrawLine(new Pen(brush), x, y + offset, x + pageWidth, y + offset);
            offset += lineSpace;
            #endregion

            #region Bill Total
            string total = InterfaceRm.GetString("Total", Culture) + ":";
            string totalValue = txbTotal.Text;

            cellHeight1 = DrawPageStringItem(graphics, brush, font1, total, x, y + offset, columnWidth1 + columnWidth2, stringFormatLeftAlign);
            cellHeight2 = DrawPageStringItem(graphics, brush, font1, totalValue, x + columnWidth1 + columnWidth2, y + offset, columnWidth3, stringFormatRightAlign);

            offset += (int)Math.Max(cellHeight1, cellHeight2) + lineSpace;
            #endregion

            #region Tax
            if (ckbTaxStatus.Checked)
            {
                string tax = InterfaceRm.GetString("Tax", Culture) + " (" + nudTax.Value + "%):";
                string afterTaxValue = txbAfterTax.Text;

                cellHeight1 = DrawPageStringItem(graphics, brush, font1, tax, x, y + offset, columnWidth1 + columnWidth2, stringFormatLeftAlign);
                cellHeight2 = DrawPageStringItem(graphics, brush, font1, afterTaxValue, x + columnWidth1 + columnWidth2, y + offset, columnWidth3, stringFormatRightAlign);

                offset += (int)Math.Max(cellHeight1, cellHeight2) + lineSpace;
            }
            #endregion

            #region Promotions
            if (lsvDiscountDetail.Items.Count > 0)
            {
                string promotion = InterfaceRm.GetString("Promotion", Culture) + ":";
                string afterPromotionValue = txbAfterPromotions.Text;

                cellHeight1 = DrawPageStringItem(graphics, brush, font1, promotion, x, y + offset, columnWidth1 + columnWidth2, stringFormatLeftAlign);
                cellHeight2 = DrawPageStringItem(graphics, brush, font1, afterPromotionValue, x + columnWidth1 + columnWidth2, y + offset, columnWidth3, stringFormatRightAlign);

                offset += (int)Math.Max(cellHeight1, cellHeight2) + lineSpace;
            }
            #endregion

            #region Last Total
            string lastTotal = InterfaceRm.GetString("LastTotal", Culture)
                + (ckbAutoRounding.Checked ? "(" + InterfaceRm.GetString("Rounded", Culture) + ")" : string.Empty) + ":";
            string lastTotalValue = txbLastTotal.Text;

            cellHeight1 = DrawPageStringItem(graphics, brush, font3, lastTotal, x, y + offset, columnWidth1 + columnWidth2, stringFormatLeftAlign);
            cellHeight2 = DrawPageStringItem(graphics, brush, font3, lastTotalValue, x + columnWidth1 + columnWidth2, y + offset, columnWidth3, stringFormatRightAlign);

            offset += (int)Math.Max(cellHeight1, cellHeight2) + lineSpace;
            #endregion

            #region Give Change
            string customerMoney = InterfaceRm.GetString("CustomerMoney", Culture) + ":";
            string customerMoneyValue = nudCustomerMoney.Value.ToString("n0", LocalFormat);

            cellHeight1 = DrawPageStringItem(graphics, brush, font1, customerMoney, x, y + offset, columnWidth1 + columnWidth2, stringFormatLeftAlign);
            cellHeight2 = DrawPageStringItem(graphics, brush, font1, customerMoneyValue, x + columnWidth1 + columnWidth2, y + offset, columnWidth3, stringFormatRightAlign);

            offset += (int)Math.Max(cellHeight1, cellHeight2) + lineSpace;

            string change = InterfaceRm.GetString("Change", Culture) + ":";
            string changeValue = txbChange.Text;

            cellHeight1 = DrawPageStringItem(graphics, brush, font1, change, x, y + offset, columnWidth1 + columnWidth2, stringFormatLeftAlign);
            cellHeight2 = DrawPageStringItem(graphics, brush, font1, changeValue, x + columnWidth1 + columnWidth2, y + offset, columnWidth3, stringFormatRightAlign);

            offset += (int)Math.Max(cellHeight1, cellHeight2) + lineSpace;
            #endregion

            #region Shop Info
            string address = Properties.Settings.Default.ShopAddress;
            string phone = Properties.Settings.Default.ShopPhone;
            string email = Properties.Settings.Default.ShopEmail;
            string site = Properties.Settings.Default.ShopSite;

            cellHeight = DrawPageStringItem(graphics, brush, font1, address, x, y + offset, pageWidth, stringFormatCenterAlign);
            offset += (int)cellHeight + lineSpace;

            cellHeight = DrawPageStringItem(graphics, brush, font1, phone, x, y + offset, pageWidth, stringFormatCenterAlign);
            offset += (int)cellHeight + lineSpace;

            cellHeight = DrawPageStringItem(graphics, brush, font1, email, x, y + offset, pageWidth, stringFormatCenterAlign);
            offset += (int)cellHeight + lineSpace;

            cellHeight = DrawPageStringItem(graphics, brush, font1, site, x, y + offset, pageWidth, stringFormatCenterAlign);
            offset += (int)cellHeight + lineSpace;
            #endregion

            #region Bye
            string bye = InterfaceRm.GetString("Bye", Culture);
            DrawPageStringItem(graphics, brush, font1, bye, x, y + offset, pageWidth, stringFormatCenterAlign);

            font1.Dispose();
            font2.Dispose();
            font3.Dispose();
            brush.Dispose();
            graphics.Dispose();
            #endregion
        }

        private float DrawPageStringItem(Graphics graphics, Brush brush, Font font, string text, float x, float y, float w, StringFormat stringFormat)
        {
            float testHeight = 500;
            SizeF stringSize = GetStringSize(text, font, graphics, new SizeF(w, testHeight));
            RectangleF cell = new RectangleF(new PointF(x, y), new SizeF(w, stringSize.Height));
            graphics.DrawString(text, font, brush, cell, stringFormat);
            return cell.Height;
        }

        private SizeF GetStringSize(string text, Font font, Graphics graphics, SizeF layoutSize)
        {
            if (layoutSize != SizeF.Empty)
            {
                return graphics.MeasureString(text, font, layoutSize);
            }
            return graphics.MeasureString(text, font);
        }
        #endregion

        #region Checkout
        private void IbtnCheckout_Click(object sender, EventArgs e)
        {
            Checkout();
        }

        private void Checkout()
        {
            string msg = InterfaceRm.GetString("MsgCheckoutConfirm", Culture);
            DialogResult result = FormMessageBox.Show(msg, string.Empty, CustomMessageBoxIcon.Question, CustomMessageBoxButton.YesNo);
            if (result == DialogResult.Yes)
            {
                UpdateBill();
                UpdateTable();
                PrintInvoice();
                CloseForm();
                IsPaid = true;
            }
        }

        private void UpdateBill()
        {
            if (ckbTaxStatus.Checked)
            {
                CurrentBill.Vat = (float)nudTax.Value;
            }
            CurrentBill.AfterVat = AfterTax;
            CurrentBill.RealPay = LastTotal;
            CurrentBill.Status = BillStatus.Paid;
            var updater = _billService.Update(CurrentBill, CultureName);
            if (!updater.Item1)
            {
                FormMessageBox.Show(updater.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
            }
        }

        private void UpdateTable()
        {
            CurrentTable.Status = TableStatus.Ready;
            var updater = _tableService.Update(CurrentTable, CultureName);
            if (!updater.Item1)
            {
                FormMessageBox.Show(updater.Item2.ToString(), ErrorTitle, CustomMessageBoxIcon.Error, CustomMessageBoxButton.OK);
            }
        }
        #endregion
    }
}
