using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zi.ZiCoffee.GUIs
{
    public partial class FormSplash2 : Form
    {
        public long SecondsCounter { get; set; }

        public FormSplash2()
        {
            InitializeComponent();
        }

        private void FormSplash2_Load(object sender, EventArgs e)
        {
            LoadSetting();
            LoadDefaultText();
            pnlProcess.Location = new Point(1, 1);
            timerLoader.Interval = 10;
            timerLoader.Start();
            SecondsCounter = 1;
            timerKillForm.Start();
        }

        private void LoadDefaultText()
        {
            lbVersion.Text = "Phiên bản: " + Properties.Resources.VersionDefault;
            lbCopyrightWarning.Text = "Cảnh báo: \n" + Properties.Resources.CopyrightWarnDefault;
            lbCopyright.Text = Properties.Resources.CopyrightDefault;
        }

        private void LoadSetting()
        {
            pnlLoadBar.BackColor = Properties.Settings.Default.MainFore;
            pnlProcess.BackColor = Properties.Settings.Default.WarningFore;
        }

        private void FormSplash2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0), 1);
            Rectangle rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush brush = new LinearGradientBrush(rectangle, Color.FromArgb(255, 0, 0), Color.FromArgb(0, 255, 0), LinearGradientMode.Vertical);
            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(pen, rectangle);
        }

        private void TimerLoader_Tick(object sender, EventArgs e)
        {
            if (pnlProcess.Location.X < 308)
            {
                pnlProcess.Location = new Point(pnlProcess.Location.X + 1, pnlProcess.Location.Y);
            }
            else
            {
                pnlProcess.Location = new Point(-56, 1);
            }
        }

        private void TimerKillForm_Tick(object sender, EventArgs e)
        {
            SecondsCounter++;
            if (SecondsCounter >= 8)
            {
                this.Dispose();
                this.Close();
            }
        }
    }
}
