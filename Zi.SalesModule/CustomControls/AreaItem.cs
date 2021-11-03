using FontAwesome.Sharp;
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
using Zi.LinqSqlLayer.DTOs;
using Zi.Utilities.Enumerators;

namespace Zi.SalesModule.CustomControls
{
    public partial class AreaItem : IconButton
    {
        #region Attributes
        public AreaModel Area { get; set; }
        public int Counter { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        #endregion

        public AreaItem(AreaModel area, int counter = 0)
        {
            InitializeComponent();
            Area = area;
            Counter = counter;
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
            Margin = new Padding(10, 10, 10, 10);
            BackColor = Properties.Settings.Default.BaseItemColor;
            ForeColor = Properties.Settings.Default.BaseTextColor;
            Size = Properties.Settings.Default.AreaItemSize;
            Tag = Area;

            if(Area.AreaId.CompareTo(Guid.Empty) == 0)
            {
                Text = InterfaceRm.GetString("BtnAllArea", Culture) + " (" + Counter + ") ";
            }
            else
            {
                Text = Area.Name + " (" + Counter + ") ";
            }
        }
        #endregion
    }
}
