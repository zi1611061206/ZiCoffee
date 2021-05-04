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
    public partial class FormSplash : Form
    {
        public long SecondsCounter { get; set; }

        public FormSplash()
        {
            InitializeComponent();
        }

        private void FormSplash_Load(object sender, EventArgs e)
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
            rtxbCopyrightWarning.Text = "Cảnh báo: \n" + Properties.Resources.CopyrightWarnDefault;
            txbCopyright.Text = Properties.Resources.CopyrightDefault;
        }

        private void LoadSetting()
        {
            (this as Form).BackColor
                = txbCopyright.BackColor
                = rtxbCopyrightWarning.BackColor
                = Properties.Settings.Default.MainBack;
            (this as Form).ForeColor
                = txbCopyright.ForeColor
                = rtxbCopyrightWarning.ForeColor
                = lbVersion.ForeColor
                = Properties.Settings.Default.MainFore;
            pnlLoadBar.BackColor = Properties.Settings.Default.MainFore;
            pnlProcess.BackColor = Properties.Settings.Default.WarningFore;
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
                Dispose();
                Close();
            }
        }
    }
}
