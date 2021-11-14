using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using Zi.SalesModule.Settings;

namespace Zi.SalesModule.PartialForms
{
    public partial class FormText : Form
    {
        #region Attributes
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public BackupSetting BackupSetting { get; set; }
        #endregion

        public FormText(BackupSetting backupSetting)
        {
            InitializeComponent();
            BackupSetting = backupSetting;
        }

        #region Initial
        private void FormText_Load(object sender, EventArgs e)
        {
            LoadSetting();
            LoadContent();
            ActiveControl = txbShopPhone;
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
            InterfaceRm = new ResourceManager(BaseName, typeof(FormText).Assembly);
        }

        private void SetStaticText()
        {
            grbTexts.Text = InterfaceRm.GetString("GrbTexts", Culture);

            lbBrandName.Text = InterfaceRm.GetString("LbBrandName", Culture);
            lbShopEmail.Text = InterfaceRm.GetString("LbShopEmail", Culture);
            lbShopPhone.Text = InterfaceRm.GetString("LbShopPhone", Culture);
            lbShopSite.Text = InterfaceRm.GetString("LbShopSite", Culture);
            lbShopAddress.Text = InterfaceRm.GetString("LbShopAddress", Culture);
        }

        private void SetColor()
        {
            BackColor = BackupSetting.BodyBackColor;
            // Label
            lbBrandName.ForeColor
                = lbShopAddress.ForeColor
                = lbShopEmail.ForeColor
                = lbShopPhone.ForeColor
                = lbShopSite.ForeColor
                = BackupSetting.BaseTextColor;
            // GroupBox
            grbTexts.ForeColor = BackupSetting.BaseTextColor;
        }

        private void LoadContent()
        {
            txbBrandName.Text = BackupSetting.BrandName;
            txbShopAddress.Text = BackupSetting.ShopAddress;
            txbShopEmail.Text = BackupSetting.ShopEmail;
            txbShopPhone.Text = BackupSetting.ShopPhone;
            txbShopSite.Text = BackupSetting.ShopSite;
        }
        #endregion

        #region Change text
        private void TxbShopPhone_TextChanged(object sender, EventArgs e)
        {
            BackupSetting.ShopPhone = (sender as TextBox).Text;
        }

        private void TxbShopEmail_TextChanged(object sender, EventArgs e)
        {
            BackupSetting.ShopEmail = (sender as TextBox).Text;
        }

        private void TxbShopAddress_TextChanged(object sender, EventArgs e)
        {
            BackupSetting.ShopAddress = (sender as TextBox).Text;
        }

        private void TxbShopSite_TextChanged(object sender, EventArgs e)
        {
            BackupSetting.ShopSite = (sender as TextBox).Text;
        }

        private void TxbBrandName_TextChanged(object sender, EventArgs e)
        {
            BackupSetting.BrandName = (sender as TextBox).Text;
        }
        #endregion
    }
}
