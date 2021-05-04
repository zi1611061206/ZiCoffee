
namespace Zi.ZiCoffee.GUIs
{
    partial class FormSplash
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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lbVersion = new System.Windows.Forms.Label();
            this.rtxbCopyrightWarning = new System.Windows.Forms.RichTextBox();
            this.txbCopyright = new System.Windows.Forms.TextBox();
            this.pnlLoadBar = new System.Windows.Forms.Panel();
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.timerLoader = new System.Windows.Forms.Timer(this.components);
            this.timerKillForm = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlLoadBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::Zi.ZiCoffee.Properties.Resources.logox;
            this.picLogo.Location = new System.Drawing.Point(179, -4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbVersion.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.ForeColor = System.Drawing.Color.White;
            this.lbVersion.Location = new System.Drawing.Point(114, 236);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(83, 19);
            this.lbVersion.TabIndex = 0;
            this.lbVersion.Text = "Phiên bản";
            // 
            // rtxbCopyrightWarning
            // 
            this.rtxbCopyrightWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.rtxbCopyrightWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxbCopyrightWarning.Font = new System.Drawing.Font("Arial", 10.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxbCopyrightWarning.ForeColor = System.Drawing.Color.White;
            this.rtxbCopyrightWarning.Location = new System.Drawing.Point(117, 273);
            this.rtxbCopyrightWarning.Name = "rtxbCopyrightWarning";
            this.rtxbCopyrightWarning.ReadOnly = true;
            this.rtxbCopyrightWarning.Size = new System.Drawing.Size(309, 205);
            this.rtxbCopyrightWarning.TabIndex = 0;
            this.rtxbCopyrightWarning.TabStop = false;
            this.rtxbCopyrightWarning.Text = "Cảnh báo bản quyền";
            // 
            // txbCopyright
            // 
            this.txbCopyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txbCopyright.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbCopyright.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCopyright.ForeColor = System.Drawing.Color.White;
            this.txbCopyright.Location = new System.Drawing.Point(117, 639);
            this.txbCopyright.Name = "txbCopyright";
            this.txbCopyright.ReadOnly = true;
            this.txbCopyright.Size = new System.Drawing.Size(308, 20);
            this.txbCopyright.TabIndex = 0;
            this.txbCopyright.TabStop = false;
            this.txbCopyright.Text = "Copyright";
            this.txbCopyright.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlLoadBar
            // 
            this.pnlLoadBar.BackColor = System.Drawing.Color.White;
            this.pnlLoadBar.Controls.Add(this.pnlProcess);
            this.pnlLoadBar.Location = new System.Drawing.Point(117, 497);
            this.pnlLoadBar.Name = "pnlLoadBar";
            this.pnlLoadBar.Size = new System.Drawing.Size(309, 5);
            this.pnlLoadBar.TabIndex = 1;
            // 
            // pnlProcess
            // 
            this.pnlProcess.BackColor = System.Drawing.Color.Lime;
            this.pnlProcess.Location = new System.Drawing.Point(1, 1);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Size = new System.Drawing.Size(56, 10);
            this.pnlProcess.TabIndex = 2;
            // 
            // timerLoader
            // 
            this.timerLoader.Tick += new System.EventHandler(this.TimerLoader_Tick);
            // 
            // timerKillForm
            // 
            this.timerKillForm.Interval = 1000;
            this.timerKillForm.Tick += new System.EventHandler(this.TimerKillForm_Tick);
            // 
            // formSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.BackgroundImage = global::Zi.ZiCoffee.Properties.Resources.ZiSplashBackground3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(555, 742);
            this.Controls.Add(this.pnlLoadBar);
            this.Controls.Add(this.txbCopyright);
            this.Controls.Add(this.rtxbCopyrightWarning);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.picLogo);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formSplash";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(177)))), ((int)(((byte)(76)))));
            this.Load += new System.EventHandler(this.FormSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlLoadBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.RichTextBox rtxbCopyrightWarning;
        private System.Windows.Forms.TextBox txbCopyright;
        private System.Windows.Forms.Panel pnlLoadBar;
        private System.Windows.Forms.Panel pnlProcess;
        private System.Windows.Forms.Timer timerLoader;
        private System.Windows.Forms.Timer timerKillForm;
    }
}