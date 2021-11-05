
namespace Zi.SalesModule.GUIs
{
    partial class FormOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrder));
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.ipicMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.ipicClose = new FontAwesome.Sharp.IconPictureBox();
            this.pnlFooterBar = new System.Windows.Forms.Panel();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.ibtnSave = new FontAwesome.Sharp.IconButton();
            this.ibtnCancel = new FontAwesome.Sharp.IconButton();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.ipicUp = new FontAwesome.Sharp.IconPictureBox();
            this.ipicDown = new FontAwesome.Sharp.IconPictureBox();
            this.lbCartAmount = new System.Windows.Forms.Label();
            this.ipicViewCart = new FontAwesome.Sharp.IconPictureBox();
            this.fpnlCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlResizeLeft = new System.Windows.Forms.Panel();
            this.pnlBill = new System.Windows.Forms.Panel();
            this.lsvBillDetail = new System.Windows.Forms.ListView();
            this.columnHeaderProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPromotion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIntoMoney = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResizeRight = new System.Windows.Forms.Panel();
            this.ttNote = new System.Windows.Forms.ToolTip(this.components);
            this.fpnlPaginator = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDivideBottom = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.fpnlSearchTag = new System.Windows.Forms.FlowLayoutPanel();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.pnlDivideTop = new System.Windows.Forms.Panel();
            this.fpnlProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicClose)).BeginInit();
            this.pnlFooterBar.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicViewCart)).BeginInit();
            this.pnlBill.SuspendLayout();
            this.pnlFilter.SuspendLayout();
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
            this.pnlFooterBar.Controls.Add(this.txbTotal);
            this.pnlFooterBar.Controls.Add(this.ibtnSave);
            this.pnlFooterBar.Controls.Add(this.ibtnCancel);
            this.pnlFooterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterBar.Location = new System.Drawing.Point(0, 850);
            this.pnlFooterBar.Name = "pnlFooterBar";
            this.pnlFooterBar.Padding = new System.Windows.Forms.Padding(20, 10, 50, 10);
            this.pnlFooterBar.Size = new System.Drawing.Size(1400, 50);
            this.pnlFooterBar.TabIndex = 0;
            // 
            // txbTotal
            // 
            this.txbTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.txbTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbTotal.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotal.ForeColor = System.Drawing.Color.Red;
            this.txbTotal.Location = new System.Drawing.Point(400, 10);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(570, 33);
            this.txbTotal.TabIndex = 0;
            this.txbTotal.TabStop = false;
            this.txbTotal.Text = "Total";
            this.txbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ibtnSave
            // 
            this.ibtnSave.BackColor = System.Drawing.Color.Transparent;
            this.ibtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ibtnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ibtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtnSave.IconColor = System.Drawing.Color.Black;
            this.ibtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnSave.Location = new System.Drawing.Point(20, 10);
            this.ibtnSave.Name = "ibtnSave";
            this.ibtnSave.Size = new System.Drawing.Size(380, 30);
            this.ibtnSave.TabIndex = 1;
            this.ibtnSave.Text = "Save";
            this.ibtnSave.UseVisualStyleBackColor = false;
            this.ibtnSave.Click += new System.EventHandler(this.IbtnSave_Click);
            this.ibtnSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnSave.MouseLeave += new System.EventHandler(this.Ibtn_MouseLeave);
            this.ibtnSave.MouseHover += new System.EventHandler(this.Ibtn_MouseHover);
            // 
            // ibtnCancel
            // 
            this.ibtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.ibtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.ibtnCancel.TabIndex = 2;
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
            this.pnlLeft.Size = new System.Drawing.Size(20, 800);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.ipicUp);
            this.pnlRight.Controls.Add(this.ipicDown);
            this.pnlRight.Controls.Add(this.lbCartAmount);
            this.pnlRight.Controls.Add(this.ipicViewCart);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1350, 50);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(50, 800);
            this.pnlRight.TabIndex = 0;
            // 
            // ipicUp
            // 
            this.ipicUp.BackColor = System.Drawing.Color.Transparent;
            this.ipicUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicUp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipicUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicUp.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicUp.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicUp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicUp.IconSize = 50;
            this.ipicUp.Location = new System.Drawing.Point(0, 630);
            this.ipicUp.Name = "ipicUp";
            this.ipicUp.Size = new System.Drawing.Size(50, 50);
            this.ipicUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicUp.TabIndex = 4;
            this.ipicUp.TabStop = false;
            this.ipicUp.Click += new System.EventHandler(this.IpicUp_Click);
            this.ipicUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ipicUp.MouseLeave += new System.EventHandler(this.Ipic_MouseLeave);
            this.ipicUp.MouseHover += new System.EventHandler(this.Ipic_MouseHover);
            // 
            // ipicDown
            // 
            this.ipicDown.BackColor = System.Drawing.Color.Transparent;
            this.ipicDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipicDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicDown.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicDown.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicDown.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicDown.IconSize = 50;
            this.ipicDown.Location = new System.Drawing.Point(0, 680);
            this.ipicDown.Name = "ipicDown";
            this.ipicDown.Size = new System.Drawing.Size(50, 50);
            this.ipicDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicDown.TabIndex = 3;
            this.ipicDown.TabStop = false;
            this.ipicDown.Click += new System.EventHandler(this.IpicDown_Click);
            this.ipicDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ipicDown.MouseLeave += new System.EventHandler(this.Ipic_MouseLeave);
            this.ipicDown.MouseHover += new System.EventHandler(this.Ipic_MouseHover);
            // 
            // lbCartAmount
            // 
            this.lbCartAmount.BackColor = System.Drawing.Color.Red;
            this.lbCartAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbCartAmount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCartAmount.ForeColor = System.Drawing.Color.White;
            this.lbCartAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCartAmount.Location = new System.Drawing.Point(0, 730);
            this.lbCartAmount.Name = "lbCartAmount";
            this.lbCartAmount.Size = new System.Drawing.Size(50, 20);
            this.lbCartAmount.TabIndex = 0;
            this.lbCartAmount.Text = "Qty";
            this.lbCartAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipicViewCart
            // 
            this.ipicViewCart.BackColor = System.Drawing.Color.Transparent;
            this.ipicViewCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicViewCart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipicViewCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicViewCart.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicViewCart.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicViewCart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicViewCart.IconSize = 50;
            this.ipicViewCart.Location = new System.Drawing.Point(0, 750);
            this.ipicViewCart.Name = "ipicViewCart";
            this.ipicViewCart.Size = new System.Drawing.Size(50, 50);
            this.ipicViewCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicViewCart.TabIndex = 2;
            this.ipicViewCart.TabStop = false;
            this.ipicViewCart.Click += new System.EventHandler(this.IpicViewCart_Click);
            this.ipicViewCart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ipicViewCart.MouseLeave += new System.EventHandler(this.Ipic_MouseLeave);
            this.ipicViewCart.MouseHover += new System.EventHandler(this.Ipic_MouseHover);
            // 
            // fpnlCategory
            // 
            this.fpnlCategory.AutoScroll = true;
            this.fpnlCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.fpnlCategory.Dock = System.Windows.Forms.DockStyle.Left;
            this.fpnlCategory.Location = new System.Drawing.Point(20, 50);
            this.fpnlCategory.MaximumSize = new System.Drawing.Size(500, 0);
            this.fpnlCategory.Name = "fpnlCategory";
            this.fpnlCategory.Padding = new System.Windows.Forms.Padding(10);
            this.fpnlCategory.Size = new System.Drawing.Size(380, 800);
            this.fpnlCategory.TabIndex = 0;
            this.fpnlCategory.SizeChanged += new System.EventHandler(this.FpnlRoundedCorner_SizeChanged);
            this.fpnlCategory.Paint += new System.Windows.Forms.PaintEventHandler(this.FpnlCategoryList_Paint);
            // 
            // pnlResizeLeft
            // 
            this.pnlResizeLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlResizeLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlResizeLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResizeLeft.Location = new System.Drawing.Point(400, 50);
            this.pnlResizeLeft.Name = "pnlResizeLeft";
            this.pnlResizeLeft.Size = new System.Drawing.Size(10, 800);
            this.pnlResizeLeft.TabIndex = 0;
            this.pnlResizeLeft.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            this.pnlResizeLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseDown);
            this.pnlResizeLeft.MouseLeave += new System.EventHandler(this.PnlResize_MouseLeave);
            this.pnlResizeLeft.MouseHover += new System.EventHandler(this.PnlResize_MouseHover);
            this.pnlResizeLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlResizeLeft_MouseMove);
            this.pnlResizeLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseUp);
            // 
            // pnlBill
            // 
            this.pnlBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.pnlBill.Controls.Add(this.lsvBillDetail);
            this.pnlBill.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBill.Location = new System.Drawing.Point(970, 50);
            this.pnlBill.MaximumSize = new System.Drawing.Size(500, 0);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(380, 800);
            this.pnlBill.TabIndex = 0;
            this.pnlBill.Visible = false;
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
            this.lsvBillDetail.Size = new System.Drawing.Size(380, 800);
            this.lsvBillDetail.TabIndex = 0;
            this.lsvBillDetail.UseCompatibleStateImageBehavior = false;
            this.lsvBillDetail.View = System.Windows.Forms.View.Details;
            this.lsvBillDetail.SelectedIndexChanged += new System.EventHandler(this.LsvBillDetail_SelectedIndexChanged);
            this.lsvBillDetail.SizeChanged += new System.EventHandler(this.LsvBillDetail_SizeChanged);
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
            // pnlResizeRight
            // 
            this.pnlResizeRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlResizeRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlResizeRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResizeRight.Location = new System.Drawing.Point(960, 50);
            this.pnlResizeRight.Name = "pnlResizeRight";
            this.pnlResizeRight.Size = new System.Drawing.Size(10, 800);
            this.pnlResizeRight.TabIndex = 0;
            this.pnlResizeRight.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            this.pnlResizeRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseDown);
            this.pnlResizeRight.MouseLeave += new System.EventHandler(this.PnlResize_MouseLeave);
            this.pnlResizeRight.MouseHover += new System.EventHandler(this.PnlResize_MouseHover);
            this.pnlResizeRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlResizeRight_MouseMove);
            this.pnlResizeRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseUp);
            // 
            // fpnlPaginator
            // 
            this.fpnlPaginator.AutoScroll = true;
            this.fpnlPaginator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.fpnlPaginator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fpnlPaginator.Location = new System.Drawing.Point(410, 790);
            this.fpnlPaginator.Margin = new System.Windows.Forms.Padding(0);
            this.fpnlPaginator.Name = "fpnlPaginator";
            this.fpnlPaginator.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.fpnlPaginator.Size = new System.Drawing.Size(550, 60);
            this.fpnlPaginator.TabIndex = 0;
            this.fpnlPaginator.SizeChanged += new System.EventHandler(this.FpnlRoundedCorner_SizeChanged);
            // 
            // pnlDivideBottom
            // 
            this.pnlDivideBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlDivideBottom.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDivideBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDivideBottom.Location = new System.Drawing.Point(410, 780);
            this.pnlDivideBottom.Name = "pnlDivideBottom";
            this.pnlDivideBottom.Size = new System.Drawing.Size(550, 10);
            this.pnlDivideBottom.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.AutoSize = true;
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.pnlFilter.Controls.Add(this.fpnlSearchTag);
            this.pnlFilter.Controls.Add(this.txbSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(410, 50);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(10);
            this.pnlFilter.Size = new System.Drawing.Size(550, 49);
            this.pnlFilter.TabIndex = 0;
            this.pnlFilter.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            // 
            // fpnlSearchTag
            // 
            this.fpnlSearchTag.AutoScroll = true;
            this.fpnlSearchTag.AutoSize = true;
            this.fpnlSearchTag.BackColor = System.Drawing.Color.Transparent;
            this.fpnlSearchTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlSearchTag.Location = new System.Drawing.Point(10, 33);
            this.fpnlSearchTag.Margin = new System.Windows.Forms.Padding(0);
            this.fpnlSearchTag.MaximumSize = new System.Drawing.Size(0, 50);
            this.fpnlSearchTag.Name = "fpnlSearchTag";
            this.fpnlSearchTag.Padding = new System.Windows.Forms.Padding(3);
            this.fpnlSearchTag.Size = new System.Drawing.Size(530, 6);
            this.fpnlSearchTag.TabIndex = 0;
            // 
            // txbSearch
            // 
            this.txbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.txbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txbSearch.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.ForeColor = System.Drawing.Color.Gainsboro;
            this.txbSearch.Location = new System.Drawing.Point(10, 10);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(530, 23);
            this.txbSearch.TabIndex = 0;
            this.txbSearch.Text = "Search";
            this.txbSearch.Click += new System.EventHandler(this.TxbSearch_Click);
            this.txbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxbSearch_KeyDown);
            // 
            // pnlDivideTop
            // 
            this.pnlDivideTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlDivideTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDivideTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDivideTop.Location = new System.Drawing.Point(410, 99);
            this.pnlDivideTop.Name = "pnlDivideTop";
            this.pnlDivideTop.Size = new System.Drawing.Size(550, 10);
            this.pnlDivideTop.TabIndex = 0;
            // 
            // fpnlProduct
            // 
            this.fpnlProduct.AutoScroll = true;
            this.fpnlProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.fpnlProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlProduct.Location = new System.Drawing.Point(410, 109);
            this.fpnlProduct.Name = "fpnlProduct";
            this.fpnlProduct.Padding = new System.Windows.Forms.Padding(10);
            this.fpnlProduct.Size = new System.Drawing.Size(550, 671);
            this.fpnlProduct.TabIndex = 0;
            this.fpnlProduct.SizeChanged += new System.EventHandler(this.FpnlRoundedCorner_SizeChanged);
            this.fpnlProduct.Paint += new System.Windows.Forms.PaintEventHandler(this.FpnlProductList_Paint);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.fpnlProduct);
            this.Controls.Add(this.pnlDivideTop);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlDivideBottom);
            this.Controls.Add(this.fpnlPaginator);
            this.Controls.Add(this.pnlResizeRight);
            this.Controls.Add(this.pnlBill);
            this.Controls.Add(this.pnlResizeLeft);
            this.Controls.Add(this.fpnlCategory);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFooterBar);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.SizeChanged += new System.EventHandler(this.FormOrder_SizeChanged);
            this.pnlTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicClose)).EndInit();
            this.pnlFooterBar.ResumeLayout(false);
            this.pnlFooterBar.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicViewCart)).EndInit();
            this.pnlBill.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.PictureBox picLogo;
        private FontAwesome.Sharp.IconPictureBox ipicClose;
        private System.Windows.Forms.Panel pnlFooterBar;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.FlowLayoutPanel fpnlCategory;
        private System.Windows.Forms.Panel pnlResizeLeft;
        private System.Windows.Forms.Panel pnlBill;
        private FontAwesome.Sharp.IconPictureBox ipicMaximize;
        private System.Windows.Forms.Panel pnlResizeRight;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ListView lsvBillDetail;
        private System.Windows.Forms.ColumnHeader columnHeaderProduct;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantity;
        private System.Windows.Forms.ColumnHeader columnHeaderPrice;
        private System.Windows.Forms.ColumnHeader columnHeaderIntoMoney;
        private FontAwesome.Sharp.IconPictureBox ipicViewCart;
        private FontAwesome.Sharp.IconPictureBox ipicUp;
        private FontAwesome.Sharp.IconPictureBox ipicDown;
        private System.Windows.Forms.Label lbCartAmount;
        private System.Windows.Forms.ToolTip ttNote;
        private System.Windows.Forms.ColumnHeader columnHeaderPromotion;
        private System.Windows.Forms.TextBox txbTotal;
        private FontAwesome.Sharp.IconButton ibtnSave;
        private FontAwesome.Sharp.IconButton ibtnCancel;
        private System.Windows.Forms.FlowLayoutPanel fpnlPaginator;
        private System.Windows.Forms.Panel pnlDivideBottom;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.FlowLayoutPanel fpnlSearchTag;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Panel pnlDivideTop;
        private System.Windows.Forms.FlowLayoutPanel fpnlProduct;
    }
}