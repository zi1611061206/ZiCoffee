namespace Zi.ZiCoffee.GUIs
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
            this.pnlFormOptions = new System.Windows.Forms.Panel();
            this.lbCartAmount = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.picViewCart = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCartConfirm = new System.Windows.Forms.Button();
            this.ttDescription = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlWinState = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnlCart = new System.Windows.Forms.Panel();
            this.lsvCart = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fpnlCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.fpnlServices = new System.Windows.Forms.FlowLayoutPanel();
            this.ctxbSearch = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.pnlFormOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewCart)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlWinState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.pnlCart.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFormOptions
            // 
            this.pnlFormOptions.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormOptions.Controls.Add(this.lbCartAmount);
            this.pnlFormOptions.Controls.Add(this.txbTotal);
            this.pnlFormOptions.Controls.Add(this.picViewCart);
            this.pnlFormOptions.Controls.Add(this.btnCancel);
            this.pnlFormOptions.Controls.Add(this.btnCartConfirm);
            this.pnlFormOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFormOptions.Location = new System.Drawing.Point(0, 652);
            this.pnlFormOptions.Name = "pnlFormOptions";
            this.pnlFormOptions.Size = new System.Drawing.Size(1220, 58);
            this.pnlFormOptions.TabIndex = 0;
            // 
            // lbCartAmount
            // 
            this.lbCartAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCartAmount.BackColor = System.Drawing.Color.Red;
            this.lbCartAmount.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCartAmount.ForeColor = System.Drawing.Color.White;
            this.lbCartAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCartAmount.Location = new System.Drawing.Point(767, 13);
            this.lbCartAmount.Name = "lbCartAmount";
            this.lbCartAmount.Size = new System.Drawing.Size(90, 35);
            this.lbCartAmount.TabIndex = 0;
            this.lbCartAmount.Text = "10+";
            this.lbCartAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCartAmount.TextChanged += new System.EventHandler(this.LbCartAmount_TextChanged);
            // 
            // txbTotal
            // 
            this.txbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txbTotal.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotal.ForeColor = System.Drawing.Color.Red;
            this.txbTotal.Location = new System.Drawing.Point(497, 14);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(223, 33);
            this.txbTotal.TabIndex = 0;
            this.txbTotal.TabStop = false;
            this.txbTotal.Text = "0 VND";
            this.txbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picViewCart
            // 
            this.picViewCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picViewCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picViewCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picViewCart.Image = ((System.Drawing.Image)(resources.GetObject("picViewCart.Image")));
            this.picViewCart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picViewCart.Location = new System.Drawing.Point(726, 13);
            this.picViewCart.Name = "picViewCart";
            this.picViewCart.Size = new System.Drawing.Size(35, 35);
            this.picViewCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picViewCart.TabIndex = 25;
            this.picViewCart.TabStop = false;
            this.picViewCart.Click += new System.EventHandler(this.PicViewCart_Click);
            this.picViewCart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllButton_MouseDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(1039, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllButton_MouseDown);
            // 
            // btnCartConfirm
            // 
            this.btnCartConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCartConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnCartConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCartConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartConfirm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCartConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnCartConfirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCartConfirm.Location = new System.Drawing.Point(863, 13);
            this.btnCartConfirm.Name = "btnCartConfirm";
            this.btnCartConfirm.Size = new System.Drawing.Size(170, 35);
            this.btnCartConfirm.TabIndex = 2;
            this.btnCartConfirm.TabStop = false;
            this.btnCartConfirm.Text = "Xác Nhận";
            this.btnCartConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCartConfirm.UseVisualStyleBackColor = false;
            this.btnCartConfirm.Click += new System.EventHandler(this.BtnCartConfirm_Click);
            this.btnCartConfirm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllButton_MouseDown);
            // 
            // ttDescription
            // 
            this.ttDescription.OwnerDraw = true;
            this.ttDescription.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlTitle.Controls.Add(this.pnlWinState);
            this.pnlTitle.Controls.Add(this.lbTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.ForeColor = System.Drawing.Color.White;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1220, 35);
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitle_MouseDown);
            // 
            // pnlWinState
            // 
            this.pnlWinState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWinState.BackColor = System.Drawing.Color.Transparent;
            this.pnlWinState.Controls.Add(this.picClose);
            this.pnlWinState.Location = new System.Drawing.Point(1182, 0);
            this.pnlWinState.Name = "pnlWinState";
            this.pnlWinState.Size = new System.Drawing.Size(26, 28);
            this.pnlWinState.TabIndex = 0;
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Zi.ZiCoffee.Properties.Resources.close2;
            this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picClose.Location = new System.Drawing.Point(1, 0);
            this.picClose.MaximumSize = new System.Drawing.Size(25, 25);
            this.picClose.MinimumSize = new System.Drawing.Size(20, 20);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(25, 25);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 21;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.PicClose_Click);
            this.picClose.MouseLeave += new System.EventHandler(this.PicClose_MouseLeave);
            this.picClose.MouseHover += new System.EventHandler(this.PicClose_MouseHover);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(150, 35);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Dịch vụ";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCart
            // 
            this.pnlCart.BackColor = System.Drawing.Color.Transparent;
            this.pnlCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCart.Controls.Add(this.lsvCart);
            this.pnlCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCart.Location = new System.Drawing.Point(776, 35);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Size = new System.Drawing.Size(444, 617);
            this.pnlCart.TabIndex = 0;
            // 
            // lsvCart
            // 
            this.lsvCart.BackColor = System.Drawing.Color.White;
            this.lsvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvCart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lsvCart.ForeColor = System.Drawing.Color.Black;
            this.lsvCart.FullRowSelect = true;
            this.lsvCart.HideSelection = false;
            this.lsvCart.Location = new System.Drawing.Point(0, 0);
            this.lsvCart.Name = "lsvCart";
            this.lsvCart.Size = new System.Drawing.Size(442, 615);
            this.lsvCart.TabIndex = 0;
            this.lsvCart.UseCompatibleStateImageBehavior = false;
            this.lsvCart.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên đồ uống";
            this.columnHeader1.Width = 155;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 84;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 113;
            // 
            // fpnlCategories
            // 
            this.fpnlCategories.BackColor = System.Drawing.Color.Transparent;
            this.fpnlCategories.Dock = System.Windows.Forms.DockStyle.Left;
            this.fpnlCategories.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnlCategories.Location = new System.Drawing.Point(0, 35);
            this.fpnlCategories.Name = "fpnlCategories";
            this.fpnlCategories.Size = new System.Drawing.Size(232, 617);
            this.fpnlCategories.TabIndex = 0;
            // 
            // fpnlServices
            // 
            this.fpnlServices.AutoScroll = true;
            this.fpnlServices.BackColor = System.Drawing.Color.Transparent;
            this.fpnlServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlServices.Location = new System.Drawing.Point(232, 120);
            this.fpnlServices.Name = "fpnlServices";
            this.fpnlServices.Size = new System.Drawing.Size(544, 532);
            this.fpnlServices.TabIndex = 0;
            // 
            // ctxbSearch
            // 
            this.ctxbSearch.BackColor = System.Drawing.Color.Transparent;
            this.ctxbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbSearch.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbSearch.ForeColor = System.Drawing.Color.Black;
            this.ctxbSearch.Location = new System.Drawing.Point(232, 35);
            this.ctxbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbSearch.Name = "ctxbSearch";
            this.ctxbSearch.Size = new System.Drawing.Size(544, 85);
            this.ctxbSearch.TabIndex = 1;
            // 
            // 
            // 
            this.ctxbSearch.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbSearch.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbSearch.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbSearch.ZiBottom.Name = "pnlBottom";
            this.ctxbSearch.ZiBottom.Size = new System.Drawing.Size(535, 3);
            this.ctxbSearch.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbSearch.ZiLabel.AutoSize = true;
            this.ctxbSearch.ZiLabel.ForeColor = System.Drawing.Color.Black;
            this.ctxbSearch.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbSearch.ZiLabel.Name = "lbLabel";
            this.ctxbSearch.ZiLabel.Size = new System.Drawing.Size(89, 22);
            this.ctxbSearch.ZiLabel.TabIndex = 0;
            this.ctxbSearch.ZiLabel.Text = "Tìm kiếm";
            // 
            // 
            // 
            this.ctxbSearch.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbSearch.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbSearch.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbSearch.ZiLeft.Name = "pnlLeft";
            this.ctxbSearch.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbSearch.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbSearch.ZiPanel.Controls.Add(this.ctxbSearch.ZiBottom);
            this.ctxbSearch.ZiPanel.Controls.Add(this.ctxbSearch.ZiLeft);
            this.ctxbSearch.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbSearch.ZiPanel.Name = "pnlGroupBox";
            this.ctxbSearch.ZiPanel.Size = new System.Drawing.Size(538, 48);
            this.ctxbSearch.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbSearch.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbSearch.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbSearch.ZiRight.Location = new System.Drawing.Point(535, 0);
            this.ctxbSearch.ZiRight.Name = "pnlRight";
            this.ctxbSearch.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbSearch.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbSearch.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbSearch.ZiTextBox.BackColor = System.Drawing.Color.White;
            this.ctxbSearch.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbSearch.ZiTextBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbSearch.ZiTextBox.ForeColor = System.Drawing.Color.Black;
            this.ctxbSearch.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbSearch.ZiTextBox.Multiline = true;
            this.ctxbSearch.ZiTextBox.Name = "txbTextContent";
            this.ctxbSearch.ZiTextBox.Size = new System.Drawing.Size(520, 23);
            this.ctxbSearch.ZiTextBox.TabIndex = 0;
            this.ctxbSearch.ZiTextBox.Text = "Nhập từ khóa cần tìm";
            // 
            // 
            // 
            this.ctxbSearch.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbSearch.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbSearch.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbSearch.ZiTop.Name = "pnlTop";
            this.ctxbSearch.ZiTop.Size = new System.Drawing.Size(532, 3);
            this.ctxbSearch.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbSearch.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbSearch.ZiValidate.AutoSize = true;
            this.ctxbSearch.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbSearch.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbSearch.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbSearch.ZiValidate.Name = "lbValidator";
            this.ctxbSearch.ZiValidate.Size = new System.Drawing.Size(83, 16);
            this.ctxbSearch.ZiValidate.TabIndex = 0;
            this.ctxbSearch.ZiValidate.Text = "Lỗi tìm kiếm";
            this.ctxbSearch.ZiValidate.Visible = false;
            this.ctxbSearch.ZiClick += new System.EventHandler(this.CtxbSearch_ZiClick);
            // 
            // FormOrder
            // 
            this.AcceptButton = this.btnCartConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1220, 710);
            this.Controls.Add(this.fpnlServices);
            this.Controls.Add(this.ctxbSearch);
            this.Controls.Add(this.fpnlCategories);
            this.Controls.Add(this.pnlCart);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlFormOptions);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formOrder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.pnlFormOptions.ResumeLayout(false);
            this.pnlFormOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewCart)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlWinState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.pnlCart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormOptions;
        private System.Windows.Forms.ToolTip ttDescription;
        private System.Windows.Forms.Button btnCartConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picViewCart;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Panel pnlWinState;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.ListView lsvCart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.FlowLayoutPanel fpnlCategories;
        private System.Windows.Forms.Label lbCartAmount;
        private CustomControls.CustomTextBox ctxbSearch;
        private System.Windows.Forms.FlowLayoutPanel fpnlServices;
    }
}