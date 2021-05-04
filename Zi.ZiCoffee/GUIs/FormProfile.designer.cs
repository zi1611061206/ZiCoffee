namespace Zi.ZiCoffee.GUIs
{
    partial class FormProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfile));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlWinState = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.lbBase = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.cpicAvatar = new Zi.ZiCoffee.GUIs.CustomControls.ItemCornerPicture();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.ctxbReEnter = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.ctxbNewPass = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.ctxbOldPass = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.pnlUnder = new System.Windows.Forms.Panel();
            this.lbChangePassResult = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.ctxbDateOfBirth = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.ctxbFullName = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.ctxbPosition = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.ctxbGender = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.ctxbCitizenId = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.ctxbAddress = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.ctxbPhone = new Zi.ZiCoffee.GUIs.CustomControls.CustomTextBox();
            this.pnlTitle.SuspendLayout();
            this.pnlWinState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpicAvatar)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlUnder.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnExit.Location = new System.Drawing.Point(899, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 35);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            this.btnExit.MouseLeave += new System.EventHandler(this.BtnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.BtnExit_MouseHover);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnChangePassword.Location = new System.Drawing.Point(723, 6);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(170, 35);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(7, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(261, 29);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "THÔNG TIN CÁ NHÂN";
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Controls.Add(this.pnlWinState);
            this.pnlTitle.Controls.Add(this.lbTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1083, 50);
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitle_MouseDown);
            // 
            // pnlWinState
            // 
            this.pnlWinState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWinState.Controls.Add(this.picClose);
            this.pnlWinState.Controls.Add(this.picMinimize);
            this.pnlWinState.Location = new System.Drawing.Point(1014, 0);
            this.pnlWinState.Name = "pnlWinState";
            this.pnlWinState.Size = new System.Drawing.Size(54, 28);
            this.pnlWinState.TabIndex = 1;
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Zi.ZiCoffee.Properties.Resources.close2;
            this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picClose.Location = new System.Drawing.Point(29, 0);
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
            // picMinimize
            // 
            this.picMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimize.BackColor = System.Drawing.Color.Transparent;
            this.picMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.Image = global::Zi.ZiCoffee.Properties.Resources.minimize;
            this.picMinimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picMinimize.Location = new System.Drawing.Point(1, -1);
            this.picMinimize.MaximumSize = new System.Drawing.Size(25, 25);
            this.picMinimize.MinimumSize = new System.Drawing.Size(20, 20);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(25, 25);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinimize.TabIndex = 23;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.PicMinimize_Click);
            this.picMinimize.MouseLeave += new System.EventHandler(this.PicClose_MouseLeave);
            this.picMinimize.MouseHover += new System.EventHandler(this.PicClose_MouseHover);
            // 
            // pnlButton
            // 
            this.pnlButton.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton.Controls.Add(this.btnChangePassword);
            this.pnlButton.Controls.Add(this.btnExit);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 617);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1083, 74);
            this.pnlButton.TabIndex = 0;
            // 
            // lbBase
            // 
            this.lbBase.BackColor = System.Drawing.Color.Transparent;
            this.lbBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBase.Location = new System.Drawing.Point(12, 293);
            this.lbBase.Name = "lbBase";
            this.lbBase.Size = new System.Drawing.Size(226, 108);
            this.lbBase.TabIndex = 0;
            this.lbBase.Text = "Mã: 1\r\nTài khoản: Zi\r\nNgày lập: 01/01/1990";
            this.lbBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Controls.Add(this.cpicAvatar);
            this.pnlLeft.Controls.Add(this.lbBase);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(248, 567);
            this.pnlLeft.TabIndex = 0;
            // 
            // cpicAvatar
            // 
            this.cpicAvatar.BackColor = System.Drawing.Color.Transparent;
            this.cpicAvatar.BackgroundImage = global::Zi.ZiCoffee.Properties.Resources.Noavatar;
            this.cpicAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpicAvatar.Image = global::Zi.ZiCoffee.Properties.Resources.Noavatar;
            this.cpicAvatar.InitialImage = global::Zi.ZiCoffee.Properties.Resources.Noavatar;
            this.cpicAvatar.Location = new System.Drawing.Point(12, 8);
            this.cpicAvatar.Name = "cpicAvatar";
            this.cpicAvatar.Size = new System.Drawing.Size(226, 278);
            this.cpicAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpicAvatar.TabIndex = 20;
            this.cpicAvatar.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.ctxbReEnter);
            this.pnlRight.Controls.Add(this.ctxbNewPass);
            this.pnlRight.Controls.Add(this.ctxbOldPass);
            this.pnlRight.Controls.Add(this.pnlUnder);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(713, 50);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(370, 567);
            this.pnlRight.TabIndex = 0;
            this.pnlRight.VisibleChanged += new System.EventHandler(this.PnlRight_VisibleChanged);
            // 
            // ctxbReEnter
            // 
            this.ctxbReEnter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbReEnter.BackColor = System.Drawing.Color.Transparent;
            this.ctxbReEnter.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbReEnter.ForeColor = System.Drawing.Color.Black;
            this.ctxbReEnter.Location = new System.Drawing.Point(13, 194);
            this.ctxbReEnter.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbReEnter.Name = "ctxbReEnter";
            this.ctxbReEnter.Size = new System.Drawing.Size(345, 85);
            this.ctxbReEnter.TabIndex = 5;
            // 
            // 
            // 
            this.ctxbReEnter.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbReEnter.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbReEnter.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbReEnter.ZiBottom.Name = "pnlBottom";
            this.ctxbReEnter.ZiBottom.Size = new System.Drawing.Size(336, 3);
            this.ctxbReEnter.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbReEnter.ZiLabel.AutoSize = true;
            this.ctxbReEnter.ZiLabel.BackColor = System.Drawing.Color.Transparent;
            this.ctxbReEnter.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbReEnter.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbReEnter.ZiLabel.Name = "lbLabel";
            this.ctxbReEnter.ZiLabel.Size = new System.Drawing.Size(168, 22);
            this.ctxbReEnter.ZiLabel.TabIndex = 0;
            this.ctxbReEnter.ZiLabel.Text = "Xác nhận mật khẩu";
            // 
            // 
            // 
            this.ctxbReEnter.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbReEnter.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbReEnter.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbReEnter.ZiLeft.Name = "pnlLeft";
            this.ctxbReEnter.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbReEnter.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbReEnter.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbReEnter.ZiPanel.Controls.Add(this.ctxbReEnter.ZiBottom);
            this.ctxbReEnter.ZiPanel.Controls.Add(this.ctxbReEnter.ZiLeft);
            this.ctxbReEnter.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbReEnter.ZiPanel.Name = "pnlGroupBox";
            this.ctxbReEnter.ZiPanel.Size = new System.Drawing.Size(339, 48);
            this.ctxbReEnter.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbReEnter.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbReEnter.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbReEnter.ZiRight.Location = new System.Drawing.Point(336, 0);
            this.ctxbReEnter.ZiRight.Name = "pnlRight";
            this.ctxbReEnter.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbReEnter.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbReEnter.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbReEnter.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbReEnter.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbReEnter.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbReEnter.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbReEnter.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbReEnter.ZiTextBox.Name = "txbTextContent";
            this.ctxbReEnter.ZiTextBox.PasswordChar = '●';
            this.ctxbReEnter.ZiTextBox.Size = new System.Drawing.Size(321, 23);
            this.ctxbReEnter.ZiTextBox.TabIndex = 0;
            this.ctxbReEnter.ZiTextBox.UseSystemPasswordChar = true;
            // 
            // 
            // 
            this.ctxbReEnter.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbReEnter.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbReEnter.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbReEnter.ZiTop.Name = "pnlTop";
            this.ctxbReEnter.ZiTop.Size = new System.Drawing.Size(333, 3);
            this.ctxbReEnter.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbReEnter.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbReEnter.ZiValidate.AutoSize = true;
            this.ctxbReEnter.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbReEnter.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbReEnter.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbReEnter.ZiValidate.Name = "lbValidator";
            this.ctxbReEnter.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbReEnter.ZiValidate.TabIndex = 0;
            this.ctxbReEnter.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbReEnter.ZiValidate.Visible = false;
            // 
            // ctxbNewPass
            // 
            this.ctxbNewPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbNewPass.BackColor = System.Drawing.Color.Transparent;
            this.ctxbNewPass.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbNewPass.ForeColor = System.Drawing.Color.Black;
            this.ctxbNewPass.Location = new System.Drawing.Point(13, 101);
            this.ctxbNewPass.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbNewPass.Name = "ctxbNewPass";
            this.ctxbNewPass.Size = new System.Drawing.Size(345, 85);
            this.ctxbNewPass.TabIndex = 4;
            // 
            // 
            // 
            this.ctxbNewPass.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbNewPass.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbNewPass.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbNewPass.ZiBottom.Name = "pnlBottom";
            this.ctxbNewPass.ZiBottom.Size = new System.Drawing.Size(336, 3);
            this.ctxbNewPass.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbNewPass.ZiLabel.AutoSize = true;
            this.ctxbNewPass.ZiLabel.BackColor = System.Drawing.Color.Transparent;
            this.ctxbNewPass.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbNewPass.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbNewPass.ZiLabel.Name = "lbLabel";
            this.ctxbNewPass.ZiLabel.Size = new System.Drawing.Size(121, 22);
            this.ctxbNewPass.ZiLabel.TabIndex = 0;
            this.ctxbNewPass.ZiLabel.Text = "Mật khẩu mới";
            // 
            // 
            // 
            this.ctxbNewPass.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbNewPass.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbNewPass.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbNewPass.ZiLeft.Name = "pnlLeft";
            this.ctxbNewPass.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbNewPass.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbNewPass.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbNewPass.ZiPanel.Controls.Add(this.ctxbNewPass.ZiBottom);
            this.ctxbNewPass.ZiPanel.Controls.Add(this.ctxbNewPass.ZiLeft);
            this.ctxbNewPass.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbNewPass.ZiPanel.Name = "pnlGroupBox";
            this.ctxbNewPass.ZiPanel.Size = new System.Drawing.Size(339, 48);
            this.ctxbNewPass.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbNewPass.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbNewPass.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbNewPass.ZiRight.Location = new System.Drawing.Point(336, 0);
            this.ctxbNewPass.ZiRight.Name = "pnlRight";
            this.ctxbNewPass.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbNewPass.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbNewPass.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbNewPass.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbNewPass.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbNewPass.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbNewPass.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbNewPass.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbNewPass.ZiTextBox.Name = "txbTextContent";
            this.ctxbNewPass.ZiTextBox.PasswordChar = '●';
            this.ctxbNewPass.ZiTextBox.Size = new System.Drawing.Size(321, 23);
            this.ctxbNewPass.ZiTextBox.TabIndex = 0;
            this.ctxbNewPass.ZiTextBox.UseSystemPasswordChar = true;
            // 
            // 
            // 
            this.ctxbNewPass.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbNewPass.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbNewPass.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbNewPass.ZiTop.Name = "pnlTop";
            this.ctxbNewPass.ZiTop.Size = new System.Drawing.Size(333, 3);
            this.ctxbNewPass.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbNewPass.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbNewPass.ZiValidate.AutoSize = true;
            this.ctxbNewPass.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbNewPass.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbNewPass.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbNewPass.ZiValidate.Name = "lbValidator";
            this.ctxbNewPass.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbNewPass.ZiValidate.TabIndex = 0;
            this.ctxbNewPass.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbNewPass.ZiValidate.Visible = false;
            // 
            // ctxbOldPass
            // 
            this.ctxbOldPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbOldPass.BackColor = System.Drawing.Color.Transparent;
            this.ctxbOldPass.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbOldPass.ForeColor = System.Drawing.Color.Black;
            this.ctxbOldPass.Location = new System.Drawing.Point(13, 8);
            this.ctxbOldPass.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbOldPass.Name = "ctxbOldPass";
            this.ctxbOldPass.Size = new System.Drawing.Size(345, 85);
            this.ctxbOldPass.TabIndex = 3;
            // 
            // 
            // 
            this.ctxbOldPass.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbOldPass.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbOldPass.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbOldPass.ZiBottom.Name = "pnlBottom";
            this.ctxbOldPass.ZiBottom.Size = new System.Drawing.Size(336, 3);
            this.ctxbOldPass.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbOldPass.ZiLabel.AutoSize = true;
            this.ctxbOldPass.ZiLabel.BackColor = System.Drawing.Color.Transparent;
            this.ctxbOldPass.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbOldPass.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbOldPass.ZiLabel.Name = "lbLabel";
            this.ctxbOldPass.ZiLabel.Size = new System.Drawing.Size(109, 22);
            this.ctxbOldPass.ZiLabel.TabIndex = 3;
            this.ctxbOldPass.ZiLabel.Text = "Mật khẩu cũ";
            // 
            // 
            // 
            this.ctxbOldPass.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbOldPass.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbOldPass.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbOldPass.ZiLeft.Name = "pnlLeft";
            this.ctxbOldPass.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbOldPass.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbOldPass.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbOldPass.ZiPanel.Controls.Add(this.ctxbOldPass.ZiBottom);
            this.ctxbOldPass.ZiPanel.Controls.Add(this.ctxbOldPass.ZiLeft);
            this.ctxbOldPass.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbOldPass.ZiPanel.Name = "pnlGroupBox";
            this.ctxbOldPass.ZiPanel.Size = new System.Drawing.Size(339, 48);
            this.ctxbOldPass.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbOldPass.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbOldPass.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbOldPass.ZiRight.Location = new System.Drawing.Point(336, 0);
            this.ctxbOldPass.ZiRight.Name = "pnlRight";
            this.ctxbOldPass.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbOldPass.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbOldPass.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbOldPass.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbOldPass.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbOldPass.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbOldPass.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbOldPass.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbOldPass.ZiTextBox.Name = "txbTextContent";
            this.ctxbOldPass.ZiTextBox.PasswordChar = '●';
            this.ctxbOldPass.ZiTextBox.Size = new System.Drawing.Size(321, 23);
            this.ctxbOldPass.ZiTextBox.TabIndex = 0;
            this.ctxbOldPass.ZiTextBox.UseSystemPasswordChar = true;
            // 
            // 
            // 
            this.ctxbOldPass.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbOldPass.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbOldPass.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbOldPass.ZiTop.Name = "pnlTop";
            this.ctxbOldPass.ZiTop.Size = new System.Drawing.Size(333, 3);
            this.ctxbOldPass.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbOldPass.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbOldPass.ZiValidate.AutoSize = true;
            this.ctxbOldPass.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbOldPass.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbOldPass.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbOldPass.ZiValidate.Name = "lbValidator";
            this.ctxbOldPass.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbOldPass.ZiValidate.TabIndex = 0;
            this.ctxbOldPass.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbOldPass.ZiValidate.Visible = false;
            // 
            // pnlUnder
            // 
            this.pnlUnder.AutoScroll = true;
            this.pnlUnder.Controls.Add(this.lbChangePassResult);
            this.pnlUnder.Controls.Add(this.btnCancel);
            this.pnlUnder.Controls.Add(this.btnSave);
            this.pnlUnder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUnder.Location = new System.Drawing.Point(0, 293);
            this.pnlUnder.Name = "pnlUnder";
            this.pnlUnder.Size = new System.Drawing.Size(370, 274);
            this.pnlUnder.TabIndex = 0;
            // 
            // lbChangePassResult
            // 
            this.lbChangePassResult.AutoSize = true;
            this.lbChangePassResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbChangePassResult.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangePassResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbChangePassResult.Location = new System.Drawing.Point(8, 61);
            this.lbChangePassResult.Name = "lbChangePassResult";
            this.lbChangePassResult.Size = new System.Drawing.Size(112, 24);
            this.lbChangePassResult.TabIndex = 0;
            this.lbChangePassResult.Text = "Thông báo";
            this.lbChangePassResult.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnCancel.Location = new System.Drawing.Point(186, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnCancel.MouseLeave += new System.EventHandler(this.BtnExit_MouseLeave);
            this.btnCancel.MouseHover += new System.EventHandler(this.BtnExit_MouseHover);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSave.Location = new System.Drawing.Point(10, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.AutoScroll = true;
            this.pnlCenter.BackColor = System.Drawing.Color.Transparent;
            this.pnlCenter.Controls.Add(this.ctxbDateOfBirth);
            this.pnlCenter.Controls.Add(this.ctxbFullName);
            this.pnlCenter.Controls.Add(this.ctxbPosition);
            this.pnlCenter.Controls.Add(this.ctxbGender);
            this.pnlCenter.Controls.Add(this.ctxbCitizenId);
            this.pnlCenter.Controls.Add(this.ctxbAddress);
            this.pnlCenter.Controls.Add(this.ctxbPhone);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(248, 50);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(465, 567);
            this.pnlCenter.TabIndex = 0;
            // 
            // ctxbDateOfBirth
            // 
            this.ctxbDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbDateOfBirth.BackColor = System.Drawing.Color.Transparent;
            this.ctxbDateOfBirth.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbDateOfBirth.ForeColor = System.Drawing.Color.Black;
            this.ctxbDateOfBirth.Location = new System.Drawing.Point(4, 473);
            this.ctxbDateOfBirth.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbDateOfBirth.Name = "ctxbDateOfBirth";
            this.ctxbDateOfBirth.Size = new System.Drawing.Size(454, 85);
            this.ctxbDateOfBirth.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbDateOfBirth.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbDateOfBirth.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbDateOfBirth.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbDateOfBirth.ZiBottom.Name = "pnlBottom";
            this.ctxbDateOfBirth.ZiBottom.Size = new System.Drawing.Size(445, 3);
            this.ctxbDateOfBirth.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbDateOfBirth.ZiLabel.AutoSize = true;
            this.ctxbDateOfBirth.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbDateOfBirth.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbDateOfBirth.ZiLabel.Name = "lbLabel";
            this.ctxbDateOfBirth.ZiLabel.Size = new System.Drawing.Size(95, 22);
            this.ctxbDateOfBirth.ZiLabel.TabIndex = 0;
            this.ctxbDateOfBirth.ZiLabel.Text = "Ngày Sinh";
            // 
            // 
            // 
            this.ctxbDateOfBirth.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbDateOfBirth.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbDateOfBirth.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbDateOfBirth.ZiLeft.Name = "pnlLeft";
            this.ctxbDateOfBirth.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbDateOfBirth.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbDateOfBirth.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbDateOfBirth.ZiPanel.Controls.Add(this.ctxbDateOfBirth.ZiBottom);
            this.ctxbDateOfBirth.ZiPanel.Controls.Add(this.ctxbDateOfBirth.ZiLeft);
            this.ctxbDateOfBirth.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbDateOfBirth.ZiPanel.Name = "pnlGroupBox";
            this.ctxbDateOfBirth.ZiPanel.Size = new System.Drawing.Size(448, 48);
            this.ctxbDateOfBirth.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbDateOfBirth.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbDateOfBirth.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbDateOfBirth.ZiRight.Location = new System.Drawing.Point(445, 0);
            this.ctxbDateOfBirth.ZiRight.Name = "pnlRight";
            this.ctxbDateOfBirth.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbDateOfBirth.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbDateOfBirth.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbDateOfBirth.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbDateOfBirth.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbDateOfBirth.ZiTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ctxbDateOfBirth.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbDateOfBirth.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbDateOfBirth.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbDateOfBirth.ZiTextBox.Multiline = true;
            this.ctxbDateOfBirth.ZiTextBox.Name = "txbTextContent";
            this.ctxbDateOfBirth.ZiTextBox.ReadOnly = true;
            this.ctxbDateOfBirth.ZiTextBox.Size = new System.Drawing.Size(430, 23);
            this.ctxbDateOfBirth.ZiTextBox.TabIndex = 0;
            this.ctxbDateOfBirth.ZiTextBox.TabStop = false;
            // 
            // 
            // 
            this.ctxbDateOfBirth.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbDateOfBirth.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbDateOfBirth.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbDateOfBirth.ZiTop.Name = "pnlTop";
            this.ctxbDateOfBirth.ZiTop.Size = new System.Drawing.Size(442, 3);
            this.ctxbDateOfBirth.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbDateOfBirth.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbDateOfBirth.ZiValidate.AutoSize = true;
            this.ctxbDateOfBirth.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbDateOfBirth.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbDateOfBirth.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbDateOfBirth.ZiValidate.Name = "lbValidator";
            this.ctxbDateOfBirth.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbDateOfBirth.ZiValidate.TabIndex = 0;
            this.ctxbDateOfBirth.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbDateOfBirth.ZiValidate.Visible = false;
            // 
            // ctxbFullName
            // 
            this.ctxbFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbFullName.BackColor = System.Drawing.Color.Transparent;
            this.ctxbFullName.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbFullName.ForeColor = System.Drawing.Color.Black;
            this.ctxbFullName.Location = new System.Drawing.Point(7, 8);
            this.ctxbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbFullName.Name = "ctxbFullName";
            this.ctxbFullName.Size = new System.Drawing.Size(454, 85);
            this.ctxbFullName.TabIndex = 0;
            this.ctxbFullName.TabStop = false;
            // 
            // 
            // 
            this.ctxbFullName.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbFullName.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbFullName.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbFullName.ZiBottom.Name = "pnlBottom";
            this.ctxbFullName.ZiBottom.Size = new System.Drawing.Size(445, 3);
            this.ctxbFullName.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbFullName.ZiLabel.AutoSize = true;
            this.ctxbFullName.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbFullName.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbFullName.ZiLabel.Name = "lbLabel";
            this.ctxbFullName.ZiLabel.Size = new System.Drawing.Size(65, 22);
            this.ctxbFullName.ZiLabel.TabIndex = 0;
            this.ctxbFullName.ZiLabel.Text = "Họ tên";
            // 
            // 
            // 
            this.ctxbFullName.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbFullName.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbFullName.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbFullName.ZiLeft.Name = "pnlLeft";
            this.ctxbFullName.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbFullName.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbFullName.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbFullName.ZiPanel.Controls.Add(this.ctxbFullName.ZiBottom);
            this.ctxbFullName.ZiPanel.Controls.Add(this.ctxbFullName.ZiLeft);
            this.ctxbFullName.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbFullName.ZiPanel.Name = "pnlGroupBox";
            this.ctxbFullName.ZiPanel.Size = new System.Drawing.Size(448, 48);
            this.ctxbFullName.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbFullName.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbFullName.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbFullName.ZiRight.Location = new System.Drawing.Point(445, 0);
            this.ctxbFullName.ZiRight.Name = "pnlRight";
            this.ctxbFullName.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbFullName.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbFullName.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbFullName.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbFullName.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbFullName.ZiTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ctxbFullName.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbFullName.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbFullName.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbFullName.ZiTextBox.Multiline = true;
            this.ctxbFullName.ZiTextBox.Name = "txbTextContent";
            this.ctxbFullName.ZiTextBox.ReadOnly = true;
            this.ctxbFullName.ZiTextBox.Size = new System.Drawing.Size(430, 23);
            this.ctxbFullName.ZiTextBox.TabIndex = 0;
            this.ctxbFullName.ZiTextBox.UseSystemPasswordChar = true;
            // 
            // 
            // 
            this.ctxbFullName.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbFullName.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbFullName.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbFullName.ZiTop.Name = "pnlTop";
            this.ctxbFullName.ZiTop.Size = new System.Drawing.Size(442, 3);
            this.ctxbFullName.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbFullName.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbFullName.ZiValidate.AutoSize = true;
            this.ctxbFullName.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbFullName.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbFullName.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbFullName.ZiValidate.Name = "lbValidator";
            this.ctxbFullName.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbFullName.ZiValidate.TabIndex = 0;
            this.ctxbFullName.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbFullName.ZiValidate.Visible = false;
            // 
            // ctxbPosition
            // 
            this.ctxbPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbPosition.BackColor = System.Drawing.Color.Transparent;
            this.ctxbPosition.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbPosition.ForeColor = System.Drawing.Color.Black;
            this.ctxbPosition.Location = new System.Drawing.Point(7, 101);
            this.ctxbPosition.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbPosition.Name = "ctxbPosition";
            this.ctxbPosition.Size = new System.Drawing.Size(215, 85);
            this.ctxbPosition.TabIndex = 0;
            this.ctxbPosition.TabStop = false;
            // 
            // 
            // 
            this.ctxbPosition.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbPosition.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbPosition.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbPosition.ZiBottom.Name = "pnlBottom";
            this.ctxbPosition.ZiBottom.Size = new System.Drawing.Size(206, 3);
            this.ctxbPosition.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPosition.ZiLabel.AutoSize = true;
            this.ctxbPosition.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbPosition.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbPosition.ZiLabel.Name = "lbLabel";
            this.ctxbPosition.ZiLabel.Size = new System.Drawing.Size(81, 22);
            this.ctxbPosition.ZiLabel.TabIndex = 0;
            this.ctxbPosition.ZiLabel.Text = "Chức vụ";
            // 
            // 
            // 
            this.ctxbPosition.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbPosition.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbPosition.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbPosition.ZiLeft.Name = "pnlLeft";
            this.ctxbPosition.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbPosition.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPosition.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbPosition.ZiPanel.Controls.Add(this.ctxbPosition.ZiBottom);
            this.ctxbPosition.ZiPanel.Controls.Add(this.ctxbPosition.ZiLeft);
            this.ctxbPosition.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbPosition.ZiPanel.Name = "pnlGroupBox";
            this.ctxbPosition.ZiPanel.Size = new System.Drawing.Size(209, 48);
            this.ctxbPosition.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPosition.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbPosition.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbPosition.ZiRight.Location = new System.Drawing.Point(206, 0);
            this.ctxbPosition.ZiRight.Name = "pnlRight";
            this.ctxbPosition.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbPosition.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPosition.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbPosition.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbPosition.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbPosition.ZiTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ctxbPosition.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbPosition.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbPosition.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbPosition.ZiTextBox.Multiline = true;
            this.ctxbPosition.ZiTextBox.Name = "txbTextContent";
            this.ctxbPosition.ZiTextBox.ReadOnly = true;
            this.ctxbPosition.ZiTextBox.Size = new System.Drawing.Size(191, 23);
            this.ctxbPosition.ZiTextBox.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPosition.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbPosition.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbPosition.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbPosition.ZiTop.Name = "pnlTop";
            this.ctxbPosition.ZiTop.Size = new System.Drawing.Size(203, 3);
            this.ctxbPosition.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPosition.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbPosition.ZiValidate.AutoSize = true;
            this.ctxbPosition.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbPosition.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbPosition.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbPosition.ZiValidate.Name = "lbValidator";
            this.ctxbPosition.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbPosition.ZiValidate.TabIndex = 0;
            this.ctxbPosition.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbPosition.ZiValidate.Visible = false;
            // 
            // ctxbGender
            // 
            this.ctxbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbGender.BackColor = System.Drawing.Color.Transparent;
            this.ctxbGender.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbGender.ForeColor = System.Drawing.Color.Black;
            this.ctxbGender.Location = new System.Drawing.Point(240, 101);
            this.ctxbGender.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbGender.Name = "ctxbGender";
            this.ctxbGender.Size = new System.Drawing.Size(218, 85);
            this.ctxbGender.TabIndex = 0;
            this.ctxbGender.TabStop = false;
            // 
            // 
            // 
            this.ctxbGender.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbGender.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbGender.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbGender.ZiBottom.Name = "pnlBottom";
            this.ctxbGender.ZiBottom.Size = new System.Drawing.Size(209, 3);
            this.ctxbGender.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbGender.ZiLabel.AutoSize = true;
            this.ctxbGender.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbGender.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbGender.ZiLabel.Name = "lbLabel";
            this.ctxbGender.ZiLabel.Size = new System.Drawing.Size(81, 22);
            this.ctxbGender.ZiLabel.TabIndex = 0;
            this.ctxbGender.ZiLabel.Text = "Giới tính";
            // 
            // 
            // 
            this.ctxbGender.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbGender.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbGender.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbGender.ZiLeft.Name = "pnlLeft";
            this.ctxbGender.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbGender.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbGender.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbGender.ZiPanel.Controls.Add(this.ctxbGender.ZiBottom);
            this.ctxbGender.ZiPanel.Controls.Add(this.ctxbGender.ZiLeft);
            this.ctxbGender.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbGender.ZiPanel.Name = "pnlGroupBox";
            this.ctxbGender.ZiPanel.Size = new System.Drawing.Size(212, 48);
            this.ctxbGender.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbGender.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbGender.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbGender.ZiRight.Location = new System.Drawing.Point(209, 0);
            this.ctxbGender.ZiRight.Name = "pnlRight";
            this.ctxbGender.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbGender.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbGender.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbGender.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbGender.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbGender.ZiTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ctxbGender.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbGender.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbGender.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbGender.ZiTextBox.Multiline = true;
            this.ctxbGender.ZiTextBox.Name = "txbTextContent";
            this.ctxbGender.ZiTextBox.ReadOnly = true;
            this.ctxbGender.ZiTextBox.Size = new System.Drawing.Size(194, 23);
            this.ctxbGender.ZiTextBox.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbGender.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbGender.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbGender.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbGender.ZiTop.Name = "pnlTop";
            this.ctxbGender.ZiTop.Size = new System.Drawing.Size(206, 3);
            this.ctxbGender.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbGender.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbGender.ZiValidate.AutoSize = true;
            this.ctxbGender.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbGender.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbGender.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbGender.ZiValidate.Name = "lbValidator";
            this.ctxbGender.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbGender.ZiValidate.TabIndex = 0;
            this.ctxbGender.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbGender.ZiValidate.Visible = false;
            // 
            // ctxbCitizenId
            // 
            this.ctxbCitizenId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbCitizenId.BackColor = System.Drawing.Color.Transparent;
            this.ctxbCitizenId.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbCitizenId.ForeColor = System.Drawing.Color.Black;
            this.ctxbCitizenId.Location = new System.Drawing.Point(4, 194);
            this.ctxbCitizenId.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbCitizenId.Name = "ctxbCitizenId";
            this.ctxbCitizenId.Size = new System.Drawing.Size(454, 85);
            this.ctxbCitizenId.TabIndex = 0;
            this.ctxbCitizenId.TabStop = false;
            // 
            // 
            // 
            this.ctxbCitizenId.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbCitizenId.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbCitizenId.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbCitizenId.ZiBottom.Name = "pnlBottom";
            this.ctxbCitizenId.ZiBottom.Size = new System.Drawing.Size(445, 3);
            this.ctxbCitizenId.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbCitizenId.ZiLabel.AutoSize = true;
            this.ctxbCitizenId.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbCitizenId.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbCitizenId.ZiLabel.Name = "lbLabel";
            this.ctxbCitizenId.ZiLabel.Size = new System.Drawing.Size(137, 22);
            this.ctxbCitizenId.ZiLabel.TabIndex = 0;
            this.ctxbCitizenId.ZiLabel.Text = "CMND / CCCD";
            // 
            // 
            // 
            this.ctxbCitizenId.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbCitizenId.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbCitizenId.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbCitizenId.ZiLeft.Name = "pnlLeft";
            this.ctxbCitizenId.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbCitizenId.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbCitizenId.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbCitizenId.ZiPanel.Controls.Add(this.ctxbCitizenId.ZiBottom);
            this.ctxbCitizenId.ZiPanel.Controls.Add(this.ctxbCitizenId.ZiLeft);
            this.ctxbCitizenId.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbCitizenId.ZiPanel.Name = "pnlGroupBox";
            this.ctxbCitizenId.ZiPanel.Size = new System.Drawing.Size(448, 48);
            this.ctxbCitizenId.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbCitizenId.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbCitizenId.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbCitizenId.ZiRight.Location = new System.Drawing.Point(445, 0);
            this.ctxbCitizenId.ZiRight.Name = "pnlRight";
            this.ctxbCitizenId.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbCitizenId.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbCitizenId.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbCitizenId.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbCitizenId.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbCitizenId.ZiTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ctxbCitizenId.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbCitizenId.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbCitizenId.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbCitizenId.ZiTextBox.Multiline = true;
            this.ctxbCitizenId.ZiTextBox.Name = "txbTextContent";
            this.ctxbCitizenId.ZiTextBox.ReadOnly = true;
            this.ctxbCitizenId.ZiTextBox.Size = new System.Drawing.Size(430, 23);
            this.ctxbCitizenId.ZiTextBox.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbCitizenId.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbCitizenId.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbCitizenId.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbCitizenId.ZiTop.Name = "pnlTop";
            this.ctxbCitizenId.ZiTop.Size = new System.Drawing.Size(442, 3);
            this.ctxbCitizenId.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbCitizenId.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbCitizenId.ZiValidate.AutoSize = true;
            this.ctxbCitizenId.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbCitizenId.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbCitizenId.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbCitizenId.ZiValidate.Name = "lbValidator";
            this.ctxbCitizenId.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbCitizenId.ZiValidate.TabIndex = 0;
            this.ctxbCitizenId.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbCitizenId.ZiValidate.Visible = false;
            // 
            // ctxbAddress
            // 
            this.ctxbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbAddress.BackColor = System.Drawing.Color.Transparent;
            this.ctxbAddress.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbAddress.ForeColor = System.Drawing.Color.Black;
            this.ctxbAddress.Location = new System.Drawing.Point(4, 287);
            this.ctxbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbAddress.Name = "ctxbAddress";
            this.ctxbAddress.Size = new System.Drawing.Size(454, 85);
            this.ctxbAddress.TabIndex = 0;
            this.ctxbAddress.TabStop = false;
            // 
            // 
            // 
            this.ctxbAddress.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbAddress.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbAddress.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbAddress.ZiBottom.Name = "pnlBottom";
            this.ctxbAddress.ZiBottom.Size = new System.Drawing.Size(445, 3);
            this.ctxbAddress.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbAddress.ZiLabel.AutoSize = true;
            this.ctxbAddress.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbAddress.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbAddress.ZiLabel.Name = "lbLabel";
            this.ctxbAddress.ZiLabel.Size = new System.Drawing.Size(67, 22);
            this.ctxbAddress.ZiLabel.TabIndex = 0;
            this.ctxbAddress.ZiLabel.Text = "Địa chỉ";
            // 
            // 
            // 
            this.ctxbAddress.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbAddress.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbAddress.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbAddress.ZiLeft.Name = "pnlLeft";
            this.ctxbAddress.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbAddress.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbAddress.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbAddress.ZiPanel.Controls.Add(this.ctxbAddress.ZiBottom);
            this.ctxbAddress.ZiPanel.Controls.Add(this.ctxbAddress.ZiLeft);
            this.ctxbAddress.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbAddress.ZiPanel.Name = "pnlGroupBox";
            this.ctxbAddress.ZiPanel.Size = new System.Drawing.Size(448, 48);
            this.ctxbAddress.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbAddress.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbAddress.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbAddress.ZiRight.Location = new System.Drawing.Point(445, 0);
            this.ctxbAddress.ZiRight.Name = "pnlRight";
            this.ctxbAddress.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbAddress.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbAddress.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbAddress.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbAddress.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbAddress.ZiTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ctxbAddress.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbAddress.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbAddress.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbAddress.ZiTextBox.Multiline = true;
            this.ctxbAddress.ZiTextBox.Name = "txbTextContent";
            this.ctxbAddress.ZiTextBox.ReadOnly = true;
            this.ctxbAddress.ZiTextBox.Size = new System.Drawing.Size(430, 23);
            this.ctxbAddress.ZiTextBox.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbAddress.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbAddress.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbAddress.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbAddress.ZiTop.Name = "pnlTop";
            this.ctxbAddress.ZiTop.Size = new System.Drawing.Size(442, 3);
            this.ctxbAddress.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbAddress.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbAddress.ZiValidate.AutoSize = true;
            this.ctxbAddress.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbAddress.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbAddress.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbAddress.ZiValidate.Name = "lbValidator";
            this.ctxbAddress.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbAddress.ZiValidate.TabIndex = 0;
            this.ctxbAddress.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbAddress.ZiValidate.Visible = false;
            // 
            // ctxbPhone
            // 
            this.ctxbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbPhone.BackColor = System.Drawing.Color.Transparent;
            this.ctxbPhone.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbPhone.ForeColor = System.Drawing.Color.Black;
            this.ctxbPhone.Location = new System.Drawing.Point(4, 380);
            this.ctxbPhone.Margin = new System.Windows.Forms.Padding(4);
            this.ctxbPhone.Name = "ctxbPhone";
            this.ctxbPhone.Size = new System.Drawing.Size(454, 85);
            this.ctxbPhone.TabIndex = 0;
            this.ctxbPhone.TabStop = false;
            // 
            // 
            // 
            this.ctxbPhone.ZiBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbPhone.ZiBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxbPhone.ZiBottom.Location = new System.Drawing.Point(3, 45);
            this.ctxbPhone.ZiBottom.Name = "pnlBottom";
            this.ctxbPhone.ZiBottom.Size = new System.Drawing.Size(445, 3);
            this.ctxbPhone.ZiBottom.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPhone.ZiLabel.AutoSize = true;
            this.ctxbPhone.ZiLabel.ForeColor = System.Drawing.Color.White;
            this.ctxbPhone.ZiLabel.Location = new System.Drawing.Point(25, 4);
            this.ctxbPhone.ZiLabel.Name = "lbLabel";
            this.ctxbPhone.ZiLabel.Size = new System.Drawing.Size(120, 22);
            this.ctxbPhone.ZiLabel.TabIndex = 0;
            this.ctxbPhone.ZiLabel.Text = "Số điện thoại";
            // 
            // 
            // 
            this.ctxbPhone.ZiLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbPhone.ZiLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctxbPhone.ZiLeft.Location = new System.Drawing.Point(0, 0);
            this.ctxbPhone.ZiLeft.Name = "pnlLeft";
            this.ctxbPhone.ZiLeft.Size = new System.Drawing.Size(3, 48);
            this.ctxbPhone.ZiLeft.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPhone.ZiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbPhone.ZiPanel.Controls.Add(this.ctxbPhone.ZiBottom);
            this.ctxbPhone.ZiPanel.Controls.Add(this.ctxbPhone.ZiLeft);
            this.ctxbPhone.ZiPanel.Location = new System.Drawing.Point(3, 15);
            this.ctxbPhone.ZiPanel.Name = "pnlGroupBox";
            this.ctxbPhone.ZiPanel.Size = new System.Drawing.Size(448, 48);
            this.ctxbPhone.ZiPanel.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPhone.ZiRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbPhone.ZiRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctxbPhone.ZiRight.Location = new System.Drawing.Point(445, 0);
            this.ctxbPhone.ZiRight.Name = "pnlRight";
            this.ctxbPhone.ZiRight.Size = new System.Drawing.Size(3, 45);
            this.ctxbPhone.ZiRight.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPhone.ZiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctxbPhone.ZiTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ctxbPhone.ZiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctxbPhone.ZiTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ctxbPhone.ZiTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbPhone.ZiTextBox.ForeColor = System.Drawing.Color.White;
            this.ctxbPhone.ZiTextBox.Location = new System.Drawing.Point(9, 18);
            this.ctxbPhone.ZiTextBox.Multiline = true;
            this.ctxbPhone.ZiTextBox.Name = "txbTextContent";
            this.ctxbPhone.ZiTextBox.ReadOnly = true;
            this.ctxbPhone.ZiTextBox.Size = new System.Drawing.Size(430, 23);
            this.ctxbPhone.ZiTextBox.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPhone.ZiTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ctxbPhone.ZiTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctxbPhone.ZiTop.Location = new System.Drawing.Point(3, 0);
            this.ctxbPhone.ZiTop.Name = "pnlTop";
            this.ctxbPhone.ZiTop.Size = new System.Drawing.Size(442, 3);
            this.ctxbPhone.ZiTop.TabIndex = 0;
            // 
            // 
            // 
            this.ctxbPhone.ZiValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctxbPhone.ZiValidate.AutoSize = true;
            this.ctxbPhone.ZiValidate.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxbPhone.ZiValidate.ForeColor = System.Drawing.Color.Red;
            this.ctxbPhone.ZiValidate.Location = new System.Drawing.Point(12, 66);
            this.ctxbPhone.ZiValidate.Name = "lbValidator";
            this.ctxbPhone.ZiValidate.Size = new System.Drawing.Size(89, 16);
            this.ctxbPhone.ZiValidate.TabIndex = 0;
            this.ctxbPhone.ZiValidate.Text = "Lỗi nhập liệu";
            this.ctxbPhone.ZiValidate.Visible = false;
            // 
            // formProfile
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1083, 691);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formProfile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin cá nhân";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormProfile_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlWinState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpicAvatar)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlUnder.ResumeLayout(false);
            this.pnlUnder.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Panel pnlWinState;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMinimize;
        private CustomControls.ItemCornerPicture cpicAvatar;
        private System.Windows.Forms.Label lbBase;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlUnder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private CustomControls.CustomTextBox ctxbFullName;
        private CustomControls.CustomTextBox ctxbDateOfBirth;
        private CustomControls.CustomTextBox ctxbPosition;
        private CustomControls.CustomTextBox ctxbGender;
        private CustomControls.CustomTextBox ctxbCitizenId;
        private CustomControls.CustomTextBox ctxbAddress;
        private CustomControls.CustomTextBox ctxbPhone;
        public CustomControls.CustomTextBox ctxbReEnter;
        public CustomControls.CustomTextBox ctxbNewPass;
        public CustomControls.CustomTextBox ctxbOldPass;
        private System.Windows.Forms.Label lbChangePassResult;
    }
}