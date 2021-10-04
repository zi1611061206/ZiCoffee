
namespace Zi.SalesModule.CustomControls
{
    partial class GroupTextBox
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
            this.pnlMarginBottom = new System.Windows.Forms.Panel();
            this.lbError = new System.Windows.Forms.Label();
            this.lbLabel = new System.Windows.Forms.Label();
            this.pnlMarginTop = new System.Windows.Forms.Panel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlTextBox = new System.Windows.Forms.Panel();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txbInput = new System.Windows.Forms.TextBox();
            this.pnlEndIcon = new System.Windows.Forms.Panel();
            this.ipicEndIcon = new FontAwesome.Sharp.IconPictureBox();
            this.pnlStartIcon = new System.Windows.Forms.Panel();
            this.ipicStartIcon = new FontAwesome.Sharp.IconPictureBox();
            this.pnlBorderRight = new System.Windows.Forms.Panel();
            this.pnlBorderLeft = new System.Windows.Forms.Panel();
            this.pnlBorderTop = new System.Windows.Forms.Panel();
            this.pnlBorderBottom = new System.Windows.Forms.Panel();
            this.pnlMarginBottom.SuspendLayout();
            this.pnlMarginTop.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTextBox.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlEndIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicEndIcon)).BeginInit();
            this.pnlStartIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipicStartIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMarginBottom
            // 
            this.pnlMarginBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlMarginBottom.Controls.Add(this.lbError);
            this.pnlMarginBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMarginBottom.Location = new System.Drawing.Point(0, 65);
            this.pnlMarginBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMarginBottom.Name = "pnlMarginBottom";
            this.pnlMarginBottom.Size = new System.Drawing.Size(494, 25);
            this.pnlMarginBottom.TabIndex = 0;
            // 
            // lbError
            // 
            this.lbError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbError.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(0, 0);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(494, 25);
            this.lbError.TabIndex = 0;
            this.lbError.Text = "Error";
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLabel
            // 
            this.lbLabel.BackColor = System.Drawing.Color.Transparent;
            this.lbLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLabel.ForeColor = System.Drawing.Color.White;
            this.lbLabel.Location = new System.Drawing.Point(0, 0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbLabel.Size = new System.Drawing.Size(494, 25);
            this.lbLabel.TabIndex = 0;
            this.lbLabel.Text = "Label";
            this.lbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMarginTop
            // 
            this.pnlMarginTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlMarginTop.Controls.Add(this.lbLabel);
            this.pnlMarginTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMarginTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMarginTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMarginTop.Name = "pnlMarginTop";
            this.pnlMarginTop.Size = new System.Drawing.Size(494, 25);
            this.pnlMarginTop.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlTextBox);
            this.pnlCenter.Controls.Add(this.pnlBorderRight);
            this.pnlCenter.Controls.Add(this.pnlBorderLeft);
            this.pnlCenter.Controls.Add(this.pnlBorderTop);
            this.pnlCenter.Controls.Add(this.pnlBorderBottom);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 25);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(494, 40);
            this.pnlCenter.TabIndex = 1;
            // 
            // pnlTextBox
            // 
            this.pnlTextBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlTextBox.Controls.Add(this.pnlInput);
            this.pnlTextBox.Controls.Add(this.pnlEndIcon);
            this.pnlTextBox.Controls.Add(this.pnlStartIcon);
            this.pnlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTextBox.Location = new System.Drawing.Point(2, 2);
            this.pnlTextBox.Name = "pnlTextBox";
            this.pnlTextBox.Size = new System.Drawing.Size(490, 36);
            this.pnlTextBox.TabIndex = 0;
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.txbInput);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(36, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlInput.Size = new System.Drawing.Size(418, 36);
            this.pnlInput.TabIndex = 0;
            // 
            // txbInput
            // 
            this.txbInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
            this.txbInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbInput.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbInput.ForeColor = System.Drawing.Color.White;
            this.txbInput.Location = new System.Drawing.Point(0, 5);
            this.txbInput.Multiline = true;
            this.txbInput.Name = "txbInput";
            this.txbInput.Size = new System.Drawing.Size(418, 31);
            this.txbInput.TabIndex = 2;
            // 
            // pnlEndIcon
            // 
            this.pnlEndIcon.AutoSize = true;
            this.pnlEndIcon.BackColor = System.Drawing.Color.Transparent;
            this.pnlEndIcon.Controls.Add(this.ipicEndIcon);
            this.pnlEndIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEndIcon.Location = new System.Drawing.Point(454, 0);
            this.pnlEndIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEndIcon.Name = "pnlEndIcon";
            this.pnlEndIcon.Size = new System.Drawing.Size(36, 36);
            this.pnlEndIcon.TabIndex = 0;
            // 
            // ipicEndIcon
            // 
            this.ipicEndIcon.BackColor = System.Drawing.Color.Transparent;
            this.ipicEndIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicEndIcon.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.ipicEndIcon.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicEndIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicEndIcon.IconSize = 30;
            this.ipicEndIcon.Location = new System.Drawing.Point(3, 3);
            this.ipicEndIcon.Name = "ipicEndIcon";
            this.ipicEndIcon.Size = new System.Drawing.Size(30, 30);
            this.ipicEndIcon.TabIndex = 0;
            this.ipicEndIcon.TabStop = false;
            this.ipicEndIcon.Click += new System.EventHandler(this.IpicEndIcon_Click);
            // 
            // pnlStartIcon
            // 
            this.pnlStartIcon.AutoSize = true;
            this.pnlStartIcon.BackColor = System.Drawing.Color.Transparent;
            this.pnlStartIcon.Controls.Add(this.ipicStartIcon);
            this.pnlStartIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStartIcon.Location = new System.Drawing.Point(0, 0);
            this.pnlStartIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pnlStartIcon.Name = "pnlStartIcon";
            this.pnlStartIcon.Size = new System.Drawing.Size(36, 36);
            this.pnlStartIcon.TabIndex = 0;
            // 
            // ipicStartIcon
            // 
            this.ipicStartIcon.BackColor = System.Drawing.Color.Transparent;
            this.ipicStartIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicStartIcon.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.ipicStartIcon.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.ipicStartIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipicStartIcon.IconSize = 30;
            this.ipicStartIcon.Location = new System.Drawing.Point(3, 3);
            this.ipicStartIcon.Name = "ipicStartIcon";
            this.ipicStartIcon.Size = new System.Drawing.Size(30, 30);
            this.ipicStartIcon.TabIndex = 0;
            this.ipicStartIcon.TabStop = false;
            // 
            // pnlBorderRight
            // 
            this.pnlBorderRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.pnlBorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBorderRight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlBorderRight.Location = new System.Drawing.Point(492, 2);
            this.pnlBorderRight.Name = "pnlBorderRight";
            this.pnlBorderRight.Size = new System.Drawing.Size(2, 36);
            this.pnlBorderRight.TabIndex = 0;
            // 
            // pnlBorderLeft
            // 
            this.pnlBorderLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.pnlBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBorderLeft.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlBorderLeft.Location = new System.Drawing.Point(0, 2);
            this.pnlBorderLeft.Name = "pnlBorderLeft";
            this.pnlBorderLeft.Size = new System.Drawing.Size(2, 36);
            this.pnlBorderLeft.TabIndex = 0;
            // 
            // pnlBorderTop
            // 
            this.pnlBorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.pnlBorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorderTop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlBorderTop.Location = new System.Drawing.Point(0, 0);
            this.pnlBorderTop.Name = "pnlBorderTop";
            this.pnlBorderTop.Size = new System.Drawing.Size(494, 2);
            this.pnlBorderTop.TabIndex = 0;
            // 
            // pnlBorderBottom
            // 
            this.pnlBorderBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(202)))), ((int)(((byte)(178)))));
            this.pnlBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBorderBottom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlBorderBottom.Location = new System.Drawing.Point(0, 38);
            this.pnlBorderBottom.Name = "pnlBorderBottom";
            this.pnlBorderBottom.Size = new System.Drawing.Size(494, 2);
            this.pnlBorderBottom.TabIndex = 0;
            // 
            // GroupTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlMarginTop);
            this.Controls.Add(this.pnlMarginBottom);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GroupTextBox";
            this.Size = new System.Drawing.Size(494, 90);
            this.pnlMarginBottom.ResumeLayout(false);
            this.pnlMarginTop.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTextBox.ResumeLayout(false);
            this.pnlTextBox.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlEndIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicEndIcon)).EndInit();
            this.pnlStartIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipicStartIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMarginBottom;
        private System.Windows.Forms.Label lbLabel;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Panel pnlMarginTop;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlTextBox;
        private System.Windows.Forms.Panel pnlEndIcon;
        private FontAwesome.Sharp.IconPictureBox ipicEndIcon;
        private System.Windows.Forms.Panel pnlStartIcon;
        private FontAwesome.Sharp.IconPictureBox ipicStartIcon;
        private System.Windows.Forms.Panel pnlBorderRight;
        private System.Windows.Forms.Panel pnlBorderLeft;
        private System.Windows.Forms.Panel pnlBorderTop;
        private System.Windows.Forms.Panel pnlBorderBottom;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TextBox txbInput;
    }
}
