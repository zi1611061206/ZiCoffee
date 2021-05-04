
namespace Zi.ZiCoffee.GUIs
{
    partial class FormSplash2
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
            this.pnlLoadBar = new System.Windows.Forms.Panel();
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.lbVersion = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.timerLoader = new System.Windows.Forms.Timer(this.components);
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbCopyrightWarning = new System.Windows.Forms.Label();
            this.timerKillForm = new System.Windows.Forms.Timer(this.components);
            this.pnlLoadBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLoadBar
            // 
            this.pnlLoadBar.BackColor = System.Drawing.Color.White;
            this.pnlLoadBar.Controls.Add(this.pnlProcess);
            this.pnlLoadBar.Location = new System.Drawing.Point(124, 541);
            this.pnlLoadBar.Name = "pnlLoadBar";
            this.pnlLoadBar.Size = new System.Drawing.Size(309, 5);
            this.pnlLoadBar.TabIndex = 6;
            // 
            // pnlProcess
            // 
            this.pnlProcess.BackColor = System.Drawing.Color.Lime;
            this.pnlProcess.Location = new System.Drawing.Point(1, 1);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Size = new System.Drawing.Size(56, 10);
            this.pnlProcess.TabIndex = 2;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbVersion.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersion.ForeColor = System.Drawing.Color.White;
            this.lbVersion.Location = new System.Drawing.Point(121, 280);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(83, 19);
            this.lbVersion.TabIndex = 4;
            this.lbVersion.Text = "Phiên bản";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::Zi.ZiCoffee.Properties.Resources.logox;
            this.picLogo.Location = new System.Drawing.Point(186, 40);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 5;
            this.picLogo.TabStop = false;
            // 
            // timerLoader
            // 
            this.timerLoader.Tick += new System.EventHandler(this.TimerLoader_Tick);
            // 
            // lbCopyright
            // 
            this.lbCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lbCopyright.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCopyright.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.ForeColor = System.Drawing.Color.White;
            this.lbCopyright.Location = new System.Drawing.Point(120, 704);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(313, 29);
            this.lbCopyright.TabIndex = 0;
            this.lbCopyright.Text = "Bản quyền";
            this.lbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCopyrightWarning
            // 
            this.lbCopyrightWarning.BackColor = System.Drawing.Color.Transparent;
            this.lbCopyrightWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCopyrightWarning.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyrightWarning.ForeColor = System.Drawing.Color.White;
            this.lbCopyrightWarning.Location = new System.Drawing.Point(121, 309);
            this.lbCopyrightWarning.Name = "lbCopyrightWarning";
            this.lbCopyrightWarning.Size = new System.Drawing.Size(313, 220);
            this.lbCopyrightWarning.TabIndex = 0;
            this.lbCopyrightWarning.Text = "Cảnh báo bản quyền";
            // 
            // timerKillForm
            // 
            this.timerKillForm.Interval = 1000;
            this.timerKillForm.Tick += new System.EventHandler(this.TimerKillForm_Tick);
            // 
            // formSplash2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(555, 742);
            this.Controls.Add(this.lbCopyrightWarning);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.pnlLoadBar);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.picLogo);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formSplash2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formSplash2";
            this.Load += new System.EventHandler(this.FormSplash2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSplash2_Paint);
            this.pnlLoadBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoadBar;
        private System.Windows.Forms.Panel pnlProcess;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Timer timerLoader;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbCopyrightWarning;
        private System.Windows.Forms.Timer timerKillForm;
    }
}