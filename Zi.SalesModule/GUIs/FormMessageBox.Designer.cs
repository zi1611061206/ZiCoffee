
namespace Zi.SalesModule.GUIs
{
    partial class FormMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox));
            this.pnlIcon = new System.Windows.Forms.Panel();
            this.ipicMessageStatus = new FontAwesome.Sharp.IconPictureBox();
            this.ttNote = new System.Windows.Forms.ToolTip(this.components);
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.ipicButton3 = new FontAwesome.Sharp.IconPictureBox();
            this.ipicButton2 = new FontAwesome.Sharp.IconPictureBox();
            this.ipicButton1 = new FontAwesome.Sharp.IconPictureBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lbContent = new System.Windows.Forms.Label();
            this.timerAppearence = new System.Windows.Forms.Timer(this.components);
            this.pnlIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicMessageStatus)).BeginInit();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicButton1)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlIcon
            // 
            this.pnlIcon.BackColor = System.Drawing.Color.Transparent;
            this.pnlIcon.Controls.Add(this.ipicMessageStatus);
            this.pnlIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIcon.Location = new System.Drawing.Point(0, 0);
            this.pnlIcon.Name = "pnlIcon";
            this.pnlIcon.Size = new System.Drawing.Size(50, 90);
            this.pnlIcon.TabIndex = 0;
            this.pnlIcon.Visible = false;
            // 
            // ipicMessageStatus
            // 
            this.ipicMessageStatus.BackColor = System.Drawing.Color.Transparent;
            this.ipicMessageStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicMessageStatus.ForeColor = System.Drawing.Color.Lime;
            this.ipicMessageStatus.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicMessageStatus.IconColor = System.Drawing.Color.Lime;
            this.ipicMessageStatus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicMessageStatus.IconSize = 30;
            this.ipicMessageStatus.Location = new System.Drawing.Point(0, 30);
            this.ipicMessageStatus.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.ipicMessageStatus.Name = "ipicMessageStatus";
            this.ipicMessageStatus.Size = new System.Drawing.Size(30, 30);
            this.ipicMessageStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicMessageStatus.TabIndex = 7;
            this.ipicMessageStatus.TabStop = false;
            this.ipicMessageStatus.Visible = false;
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.Transparent;
            this.pnlOptions.Controls.Add(this.ipicButton3);
            this.pnlOptions.Controls.Add(this.ipicButton2);
            this.pnlOptions.Controls.Add(this.ipicButton1);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOptions.Location = new System.Drawing.Point(450, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(50, 90);
            this.pnlOptions.TabIndex = 0;
            this.pnlOptions.Visible = false;
            // 
            // ipicButton3
            // 
            this.ipicButton3.BackColor = System.Drawing.Color.Transparent;
            this.ipicButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicButton3.ForeColor = System.Drawing.Color.Red;
            this.ipicButton3.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicButton3.IconColor = System.Drawing.Color.Red;
            this.ipicButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicButton3.IconSize = 30;
            this.ipicButton3.Location = new System.Drawing.Point(0, 60);
            this.ipicButton3.Name = "ipicButton3";
            this.ipicButton3.Size = new System.Drawing.Size(30, 30);
            this.ipicButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicButton3.TabIndex = 9;
            this.ipicButton3.TabStop = false;
            this.ipicButton3.Visible = false;
            this.ipicButton3.Click += new System.EventHandler(this.IpicButton_Click);
            // 
            // ipicButton2
            // 
            this.ipicButton2.BackColor = System.Drawing.Color.Transparent;
            this.ipicButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.ipicButton2.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.ipicButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicButton2.IconSize = 30;
            this.ipicButton2.Location = new System.Drawing.Point(0, 30);
            this.ipicButton2.Name = "ipicButton2";
            this.ipicButton2.Size = new System.Drawing.Size(30, 30);
            this.ipicButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicButton2.TabIndex = 8;
            this.ipicButton2.TabStop = false;
            this.ipicButton2.Visible = false;
            this.ipicButton2.Click += new System.EventHandler(this.IpicButton_Click);
            // 
            // ipicButton1
            // 
            this.ipicButton1.BackColor = System.Drawing.Color.Transparent;
            this.ipicButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipicButton1.ForeColor = System.Drawing.Color.Lime;
            this.ipicButton1.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ipicButton1.IconColor = System.Drawing.Color.Lime;
            this.ipicButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicButton1.IconSize = 30;
            this.ipicButton1.Location = new System.Drawing.Point(0, 0);
            this.ipicButton1.Name = "ipicButton1";
            this.ipicButton1.Size = new System.Drawing.Size(30, 30);
            this.ipicButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ipicButton1.TabIndex = 6;
            this.ipicButton1.TabStop = false;
            this.ipicButton1.Visible = false;
            this.ipicButton1.Click += new System.EventHandler(this.IpicButton_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Controls.Add(this.lbTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(50, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(400, 40);
            this.pnlTitle.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.lbTitle.Size = new System.Drawing.Size(400, 40);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Title";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbTitle_MouseDown);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.lbContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(50, 40);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(400, 50);
            this.pnlContent.TabIndex = 0;
            // 
            // lbContent
            // 
            this.lbContent.AutoSize = true;
            this.lbContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbContent.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContent.Location = new System.Drawing.Point(0, 0);
            this.lbContent.MaximumSize = new System.Drawing.Size(410, 0);
            this.lbContent.MinimumSize = new System.Drawing.Size(0, 40);
            this.lbContent.Name = "lbContent";
            this.lbContent.Padding = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.lbContent.Size = new System.Drawing.Size(169, 40);
            this.lbContent.TabIndex = 0;
            this.lbContent.Text = "Content Message";
            // 
            // timerAppearence
            // 
            this.timerAppearence.Interval = 3000;
            this.timerAppearence.Tick += new System.EventHandler(this.TimerAppearence_Tick);
            // 
            // FormMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(500, 90);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlIcon);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMessageBox";
            this.TopMost = true;
            this.SizeChanged += new System.EventHandler(this.FormMessageBox_SizeChanged);
            this.pnlIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicMessageStatus)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipicButton1)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlIcon;
        private System.Windows.Forms.ToolTip ttNote;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lbContent;
        private FontAwesome.Sharp.IconPictureBox ipicButton1;
        private FontAwesome.Sharp.IconPictureBox ipicMessageStatus;
        private FontAwesome.Sharp.IconPictureBox ipicButton2;
        private FontAwesome.Sharp.IconPictureBox ipicButton3;
        private System.Windows.Forms.Timer timerAppearence;
    }
}