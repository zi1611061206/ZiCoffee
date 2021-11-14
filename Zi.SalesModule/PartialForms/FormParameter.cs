using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using Zi.SalesModule.Settings;

namespace Zi.SalesModule.PartialForms
{
    public partial class FormParameter : Form
    {
        #region Attributes
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public BackupSetting BackupSetting { get; set; }
        #endregion

        public FormParameter(BackupSetting backupSetting)
        {
            InitializeComponent();
            BackupSetting = backupSetting;
        }

        #region Initial
        private void FormParameter_Load(object sender, EventArgs e)
        {
            LoadSetting();
            LoadContent();
        }

        private void LoadSetting()
        {
            SetCulture();
            SetStaticText();
            SetColor();
        }

        private void SetCulture()
        {
            CultureName = BackupSetting.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.SettingResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(FormParameter).Assembly);
        }

        private void SetStaticText()
        {
            grbInterface.Text = InterfaceRm.GetString("GrbInterface", Culture);
            grbInvoice.Text = InterfaceRm.GetString("GrbInvoice", Culture);
            grbTimer.Text = InterfaceRm.GetString("GrbTimer", Culture);

            lbAlertTimer.Text = InterfaceRm.GetString("LbAlertTimer", Culture);
            lbCornerRadius.Text = InterfaceRm.GetString("LbCornerRadius", Culture);
            lbDefaultTax.Text = InterfaceRm.GetString("LbDefaultTax", Culture);
            lbDropShadowDepth.Text = InterfaceRm.GetString("LbDropShadowDepth", Culture);
            lbRoundingTo.Text = InterfaceRm.GetString("LbRoundingTo", Culture);
        }

        private void SetColor()
        {
            BackColor = BackupSetting.BodyBackColor;
            // Label
            lbCornerRadius.ForeColor
                = lbAlertTimer.ForeColor
                = lbDefaultTax.ForeColor
                = lbDropShadowDepth.ForeColor
                = lbRoundingTo.ForeColor
                = BackupSetting.BaseTextColor;
            // GroupBox
            grbInterface.ForeColor = BackupSetting.BaseTextColor;
            grbInvoice.ForeColor = BackupSetting.BaseTextColor;
            grbTimer.ForeColor = BackupSetting.BaseTextColor;
        }

        private void LoadContent()
        {
            nudAlertTimer.Value = BackupSetting.AlertTimer;
            nudCornerRadius.Value = BackupSetting.CornerRadius;
            nudDefaultTax.Value = (decimal)BackupSetting.DefaultTax;
            nudDropShadowDepth.Value = BackupSetting.DropShadowDepth;
            nudRoundingTo.Value = BackupSetting.RoundingTo;
        }
        #endregion

        #region Change parameter
        private void NudDropShadowDepth_ValueChanged(object sender, EventArgs e)
        {
            BackupSetting.DropShadowDepth = (int)(sender as NumericUpDown).Value;
        }

        private void NudCornerRadius_ValueChanged(object sender, EventArgs e)
        {
            BackupSetting.CornerRadius = (int)(sender as NumericUpDown).Value;
        }

        private void NudDefaultTax_ValueChanged(object sender, EventArgs e)
        {
            BackupSetting.DefaultTax = (float)(sender as NumericUpDown).Value;
        }

        private void NudRoundingTo_ValueChanged(object sender, EventArgs e)
        {
            BackupSetting.RoundingTo = (int)(sender as NumericUpDown).Value;
        }

        private void NudAlertTimer_ValueChanged(object sender, EventArgs e)
        {
            BackupSetting.AlertTimer = (int)(sender as NumericUpDown).Value;
        }
        #endregion
    }
}
