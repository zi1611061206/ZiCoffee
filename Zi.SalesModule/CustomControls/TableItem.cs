using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DTOs;
using Zi.Utilities.Enumerators;

namespace Zi.SalesModule.CustomControls
{
    public partial class TableItem : RoundedIconButton
    {
        #region Attributes
        public TableModel Table { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        #endregion

        public TableItem(TableModel table)
        {
            InitializeComponent();
            Table = table;
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
            IconChar = IconChar.Chair;
            TextImageRelation = TextImageRelation.ImageAboveText;
            Margin = new Padding(10, 10, 10, 10);
            Text = Table.Name;
            BackColor = Properties.Settings.Default.BaseItemColor;
            Tag = Table;
            if (Table.Status.CompareTo(TableStatus.Using) == 0)
            {
                ForeColor = Properties.Settings.Default.ErrorTextColor;
                IconColor = Properties.Settings.Default.ErrorTextColor;
                Text += Environment.NewLine + InterfaceRm.GetString("UsingTable", Culture);
            }
            else if (Table.Status.CompareTo(TableStatus.Pending) == 0)
            {
                ForeColor = Properties.Settings.Default.WarningTextColor;
                IconColor = Properties.Settings.Default.WarningTextColor;
                Text += Environment.NewLine + InterfaceRm.GetString("PendingTable", Culture);
            }
            else
            {
                ForeColor = Properties.Settings.Default.SuccessTextColor;
                IconColor = Properties.Settings.Default.SuccessTextColor;
                Text += Environment.NewLine + InterfaceRm.GetString("ReadyTable", Culture);
            }
        }
        #endregion
    }
}
