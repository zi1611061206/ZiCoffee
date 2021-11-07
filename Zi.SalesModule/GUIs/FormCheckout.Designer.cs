
namespace Zi.SalesModule.GUIs
{
    partial class FormCheckout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckout));
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.ipicMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.ipicClose = new FontAwesome.Sharp.IconPictureBox();
            this.pnlFooterBar = new System.Windows.Forms.Panel();
            this.ibtnCheckout = new FontAwesome.Sharp.IconButton();
            this.ibtnPrintProvisionalInvoice = new FontAwesome.Sharp.IconButton();
            this.ibtnCancel = new FontAwesome.Sharp.IconButton();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.ipicWindowCalculator = new FontAwesome.Sharp.IconPictureBox();
            this.pnlBill = new System.Windows.Forms.Panel();
            this.lsvBillDetail = new System.Windows.Forms.ListView();
            this.columnHeaderProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPromotion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIntoMoney = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResizeLeft = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.grbPromotions = new System.Windows.Forms.GroupBox();
            this.lsvDiscountDetail = new System.Windows.Forms.ListView();
            this.columnHeaderPromotionType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIsPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMinValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txbAfterPromotions = new System.Windows.Forms.TextBox();
            this.grbAfterTax = new System.Windows.Forms.GroupBox();
            this.txbAfterTax = new System.Windows.Forms.TextBox();
            this.grbTax = new System.Windows.Forms.GroupBox();
            this.nudTax = new System.Windows.Forms.NumericUpDown();
            this.ckbTaxStatus = new System.Windows.Forms.CheckBox();
            this.grbTotal = new System.Windows.Forms.GroupBox();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.pnlResizeRight = new System.Windows.Forms.Panel();
            this.ttNote = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHandler = new System.Windows.Forms.Panel();
            this.pnlResizeTop = new System.Windows.Forms.Panel();
            this.grbCouponVoucher = new System.Windows.Forms.GroupBox();
            this.pnlScan = new System.Windows.Forms.Panel();
            this.picFrame = new System.Windows.Forms.PictureBox();
            this.cbCameraDevice = new System.Windows.Forms.ComboBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.ibtnCheck = new FontAwesome.Sharp.IconButton();
            this.ibtnScan = new FontAwesome.Sharp.IconButton();
            this.txbCode = new System.Windows.Forms.TextBox();
            this.timerCameraFrame = new System.Windows.Forms.Timer(this.components);
            this.pnlTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicClose)).BeginInit();
            this.pnlFooterBar.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicWindowCalculator)).BeginInit();
            this.pnlBill.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.grbPromotions.SuspendLayout();
            this.grbAfterTax.SuspendLayout();
            this.grbTax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTax)).BeginInit();
            this.grbTotal.SuspendLayout();
            this.pnlHandler.SuspendLayout();
            this.grbCouponVoucher.SuspendLayout();
            this.pnlScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFrame)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.pnlTitleBar.Controls.Add(this.lbTitle);
            this.pnlTitleBar.Controls.Add(this.ipicMaximize);
            this.pnlTitleBar.Controls.Add(this.picLogo);
            this.pnlTitleBar.Controls.Add(this.ipicClose);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlTitleBar.Size = new System.Drawing.Size(1400, 50);
            this.pnlTitleBar.TabIndex = 0;
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitleBar_MouseDown);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(70, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1210, 50);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Title";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitleBar_MouseDown);
            // 
            // ipicMaximize
            // 
            this.ipicMaximize.BackColor = System.Drawing.Color.Transparent;
            this.ipicMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.ipicMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicMaximize.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicMaximize.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicMaximize.IconSize = 50;
            this.ipicMaximize.Location = new System.Drawing.Point(1280, 0);
            this.ipicMaximize.Name = "ipicMaximize";
            this.ipicMaximize.Size = new System.Drawing.Size(50, 50);
            this.ipicMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicMaximize.TabIndex = 1;
            this.ipicMaximize.TabStop = false;
            this.ipicMaximize.Click += new System.EventHandler(this.IpicMaximize_Click);
            this.ipicMaximize.MouseLeave += new System.EventHandler(this.Ipic_MouseLeave);
            this.ipicMaximize.MouseHover += new System.EventHandler(this.Ipic_MouseHover);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = global::Zi.SalesModule.Properties.Resources.zi_logo;
            this.picLogo.Location = new System.Drawing.Point(20, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Padding = new System.Windows.Forms.Padding(5);
            this.picLogo.Size = new System.Drawing.Size(50, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitleBar_MouseDown);
            // 
            // ipicClose
            // 
            this.ipicClose.BackColor = System.Drawing.Color.Transparent;
            this.ipicClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.ipicClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicClose.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicClose.IconSize = 50;
            this.ipicClose.Location = new System.Drawing.Point(1330, 0);
            this.ipicClose.Name = "ipicClose";
            this.ipicClose.Size = new System.Drawing.Size(50, 50);
            this.ipicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicClose.TabIndex = 0;
            this.ipicClose.TabStop = false;
            this.ipicClose.Click += new System.EventHandler(this.IpicClose_Click);
            this.ipicClose.MouseLeave += new System.EventHandler(this.Ipic_MouseLeave);
            this.ipicClose.MouseHover += new System.EventHandler(this.Ipic_MouseHover);
            // 
            // pnlFooterBar
            // 
            this.pnlFooterBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooterBar.Controls.Add(this.ibtnCheckout);
            this.pnlFooterBar.Controls.Add(this.ibtnPrintProvisionalInvoice);
            this.pnlFooterBar.Controls.Add(this.ibtnCancel);
            this.pnlFooterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterBar.Location = new System.Drawing.Point(0, 750);
            this.pnlFooterBar.Name = "pnlFooterBar";
            this.pnlFooterBar.Padding = new System.Windows.Forms.Padding(20, 10, 50, 10);
            this.pnlFooterBar.Size = new System.Drawing.Size(1400, 50);
            this.pnlFooterBar.TabIndex = 0;
            // 
            // ibtnCheckout
            // 
            this.ibtnCheckout.BackColor = System.Drawing.Color.Transparent;
            this.ibtnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibtnCheckout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnCheckout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnCheckout.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnCheckout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ibtnCheckout.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtnCheckout.IconColor = System.Drawing.Color.Black;
            this.ibtnCheckout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnCheckout.Location = new System.Drawing.Point(400, 10);
            this.ibtnCheckout.Name = "ibtnCheckout";
            this.ibtnCheckout.Size = new System.Drawing.Size(570, 30);
            this.ibtnCheckout.TabIndex = 2;
            this.ibtnCheckout.Text = "Checkout";
            this.ibtnCheckout.UseVisualStyleBackColor = false;
            this.ibtnCheckout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnCheckout.MouseLeave += new System.EventHandler(this.Ibtn_MouseLeave);
            this.ibtnCheckout.MouseHover += new System.EventHandler(this.Ibtn_MouseHover);
            // 
            // ibtnPrintProvisionalInvoice
            // 
            this.ibtnPrintProvisionalInvoice.BackColor = System.Drawing.Color.Transparent;
            this.ibtnPrintProvisionalInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnPrintProvisionalInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibtnPrintProvisionalInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnPrintProvisionalInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnPrintProvisionalInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnPrintProvisionalInvoice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnPrintProvisionalInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ibtnPrintProvisionalInvoice.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtnPrintProvisionalInvoice.IconColor = System.Drawing.Color.Black;
            this.ibtnPrintProvisionalInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnPrintProvisionalInvoice.Location = new System.Drawing.Point(20, 10);
            this.ibtnPrintProvisionalInvoice.Name = "ibtnPrintProvisionalInvoice";
            this.ibtnPrintProvisionalInvoice.Size = new System.Drawing.Size(380, 30);
            this.ibtnPrintProvisionalInvoice.TabIndex = 1;
            this.ibtnPrintProvisionalInvoice.Text = "Print Provisional";
            this.ibtnPrintProvisionalInvoice.UseVisualStyleBackColor = false;
            this.ibtnPrintProvisionalInvoice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnPrintProvisionalInvoice.MouseLeave += new System.EventHandler(this.Ibtn_MouseLeave);
            this.ibtnPrintProvisionalInvoice.MouseHover += new System.EventHandler(this.Ibtn_MouseHover);
            // 
            // ibtnCancel
            // 
            this.ibtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.ibtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ibtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ibtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtnCancel.IconColor = System.Drawing.Color.Black;
            this.ibtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnCancel.Location = new System.Drawing.Point(970, 10);
            this.ibtnCancel.Name = "ibtnCancel";
            this.ibtnCancel.Size = new System.Drawing.Size(380, 30);
            this.ibtnCancel.TabIndex = 3;
            this.ibtnCancel.Text = "Cancel";
            this.ibtnCancel.UseVisualStyleBackColor = false;
            this.ibtnCancel.Click += new System.EventHandler(this.IbtnCancel_Click);
            this.ibtnCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnCancel.MouseLeave += new System.EventHandler(this.Ibtn_MouseLeave);
            this.ibtnCancel.MouseHover += new System.EventHandler(this.Ibtn_MouseHover);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(20, 700);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.ipicWindowCalculator);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1350, 50);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(50, 700);
            this.pnlRight.TabIndex = 0;
            // 
            // ipicWindowCalculator
            // 
            this.ipicWindowCalculator.BackColor = System.Drawing.Color.Transparent;
            this.ipicWindowCalculator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicWindowCalculator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipicWindowCalculator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicWindowCalculator.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicWindowCalculator.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicWindowCalculator.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicWindowCalculator.IconSize = 50;
            this.ipicWindowCalculator.Location = new System.Drawing.Point(0, 650);
            this.ipicWindowCalculator.Name = "ipicWindowCalculator";
            this.ipicWindowCalculator.Size = new System.Drawing.Size(50, 50);
            this.ipicWindowCalculator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicWindowCalculator.TabIndex = 2;
            this.ipicWindowCalculator.TabStop = false;
            this.ipicWindowCalculator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ipicWindowCalculator.MouseLeave += new System.EventHandler(this.Ipic_MouseLeave);
            this.ipicWindowCalculator.MouseHover += new System.EventHandler(this.Ipic_MouseHover);
            // 
            // pnlBill
            // 
            this.pnlBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.pnlBill.Controls.Add(this.lsvBillDetail);
            this.pnlBill.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBill.Location = new System.Drawing.Point(20, 50);
            this.pnlBill.MaximumSize = new System.Drawing.Size(500, 0);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(380, 700);
            this.pnlBill.TabIndex = 0;
            this.pnlBill.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            // 
            // lsvBillDetail
            // 
            this.lsvBillDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.lsvBillDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvBillDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProduct,
            this.columnHeaderQuantity,
            this.columnHeaderPrice,
            this.columnHeaderPromotion,
            this.columnHeaderIntoMoney});
            this.lsvBillDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvBillDetail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvBillDetail.ForeColor = System.Drawing.Color.Gainsboro;
            this.lsvBillDetail.FullRowSelect = true;
            this.lsvBillDetail.HideSelection = false;
            this.lsvBillDetail.Location = new System.Drawing.Point(0, 0);
            this.lsvBillDetail.Name = "lsvBillDetail";
            this.lsvBillDetail.Size = new System.Drawing.Size(380, 700);
            this.lsvBillDetail.TabIndex = 0;
            this.lsvBillDetail.UseCompatibleStateImageBehavior = false;
            this.lsvBillDetail.View = System.Windows.Forms.View.Details;
            this.lsvBillDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LsvBillDetail_KeyDown);
            // 
            // columnHeaderProduct
            // 
            this.columnHeaderProduct.Text = "Product";
            this.columnHeaderProduct.Width = 66;
            // 
            // columnHeaderQuantity
            // 
            this.columnHeaderQuantity.Text = "Quantity";
            this.columnHeaderQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderQuantity.Width = 93;
            // 
            // columnHeaderPrice
            // 
            this.columnHeaderPrice.Text = "Price";
            this.columnHeaderPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeaderPromotion
            // 
            this.columnHeaderPromotion.Text = "Promotion (%)";
            this.columnHeaderPromotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderPromotion.Width = 79;
            // 
            // columnHeaderIntoMoney
            // 
            this.columnHeaderIntoMoney.Text = "IntoMoney";
            this.columnHeaderIntoMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderIntoMoney.Width = 111;
            // 
            // pnlResizeLeft
            // 
            this.pnlResizeLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlResizeLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlResizeLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResizeLeft.Location = new System.Drawing.Point(400, 50);
            this.pnlResizeLeft.Name = "pnlResizeLeft";
            this.pnlResizeLeft.Size = new System.Drawing.Size(10, 700);
            this.pnlResizeLeft.TabIndex = 0;
            this.pnlResizeLeft.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            this.pnlResizeLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseDown);
            this.pnlResizeLeft.MouseLeave += new System.EventHandler(this.PnlResize_MouseLeave);
            this.pnlResizeLeft.MouseHover += new System.EventHandler(this.PnlResize_MouseHover);
            this.pnlResizeLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlResizeLeft_MouseMove);
            this.pnlResizeLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseUp);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.pnlInfo.Controls.Add(this.grbPromotions);
            this.pnlInfo.Controls.Add(this.grbAfterTax);
            this.pnlInfo.Controls.Add(this.grbTax);
            this.pnlInfo.Controls.Add(this.grbTotal);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInfo.Location = new System.Drawing.Point(970, 50);
            this.pnlInfo.MaximumSize = new System.Drawing.Size(500, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInfo.Size = new System.Drawing.Size(380, 700);
            this.pnlInfo.TabIndex = 0;
            this.pnlInfo.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            // 
            // grbPromotions
            // 
            this.grbPromotions.BackColor = System.Drawing.Color.Transparent;
            this.grbPromotions.Controls.Add(this.lsvDiscountDetail);
            this.grbPromotions.Controls.Add(this.txbAfterPromotions);
            this.grbPromotions.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbPromotions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbPromotions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbPromotions.Location = new System.Drawing.Point(10, 229);
            this.grbPromotions.Name = "grbPromotions";
            this.grbPromotions.Padding = new System.Windows.Forms.Padding(10);
            this.grbPromotions.Size = new System.Drawing.Size(360, 302);
            this.grbPromotions.TabIndex = 0;
            this.grbPromotions.TabStop = false;
            this.grbPromotions.Text = "Promotion";
            // 
            // lsvDiscountDetail
            // 
            this.lsvDiscountDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.lsvDiscountDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvDiscountDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPromotionType,
            this.columnHeaderValue,
            this.columnHeaderIsPercent,
            this.columnHeaderMinValue,
            this.columnHeaderStartTime,
            this.columnHeaderEndTime});
            this.lsvDiscountDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDiscountDetail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvDiscountDetail.ForeColor = System.Drawing.Color.Gainsboro;
            this.lsvDiscountDetail.FullRowSelect = true;
            this.lsvDiscountDetail.HideSelection = false;
            this.lsvDiscountDetail.Location = new System.Drawing.Point(10, 33);
            this.lsvDiscountDetail.Name = "lsvDiscountDetail";
            this.lsvDiscountDetail.ShowItemToolTips = true;
            this.lsvDiscountDetail.Size = new System.Drawing.Size(340, 226);
            this.lsvDiscountDetail.TabIndex = 0;
            this.lsvDiscountDetail.UseCompatibleStateImageBehavior = false;
            this.lsvDiscountDetail.View = System.Windows.Forms.View.Details;
            this.lsvDiscountDetail.SizeChanged += new System.EventHandler(this.LsvDiscountDetail_SizeChanged);
            this.lsvDiscountDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LsvDiscountDetail_KeyDown);
            // 
            // columnHeaderPromotionType
            // 
            this.columnHeaderPromotionType.Text = "PromotionType";
            this.columnHeaderPromotionType.Width = 50;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderValue.Width = 50;
            // 
            // columnHeaderIsPercent
            // 
            this.columnHeaderIsPercent.Text = "Calculation";
            this.columnHeaderIsPercent.Width = 50;
            // 
            // columnHeaderMinValue
            // 
            this.columnHeaderMinValue.Text = "Min Invoice";
            this.columnHeaderMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderMinValue.Width = 50;
            // 
            // columnHeaderStartTime
            // 
            this.columnHeaderStartTime.Text = "StartTime";
            this.columnHeaderStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderStartTime.Width = 50;
            // 
            // columnHeaderEndTime
            // 
            this.columnHeaderEndTime.Text = "EndTime";
            this.columnHeaderEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderEndTime.Width = 50;
            // 
            // txbAfterPromotions
            // 
            this.txbAfterPromotions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.txbAfterPromotions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbAfterPromotions.Cursor = System.Windows.Forms.Cursors.No;
            this.txbAfterPromotions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txbAfterPromotions.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAfterPromotions.ForeColor = System.Drawing.Color.Red;
            this.txbAfterPromotions.Location = new System.Drawing.Point(10, 259);
            this.txbAfterPromotions.Name = "txbAfterPromotions";
            this.txbAfterPromotions.ReadOnly = true;
            this.txbAfterPromotions.Size = new System.Drawing.Size(340, 33);
            this.txbAfterPromotions.TabIndex = 0;
            this.txbAfterPromotions.TabStop = false;
            this.txbAfterPromotions.Text = "After Promotion";
            this.txbAfterPromotions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbAfterTax
            // 
            this.grbAfterTax.BackColor = System.Drawing.Color.Transparent;
            this.grbAfterTax.Controls.Add(this.txbAfterTax);
            this.grbAfterTax.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbAfterTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbAfterTax.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbAfterTax.Location = new System.Drawing.Point(10, 156);
            this.grbAfterTax.Name = "grbAfterTax";
            this.grbAfterTax.Padding = new System.Windows.Forms.Padding(10);
            this.grbAfterTax.Size = new System.Drawing.Size(360, 73);
            this.grbAfterTax.TabIndex = 0;
            this.grbAfterTax.TabStop = false;
            this.grbAfterTax.Text = "After Tax";
            // 
            // txbAfterTax
            // 
            this.txbAfterTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.txbAfterTax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbAfterTax.Cursor = System.Windows.Forms.Cursors.No;
            this.txbAfterTax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbAfterTax.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAfterTax.ForeColor = System.Drawing.Color.Red;
            this.txbAfterTax.Location = new System.Drawing.Point(10, 33);
            this.txbAfterTax.Name = "txbAfterTax";
            this.txbAfterTax.ReadOnly = true;
            this.txbAfterTax.Size = new System.Drawing.Size(340, 33);
            this.txbAfterTax.TabIndex = 0;
            this.txbAfterTax.TabStop = false;
            this.txbAfterTax.Text = "After Tax";
            this.txbAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbTax
            // 
            this.grbTax.BackColor = System.Drawing.Color.Transparent;
            this.grbTax.Controls.Add(this.nudTax);
            this.grbTax.Controls.Add(this.ckbTaxStatus);
            this.grbTax.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbTax.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbTax.Location = new System.Drawing.Point(10, 83);
            this.grbTax.Name = "grbTax";
            this.grbTax.Padding = new System.Windows.Forms.Padding(10);
            this.grbTax.Size = new System.Drawing.Size(360, 73);
            this.grbTax.TabIndex = 0;
            this.grbTax.TabStop = false;
            this.grbTax.Text = "Tax (%)";
            // 
            // nudTax
            // 
            this.nudTax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudTax.Location = new System.Drawing.Point(134, 33);
            this.nudTax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTax.Name = "nudTax";
            this.nudTax.Size = new System.Drawing.Size(216, 30);
            this.nudTax.TabIndex = 0;
            this.nudTax.ValueChanged += new System.EventHandler(this.NudTax_ValueChanged);
            // 
            // ckbTaxStatus
            // 
            this.ckbTaxStatus.AutoSize = true;
            this.ckbTaxStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.ckbTaxStatus.Location = new System.Drawing.Point(10, 33);
            this.ckbTaxStatus.Name = "ckbTaxStatus";
            this.ckbTaxStatus.Size = new System.Drawing.Size(124, 30);
            this.ckbTaxStatus.TabIndex = 0;
            this.ckbTaxStatus.Text = "Tax Status";
            this.ckbTaxStatus.UseVisualStyleBackColor = true;
            this.ckbTaxStatus.CheckedChanged += new System.EventHandler(this.CkbTaxStatus_CheckedChanged);
            // 
            // grbTotal
            // 
            this.grbTotal.BackColor = System.Drawing.Color.Transparent;
            this.grbTotal.Controls.Add(this.txbTotal);
            this.grbTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbTotal.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbTotal.Location = new System.Drawing.Point(10, 10);
            this.grbTotal.Name = "grbTotal";
            this.grbTotal.Padding = new System.Windows.Forms.Padding(10);
            this.grbTotal.Size = new System.Drawing.Size(360, 73);
            this.grbTotal.TabIndex = 0;
            this.grbTotal.TabStop = false;
            this.grbTotal.Text = "Total";
            // 
            // txbTotal
            // 
            this.txbTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.txbTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbTotal.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotal.ForeColor = System.Drawing.Color.Red;
            this.txbTotal.Location = new System.Drawing.Point(10, 33);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(340, 33);
            this.txbTotal.TabIndex = 0;
            this.txbTotal.TabStop = false;
            this.txbTotal.Text = "Total";
            this.txbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlResizeRight
            // 
            this.pnlResizeRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlResizeRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlResizeRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResizeRight.Location = new System.Drawing.Point(960, 50);
            this.pnlResizeRight.Name = "pnlResizeRight";
            this.pnlResizeRight.Size = new System.Drawing.Size(10, 700);
            this.pnlResizeRight.TabIndex = 0;
            this.pnlResizeRight.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            this.pnlResizeRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseDown);
            this.pnlResizeRight.MouseLeave += new System.EventHandler(this.PnlResize_MouseLeave);
            this.pnlResizeRight.MouseHover += new System.EventHandler(this.PnlResize_MouseHover);
            this.pnlResizeRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlResizeRight_MouseMove);
            this.pnlResizeRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseUp);
            // 
            // pnlHandler
            // 
            this.pnlHandler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.pnlHandler.Controls.Add(this.pnlResizeTop);
            this.pnlHandler.Controls.Add(this.grbCouponVoucher);
            this.pnlHandler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHandler.Location = new System.Drawing.Point(410, 50);
            this.pnlHandler.Name = "pnlHandler";
            this.pnlHandler.Padding = new System.Windows.Forms.Padding(10);
            this.pnlHandler.Size = new System.Drawing.Size(550, 700);
            this.pnlHandler.TabIndex = 0;
            this.pnlHandler.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            // 
            // pnlResizeTop
            // 
            this.pnlResizeTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlResizeTop.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pnlResizeTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResizeTop.Location = new System.Drawing.Point(10, 229);
            this.pnlResizeTop.Name = "pnlResizeTop";
            this.pnlResizeTop.Size = new System.Drawing.Size(530, 10);
            this.pnlResizeTop.TabIndex = 0;
            this.pnlResizeTop.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            this.pnlResizeTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseDown);
            this.pnlResizeTop.MouseLeave += new System.EventHandler(this.PnlResize_MouseLeave);
            this.pnlResizeTop.MouseHover += new System.EventHandler(this.PnlResize_MouseHover);
            this.pnlResizeTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlResizeTop_MouseMove);
            this.pnlResizeTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseUp);
            // 
            // grbCouponVoucher
            // 
            this.grbCouponVoucher.BackColor = System.Drawing.Color.Transparent;
            this.grbCouponVoucher.Controls.Add(this.pnlScan);
            this.grbCouponVoucher.Controls.Add(this.pnlOptions);
            this.grbCouponVoucher.Controls.Add(this.txbCode);
            this.grbCouponVoucher.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbCouponVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbCouponVoucher.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbCouponVoucher.Location = new System.Drawing.Point(10, 10);
            this.grbCouponVoucher.Name = "grbCouponVoucher";
            this.grbCouponVoucher.Padding = new System.Windows.Forms.Padding(10);
            this.grbCouponVoucher.Size = new System.Drawing.Size(530, 219);
            this.grbCouponVoucher.TabIndex = 0;
            this.grbCouponVoucher.TabStop = false;
            this.grbCouponVoucher.Text = "Coupon / Voucher";
            // 
            // pnlScan
            // 
            this.pnlScan.Controls.Add(this.picFrame);
            this.pnlScan.Controls.Add(this.cbCameraDevice);
            this.pnlScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScan.Location = new System.Drawing.Point(185, 63);
            this.pnlScan.Name = "pnlScan";
            this.pnlScan.Padding = new System.Windows.Forms.Padding(10);
            this.pnlScan.Size = new System.Drawing.Size(335, 146);
            this.pnlScan.TabIndex = 0;
            this.pnlScan.Visible = false;
            // 
            // picFrame
            // 
            this.picFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFrame.Location = new System.Drawing.Point(10, 41);
            this.picFrame.Name = "picFrame";
            this.picFrame.Size = new System.Drawing.Size(315, 95);
            this.picFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFrame.TabIndex = 1;
            this.picFrame.TabStop = false;
            // 
            // cbCameraDevice
            // 
            this.cbCameraDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbCameraDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCameraDevice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbCameraDevice.FormattingEnabled = true;
            this.cbCameraDevice.Location = new System.Drawing.Point(10, 10);
            this.cbCameraDevice.Name = "cbCameraDevice";
            this.cbCameraDevice.Size = new System.Drawing.Size(315, 31);
            this.cbCameraDevice.TabIndex = 0;
            this.cbCameraDevice.SelectedIndexChanged += new System.EventHandler(this.CbCameraDevice_SelectedIndexChanged);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.ibtnCheck);
            this.pnlOptions.Controls.Add(this.ibtnScan);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOptions.Location = new System.Drawing.Point(10, 63);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlOptions.Size = new System.Drawing.Size(175, 146);
            this.pnlOptions.TabIndex = 0;
            // 
            // ibtnCheck
            // 
            this.ibtnCheck.BackColor = System.Drawing.Color.Transparent;
            this.ibtnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.ibtnCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnCheck.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ibtnCheck.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtnCheck.IconColor = System.Drawing.Color.Black;
            this.ibtnCheck.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnCheck.Location = new System.Drawing.Point(10, 50);
            this.ibtnCheck.Name = "ibtnCheck";
            this.ibtnCheck.Size = new System.Drawing.Size(155, 40);
            this.ibtnCheck.TabIndex = 0;
            this.ibtnCheck.Text = "Check";
            this.ibtnCheck.UseVisualStyleBackColor = false;
            this.ibtnCheck.Click += new System.EventHandler(this.IbtnCheck_Click);
            this.ibtnCheck.MouseLeave += new System.EventHandler(this.Ibtn_MouseLeave);
            this.ibtnCheck.MouseHover += new System.EventHandler(this.Ibtn_MouseHover);
            // 
            // ibtnScan
            // 
            this.ibtnScan.BackColor = System.Drawing.Color.Transparent;
            this.ibtnScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnScan.Dock = System.Windows.Forms.DockStyle.Top;
            this.ibtnScan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnScan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnScan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ibtnScan.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtnScan.IconColor = System.Drawing.Color.Black;
            this.ibtnScan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnScan.Location = new System.Drawing.Point(10, 10);
            this.ibtnScan.Name = "ibtnScan";
            this.ibtnScan.Size = new System.Drawing.Size(155, 40);
            this.ibtnScan.TabIndex = 0;
            this.ibtnScan.Text = "Scan Code";
            this.ibtnScan.UseVisualStyleBackColor = false;
            this.ibtnScan.Click += new System.EventHandler(this.IbtnScan_Click);
            this.ibtnScan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnScan.MouseLeave += new System.EventHandler(this.Ibtn_MouseLeave);
            this.ibtnScan.MouseHover += new System.EventHandler(this.Ibtn_MouseHover);
            // 
            // txbCode
            // 
            this.txbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txbCode.Location = new System.Drawing.Point(10, 33);
            this.txbCode.Name = "txbCode";
            this.txbCode.Size = new System.Drawing.Size(510, 30);
            this.txbCode.TabIndex = 0;
            this.txbCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerCameraFrame
            // 
            this.timerCameraFrame.Interval = 1000;
            this.timerCameraFrame.Tick += new System.EventHandler(this.TimerCameraFrame_Tick);
            // 
            // FormCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlHandler);
            this.Controls.Add(this.pnlResizeRight);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlResizeLeft);
            this.Controls.Add(this.pnlBill);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFooterBar);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCheckout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormCheckout_Load);
            this.SizeChanged += new System.EventHandler(this.FormCheckout_SizeChanged);
            this.pnlTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicClose)).EndInit();
            this.pnlFooterBar.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicWindowCalculator)).EndInit();
            this.pnlBill.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.grbPromotions.ResumeLayout(false);
            this.grbPromotions.PerformLayout();
            this.grbAfterTax.ResumeLayout(false);
            this.grbAfterTax.PerformLayout();
            this.grbTax.ResumeLayout(false);
            this.grbTax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTax)).EndInit();
            this.grbTotal.ResumeLayout(false);
            this.grbTotal.PerformLayout();
            this.pnlHandler.ResumeLayout(false);
            this.grbCouponVoucher.ResumeLayout(false);
            this.grbCouponVoucher.PerformLayout();
            this.pnlScan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFrame)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lbTitle;
        private FontAwesome.Sharp.IconPictureBox ipicMaximize;
        private System.Windows.Forms.PictureBox picLogo;
        private FontAwesome.Sharp.IconPictureBox ipicClose;
        private System.Windows.Forms.Panel pnlFooterBar;
        private FontAwesome.Sharp.IconButton ibtnPrintProvisionalInvoice;
        private FontAwesome.Sharp.IconButton ibtnCancel;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private FontAwesome.Sharp.IconPictureBox ipicWindowCalculator;
        private System.Windows.Forms.Panel pnlBill;
        private System.Windows.Forms.ListView lsvBillDetail;
        private System.Windows.Forms.ColumnHeader columnHeaderProduct;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantity;
        private System.Windows.Forms.ColumnHeader columnHeaderPrice;
        private System.Windows.Forms.ColumnHeader columnHeaderPromotion;
        private System.Windows.Forms.ColumnHeader columnHeaderIntoMoney;
        private System.Windows.Forms.Panel pnlResizeLeft;
        private FontAwesome.Sharp.IconButton ibtnCheckout;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlResizeRight;
        private System.Windows.Forms.ToolTip ttNote;
        private System.Windows.Forms.Panel pnlHandler;
        private System.Windows.Forms.GroupBox grbAfterTax;
        private System.Windows.Forms.TextBox txbAfterTax;
        private System.Windows.Forms.GroupBox grbTax;
        private System.Windows.Forms.NumericUpDown nudTax;
        private System.Windows.Forms.CheckBox ckbTaxStatus;
        private System.Windows.Forms.GroupBox grbTotal;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.GroupBox grbCouponVoucher;
        private FontAwesome.Sharp.IconButton ibtnScan;
        private System.Windows.Forms.TextBox txbCode;
        private System.Windows.Forms.Timer timerCameraFrame;
        private System.Windows.Forms.Panel pnlScan;
        private System.Windows.Forms.PictureBox picFrame;
        private System.Windows.Forms.ComboBox cbCameraDevice;
        private System.Windows.Forms.Panel pnlOptions;
        private FontAwesome.Sharp.IconButton ibtnCheck;
        private System.Windows.Forms.Panel pnlResizeTop;
        private System.Windows.Forms.GroupBox grbPromotions;
        private System.Windows.Forms.TextBox txbAfterPromotions;
        private System.Windows.Forms.ListView lsvDiscountDetail;
        private System.Windows.Forms.ColumnHeader columnHeaderPromotionType;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.ColumnHeader columnHeaderIsPercent;
        private System.Windows.Forms.ColumnHeader columnHeaderMinValue;
        private System.Windows.Forms.ColumnHeader columnHeaderStartTime;
        private System.Windows.Forms.ColumnHeader columnHeaderEndTime;
    }
}