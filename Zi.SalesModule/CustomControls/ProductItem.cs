using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Convertors;
using Zi.Utilities.Enumerators;

namespace Zi.SalesModule.CustomControls
{
    public partial class ProductItem : UserControl
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

        #region Attributes
        public ProductModel Product { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public NumberFormatInfo LocalFormat { get; set; }
        #endregion

        #region EventHandler
        public event EventHandler ZiClick;
        public event EventHandler ZiMouseHover;
        public event EventHandler ZiMouseLeave;
        public event MouseEventHandler ZiMouseDown;
        public event KeyEventHandler ZiKeyDown;
        #endregion

        public ProductItem(ProductModel product)
        {
            InitializeComponent();
            Product = product;
        }

        #region Initial
        private void ProductHorizontalItem_Load(object sender, EventArgs e)
        {
            DrawRoundedCorner();
            LoadSetting();
            LoadContent();
        }

        private void DrawRoundedCorner()
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void LoadSetting()
        {
            SetCulture();
            SetCurrencyFormat();
            SetColor();
        }

        private void SetColor()
        {
            BackColor = Properties.Settings.Default.BaseItemColor;
            lbName.ForeColor = Properties.Settings.Default.BaseTextColor;
            lbOriginalPrice.ForeColor = Properties.Settings.Default.ErrorTextColor;
            lbPromotionPrice.ForeColor = Properties.Settings.Default.SuccessTextColor;
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ItemResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(ProductItem).Assembly);
        }

        private void SetCurrencyFormat()
        {
            LocalFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            LocalFormat.CurrencySymbol = InterfaceRm.GetString("CurrencySymbol", Culture);
            LocalFormat.CurrencyPositivePattern = 3;
            LocalFormat.CurrencyDecimalDigits = 0;
        }

        private void LoadContent()
        {
            lbName.Text = Product.Name;
            rpicThumnail.Image = DataTypeConvertor.Instance.GetImageFromBytes(Product.Thumnail);
            if (Product.PromotionValue > 0)
            {
                lbOriginalPrice.Show();
                lbOriginalPrice.Font = new Font(lbOriginalPrice.Font, FontStyle.Strikeout | FontStyle.Italic);
                lbOriginalPrice.Text = Product.Price.ToString("n0", LocalFormat);
                float promotionPrice = Product.Price * (100 - Product.PromotionValue) / 100;
                lbPromotionPrice.Text = "(" + Product.PromotionValue + "%) " + ((int)promotionPrice).ToString("n0", LocalFormat);
            }
            else
            {
                lbOriginalPrice.Hide();
                lbPromotionPrice.Text = Product.Price.ToString("n0", LocalFormat);
            }
            if (Product.Status.CompareTo(ProductStatus.NotAvailabled) == 0)
            {
                Enabled = false;
                BackColor = Properties.Settings.Default.BlurTextColor;
                lbName.Font = new Font(lbName.Font, FontStyle.Strikeout);
                lbName.ForeColor = Properties.Settings.Default.ErrorTextColor;
            }
            Tag = Product;
        }
        #endregion

        #region Effects - Auto resize thumnail size follow container size
        private void ProductHorizontalItem_SizeChanged(object sender, EventArgs e)
        {
            ResizeThumnail();
        }

        private void ResizeThumnail()
        {
            int h = rpicThumnail.Height;
            float w = h * 2 / 3;
            rpicThumnail.Size = new Size((int)w, h);
        }
        #endregion

        #region Custom Events
        public virtual void Zi_Click(object sender, EventArgs e)
        {
            ZiClick?.Invoke(this, e);
        }

        public virtual void Zi_MouseHover(object sender, EventArgs e)
        {
            ZiMouseHover?.Invoke(this, e);
        }

        public virtual void Zi_MouseLeave(object sender, EventArgs e)
        {
            ZiMouseLeave?.Invoke(this, e);
        }

        public virtual void Zi_MouseDown(object sender, MouseEventArgs e)
        {
            ZiMouseDown?.Invoke(this, e);
        }

        public virtual void Zi_KeyDown(object sender, KeyEventArgs e)
        {
            ZiKeyDown?.Invoke(this, e);
        }
        #endregion
    }
}
