using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.SalesModule.Settings;

namespace Zi.SalesModule.PartialForms
{
    public partial class FormLanguage : Form
    {
        #region Attributes
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public BackupSetting BackupSetting { get; set; }
        #endregion

        public FormLanguage(BackupSetting backupSetting)
        {
            InitializeComponent();
            BackupSetting = backupSetting;
        }

        #region Initial
        private void FormLanguage_Load(object sender, EventArgs e)
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
            InterfaceRm = new ResourceManager(BaseName, typeof(FormLanguage).Assembly);
        }

        private void SetStaticText()
        {
            grbLanguages.Text = InterfaceRm.GetString("GrbLanguages", Culture);

            lbLanguages.Text = InterfaceRm.GetString("LbLanguages", Culture);

            rdEnglish.Text = InterfaceRm.GetString("RdEnglish", Culture);
            rdVietnamese.Text = InterfaceRm.GetString("RdVietnamese", Culture);
        }

        private void SetColor()
        {
            BackColor = BackupSetting.BodyBackColor;
            // Label
            lbLanguages.ForeColor = BackupSetting.BaseTextColor;
            // GroupBox
            grbLanguages.ForeColor = BackupSetting.BaseTextColor;
            // RadioButton
            rdVietnamese.ForeColor = BackupSetting.BaseTextColor;
            rdEnglish.ForeColor = BackupSetting.BaseTextColor;
        }

        private void LoadContent()
        {
            switch (BackupSetting.CultureName)
            {
                case "en-US":
                    rdEnglish.Checked = true;
                    break;
                case "vi-VN":
                    rdVietnamese.Checked = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Change language
        private void RdEnglish_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                BackupSetting.CultureName = "en-US";
            }
        }

        private void RdVietnamese_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                BackupSetting.CultureName = "vi-VN";
            }
        }
        #endregion
    }
}
