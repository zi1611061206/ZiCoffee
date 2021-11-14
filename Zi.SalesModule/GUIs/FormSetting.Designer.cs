
namespace Zi.SalesModule.GUIs
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.ipicMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.ipicClose = new FontAwesome.Sharp.IconPictureBox();
            this.pnlFooterBar = new System.Windows.Forms.Panel();
            this.ibtnSave = new FontAwesome.Sharp.IconButton();
            this.ibtnSetDefault = new FontAwesome.Sharp.IconButton();
            this.ibtnCancel = new FontAwesome.Sharp.IconButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlNavigationBar = new System.Windows.Forms.Panel();
            this.ibtnParameter = new FontAwesome.Sharp.IconButton();
            this.ibtnText = new FontAwesome.Sharp.IconButton();
            this.ibtnSize = new FontAwesome.Sharp.IconButton();
            this.ibtnColor = new FontAwesome.Sharp.IconButton();
            this.ibtnLanguage = new FontAwesome.Sharp.IconButton();
            this.ibtnSound = new FontAwesome.Sharp.IconButton();
            this.pnlResizeNav = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ttNote = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicClose)).BeginInit();
            this.pnlFooterBar.SuspendLayout();
            this.pnlNavigationBar.SuspendLayout();
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
            this.pnlFooterBar.Controls.Add(this.ibtnSave);
            this.pnlFooterBar.Controls.Add(this.ibtnSetDefault);
            this.pnlFooterBar.Controls.Add(this.ibtnCancel);
            this.pnlFooterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterBar.Location = new System.Drawing.Point(0, 750);
            this.pnlFooterBar.Name = "pnlFooterBar";
            this.pnlFooterBar.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlFooterBar.Size = new System.Drawing.Size(1400, 50);
            this.pnlFooterBar.TabIndex = 0;
            // 
            // ibtnSave
            // 
            this.ibtnSave.BackColor = System.Drawing.Color.Transparent;
            this.ibtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ibtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtnSave.IconColor = System.Drawing.Color.Black;
            this.ibtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnSave.Location = new System.Drawing.Point(400, 10);
            this.ibtnSave.Name = "ibtnSave";
            this.ibtnSave.Size = new System.Drawing.Size(600, 30);
            this.ibtnSave.TabIndex = 2;
            this.ibtnSave.Text = "Save";
            this.ibtnSave.UseVisualStyleBackColor = false;
            this.ibtnSave.Click += new System.EventHandler(this.IbtnSave_Click);
            this.ibtnSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnSave.MouseLeave += new System.EventHandler(this.Ibtn_MouseLeave);
            this.ibtnSave.MouseHover += new System.EventHandler(this.Ibtn_MouseHover);
            // 
            // ibtnSetDefault
            // 
            this.ibtnSetDefault.BackColor = System.Drawing.Color.Transparent;
            this.ibtnSetDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnSetDefault.Dock = System.Windows.Forms.DockStyle.Left;
            this.ibtnSetDefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnSetDefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnSetDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnSetDefault.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnSetDefault.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ibtnSetDefault.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtnSetDefault.IconColor = System.Drawing.Color.Black;
            this.ibtnSetDefault.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnSetDefault.Location = new System.Drawing.Point(20, 10);
            this.ibtnSetDefault.Name = "ibtnSetDefault";
            this.ibtnSetDefault.Size = new System.Drawing.Size(380, 30);
            this.ibtnSetDefault.TabIndex = 1;
            this.ibtnSetDefault.Text = "Set To Default";
            this.ibtnSetDefault.UseVisualStyleBackColor = false;
            this.ibtnSetDefault.Click += new System.EventHandler(this.IbtnSetDefault_Click);
            this.ibtnSetDefault.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnSetDefault.MouseLeave += new System.EventHandler(this.Ibtn_MouseLeave);
            this.ibtnSetDefault.MouseHover += new System.EventHandler(this.Ibtn_MouseHover);
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
            this.ibtnCancel.Location = new System.Drawing.Point(1000, 10);
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
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1380, 50);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(20, 700);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlNavigationBar
            // 
            this.pnlNavigationBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.pnlNavigationBar.Controls.Add(this.ibtnParameter);
            this.pnlNavigationBar.Controls.Add(this.ibtnText);
            this.pnlNavigationBar.Controls.Add(this.ibtnSize);
            this.pnlNavigationBar.Controls.Add(this.ibtnColor);
            this.pnlNavigationBar.Controls.Add(this.ibtnLanguage);
            this.pnlNavigationBar.Controls.Add(this.ibtnSound);
            this.pnlNavigationBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigationBar.Location = new System.Drawing.Point(0, 50);
            this.pnlNavigationBar.MaximumSize = new System.Drawing.Size(250, 0);
            this.pnlNavigationBar.MinimumSize = new System.Drawing.Size(65, 0);
            this.pnlNavigationBar.Name = "pnlNavigationBar";
            this.pnlNavigationBar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlNavigationBar.Size = new System.Drawing.Size(250, 700);
            this.pnlNavigationBar.TabIndex = 0;
            // 
            // ibtnParameter
            // 
            this.ibtnParameter.BackColor = System.Drawing.Color.Transparent;
            this.ibtnParameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnParameter.FlatAppearance.BorderSize = 0;
            this.ibtnParameter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnParameter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnParameter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnParameter.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnParameter.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ibtnParameter.IconColor = System.Drawing.Color.Gainsboro;
            this.ibtnParameter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnParameter.IconSize = 50;
            this.ibtnParameter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnParameter.Location = new System.Drawing.Point(10, 286);
            this.ibtnParameter.Name = "ibtnParameter";
            this.ibtnParameter.Size = new System.Drawing.Size(240, 50);
            this.ibtnParameter.TabIndex = 5;
            this.ibtnParameter.Text = "Parameter";
            this.ibtnParameter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnParameter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnParameter.UseVisualStyleBackColor = false;
            this.ibtnParameter.Click += new System.EventHandler(this.IbtnParameter_Click);
            this.ibtnParameter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnParameter.MouseLeave += new System.EventHandler(this.BtnNav_MouseLeave);
            this.ibtnParameter.MouseHover += new System.EventHandler(this.BtnNav_MouseHover);
            // 
            // ibtnText
            // 
            this.ibtnText.BackColor = System.Drawing.Color.Transparent;
            this.ibtnText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnText.FlatAppearance.BorderSize = 0;
            this.ibtnText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnText.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnText.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ibtnText.IconColor = System.Drawing.Color.Gainsboro;
            this.ibtnText.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnText.IconSize = 50;
            this.ibtnText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnText.Location = new System.Drawing.Point(10, 230);
            this.ibtnText.Name = "ibtnText";
            this.ibtnText.Size = new System.Drawing.Size(240, 50);
            this.ibtnText.TabIndex = 4;
            this.ibtnText.Text = "Text";
            this.ibtnText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnText.UseVisualStyleBackColor = false;
            this.ibtnText.Click += new System.EventHandler(this.IbtnText_Click);
            this.ibtnText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnText.MouseLeave += new System.EventHandler(this.BtnNav_MouseLeave);
            this.ibtnText.MouseHover += new System.EventHandler(this.BtnNav_MouseHover);
            // 
            // ibtnSize
            // 
            this.ibtnSize.BackColor = System.Drawing.Color.Transparent;
            this.ibtnSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnSize.FlatAppearance.BorderSize = 0;
            this.ibtnSize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnSize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnSize.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnSize.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ibtnSize.IconColor = System.Drawing.Color.Gainsboro;
            this.ibtnSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnSize.IconSize = 50;
            this.ibtnSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnSize.Location = new System.Drawing.Point(10, 174);
            this.ibtnSize.Name = "ibtnSize";
            this.ibtnSize.Size = new System.Drawing.Size(240, 50);
            this.ibtnSize.TabIndex = 3;
            this.ibtnSize.Text = "Size";
            this.ibtnSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnSize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnSize.UseVisualStyleBackColor = false;
            this.ibtnSize.Click += new System.EventHandler(this.IbtnSize_Click);
            this.ibtnSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnSize.MouseLeave += new System.EventHandler(this.BtnNav_MouseLeave);
            this.ibtnSize.MouseHover += new System.EventHandler(this.BtnNav_MouseHover);
            // 
            // ibtnColor
            // 
            this.ibtnColor.BackColor = System.Drawing.Color.Transparent;
            this.ibtnColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnColor.FlatAppearance.BorderSize = 0;
            this.ibtnColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnColor.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnColor.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ibtnColor.IconColor = System.Drawing.Color.Gainsboro;
            this.ibtnColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnColor.IconSize = 50;
            this.ibtnColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnColor.Location = new System.Drawing.Point(10, 6);
            this.ibtnColor.Name = "ibtnColor";
            this.ibtnColor.Size = new System.Drawing.Size(240, 50);
            this.ibtnColor.TabIndex = 0;
            this.ibtnColor.Text = "Color";
            this.ibtnColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnColor.UseVisualStyleBackColor = false;
            this.ibtnColor.Click += new System.EventHandler(this.IbtnColor_Click);
            this.ibtnColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnColor.MouseLeave += new System.EventHandler(this.BtnNav_MouseLeave);
            this.ibtnColor.MouseHover += new System.EventHandler(this.BtnNav_MouseHover);
            // 
            // ibtnLanguage
            // 
            this.ibtnLanguage.BackColor = System.Drawing.Color.Transparent;
            this.ibtnLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnLanguage.FlatAppearance.BorderSize = 0;
            this.ibtnLanguage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnLanguage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnLanguage.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnLanguage.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ibtnLanguage.IconColor = System.Drawing.Color.Gainsboro;
            this.ibtnLanguage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnLanguage.IconSize = 50;
            this.ibtnLanguage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnLanguage.Location = new System.Drawing.Point(10, 118);
            this.ibtnLanguage.Name = "ibtnLanguage";
            this.ibtnLanguage.Size = new System.Drawing.Size(240, 50);
            this.ibtnLanguage.TabIndex = 2;
            this.ibtnLanguage.Text = "Language";
            this.ibtnLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnLanguage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnLanguage.UseVisualStyleBackColor = false;
            this.ibtnLanguage.Click += new System.EventHandler(this.IbtnLanguage_Click);
            this.ibtnLanguage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnLanguage.MouseLeave += new System.EventHandler(this.BtnNav_MouseLeave);
            this.ibtnLanguage.MouseHover += new System.EventHandler(this.BtnNav_MouseHover);
            // 
            // ibtnSound
            // 
            this.ibtnSound.BackColor = System.Drawing.Color.Transparent;
            this.ibtnSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtnSound.FlatAppearance.BorderSize = 0;
            this.ibtnSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ibtnSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ibtnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnSound.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnSound.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ibtnSound.IconColor = System.Drawing.Color.Gainsboro;
            this.ibtnSound.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnSound.IconSize = 50;
            this.ibtnSound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnSound.Location = new System.Drawing.Point(10, 62);
            this.ibtnSound.Name = "ibtnSound";
            this.ibtnSound.Size = new System.Drawing.Size(240, 50);
            this.ibtnSound.TabIndex = 1;
            this.ibtnSound.Text = "Sound";
            this.ibtnSound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnSound.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnSound.UseVisualStyleBackColor = false;
            this.ibtnSound.Click += new System.EventHandler(this.IbtnSound_Click);
            this.ibtnSound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllBtn_MouseDown);
            this.ibtnSound.MouseLeave += new System.EventHandler(this.BtnNav_MouseLeave);
            this.ibtnSound.MouseHover += new System.EventHandler(this.BtnNav_MouseHover);
            // 
            // pnlResizeNav
            // 
            this.pnlResizeNav.BackColor = System.Drawing.Color.Transparent;
            this.pnlResizeNav.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlResizeNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResizeNav.Location = new System.Drawing.Point(250, 50);
            this.pnlResizeNav.Name = "pnlResizeNav";
            this.pnlResizeNav.Size = new System.Drawing.Size(10, 700);
            this.pnlResizeNav.TabIndex = 0;
            this.pnlResizeNav.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            this.pnlResizeNav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseDown);
            this.pnlResizeNav.MouseLeave += new System.EventHandler(this.PnlResize_MouseLeave);
            this.pnlResizeNav.MouseHover += new System.EventHandler(this.PnlResize_MouseHover);
            this.pnlResizeNav.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlResizeNavigation_MouseMove);
            this.pnlResizeNav.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlResize_MouseUp);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(260, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContent.Size = new System.Drawing.Size(1120, 700);
            this.pnlContent.TabIndex = 0;
            this.pnlContent.SizeChanged += new System.EventHandler(this.PnlRoundedCorner_SizeChanged);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlResizeNav);
            this.Controls.Add(this.pnlNavigationBar);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlFooterBar);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSetting";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.SizeChanged += new System.EventHandler(this.FormSetting_SizeChanged);
            this.pnlTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicClose)).EndInit();
            this.pnlFooterBar.ResumeLayout(false);
            this.pnlNavigationBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lbTitle;
        private FontAwesome.Sharp.IconPictureBox ipicMaximize;
        private System.Windows.Forms.PictureBox picLogo;
        private FontAwesome.Sharp.IconPictureBox ipicClose;
        private System.Windows.Forms.Panel pnlFooterBar;
        private FontAwesome.Sharp.IconButton ibtnSave;
        private FontAwesome.Sharp.IconButton ibtnSetDefault;
        private FontAwesome.Sharp.IconButton ibtnCancel;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlNavigationBar;
        private FontAwesome.Sharp.IconButton ibtnColor;
        private FontAwesome.Sharp.IconButton ibtnLanguage;
        private FontAwesome.Sharp.IconButton ibtnSound;
        private FontAwesome.Sharp.IconButton ibtnSize;
        private FontAwesome.Sharp.IconButton ibtnParameter;
        private FontAwesome.Sharp.IconButton ibtnText;
        private System.Windows.Forms.Panel pnlResizeNav;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolTip ttNote;
    }
}