namespace Zi.ZiCoffee.GUIs
{
    partial class FormSplash3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSplash3));
            this.timerLoader = new System.Windows.Forms.Timer(this.components);
            this.picGif = new System.Windows.Forms.PictureBox();
            this.lbCopyrightWarning = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlLoadBar = new System.Windows.Forms.Panel();
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.pnlTrans = new System.Windows.Forms.Panel();
            this.timerKillForm = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlLoadBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerLoader
            // 
            this.timerLoader.Enabled = true;
            this.timerLoader.Tick += new System.EventHandler(this.TimerLoader_Tick);
            // 
            // picGif
            // 
            this.picGif.BackColor = System.Drawing.Color.Transparent;
            this.picGif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGif.Image = global::Zi.ZiCoffee.Properties.Resources.loading;
            this.picGif.Location = new System.Drawing.Point(0, 0);
            this.picGif.Name = "picGif";
            this.picGif.Size = new System.Drawing.Size(742, 464);
            this.picGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGif.TabIndex = 11;
            this.picGif.TabStop = false;
            // 
            // lbCopyrightWarning
            // 
            this.lbCopyrightWarning.BackColor = System.Drawing.Color.Transparent;
            this.lbCopyrightWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCopyrightWarning.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyrightWarning.ForeColor = System.Drawing.Color.White;
            this.lbCopyrightWarning.Location = new System.Drawing.Point(12, 153);
            this.lbCopyrightWarning.Name = "lbCopyrightWarning";
            this.lbCopyrightWarning.Size = new System.Drawing.Size(313, 220);
            this.lbCopyrightWarning.TabIndex = 13;
            this.lbCopyrightWarning.Text = "Cảnh báo bản quyền";
            // 
            // lbCopyright
            // 
            this.lbCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lbCopyright.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCopyright.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.ForeColor = System.Drawing.Color.White;
            this.lbCopyright.Location = new System.Drawing.Point(373, 422);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(357, 29);
            this.lbCopyright.TabIndex = 14;
            this.lbCopyright.Text = "Bản quyền";
            this.lbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbVersion.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.ForeColor = System.Drawing.Color.White;
            this.lbVersion.Location = new System.Drawing.Point(8, 427);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(83, 19);
            this.lbVersion.TabIndex = 15;
            this.lbVersion.Text = "Phiên bản";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::Zi.ZiCoffee.Properties.Resources.logox;
            this.picLogo.Location = new System.Drawing.Point(12, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 150);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 12;
            this.picLogo.TabStop = false;
            // 
            // pnlLoadBar
            // 
            this.pnlLoadBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoadBar.Controls.Add(this.pnlProcess);
            this.pnlLoadBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLoadBar.Location = new System.Drawing.Point(0, 454);
            this.pnlLoadBar.Name = "pnlLoadBar";
            this.pnlLoadBar.Size = new System.Drawing.Size(742, 10);
            this.pnlLoadBar.TabIndex = 16;
            // 
            // pnlProcess
            // 
            this.pnlProcess.BackColor = System.Drawing.Color.Lime;
            this.pnlProcess.Location = new System.Drawing.Point(0, 0);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Size = new System.Drawing.Size(200, 10);
            this.pnlProcess.TabIndex = 2;
            // 
            // pnlTrans
            // 
            this.pnlTrans.BackgroundImage = global::Zi.ZiCoffee.Properties.Resources.ZiSplashBackground5;
            this.pnlTrans.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTrans.Location = new System.Drawing.Point(377, 0);
            this.pnlTrans.Name = "pnlTrans";
            this.pnlTrans.Size = new System.Drawing.Size(365, 68);
            this.pnlTrans.TabIndex = 17;
            // 
            // timerKillForm
            // 
            this.timerKillForm.Interval = 1000;
            this.timerKillForm.Tick += new System.EventHandler(this.TimerKillForm_Tick);
            // 
            // formSplash3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(742, 464);
            this.Controls.Add(this.pnlTrans);
            this.Controls.Add(this.pnlLoadBar);
            this.Controls.Add(this.lbCopyrightWarning);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picGif);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "formSplash3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.Load += new System.EventHandler(this.FormSplash3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlLoadBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerLoader;
        private System.Windows.Forms.PictureBox picGif;
        private System.Windows.Forms.Label lbCopyrightWarning;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlLoadBar;
        private System.Windows.Forms.Panel pnlProcess;
        private System.Windows.Forms.Panel pnlTrans;
        private System.Windows.Forms.Timer timerKillForm;
    }
}