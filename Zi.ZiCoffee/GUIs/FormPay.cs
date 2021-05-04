using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.DataTransferLayer.DTOs;

namespace Zi.ZiCoffee.GUIs
{
    public partial class FormPay : Form
    {
        #region Form Corner
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
        #endregion

        #region Form Move
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Attributes
        public NumberFormatInfo LocalFormat { get; set; }
        public Table ChoosingTable { get; set; }
        public Stream StreamOpen { get; set; }
        public Stream StreamClick { get; set; }
        #endregion
        public FormPay(Table choosingTable)
        {
            LocalFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            LocalFormat.CurrencySymbol = Properties.Settings.Default.currencySymbol;
            LocalFormat.CurrencyPositivePattern = 3;
            LocalFormat.CurrencyDecimalDigits = 0;

            InitializeComponent();
            this.ChoosingTable = choosingTable;
        }

        private void FormPay_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            LoadSetting();
        }

        private void LoadSetting()
        {
            throw new NotImplementedException();
        }
    }
}
