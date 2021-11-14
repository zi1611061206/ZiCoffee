
namespace Zi.SalesModule.PartialForms
{
    partial class FormLanguage
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grbLanguages = new System.Windows.Forms.GroupBox();
            this.pnlLanguage = new System.Windows.Forms.Panel();
            this.rdVietnamese = new System.Windows.Forms.RadioButton();
            this.picVietnameseFlag = new System.Windows.Forms.PictureBox();
            this.rdEnglish = new System.Windows.Forms.RadioButton();
            this.picEnglishFlag = new System.Windows.Forms.PictureBox();
            this.lbLanguages = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.grbLanguages.SuspendLayout();
            this.pnlLanguage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVietnameseFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnglishFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.grbLanguages);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(10, 10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1080, 627);
            this.pnlContent.TabIndex = 0;
            // 
            // grbLanguages
            // 
            this.grbLanguages.BackColor = System.Drawing.Color.Transparent;
            this.grbLanguages.Controls.Add(this.pnlLanguage);
            this.grbLanguages.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbLanguages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbLanguages.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbLanguages.Location = new System.Drawing.Point(0, 0);
            this.grbLanguages.Name = "grbLanguages";
            this.grbLanguages.Padding = new System.Windows.Forms.Padding(10);
            this.grbLanguages.Size = new System.Drawing.Size(1080, 104);
            this.grbLanguages.TabIndex = 0;
            this.grbLanguages.TabStop = false;
            this.grbLanguages.Text = "Languages";
            // 
            // pnlLanguage
            // 
            this.pnlLanguage.Controls.Add(this.rdVietnamese);
            this.pnlLanguage.Controls.Add(this.picVietnameseFlag);
            this.pnlLanguage.Controls.Add(this.rdEnglish);
            this.pnlLanguage.Controls.Add(this.picEnglishFlag);
            this.pnlLanguage.Controls.Add(this.lbLanguages);
            this.pnlLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLanguage.Location = new System.Drawing.Point(10, 33);
            this.pnlLanguage.Name = "pnlLanguage";
            this.pnlLanguage.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLanguage.Size = new System.Drawing.Size(1060, 50);
            this.pnlLanguage.TabIndex = 0;
            // 
            // rdVietnamese
            // 
            this.rdVietnamese.AutoSize = true;
            this.rdVietnamese.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdVietnamese.Location = new System.Drawing.Point(703, 10);
            this.rdVietnamese.Name = "rdVietnamese";
            this.rdVietnamese.Size = new System.Drawing.Size(134, 30);
            this.rdVietnamese.TabIndex = 0;
            this.rdVietnamese.TabStop = true;
            this.rdVietnamese.Text = "Vietnamese";
            this.rdVietnamese.UseVisualStyleBackColor = true;
            this.rdVietnamese.CheckedChanged += new System.EventHandler(this.RdVietnamese_CheckedChanged);
            // 
            // picVietnameseFlag
            // 
            this.picVietnameseFlag.Dock = System.Windows.Forms.DockStyle.Right;
            this.picVietnameseFlag.Image = global::Zi.SalesModule.Properties.Resources.VietnameseFlag;
            this.picVietnameseFlag.Location = new System.Drawing.Point(837, 10);
            this.picVietnameseFlag.Name = "picVietnameseFlag";
            this.picVietnameseFlag.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.picVietnameseFlag.Size = new System.Drawing.Size(60, 30);
            this.picVietnameseFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVietnameseFlag.TabIndex = 3;
            this.picVietnameseFlag.TabStop = false;
            // 
            // rdEnglish
            // 
            this.rdEnglish.AutoSize = true;
            this.rdEnglish.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdEnglish.Location = new System.Drawing.Point(897, 10);
            this.rdEnglish.Name = "rdEnglish";
            this.rdEnglish.Size = new System.Drawing.Size(93, 30);
            this.rdEnglish.TabIndex = 0;
            this.rdEnglish.TabStop = true;
            this.rdEnglish.Text = "English";
            this.rdEnglish.UseVisualStyleBackColor = true;
            this.rdEnglish.CheckedChanged += new System.EventHandler(this.RdEnglish_CheckedChanged);
            // 
            // picEnglishFlag
            // 
            this.picEnglishFlag.Dock = System.Windows.Forms.DockStyle.Right;
            this.picEnglishFlag.Image = global::Zi.SalesModule.Properties.Resources.EnglishFlag;
            this.picEnglishFlag.Location = new System.Drawing.Point(990, 10);
            this.picEnglishFlag.Name = "picEnglishFlag";
            this.picEnglishFlag.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.picEnglishFlag.Size = new System.Drawing.Size(60, 30);
            this.picEnglishFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEnglishFlag.TabIndex = 1;
            this.picEnglishFlag.TabStop = false;
            // 
            // lbLanguages
            // 
            this.lbLanguages.AutoSize = true;
            this.lbLanguages.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLanguages.Location = new System.Drawing.Point(10, 10);
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.Size = new System.Drawing.Size(106, 23);
            this.lbLanguages.TabIndex = 0;
            this.lbLanguages.Text = "Languages";
            // 
            // FormLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1100, 647);
            this.Controls.Add(this.pnlContent);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLanguage";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.Text = "FormLanguage";
            this.Load += new System.EventHandler(this.FormLanguage_Load);
            this.pnlContent.ResumeLayout(false);
            this.grbLanguages.ResumeLayout(false);
            this.pnlLanguage.ResumeLayout(false);
            this.pnlLanguage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVietnameseFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnglishFlag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grbLanguages;
        private System.Windows.Forms.Panel pnlLanguage;
        private System.Windows.Forms.Label lbLanguages;
        private System.Windows.Forms.RadioButton rdVietnamese;
        private System.Windows.Forms.PictureBox picVietnameseFlag;
        private System.Windows.Forms.RadioButton rdEnglish;
        private System.Windows.Forms.PictureBox picEnglishFlag;
    }
}