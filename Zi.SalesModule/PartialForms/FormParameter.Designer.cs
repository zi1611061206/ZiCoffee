
namespace Zi.SalesModule.PartialForms
{
    partial class FormParameter
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
            this.grbTimer = new System.Windows.Forms.GroupBox();
            this.pnlAlertTimer = new System.Windows.Forms.Panel();
            this.nudAlertTimer = new System.Windows.Forms.NumericUpDown();
            this.lbAlertTimer = new System.Windows.Forms.Label();
            this.grbInvoice = new System.Windows.Forms.GroupBox();
            this.pnlRoundingTo = new System.Windows.Forms.Panel();
            this.nudRoundingTo = new System.Windows.Forms.NumericUpDown();
            this.lbRoundingTo = new System.Windows.Forms.Label();
            this.pnlDefaultTax = new System.Windows.Forms.Panel();
            this.nudDefaultTax = new System.Windows.Forms.NumericUpDown();
            this.lbDefaultTax = new System.Windows.Forms.Label();
            this.grbInterface = new System.Windows.Forms.GroupBox();
            this.pnlCornerRadius = new System.Windows.Forms.Panel();
            this.nudCornerRadius = new System.Windows.Forms.NumericUpDown();
            this.lbCornerRadius = new System.Windows.Forms.Label();
            this.pnlDropShadowDepth = new System.Windows.Forms.Panel();
            this.nudDropShadowDepth = new System.Windows.Forms.NumericUpDown();
            this.lbDropShadowDepth = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.grbTimer.SuspendLayout();
            this.pnlAlertTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlertTimer)).BeginInit();
            this.grbInvoice.SuspendLayout();
            this.pnlRoundingTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoundingTo)).BeginInit();
            this.pnlDefaultTax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefaultTax)).BeginInit();
            this.grbInterface.SuspendLayout();
            this.pnlCornerRadius.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCornerRadius)).BeginInit();
            this.pnlDropShadowDepth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropShadowDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.grbTimer);
            this.pnlContent.Controls.Add(this.grbInvoice);
            this.pnlContent.Controls.Add(this.grbInterface);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(10, 10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1080, 627);
            this.pnlContent.TabIndex = 0;
            // 
            // grbTimer
            // 
            this.grbTimer.BackColor = System.Drawing.Color.Transparent;
            this.grbTimer.Controls.Add(this.pnlAlertTimer);
            this.grbTimer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbTimer.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbTimer.Location = new System.Drawing.Point(0, 298);
            this.grbTimer.Name = "grbTimer";
            this.grbTimer.Padding = new System.Windows.Forms.Padding(10);
            this.grbTimer.Size = new System.Drawing.Size(1080, 99);
            this.grbTimer.TabIndex = 0;
            this.grbTimer.TabStop = false;
            this.grbTimer.Text = "Timer";
            // 
            // pnlAlertTimer
            // 
            this.pnlAlertTimer.Controls.Add(this.nudAlertTimer);
            this.pnlAlertTimer.Controls.Add(this.lbAlertTimer);
            this.pnlAlertTimer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlertTimer.Location = new System.Drawing.Point(10, 33);
            this.pnlAlertTimer.Name = "pnlAlertTimer";
            this.pnlAlertTimer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlAlertTimer.Size = new System.Drawing.Size(1060, 50);
            this.pnlAlertTimer.TabIndex = 0;
            // 
            // nudAlertTimer
            // 
            this.nudAlertTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudAlertTimer.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudAlertTimer.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAlertTimer.Location = new System.Drawing.Point(930, 10);
            this.nudAlertTimer.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudAlertTimer.Name = "nudAlertTimer";
            this.nudAlertTimer.Size = new System.Drawing.Size(120, 26);
            this.nudAlertTimer.TabIndex = 0;
            this.nudAlertTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAlertTimer.ValueChanged += new System.EventHandler(this.NudAlertTimer_ValueChanged);
            // 
            // lbAlertTimer
            // 
            this.lbAlertTimer.AutoSize = true;
            this.lbAlertTimer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbAlertTimer.Location = new System.Drawing.Point(10, 10);
            this.lbAlertTimer.Name = "lbAlertTimer";
            this.lbAlertTimer.Size = new System.Drawing.Size(106, 23);
            this.lbAlertTimer.TabIndex = 0;
            this.lbAlertTimer.Text = "Alert Timer";
            // 
            // grbInvoice
            // 
            this.grbInvoice.BackColor = System.Drawing.Color.Transparent;
            this.grbInvoice.Controls.Add(this.pnlRoundingTo);
            this.grbInvoice.Controls.Add(this.pnlDefaultTax);
            this.grbInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbInvoice.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbInvoice.Location = new System.Drawing.Point(0, 149);
            this.grbInvoice.Name = "grbInvoice";
            this.grbInvoice.Padding = new System.Windows.Forms.Padding(10);
            this.grbInvoice.Size = new System.Drawing.Size(1080, 149);
            this.grbInvoice.TabIndex = 0;
            this.grbInvoice.TabStop = false;
            this.grbInvoice.Text = "Invoice";
            // 
            // pnlRoundingTo
            // 
            this.pnlRoundingTo.Controls.Add(this.nudRoundingTo);
            this.pnlRoundingTo.Controls.Add(this.lbRoundingTo);
            this.pnlRoundingTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoundingTo.Location = new System.Drawing.Point(10, 83);
            this.pnlRoundingTo.Name = "pnlRoundingTo";
            this.pnlRoundingTo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRoundingTo.Size = new System.Drawing.Size(1060, 50);
            this.pnlRoundingTo.TabIndex = 0;
            // 
            // nudRoundingTo
            // 
            this.nudRoundingTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudRoundingTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudRoundingTo.Location = new System.Drawing.Point(930, 10);
            this.nudRoundingTo.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudRoundingTo.Name = "nudRoundingTo";
            this.nudRoundingTo.Size = new System.Drawing.Size(120, 26);
            this.nudRoundingTo.TabIndex = 0;
            this.nudRoundingTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRoundingTo.ValueChanged += new System.EventHandler(this.NudRoundingTo_ValueChanged);
            // 
            // lbRoundingTo
            // 
            this.lbRoundingTo.AutoSize = true;
            this.lbRoundingTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbRoundingTo.Location = new System.Drawing.Point(10, 10);
            this.lbRoundingTo.Name = "lbRoundingTo";
            this.lbRoundingTo.Size = new System.Drawing.Size(118, 23);
            this.lbRoundingTo.TabIndex = 0;
            this.lbRoundingTo.Text = "Rounding To";
            // 
            // pnlDefaultTax
            // 
            this.pnlDefaultTax.Controls.Add(this.nudDefaultTax);
            this.pnlDefaultTax.Controls.Add(this.lbDefaultTax);
            this.pnlDefaultTax.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDefaultTax.Location = new System.Drawing.Point(10, 33);
            this.pnlDefaultTax.Name = "pnlDefaultTax";
            this.pnlDefaultTax.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDefaultTax.Size = new System.Drawing.Size(1060, 50);
            this.pnlDefaultTax.TabIndex = 0;
            // 
            // nudDefaultTax
            // 
            this.nudDefaultTax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudDefaultTax.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudDefaultTax.Location = new System.Drawing.Point(930, 10);
            this.nudDefaultTax.Name = "nudDefaultTax";
            this.nudDefaultTax.Size = new System.Drawing.Size(120, 26);
            this.nudDefaultTax.TabIndex = 0;
            this.nudDefaultTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDefaultTax.ValueChanged += new System.EventHandler(this.NudDefaultTax_ValueChanged);
            // 
            // lbDefaultTax
            // 
            this.lbDefaultTax.AutoSize = true;
            this.lbDefaultTax.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbDefaultTax.Location = new System.Drawing.Point(10, 10);
            this.lbDefaultTax.Name = "lbDefaultTax";
            this.lbDefaultTax.Size = new System.Drawing.Size(108, 23);
            this.lbDefaultTax.TabIndex = 0;
            this.lbDefaultTax.Text = "Default Tax";
            // 
            // grbInterface
            // 
            this.grbInterface.BackColor = System.Drawing.Color.Transparent;
            this.grbInterface.Controls.Add(this.pnlCornerRadius);
            this.grbInterface.Controls.Add(this.pnlDropShadowDepth);
            this.grbInterface.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbInterface.ForeColor = System.Drawing.Color.Gainsboro;
            this.grbInterface.Location = new System.Drawing.Point(0, 0);
            this.grbInterface.Name = "grbInterface";
            this.grbInterface.Padding = new System.Windows.Forms.Padding(10);
            this.grbInterface.Size = new System.Drawing.Size(1080, 149);
            this.grbInterface.TabIndex = 0;
            this.grbInterface.TabStop = false;
            this.grbInterface.Text = "Interface";
            // 
            // pnlCornerRadius
            // 
            this.pnlCornerRadius.Controls.Add(this.nudCornerRadius);
            this.pnlCornerRadius.Controls.Add(this.lbCornerRadius);
            this.pnlCornerRadius.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCornerRadius.Location = new System.Drawing.Point(10, 83);
            this.pnlCornerRadius.Name = "pnlCornerRadius";
            this.pnlCornerRadius.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCornerRadius.Size = new System.Drawing.Size(1060, 50);
            this.pnlCornerRadius.TabIndex = 0;
            // 
            // nudCornerRadius
            // 
            this.nudCornerRadius.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudCornerRadius.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudCornerRadius.Location = new System.Drawing.Point(930, 10);
            this.nudCornerRadius.Name = "nudCornerRadius";
            this.nudCornerRadius.Size = new System.Drawing.Size(120, 26);
            this.nudCornerRadius.TabIndex = 0;
            this.nudCornerRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCornerRadius.ValueChanged += new System.EventHandler(this.NudCornerRadius_ValueChanged);
            // 
            // lbCornerRadius
            // 
            this.lbCornerRadius.AutoSize = true;
            this.lbCornerRadius.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCornerRadius.Location = new System.Drawing.Point(10, 10);
            this.lbCornerRadius.Name = "lbCornerRadius";
            this.lbCornerRadius.Size = new System.Drawing.Size(167, 23);
            this.lbCornerRadius.TabIndex = 0;
            this.lbCornerRadius.Text = "Angular Curvature";
            // 
            // pnlDropShadowDepth
            // 
            this.pnlDropShadowDepth.Controls.Add(this.nudDropShadowDepth);
            this.pnlDropShadowDepth.Controls.Add(this.lbDropShadowDepth);
            this.pnlDropShadowDepth.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDropShadowDepth.Location = new System.Drawing.Point(10, 33);
            this.pnlDropShadowDepth.Name = "pnlDropShadowDepth";
            this.pnlDropShadowDepth.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDropShadowDepth.Size = new System.Drawing.Size(1060, 50);
            this.pnlDropShadowDepth.TabIndex = 0;
            // 
            // nudDropShadowDepth
            // 
            this.nudDropShadowDepth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudDropShadowDepth.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudDropShadowDepth.Location = new System.Drawing.Point(930, 10);
            this.nudDropShadowDepth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudDropShadowDepth.Name = "nudDropShadowDepth";
            this.nudDropShadowDepth.Size = new System.Drawing.Size(120, 26);
            this.nudDropShadowDepth.TabIndex = 0;
            this.nudDropShadowDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDropShadowDepth.ValueChanged += new System.EventHandler(this.NudDropShadowDepth_ValueChanged);
            // 
            // lbDropShadowDepth
            // 
            this.lbDropShadowDepth.AutoSize = true;
            this.lbDropShadowDepth.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbDropShadowDepth.Location = new System.Drawing.Point(10, 10);
            this.lbDropShadowDepth.Name = "lbDropShadowDepth";
            this.lbDropShadowDepth.Size = new System.Drawing.Size(139, 23);
            this.lbDropShadowDepth.TabIndex = 0;
            this.lbDropShadowDepth.Text = "Shadow Depth";
            // 
            // FormParameter
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
            this.Name = "FormParameter";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.Text = "FormParameter";
            this.Load += new System.EventHandler(this.FormParameter_Load);
            this.pnlContent.ResumeLayout(false);
            this.grbTimer.ResumeLayout(false);
            this.pnlAlertTimer.ResumeLayout(false);
            this.pnlAlertTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlertTimer)).EndInit();
            this.grbInvoice.ResumeLayout(false);
            this.pnlRoundingTo.ResumeLayout(false);
            this.pnlRoundingTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoundingTo)).EndInit();
            this.pnlDefaultTax.ResumeLayout(false);
            this.pnlDefaultTax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefaultTax)).EndInit();
            this.grbInterface.ResumeLayout(false);
            this.pnlCornerRadius.ResumeLayout(false);
            this.pnlCornerRadius.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCornerRadius)).EndInit();
            this.pnlDropShadowDepth.ResumeLayout(false);
            this.pnlDropShadowDepth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropShadowDepth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grbInterface;
        private System.Windows.Forms.Panel pnlCornerRadius;
        private System.Windows.Forms.Label lbCornerRadius;
        private System.Windows.Forms.Panel pnlDropShadowDepth;
        private System.Windows.Forms.Label lbDropShadowDepth;
        private System.Windows.Forms.NumericUpDown nudCornerRadius;
        private System.Windows.Forms.NumericUpDown nudDropShadowDepth;
        private System.Windows.Forms.GroupBox grbInvoice;
        private System.Windows.Forms.Panel pnlRoundingTo;
        private System.Windows.Forms.NumericUpDown nudRoundingTo;
        private System.Windows.Forms.Label lbRoundingTo;
        private System.Windows.Forms.Panel pnlDefaultTax;
        private System.Windows.Forms.NumericUpDown nudDefaultTax;
        private System.Windows.Forms.Label lbDefaultTax;
        private System.Windows.Forms.GroupBox grbTimer;
        private System.Windows.Forms.Panel pnlAlertTimer;
        private System.Windows.Forms.NumericUpDown nudAlertTimer;
        private System.Windows.Forms.Label lbAlertTimer;
    }
}