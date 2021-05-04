namespace Zi.ZiCoffee.GUIs
{
    partial class FormPay
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTempPrint = new System.Windows.Forms.Button();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.pnlBill = new System.Windows.Forms.Panel();
            this.lstViewBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.ckbDiscount = new System.Windows.Forms.CheckBox();
            this.txbCash = new System.Windows.Forms.TextBox();
            this.txbSurplus = new System.Windows.Forms.TextBox();
            this.lbCash = new System.Windows.Forms.Label();
            this.txbFinalTotal = new System.Windows.Forms.TextBox();
            this.lbFinalTotal = new System.Windows.Forms.Label();
            this.txbDiscount = new System.Windows.Forms.TextBox();
            this.lbSurplus = new System.Windows.Forms.Label();
            this.txbVoucher = new System.Windows.Forms.TextBox();
            this.lbVoucher = new System.Windows.Forms.Label();
            this.txbTotalAfterVAT = new System.Windows.Forms.TextBox();
            this.lbTotalAfterVAT = new System.Windows.Forms.Label();
            this.txbVAT = new System.Windows.Forms.TextBox();
            this.ckbVAT = new System.Windows.Forms.CheckBox();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.pnlDiscount = new System.Windows.Forms.Panel();
            this.pnlPromotion = new System.Windows.Forms.Panel();
            this.grbDiscountList = new System.Windows.Forms.GroupBox();
            this.fpnlDiscountContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlVoucher = new System.Windows.Forms.Panel();
            this.grbVoucher = new System.Windows.Forms.GroupBox();
            this.pnlCoucherContent = new System.Windows.Forms.Panel();
            this.btnVoucherApply = new System.Windows.Forms.Button();
            this.txbVoucherContent = new System.Windows.Forms.TextBox();
            this.txbVoucherEnter = new System.Windows.Forms.TextBox();
            this.lbContent = new System.Windows.Forms.Label();
            this.lbVoucherEnter = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlBill.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            this.pnlDiscount.SuspendLayout();
            this.pnlPromotion.SuspendLayout();
            this.grbDiscountList.SuspendLayout();
            this.pnlVoucher.SuspendLayout();
            this.grbVoucher.SuspendLayout();
            this.pnlCoucherContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlTitle.Controls.Add(this.lbTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.ForeColor = System.Drawing.Color.White;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(941, 28);
            this.pnlTitle.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(941, 28);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Thanh toán";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOptions.Controls.Add(this.btnPay);
            this.pnlOptions.Controls.Add(this.btnCancel);
            this.pnlOptions.Controls.Add(this.btnTempPrint);
            this.pnlOptions.Controls.Add(this.btnCalculator);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOptions.Location = new System.Drawing.Point(0, 448);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(941, 45);
            this.pnlOptions.TabIndex = 0;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPay.Location = new System.Drawing.Point(582, 5);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(170, 35);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(758, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 35);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnTempPrint
            // 
            this.btnTempPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnTempPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTempPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTempPrint.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnTempPrint.ForeColor = System.Drawing.Color.White;
            this.btnTempPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTempPrint.Location = new System.Drawing.Point(406, 5);
            this.btnTempPrint.Name = "btnTempPrint";
            this.btnTempPrint.Size = new System.Drawing.Size(170, 35);
            this.btnTempPrint.TabIndex = 0;
            this.btnTempPrint.TabStop = false;
            this.btnTempPrint.Text = "In tạm tính";
            this.btnTempPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTempPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTempPrint.UseVisualStyleBackColor = false;
            // 
            // btnCalculator
            // 
            this.btnCalculator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnCalculator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCalculator.ForeColor = System.Drawing.Color.White;
            this.btnCalculator.Image = global::Zi.ZiCoffee.Properties.Resources.calculatorwhite;
            this.btnCalculator.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCalculator.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCalculator.Location = new System.Drawing.Point(365, 5);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(35, 35);
            this.btnCalculator.TabIndex = 0;
            this.btnCalculator.TabStop = false;
            this.btnCalculator.Tag = "";
            this.btnCalculator.UseVisualStyleBackColor = false;
            // 
            // pnlBill
            // 
            this.pnlBill.Controls.Add(this.lstViewBill);
            this.pnlBill.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBill.Location = new System.Drawing.Point(0, 28);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(424, 420);
            this.pnlBill.TabIndex = 0;
            // 
            // lstViewBill
            // 
            this.lstViewBill.BackColor = System.Drawing.SystemColors.Control;
            this.lstViewBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstViewBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViewBill.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lstViewBill.ForeColor = System.Drawing.Color.Black;
            this.lstViewBill.GridLines = true;
            this.lstViewBill.HideSelection = false;
            this.lstViewBill.Location = new System.Drawing.Point(0, 0);
            this.lstViewBill.Name = "lstViewBill";
            this.lstViewBill.Size = new System.Drawing.Size(424, 420);
            this.lstViewBill.TabIndex = 0;
            this.lstViewBill.UseCompatibleStateImageBehavior = false;
            this.lstViewBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên đồ uống";
            this.columnHeader1.Width = 157;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 96;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mã dịch vụ";
            this.columnHeader5.Width = 0;
            // 
            // pnlPreview
            // 
            this.pnlPreview.Controls.Add(this.ckbDiscount);
            this.pnlPreview.Controls.Add(this.txbCash);
            this.pnlPreview.Controls.Add(this.txbSurplus);
            this.pnlPreview.Controls.Add(this.lbCash);
            this.pnlPreview.Controls.Add(this.txbFinalTotal);
            this.pnlPreview.Controls.Add(this.lbFinalTotal);
            this.pnlPreview.Controls.Add(this.txbDiscount);
            this.pnlPreview.Controls.Add(this.lbSurplus);
            this.pnlPreview.Controls.Add(this.txbVoucher);
            this.pnlPreview.Controls.Add(this.lbVoucher);
            this.pnlPreview.Controls.Add(this.txbTotalAfterVAT);
            this.pnlPreview.Controls.Add(this.lbTotalAfterVAT);
            this.pnlPreview.Controls.Add(this.txbVAT);
            this.pnlPreview.Controls.Add(this.ckbVAT);
            this.pnlPreview.Controls.Add(this.txbTotal);
            this.pnlPreview.Controls.Add(this.lbTotal);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPreview.Location = new System.Drawing.Point(767, 28);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(174, 420);
            this.pnlPreview.TabIndex = 0;
            // 
            // ckbDiscount
            // 
            this.ckbDiscount.AutoSize = true;
            this.ckbDiscount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbDiscount.Checked = true;
            this.ckbDiscount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDiscount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ckbDiscount.FlatAppearance.BorderSize = 2;
            this.ckbDiscount.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbDiscount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDiscount.ForeColor = System.Drawing.Color.Black;
            this.ckbDiscount.Location = new System.Drawing.Point(6, 212);
            this.ckbDiscount.Name = "ckbDiscount";
            this.ckbDiscount.Size = new System.Drawing.Size(162, 23);
            this.ckbDiscount.TabIndex = 0;
            this.ckbDiscount.Text = "Khuyến mãi (%):";
            this.ckbDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbDiscount.UseVisualStyleBackColor = true;
            // 
            // txbCash
            // 
            this.txbCash.BackColor = System.Drawing.SystemColors.Control;
            this.txbCash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbCash.Location = new System.Drawing.Point(9, 336);
            this.txbCash.Name = "txbCash";
            this.txbCash.Size = new System.Drawing.Size(154, 30);
            this.txbCash.TabIndex = 0;
            this.txbCash.TabStop = false;
            this.txbCash.Text = "0";
            // 
            // txbSurplus
            // 
            this.txbSurplus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbSurplus.Cursor = System.Windows.Forms.Cursors.No;
            this.txbSurplus.ForeColor = System.Drawing.Color.Black;
            this.txbSurplus.Location = new System.Drawing.Point(9, 385);
            this.txbSurplus.Name = "txbSurplus";
            this.txbSurplus.ReadOnly = true;
            this.txbSurplus.Size = new System.Drawing.Size(154, 30);
            this.txbSurplus.TabIndex = 0;
            this.txbSurplus.TabStop = false;
            this.txbSurplus.Text = "0";
            // 
            // lbCash
            // 
            this.lbCash.AutoSize = true;
            this.lbCash.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCash.ForeColor = System.Drawing.Color.Black;
            this.lbCash.Location = new System.Drawing.Point(6, 317);
            this.lbCash.Name = "lbCash";
            this.lbCash.Size = new System.Drawing.Size(141, 19);
            this.lbCash.TabIndex = 0;
            this.lbCash.Text = "Nhận của khách:";
            // 
            // txbFinalTotal
            // 
            this.txbFinalTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbFinalTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txbFinalTotal.ForeColor = System.Drawing.Color.Blue;
            this.txbFinalTotal.Location = new System.Drawing.Point(9, 287);
            this.txbFinalTotal.Name = "txbFinalTotal";
            this.txbFinalTotal.ReadOnly = true;
            this.txbFinalTotal.Size = new System.Drawing.Size(154, 30);
            this.txbFinalTotal.TabIndex = 0;
            this.txbFinalTotal.TabStop = false;
            this.txbFinalTotal.Text = "0";
            // 
            // lbFinalTotal
            // 
            this.lbFinalTotal.AutoSize = true;
            this.lbFinalTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFinalTotal.ForeColor = System.Drawing.Color.Black;
            this.lbFinalTotal.Location = new System.Drawing.Point(6, 266);
            this.lbFinalTotal.Name = "lbFinalTotal";
            this.lbFinalTotal.Size = new System.Drawing.Size(116, 19);
            this.lbFinalTotal.TabIndex = 0;
            this.lbFinalTotal.Text = "Còn phải thu:";
            // 
            // txbDiscount
            // 
            this.txbDiscount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbDiscount.Cursor = System.Windows.Forms.Cursors.No;
            this.txbDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbDiscount.Location = new System.Drawing.Point(9, 235);
            this.txbDiscount.Name = "txbDiscount";
            this.txbDiscount.ReadOnly = true;
            this.txbDiscount.Size = new System.Drawing.Size(154, 30);
            this.txbDiscount.TabIndex = 0;
            this.txbDiscount.TabStop = false;
            this.txbDiscount.Text = "0";
            // 
            // lbSurplus
            // 
            this.lbSurplus.AutoSize = true;
            this.lbSurplus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSurplus.ForeColor = System.Drawing.Color.Black;
            this.lbSurplus.Location = new System.Drawing.Point(6, 366);
            this.lbSurplus.Name = "lbSurplus";
            this.lbSurplus.Size = new System.Drawing.Size(78, 19);
            this.lbSurplus.TabIndex = 0;
            this.lbSurplus.Text = "Hoàn lại:";
            // 
            // txbVoucher
            // 
            this.txbVoucher.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbVoucher.Cursor = System.Windows.Forms.Cursors.No;
            this.txbVoucher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbVoucher.Location = new System.Drawing.Point(9, 183);
            this.txbVoucher.Name = "txbVoucher";
            this.txbVoucher.ReadOnly = true;
            this.txbVoucher.Size = new System.Drawing.Size(154, 30);
            this.txbVoucher.TabIndex = 0;
            this.txbVoucher.TabStop = false;
            this.txbVoucher.Text = "0";
            // 
            // lbVoucher
            // 
            this.lbVoucher.AutoSize = true;
            this.lbVoucher.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVoucher.ForeColor = System.Drawing.Color.Black;
            this.lbVoucher.Location = new System.Drawing.Point(6, 164);
            this.lbVoucher.Name = "lbVoucher";
            this.lbVoucher.Size = new System.Drawing.Size(157, 19);
            this.lbVoucher.TabIndex = 0;
            this.lbVoucher.Text = "Voucher / Coupon:";
            // 
            // txbTotalAfterVAT
            // 
            this.txbTotalAfterVAT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbTotalAfterVAT.Cursor = System.Windows.Forms.Cursors.No;
            this.txbTotalAfterVAT.ForeColor = System.Drawing.Color.Black;
            this.txbTotalAfterVAT.Location = new System.Drawing.Point(9, 134);
            this.txbTotalAfterVAT.Name = "txbTotalAfterVAT";
            this.txbTotalAfterVAT.ReadOnly = true;
            this.txbTotalAfterVAT.Size = new System.Drawing.Size(154, 30);
            this.txbTotalAfterVAT.TabIndex = 0;
            this.txbTotalAfterVAT.TabStop = false;
            this.txbTotalAfterVAT.Text = "0";
            // 
            // lbTotalAfterVAT
            // 
            this.lbTotalAfterVAT.AutoSize = true;
            this.lbTotalAfterVAT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalAfterVAT.ForeColor = System.Drawing.Color.Black;
            this.lbTotalAfterVAT.Location = new System.Drawing.Point(6, 115);
            this.lbTotalAfterVAT.Name = "lbTotalAfterVAT";
            this.lbTotalAfterVAT.Size = new System.Drawing.Size(145, 19);
            this.lbTotalAfterVAT.TabIndex = 0;
            this.lbTotalAfterVAT.Text = "Tổng thanh toán:";
            // 
            // txbVAT
            // 
            this.txbVAT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbVAT.Cursor = System.Windows.Forms.Cursors.No;
            this.txbVAT.ForeColor = System.Drawing.Color.Lime;
            this.txbVAT.Location = new System.Drawing.Point(9, 83);
            this.txbVAT.Name = "txbVAT";
            this.txbVAT.ReadOnly = true;
            this.txbVAT.Size = new System.Drawing.Size(154, 30);
            this.txbVAT.TabIndex = 0;
            this.txbVAT.TabStop = false;
            this.txbVAT.Text = "0";
            // 
            // ckbVAT
            // 
            this.ckbVAT.AutoSize = true;
            this.ckbVAT.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbVAT.Checked = true;
            this.ckbVAT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbVAT.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ckbVAT.FlatAppearance.BorderSize = 2;
            this.ckbVAT.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbVAT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbVAT.ForeColor = System.Drawing.Color.Black;
            this.ckbVAT.Location = new System.Drawing.Point(6, 63);
            this.ckbVAT.Name = "ckbVAT";
            this.ckbVAT.Size = new System.Drawing.Size(172, 23);
            this.ckbVAT.TabIndex = 0;
            this.ckbVAT.Text = "Thuế GTGT (10%)";
            this.ckbVAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbVAT.UseVisualStyleBackColor = true;
            // 
            // txbTotal
            // 
            this.txbTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txbTotal.ForeColor = System.Drawing.Color.Black;
            this.txbTotal.Location = new System.Drawing.Point(9, 31);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(154, 30);
            this.txbTotal.TabIndex = 0;
            this.txbTotal.TabStop = false;
            this.txbTotal.Text = "0";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.Black;
            this.lbTotal.Location = new System.Drawing.Point(6, 12);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(98, 19);
            this.lbTotal.TabIndex = 0;
            this.lbTotal.Text = "Thành tiền:";
            // 
            // pnlDiscount
            // 
            this.pnlDiscount.Controls.Add(this.pnlPromotion);
            this.pnlDiscount.Controls.Add(this.pnlVoucher);
            this.pnlDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDiscount.Location = new System.Drawing.Point(424, 28);
            this.pnlDiscount.Name = "pnlDiscount";
            this.pnlDiscount.Size = new System.Drawing.Size(343, 420);
            this.pnlDiscount.TabIndex = 0;
            // 
            // pnlPromotion
            // 
            this.pnlPromotion.AutoScroll = true;
            this.pnlPromotion.Controls.Add(this.grbDiscountList);
            this.pnlPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPromotion.Location = new System.Drawing.Point(0, 213);
            this.pnlPromotion.Name = "pnlPromotion";
            this.pnlPromotion.Size = new System.Drawing.Size(343, 207);
            this.pnlPromotion.TabIndex = 0;
            // 
            // grbDiscountList
            // 
            this.grbDiscountList.AutoSize = true;
            this.grbDiscountList.Controls.Add(this.fpnlDiscountContent);
            this.grbDiscountList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDiscountList.ForeColor = System.Drawing.Color.Blue;
            this.grbDiscountList.Location = new System.Drawing.Point(0, 0);
            this.grbDiscountList.Name = "grbDiscountList";
            this.grbDiscountList.Size = new System.Drawing.Size(343, 207);
            this.grbDiscountList.TabIndex = 0;
            this.grbDiscountList.TabStop = false;
            this.grbDiscountList.Text = "Chương trình khuyến mãi";
            // 
            // fpnlDiscountContent
            // 
            this.fpnlDiscountContent.AutoScroll = true;
            this.fpnlDiscountContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlDiscountContent.ForeColor = System.Drawing.Color.Black;
            this.fpnlDiscountContent.Location = new System.Drawing.Point(3, 26);
            this.fpnlDiscountContent.Name = "fpnlDiscountContent";
            this.fpnlDiscountContent.Size = new System.Drawing.Size(337, 178);
            this.fpnlDiscountContent.TabIndex = 0;
            // 
            // pnlVoucher
            // 
            this.pnlVoucher.AutoScroll = true;
            this.pnlVoucher.Controls.Add(this.grbVoucher);
            this.pnlVoucher.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVoucher.Location = new System.Drawing.Point(0, 0);
            this.pnlVoucher.Name = "pnlVoucher";
            this.pnlVoucher.Size = new System.Drawing.Size(343, 213);
            this.pnlVoucher.TabIndex = 0;
            // 
            // grbVoucher
            // 
            this.grbVoucher.AutoSize = true;
            this.grbVoucher.Controls.Add(this.pnlCoucherContent);
            this.grbVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbVoucher.ForeColor = System.Drawing.Color.Blue;
            this.grbVoucher.Location = new System.Drawing.Point(0, 0);
            this.grbVoucher.Name = "grbVoucher";
            this.grbVoucher.Size = new System.Drawing.Size(343, 213);
            this.grbVoucher.TabIndex = 0;
            this.grbVoucher.TabStop = false;
            this.grbVoucher.Text = "Voucher/Coupon";
            // 
            // pnlCoucherContent
            // 
            this.pnlCoucherContent.AutoSize = true;
            this.pnlCoucherContent.Controls.Add(this.btnVoucherApply);
            this.pnlCoucherContent.Controls.Add(this.txbVoucherContent);
            this.pnlCoucherContent.Controls.Add(this.txbVoucherEnter);
            this.pnlCoucherContent.Controls.Add(this.lbContent);
            this.pnlCoucherContent.Controls.Add(this.lbVoucherEnter);
            this.pnlCoucherContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCoucherContent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCoucherContent.ForeColor = System.Drawing.Color.Black;
            this.pnlCoucherContent.Location = new System.Drawing.Point(3, 26);
            this.pnlCoucherContent.Name = "pnlCoucherContent";
            this.pnlCoucherContent.Size = new System.Drawing.Size(337, 184);
            this.pnlCoucherContent.TabIndex = 0;
            // 
            // btnVoucherApply
            // 
            this.btnVoucherApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoucherApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnVoucherApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoucherApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherApply.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoucherApply.ForeColor = System.Drawing.Color.White;
            this.btnVoucherApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVoucherApply.Location = new System.Drawing.Point(6, 144);
            this.btnVoucherApply.Name = "btnVoucherApply";
            this.btnVoucherApply.Size = new System.Drawing.Size(328, 32);
            this.btnVoucherApply.TabIndex = 0;
            this.btnVoucherApply.TabStop = false;
            this.btnVoucherApply.Text = "Áp dụng";
            this.btnVoucherApply.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoucherApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoucherApply.UseVisualStyleBackColor = false;
            // 
            // txbVoucherContent
            // 
            this.txbVoucherContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbVoucherContent.Cursor = System.Windows.Forms.Cursors.No;
            this.txbVoucherContent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbVoucherContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txbVoucherContent.Location = new System.Drawing.Point(6, 80);
            this.txbVoucherContent.MinimumSize = new System.Drawing.Size(4, 20);
            this.txbVoucherContent.Multiline = true;
            this.txbVoucherContent.Name = "txbVoucherContent";
            this.txbVoucherContent.ReadOnly = true;
            this.txbVoucherContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbVoucherContent.Size = new System.Drawing.Size(328, 58);
            this.txbVoucherContent.TabIndex = 0;
            this.txbVoucherContent.TabStop = false;
            // 
            // txbVoucherEnter
            // 
            this.txbVoucherEnter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbVoucherEnter.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbVoucherEnter.Location = new System.Drawing.Point(6, 31);
            this.txbVoucherEnter.Name = "txbVoucherEnter";
            this.txbVoucherEnter.Size = new System.Drawing.Size(328, 26);
            this.txbVoucherEnter.TabIndex = 0;
            // 
            // lbContent
            // 
            this.lbContent.AutoSize = true;
            this.lbContent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContent.ForeColor = System.Drawing.Color.Black;
            this.lbContent.Location = new System.Drawing.Point(3, 61);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(233, 19);
            this.lbContent.TabIndex = 0;
            this.lbContent.Text = "Nội dung Voucher / Coupon:";
            // 
            // lbVoucherEnter
            // 
            this.lbVoucherEnter.AutoSize = true;
            this.lbVoucherEnter.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVoucherEnter.ForeColor = System.Drawing.Color.Black;
            this.lbVoucherEnter.Location = new System.Drawing.Point(3, 11);
            this.lbVoucherEnter.Name = "lbVoucherEnter";
            this.lbVoucherEnter.Size = new System.Drawing.Size(231, 19);
            this.lbVoucherEnter.TabIndex = 0;
            this.lbVoucherEnter.Text = "Nhập mã Voucher / Coupon:";
            // 
            // FormPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(941, 493);
            this.Controls.Add(this.pnlDiscount);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.pnlBill);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormPay_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlBill.ResumeLayout(false);
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            this.pnlDiscount.ResumeLayout(false);
            this.pnlPromotion.ResumeLayout(false);
            this.pnlPromotion.PerformLayout();
            this.grbDiscountList.ResumeLayout(false);
            this.pnlVoucher.ResumeLayout(false);
            this.pnlVoucher.PerformLayout();
            this.grbVoucher.ResumeLayout(false);
            this.grbVoucher.PerformLayout();
            this.pnlCoucherContent.ResumeLayout(false);
            this.pnlCoucherContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlBill;
        private System.Windows.Forms.ListView lstViewBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Panel pnlDiscount;
        private System.Windows.Forms.Panel pnlPromotion;
        private System.Windows.Forms.GroupBox grbDiscountList;
        private System.Windows.Forms.Panel pnlVoucher;
        private System.Windows.Forms.GroupBox grbVoucher;
        private System.Windows.Forms.Panel pnlCoucherContent;
        private System.Windows.Forms.TextBox txbVoucherContent;
        private System.Windows.Forms.TextBox txbVoucherEnter;
        private System.Windows.Forms.Label lbContent;
        private System.Windows.Forms.Label lbVoucherEnter;
        private System.Windows.Forms.Button btnVoucherApply;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.CheckBox ckbDiscount;
        private System.Windows.Forms.TextBox txbSurplus;
        private System.Windows.Forms.Label lbCash;
        private System.Windows.Forms.TextBox txbFinalTotal;
        private System.Windows.Forms.Label lbFinalTotal;
        private System.Windows.Forms.TextBox txbDiscount;
        private System.Windows.Forms.Label lbSurplus;
        private System.Windows.Forms.TextBox txbVoucher;
        private System.Windows.Forms.Label lbVoucher;
        private System.Windows.Forms.TextBox txbTotalAfterVAT;
        private System.Windows.Forms.Label lbTotalAfterVAT;
        private System.Windows.Forms.TextBox txbVAT;
        private System.Windows.Forms.CheckBox ckbVAT;
        private System.Windows.Forms.TextBox txbCash;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Button btnTempPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.FlowLayoutPanel fpnlDiscountContent;
    }
}