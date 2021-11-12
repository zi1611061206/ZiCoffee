using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zi.SalesModule.CustomControls
{
    public partial class ErrorLabel : Label
    {
        #region Attributes
        public string ErrorText { get; set; }
        #endregion

        public ErrorLabel(string errorText)
        {
            InitializeComponent();
            ErrorText = errorText;
            LoadContent();
        }

        #region Initial
        private void LoadContent()
        {
            Text = ErrorText;
            ForeColor = Properties.Settings.Default.ErrorTextColor;
            Font = new Font("Arial", 9, FontStyle.Italic);
            AutoSize = true;
        }
        #endregion
    }
}
