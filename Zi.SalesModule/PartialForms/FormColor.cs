using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.SalesModule.Settings;

namespace Zi.SalesModule.PartialForms
{
    public partial class FormColor : Form
    {
        #region Attributes
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public BackupSetting BackupSetting { get; set; }
        #endregion

        public FormColor(BackupSetting backupSetting)
        {
            InitializeComponent();
            BackupSetting = backupSetting;
        }

        #region Initial
        private void FormColor_Load(object sender, EventArgs e)
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
            InterfaceRm = new ResourceManager(BaseName, typeof(FormColor).Assembly);
        }

        private void SetStaticText()
        {
            grbBackColor.Text = InterfaceRm.GetString("GrbBackColor", Culture);
            grbForeColor.Text = InterfaceRm.GetString("GrbForeColor", Culture);
            grbItemColor.Text = InterfaceRm.GetString("GrbItemColor", Culture);
            grbOtherColor.Text = InterfaceRm.GetString("GrbOtherColor", Culture);

            lbBaseBackColor.Text = InterfaceRm.GetString("LbBaseBackColor", Culture);
            lbBaseHoverColor.Text = InterfaceRm.GetString("LbBaseHoverColor", Culture);
            lbBaseItemColor.Text = InterfaceRm.GetString("LbBaseItemColor", Culture);
            lbBaseTextColor.Text = InterfaceRm.GetString("LbBaseTextColor", Culture);
            lbBlurTextColor.Text = InterfaceRm.GetString("LbBlurTextColor", Culture);
            lbBodyColor.Text = InterfaceRm.GetString("LbBodyColor", Culture);
            lbButtonTextColor.Text = InterfaceRm.GetString("LbButtonTextColor", Culture);
            lbErrorTextColor.Text = InterfaceRm.GetString("LbErrorTextColor", Culture);
            lbFooterColor.Text = InterfaceRm.GetString("LbFooterColor", Culture);
            lbHeaderColor.Text = InterfaceRm.GetString("LbHeaderColor", Culture);
            lbHoverItemColor.Text = InterfaceRm.GetString("LbHoverItemColor", Culture);
            lbIconColor.Text = InterfaceRm.GetString("LbIconColor", Culture);
            lbInfoTextColor.Text = InterfaceRm.GetString("LbInfoTextColor", Culture);
            lbLeftSideBarColor.Text = InterfaceRm.GetString("LbLeftSideBarColor", Culture);
            lbNotificationColor.Text = InterfaceRm.GetString("LbNotificationColor", Culture);
            lbRightSideBarColor.Text = InterfaceRm.GetString("LbRightSideBarColor", Culture);
            lbSelectedItemColor.Text = InterfaceRm.GetString("LbSelectedItemColor", Culture);
            lbShadowColor.Text = InterfaceRm.GetString("LbShadowColor", Culture);
            lbSuccessTextColor.Text = InterfaceRm.GetString("LbSuccessTextColor", Culture);
            lbWarningTextColor.Text = InterfaceRm.GetString("LbWarningTextColor", Culture);
        }

        private void SetColor()
        {
            BackColor = BackupSetting.BodyBackColor;
            // Label
            lbBaseBackColor.ForeColor
                = lbBaseHoverColor.ForeColor
                = lbBaseItemColor.ForeColor
                = lbBaseTextColor.ForeColor
                = lbBlurTextColor.ForeColor
                = lbBodyColor.ForeColor
                = lbButtonTextColor.ForeColor
                = lbErrorTextColor.ForeColor
                = lbFooterColor.ForeColor
                = lbHeaderColor.ForeColor
                = lbHoverItemColor.ForeColor
                = lbIconColor.ForeColor
                = lbInfoTextColor.ForeColor
                = lbLeftSideBarColor.ForeColor
                = lbNotificationColor.ForeColor
                = lbRightSideBarColor.ForeColor
                = lbSelectedItemColor.ForeColor
                = lbShadowColor.ForeColor
                = lbSuccessTextColor.ForeColor
                = lbWarningTextColor.ForeColor
                = BackupSetting.BaseTextColor;
            // GroupBox
            grbBackColor.ForeColor
                = grbForeColor.ForeColor
                = grbItemColor.ForeColor
                = grbOtherColor.ForeColor
                = BackupSetting.BaseTextColor;
        }

        private void LoadContent()
        {
            pnlBaseBackColorPicker.BackColor = BackupSetting.BaseBackColor;
            pnlBaseHoverColorPicker.BackColor = BackupSetting.BaseHoverColor;
            pnlBaseItemColorPicker.BackColor = BackupSetting.BaseItemColor;
            pnlBaseTextColorPicker.BackColor = BackupSetting.BaseTextColor;
            pnlBlurTextColorPicker.BackColor = BackupSetting.BlurTextColor;
            pnlBodyColorPicker.BackColor = BackupSetting.BodyBackColor;
            pnlButtonTextColorPicker.BackColor = BackupSetting.BaseBorderColor;
            pnlErrorTextColorPicker.BackColor = BackupSetting.ErrorTextColor;
            pnlFooterColorPicker.BackColor = BackupSetting.FooterBackColor;
            pnlHeaderColorPicker.BackColor = BackupSetting.HeaderBackColor;
            pnlHoverItemColorPicker.BackColor = BackupSetting.ItemHoverColor;
            pnlIconColorPicker.BackColor = BackupSetting.BaseIconColor;
            pnlInfoTextColorPicker.BackColor = BackupSetting.InfoTextColor;
            pnlLeftSideBarColorPicker.BackColor = BackupSetting.LeftSideBarBackColor;
            pnlNotificationColorPicker.BackColor = BackupSetting.MsgBackColor;
            pnlRightSideBarPicker.BackColor = BackupSetting.RightSideBarBackColor;
            pnlSelectedItemColorPicker.BackColor = BackupSetting.ItemSelectedColor;
            pnlShadowColorPicker.BackColor = BackupSetting.DropShadowColor;
            pnlSuccessTextColorPicker.BackColor = BackupSetting.SuccessTextColor;
            pnlWarningTextColorPicker.BackColor = BackupSetting.WarningTextColor;
        }
        #endregion

        #region Change color
        private void PnlHeaderColorPicker_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.HeaderBackColor = colorDialog.Color;
            }
        }

        private void PnlFooterColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.FooterBackColor = colorDialog.Color;
            }
        }

        private void PnlLeftSideBarColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.LeftSideBarBackColor = colorDialog.Color;
            }
        }

        private void PnlRightSideBarPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.RightSideBarBackColor = colorDialog.Color;
            }
        }

        private void PnlBodyColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.BodyBackColor = colorDialog.Color;
            }
        }

        private void PnlBaseBackColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.BaseBackColor = colorDialog.Color;
            }
        }

        private void PnlBaseTextColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.BaseTextColor = colorDialog.Color;
            }
        }

        private void PnlErrorTextColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.ErrorTextColor = colorDialog.Color;
            }
        }

        private void PnlSuccessTextColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.SuccessTextColor = colorDialog.Color;
            }
        }

        private void PnlWarningTextColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.WarningTextColor = colorDialog.Color;
            }
        }

        private void PnlInfoTextColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.InfoTextColor = colorDialog.Color;
            }
        }

        private void PnlBlurTextColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.BlurTextColor = colorDialog.Color;
            }
        }

        private void PnlBaseItemColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.BaseItemColor = colorDialog.Color;
            }
        }

        private void PnlSelectedItemColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.ItemSelectedColor = colorDialog.Color;
            }
        }

        private void PnlHoverItemColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.ItemHoverColor = colorDialog.Color;
            }
        }

        private void PnlShadowColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.DropShadowColor = colorDialog.Color;
            }
        }

        private void PnlButtonTextColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.BaseBorderColor = colorDialog.Color;
            }
        }

        private void PnlIconColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.BaseIconColor = colorDialog.Color;
            }
        }

        private void PnlNotificationColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.MsgBackColor = colorDialog.Color;
            }
        }

        private void PnlBaseHoverColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog.Color;
                BackupSetting.BaseHoverColor = colorDialog.Color;
            }
        }
        #endregion
    }
}
