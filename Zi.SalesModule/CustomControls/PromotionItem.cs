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
using FontAwesome.Sharp;

namespace Zi.SalesModule.CustomControls
{
    public partial class PromotionItem : RoundedIconButton
    {
        #region Attributes
        public PromotionModel Promotion { get; set; }
        public PromotionTypeModel PromotionType { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public DateTimeFormatInfo DateTimeFormat { get; set; }
        public NumberFormatInfo LocalFormat { get; set; }
        #endregion

        public PromotionItem(PromotionModel promotion, PromotionTypeModel promotionType)
        {
            InitializeComponent();
            Promotion = promotion;
            PromotionType = promotionType;
            LoadSetting();
            LoadContent();
        }

        #region Initial
        private void LoadSetting()
        {
            SetCulture();
            SetDateTimeFormat();
            SetCurrencyFormat();
        }

        private void SetCulture()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ItemResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(PromotionItem).Assembly);
        }

        private void SetDateTimeFormat()
        {
            DateTimeFormat = (new CultureInfo(CultureName)).DateTimeFormat;
        }

        private void SetCurrencyFormat()
        {
            LocalFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            LocalFormat.CurrencySymbol = InterfaceRm.GetString("CurrencySymbol", Culture);
            LocalFormat.CurrencyPositivePattern = 3;
            LocalFormat.CurrencyDecimalDigits = 0;
        }

        private void LoadContent()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = new Font("Arial", 12);
            IconChar = IconChar.Tags;
            IconColor = Properties.Settings.Default.WarningTextColor;
            TextImageRelation = TextImageRelation.ImageAboveText;
            TextAlign = ContentAlignment.MiddleLeft;
            Padding = new Padding(20,20,20,20);
            BackColor = Properties.Settings.Default.BaseItemColor;
            ForeColor = Properties.Settings.Default.BaseTextColor;
            AutoSize = true;
            Tag = Promotion;
            Text = PromotionType.Name + Environment.NewLine
                + InterfaceRm.GetString("", Culture) + Promotion.Description + Environment.NewLine
                + "- " + InterfaceRm.GetString("PromotionValue", Culture) + ": " + Promotion.Value.ToString("n0", LocalFormat) + (Promotion.IsPercent.CompareTo(PromotionPercent.Percent) == 0 ? "%" : string.Empty) + Environment.NewLine
                + "- " + InterfaceRm.GetString("StartTime", Culture) + ": " + Promotion.StartTime.ToString("d", DateTimeFormat) + Environment.NewLine
                + "- " + InterfaceRm.GetString("EndTime", Culture) + ": " + Promotion.EndTime.ToString("d", DateTimeFormat) + Environment.NewLine
                + "- " + InterfaceRm.GetString("InvoiceMinValue", Culture) + ": " + Promotion.MinValue.ToString("n0", LocalFormat) + Environment.NewLine
                + InterfaceRm.GetString("Availability", Culture).ToUpper();
        }
        #endregion
    }
}
