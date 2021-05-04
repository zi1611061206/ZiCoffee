namespace Zi.ZiCoffee.GUIs
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.lbUsernameValidator = new System.Windows.Forms.Label();
            this.pnlLine1 = new System.Windows.Forms.Panel();
            this.picUsername = new System.Windows.Forms.PictureBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.picShowPassword = new System.Windows.Forms.PictureBox();
            this.lbPasswordValidator = new System.Windows.Forms.Label();
            this.pnlLine2 = new System.Windows.Forms.Panel();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picFacebook = new System.Windows.Forms.PictureBox();
            this.picGooglePlus = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlWinState = new System.Windows.Forms.Panel();
            this.pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).BeginInit();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFacebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGooglePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlWinState.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.Transparent;
            this.pnlUsername.Controls.Add(this.lbUsernameValidator);
            this.pnlUsername.Controls.Add(this.pnlLine1);
            this.pnlUsername.Controls.Add(this.picUsername);
            this.pnlUsername.Controls.Add(this.txbUsername);
            this.pnlUsername.Location = new System.Drawing.Point(12, 167);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(376, 67);
            this.pnlUsername.TabIndex = 0;
            // 
            // lbUsernameValidator
            // 
            this.lbUsernameValidator.AutoSize = true;
            this.lbUsernameValidator.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsernameValidator.ForeColor = System.Drawing.Color.Red;
            this.lbUsernameValidator.Location = new System.Drawing.Point(10, 45);
            this.lbUsernameValidator.Name = "lbUsernameValidator";
            this.lbUsernameValidator.Size = new System.Drawing.Size(123, 16);
            this.lbUsernameValidator.TabIndex = 30;
            this.lbUsernameValidator.Text = "Lỗi tên đăng nhập";
            // 
            // pnlLine1
            // 
            this.pnlLine1.BackColor = System.Drawing.Color.White;
            this.pnlLine1.Location = new System.Drawing.Point(13, 41);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Size = new System.Drawing.Size(350, 1);
            this.pnlLine1.TabIndex = 0;
            // 
            // picUsername
            // 
            this.picUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUsername.Image = global::Zi.ZiCoffee.Properties.Resources.ZiWhiteUser;
            this.picUsername.Location = new System.Drawing.Point(13, 11);
            this.picUsername.Name = "picUsername";
            this.picUsername.Size = new System.Drawing.Size(26, 25);
            this.picUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUsername.TabIndex = 2;
            this.picUsername.TabStop = false;
            // 
            // txbUsername
            // 
            this.txbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txbUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbUsername.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.ForeColor = System.Drawing.Color.White;
            this.txbUsername.Location = new System.Drawing.Point(45, 17);
            this.txbUsername.MaxLength = 50;
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(307, 23);
            this.txbUsername.TabIndex = 1;
            this.txbUsername.Text = "TÊN ĐĂNG NHẬP";
            this.txbUsername.Click += new System.EventHandler(this.TxbUsername_Click);
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.Transparent;
            this.pnlPassword.Controls.Add(this.picShowPassword);
            this.pnlPassword.Controls.Add(this.lbPasswordValidator);
            this.pnlPassword.Controls.Add(this.pnlLine2);
            this.pnlPassword.Controls.Add(this.picPassword);
            this.pnlPassword.Controls.Add(this.txbPassword);
            this.pnlPassword.Location = new System.Drawing.Point(12, 240);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(376, 65);
            this.pnlPassword.TabIndex = 1;
            // 
            // picShowPassword
            // 
            this.picShowPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picShowPassword.Image = global::Zi.ZiCoffee.Properties.Resources.ZiWhiteShowPass;
            this.picShowPassword.Location = new System.Drawing.Point(337, 10);
            this.picShowPassword.Name = "picShowPassword";
            this.picShowPassword.Size = new System.Drawing.Size(26, 25);
            this.picShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShowPassword.TabIndex = 32;
            this.picShowPassword.TabStop = false;
            this.picShowPassword.Click += new System.EventHandler(this.PicShowPassword_Click);
            // 
            // lbPasswordValidator
            // 
            this.lbPasswordValidator.AutoSize = true;
            this.lbPasswordValidator.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPasswordValidator.ForeColor = System.Drawing.Color.Red;
            this.lbPasswordValidator.Location = new System.Drawing.Point(10, 45);
            this.lbPasswordValidator.Name = "lbPasswordValidator";
            this.lbPasswordValidator.Size = new System.Drawing.Size(89, 16);
            this.lbPasswordValidator.TabIndex = 31;
            this.lbPasswordValidator.Text = "Lỗi mật khẩu";
            // 
            // pnlLine2
            // 
            this.pnlLine2.BackColor = System.Drawing.Color.White;
            this.pnlLine2.Location = new System.Drawing.Point(13, 41);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(350, 1);
            this.pnlLine2.TabIndex = 4;
            // 
            // picPassword
            // 
            this.picPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPassword.Image = global::Zi.ZiCoffee.Properties.Resources.ZiWhiteLock;
            this.picPassword.Location = new System.Drawing.Point(13, 10);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(26, 25);
            this.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPassword.TabIndex = 3;
            this.picPassword.TabStop = false;
            // 
            // txbPassword
            // 
            this.txbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPassword.ForeColor = System.Drawing.Color.White;
            this.txbPassword.Location = new System.Drawing.Point(45, 16);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(286, 23);
            this.txbPassword.TabIndex = 2;
            this.txbPassword.Text = "Password";
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.Click += new System.EventHandler(this.TxbUsername_Click);
            // 
            // pnlButton
            // 
            this.pnlButton.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton.Controls.Add(this.btnExit);
            this.pnlButton.Controls.Add(this.btnLogin);
            this.pnlButton.Location = new System.Drawing.Point(12, 311);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(376, 52);
            this.pnlButton.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnExit.Location = new System.Drawing.Point(194, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            this.btnExit.MouseLeave += new System.EventHandler(this.BtnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.BtnExit_MouseHover);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnLogin.Location = new System.Drawing.Point(13, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(170, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // picMinimize
            // 
            this.picMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.Image = global::Zi.ZiCoffee.Properties.Resources.minimize1;
            this.picMinimize.Location = new System.Drawing.Point(3, 3);
            this.picMinimize.MaximumSize = new System.Drawing.Size(25, 25);
            this.picMinimize.MinimumSize = new System.Drawing.Size(20, 20);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(20, 20);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinimize.TabIndex = 5;
            this.picMinimize.TabStop = false;
            this.toolTip1.SetToolTip(this.picMinimize, "Minimize");
            this.picMinimize.Click += new System.EventHandler(this.PicMinimize_Click);
            this.picMinimize.MouseLeave += new System.EventHandler(this.PicMinimize_MouseLeave);
            this.picMinimize.MouseHover += new System.EventHandler(this.PicMinimize_MouseHover);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Zi.ZiCoffee.Properties.Resources.close2;
            this.picClose.Location = new System.Drawing.Point(25, 3);
            this.picClose.MaximumSize = new System.Drawing.Size(25, 25);
            this.picClose.MinimumSize = new System.Drawing.Size(20, 20);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 4;
            this.picClose.TabStop = false;
            this.toolTip1.SetToolTip(this.picClose, "Close");
            this.picClose.Click += new System.EventHandler(this.PicClose_Click);
            this.picClose.MouseLeave += new System.EventHandler(this.PicMinimize_MouseLeave);
            this.picClose.MouseHover += new System.EventHandler(this.PicMinimize_MouseHover);
            // 
            // picFacebook
            // 
            this.picFacebook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFacebook.BackColor = System.Drawing.Color.Transparent;
            this.picFacebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFacebook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFacebook.Image = global::Zi.ZiCoffee.Properties.Resources.fb;
            this.picFacebook.Location = new System.Drawing.Point(202, 385);
            this.picFacebook.Name = "picFacebook";
            this.picFacebook.Size = new System.Drawing.Size(60, 60);
            this.picFacebook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFacebook.TabIndex = 29;
            this.picFacebook.TabStop = false;
            // 
            // picGooglePlus
            // 
            this.picGooglePlus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picGooglePlus.BackColor = System.Drawing.Color.Transparent;
            this.picGooglePlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picGooglePlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGooglePlus.Image = global::Zi.ZiCoffee.Properties.Resources.g_;
            this.picGooglePlus.Location = new System.Drawing.Point(130, 385);
            this.picGooglePlus.Name = "picGooglePlus";
            this.picGooglePlus.Size = new System.Drawing.Size(60, 60);
            this.picGooglePlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGooglePlus.TabIndex = 28;
            this.picGooglePlus.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Image = global::Zi.ZiCoffee.Properties.Resources.logox;
            this.picLogo.Location = new System.Drawing.Point(157, 53);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Controls.Add(this.pnlWinState);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(402, 37);
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitle_MouseDown);
            // 
            // pnlWinState
            // 
            this.pnlWinState.BackColor = System.Drawing.Color.Transparent;
            this.pnlWinState.Controls.Add(this.picMinimize);
            this.pnlWinState.Controls.Add(this.picClose);
            this.pnlWinState.Location = new System.Drawing.Point(326, 0);
            this.pnlWinState.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWinState.Name = "pnlWinState";
            this.pnlWinState.Size = new System.Drawing.Size(49, 26);
            this.pnlWinState.TabIndex = 0;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(402, 470);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.picFacebook);
            this.Controls.Add(this.picGooglePlus);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.pnlPassword);
            this.Controls.Add(this.pnlUsername);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).EndInit();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFacebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGooglePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlWinState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picUsername;
        private System.Windows.Forms.Panel pnlLine1;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.Panel pnlLine2;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picGooglePlus;
        private System.Windows.Forms.PictureBox picFacebook;
        private System.Windows.Forms.Panel pnlTitle;
        public System.Windows.Forms.Label lbUsernameValidator;
        public System.Windows.Forms.Label lbPasswordValidator;
        private System.Windows.Forms.Panel pnlWinState;
        private System.Windows.Forms.PictureBox picShowPassword;
    }
}