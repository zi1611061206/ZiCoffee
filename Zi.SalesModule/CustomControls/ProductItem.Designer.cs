
namespace Zi.SalesModule.CustomControls
{
    partial class ProductItem
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
            this.lbPromotionPrice = new System.Windows.Forms.Label();
            this.lbOriginalPrice = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.rpicThumnail = new Zi.SalesModule.CustomControls.RoundedPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rpicThumnail)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPromotionPrice
            // 
            this.lbPromotionPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbPromotionPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbPromotionPrice.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPromotionPrice.ForeColor = System.Drawing.Color.Lime;
            this.lbPromotionPrice.Location = new System.Drawing.Point(130, 154);
            this.lbPromotionPrice.Name = "lbPromotionPrice";
            this.lbPromotionPrice.Size = new System.Drawing.Size(360, 36);
            this.lbPromotionPrice.TabIndex = 0;
            this.lbPromotionPrice.Text = "Promotion Price";
            this.lbPromotionPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbPromotionPrice.Click += new System.EventHandler(this.Zi_Click);
            this.lbPromotionPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zi_MouseDown);
            this.lbPromotionPrice.MouseLeave += new System.EventHandler(this.Zi_MouseLeave);
            this.lbPromotionPrice.MouseHover += new System.EventHandler(this.Zi_MouseHover);
            // 
            // lbOriginalPrice
            // 
            this.lbOriginalPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbOriginalPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbOriginalPrice.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOriginalPrice.ForeColor = System.Drawing.Color.Red;
            this.lbOriginalPrice.Location = new System.Drawing.Point(130, 118);
            this.lbOriginalPrice.Name = "lbOriginalPrice";
            this.lbOriginalPrice.Size = new System.Drawing.Size(360, 36);
            this.lbOriginalPrice.TabIndex = 0;
            this.lbOriginalPrice.Text = "Original Price";
            this.lbOriginalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbOriginalPrice.Click += new System.EventHandler(this.Zi_Click);
            this.lbOriginalPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zi_MouseDown);
            this.lbOriginalPrice.MouseLeave += new System.EventHandler(this.Zi_MouseLeave);
            this.lbOriginalPrice.MouseHover += new System.EventHandler(this.Zi_MouseHover);
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbName.Location = new System.Drawing.Point(130, 10);
            this.lbName.Name = "lbName";
            this.lbName.Padding = new System.Windows.Forms.Padding(10);
            this.lbName.Size = new System.Drawing.Size(360, 108);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            this.lbName.Click += new System.EventHandler(this.Zi_Click);
            this.lbName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zi_MouseDown);
            this.lbName.MouseLeave += new System.EventHandler(this.Zi_MouseLeave);
            this.lbName.MouseHover += new System.EventHandler(this.Zi_MouseHover);
            // 
            // rpicThumnail
            // 
            this.rpicThumnail.BackColor = System.Drawing.Color.Gainsboro;
            this.rpicThumnail.Dock = System.Windows.Forms.DockStyle.Left;
            this.rpicThumnail.Location = new System.Drawing.Point(10, 10);
            this.rpicThumnail.Margin = new System.Windows.Forms.Padding(4);
            this.rpicThumnail.Name = "rpicThumnail";
            this.rpicThumnail.Size = new System.Drawing.Size(120, 180);
            this.rpicThumnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rpicThumnail.TabIndex = 0;
            this.rpicThumnail.TabStop = false;
            this.rpicThumnail.Click += new System.EventHandler(this.Zi_Click);
            this.rpicThumnail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zi_MouseDown);
            this.rpicThumnail.MouseLeave += new System.EventHandler(this.Zi_MouseLeave);
            this.rpicThumnail.MouseHover += new System.EventHandler(this.Zi_MouseHover);
            // 
            // ProductHorizontalItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbOriginalPrice);
            this.Controls.Add(this.lbPromotionPrice);
            this.Controls.Add(this.rpicThumnail);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductHorizontalItem";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(500, 200);
            this.Load += new System.EventHandler(this.ProductHorizontalItem_Load);
            this.SizeChanged += new System.EventHandler(this.ProductHorizontalItem_SizeChanged);
            this.Click += new System.EventHandler(this.Zi_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zi_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Zi_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Zi_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.rpicThumnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPictureBox rpicThumnail;
        private System.Windows.Forms.Label lbPromotionPrice;
        private System.Windows.Forms.Label lbOriginalPrice;
        private System.Windows.Forms.Label lbName;
    }
}
