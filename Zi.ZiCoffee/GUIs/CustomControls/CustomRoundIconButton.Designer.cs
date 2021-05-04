
namespace Zi.ZiCoffee.GUIs.CustomControls
{
    public partial class CustomRoundIconButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomRoundIconButton));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.rpicIcon = new Zi.ZiCoffee.GUIs.CustomControls.ItemRoundPicture();
            this.btnItem = new System.Windows.Forms.Button();
            this.pnlContainer.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpicIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlMiddle);
            this.pnlContainer.Controls.Add(this.pnlRight);
            this.pnlContainer.Controls.Add(this.pnlLeft);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(411, 88);
            this.pnlContainer.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(23, 88);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.Click += new System.EventHandler(this.PnlLeft_Click);
            this.pnlLeft.MouseLeave += new System.EventHandler(this.PnlLeft_MouseLeave);
            this.pnlLeft.MouseHover += new System.EventHandler(this.PnlLeft_MouseHover);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRight.BackgroundImage")));
            this.pnlRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(388, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(23, 88);
            this.pnlRight.TabIndex = 0;
            this.pnlRight.Click += new System.EventHandler(this.PnlLeft_Click);
            this.pnlRight.MouseLeave += new System.EventHandler(this.PnlLeft_MouseLeave);
            this.pnlRight.MouseHover += new System.EventHandler(this.PnlLeft_MouseHover);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.btnItem);
            this.pnlMiddle.Controls.Add(this.rpicIcon);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(23, 0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(365, 88);
            this.pnlMiddle.TabIndex = 0;
            // 
            // rpicIcon
            // 
            this.rpicIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpicIcon.Location = new System.Drawing.Point(0, 0);
            this.rpicIcon.Name = "rpicIcon";
            this.rpicIcon.Size = new System.Drawing.Size(88, 88);
            this.rpicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rpicIcon.TabIndex = 0;
            this.rpicIcon.TabStop = false;
            this.rpicIcon.Click += new System.EventHandler(this.PnlLeft_Click);
            this.rpicIcon.MouseLeave += new System.EventHandler(this.PnlLeft_MouseLeave);
            this.rpicIcon.MouseHover += new System.EventHandler(this.PnlLeft_MouseHover);
            // 
            // btnItem
            // 
            this.btnItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnItem.FlatAppearance.BorderSize = 0;
            this.btnItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItem.Location = new System.Drawing.Point(88, 0);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(277, 88);
            this.btnItem.TabIndex = 0;
            this.btnItem.Text = "button1";
            this.btnItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.PnlLeft_Click);
            this.btnItem.MouseLeave += new System.EventHandler(this.PnlLeft_MouseLeave);
            this.btnItem.MouseHover += new System.EventHandler(this.PnlLeft_MouseHover);
            // 
            // RoundNavButtonItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RoundNavButtonItem";
            this.Size = new System.Drawing.Size(411, 88);
            this.pnlContainer.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpicIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlMiddle;
        private ItemRoundPicture rpicIcon;
        private System.Windows.Forms.Button btnItem;
    }
}
