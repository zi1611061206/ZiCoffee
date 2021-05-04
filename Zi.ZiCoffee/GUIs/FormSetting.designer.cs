namespace Zi.ZiCoffee.GUIs
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlWinState = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnlFormOptions = new System.Windows.Forms.Panel();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cldPicker = new System.Windows.Forms.ColorDialog();
            this.pnlLanguage = new System.Windows.Forms.Panel();
            this.picFlag = new System.Windows.Forms.PictureBox();
            this.pnlLanguageTitle = new System.Windows.Forms.Panel();
            this.lbLanguageTitle = new System.Windows.Forms.Label();
            this.pnlSound = new System.Windows.Forms.Panel();
            this.pnlSoundChecker = new System.Windows.Forms.Panel();
            this.ckbSoundGreeting = new System.Windows.Forms.CheckBox();
            this.ckbSoundAppearance = new System.Windows.Forms.CheckBox();
            this.ckbSoundClick = new System.Windows.Forms.CheckBox();
            this.ckbSoundBye = new System.Windows.Forms.CheckBox();
            this.ckbSoundNotification = new System.Windows.Forms.CheckBox();
            this.ckbSoundTrack = new System.Windows.Forms.CheckBox();
            this.pnlSoundTitle = new System.Windows.Forms.Panel();
            this.lbSoundTitle = new System.Windows.Forms.Label();
            this.pnlTheme = new System.Windows.Forms.Panel();
            this.pnlThemeSelector = new System.Windows.Forms.Panel();
            this.picSelected = new System.Windows.Forms.PictureBox();
            this.cpicLightTheme = new Zi.ZiCoffee.GUIs.CustomControls.ItemCornerPicture();
            this.cpicDarkTheme = new Zi.ZiCoffee.GUIs.CustomControls.ItemCornerPicture();
            this.pnlThemeTitle = new System.Windows.Forms.Panel();
            this.lbThemeTitle = new System.Windows.Forms.Label();
            this.pnlObject = new System.Windows.Forms.Panel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.pnlObjectModifier = new System.Windows.Forms.Panel();
            this.pnlSubFore = new System.Windows.Forms.Panel();
            this.pnlMainFore = new System.Windows.Forms.Panel();
            this.pnlOffBackColor = new System.Windows.Forms.Panel();
            this.pnlOnBackColor = new System.Windows.Forms.Panel();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.pnlObjectTitle = new System.Windows.Forms.Panel();
            this.cbObjectSelector = new System.Windows.Forms.ComboBox();
            this.lbObjectTitle = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmsLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlTitle.SuspendLayout();
            this.pnlWinState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.pnlFormOptions.SuspendLayout();
            this.pnlLanguage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFlag)).BeginInit();
            this.pnlLanguageTitle.SuspendLayout();
            this.pnlSound.SuspendLayout();
            this.pnlSoundChecker.SuspendLayout();
            this.pnlSoundTitle.SuspendLayout();
            this.pnlTheme.SuspendLayout();
            this.pnlThemeSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpicLightTheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpicDarkTheme)).BeginInit();
            this.pnlThemeTitle.SuspendLayout();
            this.pnlObject.SuspendLayout();
            this.pnlObjectModifier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.pnlObjectTitle.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlTitle.Size = new System.Drawing.Size(938, 35);
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitle_MouseDown);
            // 
            // pnlWinState
            // 
            this.pnlWinState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWinState.BackColor = System.Drawing.Color.Transparent;
            this.pnlWinState.Controls.Add(this.picClose);
            this.pnlWinState.Location = new System.Drawing.Point(900, 0);
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
            this.lbTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lbTitle.Size = new System.Drawing.Size(150, 35);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Cài đặt";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFormOptions
            // 
            this.pnlFormOptions.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormOptions.Controls.Add(this.btnDefault);
            this.pnlFormOptions.Controls.Add(this.btnCancel);
            this.pnlFormOptions.Controls.Add(this.btnSave);
            this.pnlFormOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFormOptions.ForeColor = System.Drawing.Color.White;
            this.pnlFormOptions.Location = new System.Drawing.Point(0, 382);
            this.pnlFormOptions.Name = "pnlFormOptions";
            this.pnlFormOptions.Size = new System.Drawing.Size(938, 50);
            this.pnlFormOptions.TabIndex = 0;
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefault.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnDefault.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnDefault.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDefault.Location = new System.Drawing.Point(12, 3);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(228, 35);
            this.btnDefault.TabIndex = 0;
            this.btnDefault.TabStop = false;
            this.btnDefault.Text = "Đặt lại mặc định";
            this.btnDefault.UseVisualStyleBackColor = false;
            this.btnDefault.Click += new System.EventHandler(this.BtnDefault_Click);
            this.btnDefault.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllButton_MouseDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(755, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 35);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllButton_MouseDown);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(579, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllButton_MouseDown);
            // 
            // pnlLanguage
            // 
            this.pnlLanguage.Controls.Add(this.picFlag);
            this.pnlLanguage.Controls.Add(this.pnlLanguageTitle);
            this.pnlLanguage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLanguage.Location = new System.Drawing.Point(0, 223);
            this.pnlLanguage.Name = "pnlLanguage";
            this.pnlLanguage.Size = new System.Drawing.Size(238, 84);
            this.pnlLanguage.TabIndex = 0;
            // 
            // picFlag
            // 
            this.picFlag.BackColor = System.Drawing.Color.Transparent;
            this.picFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFlag.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picFlag.Image = global::Zi.ZiCoffee.Properties.Resources.vi;
            this.picFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picFlag.Location = new System.Drawing.Point(9, 44);
            this.picFlag.Name = "picFlag";
            this.picFlag.Size = new System.Drawing.Size(70, 35);
            this.picFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFlag.TabIndex = 23;
            this.picFlag.TabStop = false;
            this.picFlag.Click += new System.EventHandler(this.PicFlag_Click);
            // 
            // pnlLanguageTitle
            // 
            this.pnlLanguageTitle.Controls.Add(this.lbLanguageTitle);
            this.pnlLanguageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLanguageTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlLanguageTitle.Name = "pnlLanguageTitle";
            this.pnlLanguageTitle.Size = new System.Drawing.Size(238, 38);
            this.pnlLanguageTitle.TabIndex = 0;
            // 
            // lbLanguageTitle
            // 
            this.lbLanguageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbLanguageTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLanguageTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbLanguageTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLanguageTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbLanguageTitle.Location = new System.Drawing.Point(0, 0);
            this.lbLanguageTitle.Name = "lbLanguageTitle";
            this.lbLanguageTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lbLanguageTitle.Size = new System.Drawing.Size(110, 38);
            this.lbLanguageTitle.TabIndex = 0;
            this.lbLanguageTitle.Text = "Ngôn ngữ";
            // 
            // pnlSound
            // 
            this.pnlSound.BackColor = System.Drawing.Color.Transparent;
            this.pnlSound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSound.Controls.Add(this.pnlSoundChecker);
            this.pnlSound.Controls.Add(this.pnlSoundTitle);
            this.pnlSound.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSound.ForeColor = System.Drawing.Color.White;
            this.pnlSound.Location = new System.Drawing.Point(698, 35);
            this.pnlSound.Name = "pnlSound";
            this.pnlSound.Size = new System.Drawing.Size(240, 347);
            this.pnlSound.TabIndex = 0;
            // 
            // pnlSoundChecker
            // 
            this.pnlSoundChecker.AutoScroll = true;
            this.pnlSoundChecker.Controls.Add(this.ckbSoundGreeting);
            this.pnlSoundChecker.Controls.Add(this.pnlLanguage);
            this.pnlSoundChecker.Controls.Add(this.ckbSoundAppearance);
            this.pnlSoundChecker.Controls.Add(this.ckbSoundClick);
            this.pnlSoundChecker.Controls.Add(this.ckbSoundBye);
            this.pnlSoundChecker.Controls.Add(this.ckbSoundNotification);
            this.pnlSoundChecker.Controls.Add(this.ckbSoundTrack);
            this.pnlSoundChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSoundChecker.Location = new System.Drawing.Point(0, 38);
            this.pnlSoundChecker.Name = "pnlSoundChecker";
            this.pnlSoundChecker.Size = new System.Drawing.Size(238, 307);
            this.pnlSoundChecker.TabIndex = 0;
            // 
            // ckbSoundGreeting
            // 
            this.ckbSoundGreeting.AutoSize = true;
            this.ckbSoundGreeting.Checked = true;
            this.ckbSoundGreeting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSoundGreeting.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ckbSoundGreeting.FlatAppearance.BorderSize = 2;
            this.ckbSoundGreeting.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbSoundGreeting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSoundGreeting.ForeColor = System.Drawing.Color.White;
            this.ckbSoundGreeting.Location = new System.Drawing.Point(5, 6);
            this.ckbSoundGreeting.Name = "ckbSoundGreeting";
            this.ckbSoundGreeting.Size = new System.Drawing.Size(199, 27);
            this.ckbSoundGreeting.TabIndex = 0;
            this.ckbSoundGreeting.Text = "Tiếng chào bắt đầu";
            this.ckbSoundGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbSoundGreeting.UseVisualStyleBackColor = true;
            this.ckbSoundGreeting.CheckedChanged += new System.EventHandler(this.AllCheckBoxSound_CheckedChanged);
            this.ckbSoundGreeting.MouseLeave += new System.EventHandler(this.AllCheckBoxSound_MouseLeave);
            this.ckbSoundGreeting.MouseHover += new System.EventHandler(this.AllCheckBoxSound_MouseHover);
            // 
            // ckbSoundAppearance
            // 
            this.ckbSoundAppearance.AutoSize = true;
            this.ckbSoundAppearance.Checked = true;
            this.ckbSoundAppearance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSoundAppearance.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ckbSoundAppearance.FlatAppearance.BorderSize = 2;
            this.ckbSoundAppearance.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbSoundAppearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSoundAppearance.ForeColor = System.Drawing.Color.White;
            this.ckbSoundAppearance.Location = new System.Drawing.Point(5, 118);
            this.ckbSoundAppearance.Name = "ckbSoundAppearance";
            this.ckbSoundAppearance.Size = new System.Drawing.Size(197, 27);
            this.ckbSoundAppearance.TabIndex = 0;
            this.ckbSoundAppearance.Text = "Âm thanh xuất hiện";
            this.ckbSoundAppearance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbSoundAppearance.UseVisualStyleBackColor = true;
            this.ckbSoundAppearance.CheckedChanged += new System.EventHandler(this.AllCheckBoxSound_CheckedChanged);
            this.ckbSoundAppearance.MouseLeave += new System.EventHandler(this.AllCheckBoxSound_MouseLeave);
            this.ckbSoundAppearance.MouseHover += new System.EventHandler(this.AllCheckBoxSound_MouseHover);
            // 
            // ckbSoundClick
            // 
            this.ckbSoundClick.AutoSize = true;
            this.ckbSoundClick.Checked = true;
            this.ckbSoundClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSoundClick.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ckbSoundClick.FlatAppearance.BorderSize = 2;
            this.ckbSoundClick.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbSoundClick.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSoundClick.ForeColor = System.Drawing.Color.White;
            this.ckbSoundClick.Location = new System.Drawing.Point(5, 90);
            this.ckbSoundClick.Name = "ckbSoundClick";
            this.ckbSoundClick.Size = new System.Drawing.Size(194, 27);
            this.ckbSoundClick.TabIndex = 0;
            this.ckbSoundClick.Text = "Âm thanh nhấn nút";
            this.ckbSoundClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbSoundClick.UseVisualStyleBackColor = true;
            this.ckbSoundClick.CheckedChanged += new System.EventHandler(this.AllCheckBoxSound_CheckedChanged);
            this.ckbSoundClick.MouseLeave += new System.EventHandler(this.AllCheckBoxSound_MouseLeave);
            this.ckbSoundClick.MouseHover += new System.EventHandler(this.AllCheckBoxSound_MouseHover);
            // 
            // ckbSoundBye
            // 
            this.ckbSoundBye.AutoSize = true;
            this.ckbSoundBye.Checked = true;
            this.ckbSoundBye.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSoundBye.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ckbSoundBye.FlatAppearance.BorderSize = 2;
            this.ckbSoundBye.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbSoundBye.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSoundBye.ForeColor = System.Drawing.Color.White;
            this.ckbSoundBye.Location = new System.Drawing.Point(5, 34);
            this.ckbSoundBye.Name = "ckbSoundBye";
            this.ckbSoundBye.Size = new System.Drawing.Size(156, 27);
            this.ckbSoundBye.TabIndex = 0;
            this.ckbSoundBye.Text = "Tiếng tạm biệt";
            this.ckbSoundBye.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbSoundBye.UseVisualStyleBackColor = true;
            this.ckbSoundBye.CheckedChanged += new System.EventHandler(this.AllCheckBoxSound_CheckedChanged);
            this.ckbSoundBye.MouseLeave += new System.EventHandler(this.AllCheckBoxSound_MouseLeave);
            this.ckbSoundBye.MouseHover += new System.EventHandler(this.AllCheckBoxSound_MouseHover);
            // 
            // ckbSoundNotification
            // 
            this.ckbSoundNotification.AutoSize = true;
            this.ckbSoundNotification.Checked = true;
            this.ckbSoundNotification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSoundNotification.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ckbSoundNotification.FlatAppearance.BorderSize = 2;
            this.ckbSoundNotification.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbSoundNotification.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSoundNotification.ForeColor = System.Drawing.Color.White;
            this.ckbSoundNotification.Location = new System.Drawing.Point(5, 146);
            this.ckbSoundNotification.Name = "ckbSoundNotification";
            this.ckbSoundNotification.Size = new System.Drawing.Size(207, 27);
            this.ckbSoundNotification.TabIndex = 0;
            this.ckbSoundNotification.Text = "Âm thanh thông báo";
            this.ckbSoundNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbSoundNotification.UseVisualStyleBackColor = true;
            this.ckbSoundNotification.CheckedChanged += new System.EventHandler(this.AllCheckBoxSound_CheckedChanged);
            this.ckbSoundNotification.MouseLeave += new System.EventHandler(this.AllCheckBoxSound_MouseLeave);
            this.ckbSoundNotification.MouseHover += new System.EventHandler(this.AllCheckBoxSound_MouseHover);
            // 
            // ckbSoundTrack
            // 
            this.ckbSoundTrack.AutoSize = true;
            this.ckbSoundTrack.Checked = true;
            this.ckbSoundTrack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSoundTrack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ckbSoundTrack.FlatAppearance.BorderSize = 2;
            this.ckbSoundTrack.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbSoundTrack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSoundTrack.ForeColor = System.Drawing.Color.White;
            this.ckbSoundTrack.Location = new System.Drawing.Point(5, 62);
            this.ckbSoundTrack.Name = "ckbSoundTrack";
            this.ckbSoundTrack.Size = new System.Drawing.Size(113, 27);
            this.ckbSoundTrack.TabIndex = 0;
            this.ckbSoundTrack.Text = "Nhạc nền";
            this.ckbSoundTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbSoundTrack.UseVisualStyleBackColor = true;
            this.ckbSoundTrack.CheckedChanged += new System.EventHandler(this.AllCheckBoxSound_CheckedChanged);
            this.ckbSoundTrack.MouseLeave += new System.EventHandler(this.AllCheckBoxSound_MouseLeave);
            this.ckbSoundTrack.MouseHover += new System.EventHandler(this.AllCheckBoxSound_MouseHover);
            // 
            // pnlSoundTitle
            // 
            this.pnlSoundTitle.Controls.Add(this.lbSoundTitle);
            this.pnlSoundTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSoundTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlSoundTitle.Name = "pnlSoundTitle";
            this.pnlSoundTitle.Size = new System.Drawing.Size(238, 38);
            this.pnlSoundTitle.TabIndex = 0;
            // 
            // lbSoundTitle
            // 
            this.lbSoundTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbSoundTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSoundTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbSoundTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoundTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSoundTitle.Location = new System.Drawing.Point(0, 0);
            this.lbSoundTitle.Name = "lbSoundTitle";
            this.lbSoundTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lbSoundTitle.Size = new System.Drawing.Size(107, 38);
            this.lbSoundTitle.TabIndex = 0;
            this.lbSoundTitle.Text = "Âm thanh";
            // 
            // pnlTheme
            // 
            this.pnlTheme.BackColor = System.Drawing.Color.Transparent;
            this.pnlTheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTheme.Controls.Add(this.pnlThemeSelector);
            this.pnlTheme.Controls.Add(this.pnlThemeTitle);
            this.pnlTheme.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTheme.ForeColor = System.Drawing.Color.White;
            this.pnlTheme.Location = new System.Drawing.Point(0, 35);
            this.pnlTheme.Name = "pnlTheme";
            this.pnlTheme.Size = new System.Drawing.Size(241, 347);
            this.pnlTheme.TabIndex = 0;
            // 
            // pnlThemeSelector
            // 
            this.pnlThemeSelector.AutoScroll = true;
            this.pnlThemeSelector.Controls.Add(this.picSelected);
            this.pnlThemeSelector.Controls.Add(this.cpicLightTheme);
            this.pnlThemeSelector.Controls.Add(this.cpicDarkTheme);
            this.pnlThemeSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThemeSelector.Location = new System.Drawing.Point(0, 38);
            this.pnlThemeSelector.Name = "pnlThemeSelector";
            this.pnlThemeSelector.Size = new System.Drawing.Size(239, 307);
            this.pnlThemeSelector.TabIndex = 0;
            // 
            // picSelected
            // 
            this.picSelected.BackColor = System.Drawing.Color.Transparent;
            this.picSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSelected.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picSelected.Image = global::Zi.ZiCoffee.Properties.Resources.check;
            this.picSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picSelected.Location = new System.Drawing.Point(12, 10);
            this.picSelected.MaximumSize = new System.Drawing.Size(25, 25);
            this.picSelected.MinimumSize = new System.Drawing.Size(20, 20);
            this.picSelected.Name = "picSelected";
            this.picSelected.Size = new System.Drawing.Size(25, 25);
            this.picSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelected.TabIndex = 22;
            this.picSelected.TabStop = false;
            // 
            // cpicLightTheme
            // 
            this.cpicLightTheme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cpicLightTheme.Image = global::Zi.ZiCoffee.Properties.Resources.ZiLightThemeSample;
            this.cpicLightTheme.Location = new System.Drawing.Point(3, 134);
            this.cpicLightTheme.Name = "cpicLightTheme";
            this.cpicLightTheme.Size = new System.Drawing.Size(231, 125);
            this.cpicLightTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpicLightTheme.TabIndex = 1;
            this.cpicLightTheme.TabStop = false;
            this.cpicLightTheme.Click += new System.EventHandler(this.PicThemeSelector_Click);
            // 
            // cpicDarkTheme
            // 
            this.cpicDarkTheme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cpicDarkTheme.Image = global::Zi.ZiCoffee.Properties.Resources.ZiDarkThemeSample;
            this.cpicDarkTheme.Location = new System.Drawing.Point(3, 3);
            this.cpicDarkTheme.Name = "cpicDarkTheme";
            this.cpicDarkTheme.Size = new System.Drawing.Size(231, 125);
            this.cpicDarkTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpicDarkTheme.TabIndex = 0;
            this.cpicDarkTheme.TabStop = false;
            this.cpicDarkTheme.Click += new System.EventHandler(this.PicThemeSelector_Click);
            // 
            // pnlThemeTitle
            // 
            this.pnlThemeTitle.Controls.Add(this.lbThemeTitle);
            this.pnlThemeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThemeTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlThemeTitle.Name = "pnlThemeTitle";
            this.pnlThemeTitle.Size = new System.Drawing.Size(239, 38);
            this.pnlThemeTitle.TabIndex = 0;
            // 
            // lbThemeTitle
            // 
            this.lbThemeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbThemeTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbThemeTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbThemeTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThemeTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbThemeTitle.Location = new System.Drawing.Point(0, 0);
            this.lbThemeTitle.Name = "lbThemeTitle";
            this.lbThemeTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lbThemeTitle.Size = new System.Drawing.Size(176, 38);
            this.lbThemeTitle.TabIndex = 0;
            this.lbThemeTitle.Text = "Giao diện chủ đề";
            // 
            // pnlObject
            // 
            this.pnlObject.AutoSize = true;
            this.pnlObject.BackColor = System.Drawing.Color.Transparent;
            this.pnlObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObject.Controls.Add(this.pnlPreview);
            this.pnlObject.Controls.Add(this.pnlObjectModifier);
            this.pnlObject.Controls.Add(this.pnlObjectTitle);
            this.pnlObject.Controls.Add(this.panel5);
            this.pnlObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObject.ForeColor = System.Drawing.Color.White;
            this.pnlObject.Location = new System.Drawing.Point(241, 35);
            this.pnlObject.Name = "pnlObject";
            this.pnlObject.Size = new System.Drawing.Size(457, 347);
            this.pnlObject.TabIndex = 0;
            // 
            // pnlPreview
            // 
            this.pnlPreview.AutoScroll = true;
            this.pnlPreview.AutoSize = true;
            this.pnlPreview.BackColor = System.Drawing.Color.Transparent;
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreview.Location = new System.Drawing.Point(0, 38);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(382, 307);
            this.pnlPreview.TabIndex = 2;
            // 
            // pnlObjectModifier
            // 
            this.pnlObjectModifier.Controls.Add(this.pnlSubFore);
            this.pnlObjectModifier.Controls.Add(this.pnlMainFore);
            this.pnlObjectModifier.Controls.Add(this.pnlOffBackColor);
            this.pnlObjectModifier.Controls.Add(this.pnlOnBackColor);
            this.pnlObjectModifier.Controls.Add(this.nudHeight);
            this.pnlObjectModifier.Controls.Add(this.nudWidth);
            this.pnlObjectModifier.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlObjectModifier.Location = new System.Drawing.Point(382, 38);
            this.pnlObjectModifier.Name = "pnlObjectModifier";
            this.pnlObjectModifier.Size = new System.Drawing.Size(73, 307);
            this.pnlObjectModifier.TabIndex = 0;
            // 
            // pnlSubFore
            // 
            this.pnlSubFore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSubFore.BackColor = System.Drawing.Color.White;
            this.pnlSubFore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSubFore.Location = new System.Drawing.Point(8, 182);
            this.pnlSubFore.Name = "pnlSubFore";
            this.pnlSubFore.Size = new System.Drawing.Size(60, 30);
            this.pnlSubFore.TabIndex = 0;
            this.pnlSubFore.Click += new System.EventHandler(this.PnlOnBackColor_Click);
            // 
            // pnlMainFore
            // 
            this.pnlMainFore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainFore.BackColor = System.Drawing.Color.White;
            this.pnlMainFore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMainFore.Location = new System.Drawing.Point(8, 146);
            this.pnlMainFore.Name = "pnlMainFore";
            this.pnlMainFore.Size = new System.Drawing.Size(60, 30);
            this.pnlMainFore.TabIndex = 0;
            this.pnlMainFore.Click += new System.EventHandler(this.PnlOnBackColor_Click);
            // 
            // pnlOffBackColor
            // 
            this.pnlOffBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOffBackColor.BackColor = System.Drawing.Color.White;
            this.pnlOffBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOffBackColor.Location = new System.Drawing.Point(8, 110);
            this.pnlOffBackColor.Name = "pnlOffBackColor";
            this.pnlOffBackColor.Size = new System.Drawing.Size(60, 30);
            this.pnlOffBackColor.TabIndex = 0;
            this.pnlOffBackColor.Click += new System.EventHandler(this.PnlOnBackColor_Click);
            // 
            // pnlOnBackColor
            // 
            this.pnlOnBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOnBackColor.BackColor = System.Drawing.Color.White;
            this.pnlOnBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOnBackColor.Location = new System.Drawing.Point(8, 74);
            this.pnlOnBackColor.Name = "pnlOnBackColor";
            this.pnlOnBackColor.Size = new System.Drawing.Size(60, 30);
            this.pnlOnBackColor.TabIndex = 0;
            this.pnlOnBackColor.Click += new System.EventHandler(this.PnlOnBackColor_Click);
            // 
            // nudHeight
            // 
            this.nudHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudHeight.Location = new System.Drawing.Point(8, 37);
            this.nudHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(60, 30);
            this.nudHeight.TabIndex = 0;
            this.nudHeight.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            this.nudWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWidth.Location = new System.Drawing.Point(8, 5);
            this.nudWidth.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(60, 30);
            this.nudWidth.TabIndex = 0;
            this.nudWidth.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // pnlObjectTitle
            // 
            this.pnlObjectTitle.Controls.Add(this.cbObjectSelector);
            this.pnlObjectTitle.Controls.Add(this.lbObjectTitle);
            this.pnlObjectTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlObjectTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlObjectTitle.Name = "pnlObjectTitle";
            this.pnlObjectTitle.Size = new System.Drawing.Size(455, 38);
            this.pnlObjectTitle.TabIndex = 0;
            // 
            // cbObjectSelector
            // 
            this.cbObjectSelector.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbObjectSelector.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbObjectSelector.BackColor = System.Drawing.SystemColors.Window;
            this.cbObjectSelector.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbObjectSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbObjectSelector.FormattingEnabled = true;
            this.cbObjectSelector.Items.AddRange(new object[] {
            "Bàn",
            "Dịch vụ"});
            this.cbObjectSelector.Location = new System.Drawing.Point(221, 0);
            this.cbObjectSelector.Name = "cbObjectSelector";
            this.cbObjectSelector.Size = new System.Drawing.Size(234, 32);
            this.cbObjectSelector.TabIndex = 0;
            this.cbObjectSelector.TabStop = false;
            this.cbObjectSelector.SelectedIndexChanged += new System.EventHandler(this.CbObjectSelector_SelectedIndexChanged);
            // 
            // lbObjectTitle
            // 
            this.lbObjectTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbObjectTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbObjectTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbObjectTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObjectTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbObjectTitle.Location = new System.Drawing.Point(0, 0);
            this.lbObjectTitle.Name = "lbObjectTitle";
            this.lbObjectTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lbObjectTitle.Size = new System.Drawing.Size(210, 38);
            this.lbObjectTitle.TabIndex = 0;
            this.lbObjectTitle.Text = "Tùy chỉnh đối tượng";
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(455, 0);
            this.panel5.TabIndex = 0;
            // 
            // cmsLanguage
            // 
            this.cmsLanguage.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLanguage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLanguage.Name = "cmsLanguage";
            this.cmsLanguage.Size = new System.Drawing.Size(61, 4);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(938, 432);
            this.Controls.Add(this.pnlObject);
            this.Controls.Add(this.pnlTheme);
            this.Controls.Add(this.pnlSound);
            this.Controls.Add(this.pnlFormOptions);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.Opacity = 0.98D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formSetting";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlWinState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.pnlFormOptions.ResumeLayout(false);
            this.pnlLanguage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFlag)).EndInit();
            this.pnlLanguageTitle.ResumeLayout(false);
            this.pnlSound.ResumeLayout(false);
            this.pnlSoundChecker.ResumeLayout(false);
            this.pnlSoundChecker.PerformLayout();
            this.pnlSoundTitle.ResumeLayout(false);
            this.pnlTheme.ResumeLayout(false);
            this.pnlThemeSelector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpicLightTheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpicDarkTheme)).EndInit();
            this.pnlThemeTitle.ResumeLayout(false);
            this.pnlObject.ResumeLayout(false);
            this.pnlObject.PerformLayout();
            this.pnlObjectModifier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.pnlObjectTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnlFormOptions;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColorDialog cldPicker;
        private System.Windows.Forms.Panel pnlLanguage;
        private System.Windows.Forms.Panel pnlWinState;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel pnlLanguageTitle;
        private System.Windows.Forms.Label lbLanguageTitle;
        private System.Windows.Forms.Panel pnlSound;
        private System.Windows.Forms.Panel pnlSoundChecker;
        private System.Windows.Forms.CheckBox ckbSoundGreeting;
        private System.Windows.Forms.CheckBox ckbSoundAppearance;
        private System.Windows.Forms.CheckBox ckbSoundClick;
        private System.Windows.Forms.CheckBox ckbSoundBye;
        private System.Windows.Forms.CheckBox ckbSoundNotification;
        private System.Windows.Forms.CheckBox ckbSoundTrack;
        private System.Windows.Forms.Panel pnlSoundTitle;
        private System.Windows.Forms.Label lbSoundTitle;
        private System.Windows.Forms.Panel pnlTheme;
        private System.Windows.Forms.Panel pnlThemeSelector;
        private CustomControls.ItemCornerPicture cpicLightTheme;
        private CustomControls.ItemCornerPicture cpicDarkTheme;
        private System.Windows.Forms.Panel pnlThemeTitle;
        private System.Windows.Forms.Label lbThemeTitle;
        private System.Windows.Forms.Panel pnlObject;
        private System.Windows.Forms.Panel pnlObjectModifier;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Panel pnlObjectTitle;
        private System.Windows.Forms.Label lbObjectTitle;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlMainFore;
        private System.Windows.Forms.Panel pnlOffBackColor;
        private System.Windows.Forms.Panel pnlOnBackColor;
        private System.Windows.Forms.ComboBox cbObjectSelector;
        private System.Windows.Forms.PictureBox picSelected;
        private System.Windows.Forms.ContextMenuStrip cmsLanguage;
        private System.Windows.Forms.PictureBox picFlag;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Panel pnlSubFore;
    }
}