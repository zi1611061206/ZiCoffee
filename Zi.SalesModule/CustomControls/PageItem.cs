using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zi.SalesModule.CustomControls
{
    public partial class PageItem : RoundedIconButton
    {
        #region Attributes
        public string Content { get; set; }
        public bool IsCurrentIndex { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        #endregion

        public PageItem(string content, bool isCurrentIndex = false)
        {
            InitializeComponent();
            Content = content;
            IsCurrentIndex = isCurrentIndex;
            LoadSetting();
            LoadContent();
        }

        #region Initial
        private void LoadSetting()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ItemResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(TableItem).Assembly);
        }

        private void LoadContent()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = new Font("Arial", 12, FontStyle.Bold);
            Margin = new Padding(10, 0, 10, 0);
            ForeColor = Properties.Settings.Default.BaseTextColor;
            MaximumSize = new Size(0, 40);
            AutoSize = true;

            if (IsCurrentIndex)
            {
                BackColor = Properties.Settings.Default.WarningTextColor;
            }
            else
            {
                BackColor = Properties.Settings.Default.BaseBorderColor;
            }

            switch (Content)
            {
                case "first":
                    Text = "<<";
                    break;
                case "previous":
                    Text = "<";
                    break;
                case "next":
                    Text = ">";
                    break;
                case "last":
                    Text = ">>";
                    break;
                default:
                    Text = Content;
                    break;
            }
        }
        #endregion
    }
}
