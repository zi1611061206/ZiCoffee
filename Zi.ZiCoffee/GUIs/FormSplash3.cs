using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zi.ZiCoffee.GUIs
{
    public partial class FormSplash3 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public Stream StreamOpen { get; set; }
        public long SecondsCounter { get; set; }

        public FormSplash3()
        {
            InitializeComponent();
        }

        private void FormSplash3_Load(object sender, EventArgs e)
        {
            lbCopyright.Parent = picGif;
            lbCopyrightWarning.Parent = picGif;
            lbVersion.Parent = picGif;
            picLogo.Parent = picGif;
            pnlLoadBar.Parent = picGif;
            pnlTrans.Parent = picGif;

            lbCopyright.BackColor = Color.Transparent;
            lbCopyrightWarning.BackColor = Color.Transparent;
            lbVersion.BackColor = Color.Transparent;
            picLogo.BackColor = Color.Transparent;
            pnlLoadBar.BackColor = Color.Transparent;
            pnlTrans.BackColor = Color.Transparent;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            LoadDefaultText();
            pnlProcess.Location = new Point(0, 0);
            timerLoader.Interval = 10;
            timerLoader.Start();
            SecondsCounter = 1;
            timerKillForm.Start();

            if (Properties.Settings.Default.IsAppearance)
            {
                StreamOpen = Properties.Resources.intro;
            }
            else
            {
                StreamOpen = null;
            }

            if (StreamOpen != null)
            {
                SoundPlayer sound = new SoundPlayer
                {
                    Stream = StreamOpen
                };
                sound.Play();
            }
        }

        private void LoadDefaultText()
        {
            lbVersion.Text = "Phiên bản: " + Properties.Resources.VersionDefault;
            lbCopyrightWarning.Text = "Cảnh báo: \n" + Properties.Resources.CopyrightWarnDefault;
            lbCopyright.Text = Properties.Resources.CopyrightDefault;
        }

        private void TimerLoader_Tick(object sender, EventArgs e)
        {
            if (pnlProcess.Location.X < 743)
            {
                pnlProcess.Location = new Point(pnlProcess.Location.X + 1, pnlProcess.Location.Y);
            }
            else
            {
                pnlProcess.Location = new Point(-200, 0);
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
