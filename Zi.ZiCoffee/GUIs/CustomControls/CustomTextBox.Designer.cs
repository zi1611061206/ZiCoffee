
namespace Zi.ZiCoffee.GUIs.CustomControls
{
    partial class CustomTextBox
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
            this.pnlGroupBox = new System.Windows.Forms.Panel();
            this.txbTextContent = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lbLabel = new System.Windows.Forms.Label();
            this.lbValidator = new System.Windows.Forms.Label();
            this.pnlGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGroupBox
            // 
            this.pnlGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGroupBox.Controls.Add(this.txbTextContent);
            this.pnlGroupBox.Controls.Add(this.pnlBottom);
            this.pnlGroupBox.Controls.Add(this.pnlTop);
            this.pnlGroupBox.Controls.Add(this.pnlLeft);
            this.pnlGroupBox.Controls.Add(this.pnlRight);
            this.pnlGroupBox.Location = new System.Drawing.Point(3, 15);
            this.pnlGroupBox.Name = "pnlGroupBox";
            this.pnlGroupBox.Size = new System.Drawing.Size(550, 48);
            this.pnlGroupBox.TabIndex = 0;
            // 
            // txbTextContent
            // 
            this.txbTextContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTextContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txbTextContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTextContent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTextContent.ForeColor = System.Drawing.Color.White;
            this.txbTextContent.Location = new System.Drawing.Point(9, 18);
            this.txbTextContent.Multiline = true;
            this.txbTextContent.Name = "txbTextContent";
            this.txbTextContent.Size = new System.Drawing.Size(532, 23);
            this.txbTextContent.TabIndex = 0;
            this.txbTextContent.Text = "Text";
            this.txbTextContent.Click += new System.EventHandler(this.TxbTextContent_Click);
            this.txbTextContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbTextContent_KeyPress);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(3, 45);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(544, 3);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(3, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(544, 3);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(3, 48);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(547, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(3, 48);
            this.pnlRight.TabIndex = 0;
            // 
            // lbLabel
            // 
            this.lbLabel.AutoSize = true;
            this.lbLabel.ForeColor = System.Drawing.Color.White;
            this.lbLabel.Location = new System.Drawing.Point(25, 4);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(53, 22);
            this.lbLabel.TabIndex = 0;
            this.lbLabel.Text = "Nhãn";
            // 
            // lbValidator
            // 
            this.lbValidator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbValidator.AutoSize = true;
            this.lbValidator.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValidator.ForeColor = System.Drawing.Color.Red;
            this.lbValidator.Location = new System.Drawing.Point(12, 66);
            this.lbValidator.Name = "lbValidator";
            this.lbValidator.Size = new System.Drawing.Size(89, 16);
            this.lbValidator.TabIndex = 0;
            this.lbValidator.Text = "Lỗi nhập liệu";
            // 
            // CustomTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbValidator);
            this.Controls.Add(this.lbLabel);
            this.Controls.Add(this.pnlGroupBox);
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomTextBox";
            this.Size = new System.Drawing.Size(556, 85);
            this.pnlGroupBox.ResumeLayout(false);
            this.pnlGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGroupBox;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lbLabel;
        public System.Windows.Forms.Label lbValidator;
        private System.Windows.Forms.TextBox txbTextContent;
    }
}
