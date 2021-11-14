using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Convertors;
using Zi.SalesModule.CustomControls;
using Zi.SalesModule.Settings;

namespace Zi.SalesModule.PartialForms
{
    public partial class FormSize : Form
    {
        #region Attributes
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public BackupSetting BackupSetting { get; set; }
        #endregion

        public FormSize(BackupSetting backupSetting)
        {
            InitializeComponent();
            BackupSetting = backupSetting;
        }

        #region Initial
        private void FormSize_Load(object sender, EventArgs e)
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
            InterfaceRm = new ResourceManager(BaseName, typeof(FormSize).Assembly);
        }

        private void SetStaticText()
        {
            grbAreaItem.Text = InterfaceRm.GetString("GrbAreaItem", Culture);
            grbCategoryItem.Text = InterfaceRm.GetString("GrbCategoryItem", Culture);
            grbProductItem.Text = InterfaceRm.GetString("GrbProductItem", Culture);
            grbTableItem.Text = InterfaceRm.GetString("GrbTableItem", Culture);

            lbAreaItemWidth.Text
                = lbCategoryItemWidth.Text
                = lbProductItemWidth.Text
                = lbTableItemWidth.Text
                = InterfaceRm.GetString("LbItemWidth", Culture);

            lbAreaItemHeight.Text
                = lbCategoryItemHeight.Text
                = lbProductItemHeight.Text
                = lbTableItemHeight.Text
                = InterfaceRm.GetString("LbItemHeight", Culture);
        }

        private void SetColor()
        {
            BackColor = BackupSetting.BodyBackColor;
            // Label
            lbAreaItemHeight.ForeColor
                = lbAreaItemWidth.ForeColor
                = lbCategoryItemHeight.ForeColor
                = lbCategoryItemWidth.ForeColor
                = lbProductItemHeight.ForeColor
                = lbProductItemWidth.ForeColor
                = lbTableItemHeight.ForeColor
                = lbTableItemWidth.ForeColor
                = BackupSetting.BaseTextColor;
            // GroupBox
            grbAreaItem.ForeColor 
                = grbCategoryItem.ForeColor
                = grbProductItem.ForeColor
                = grbTableItem.ForeColor
                = BackupSetting.BaseTextColor;
        }

        private void LoadContent()
        {
            Size areaItemSize = BackupSetting.AreaItemSize;
            Size tableItemSize = BackupSetting.TableItemSize;
            Size categoryItemSize = BackupSetting.CategoryItemSize;
            Size productItemSize = BackupSetting.ProductItemSize;

            nudAreaItemHeight.Value = areaItemSize.Height;
            nudCategoryItemHeight.Value = categoryItemSize.Height;
            nudProductItemHeight.Value = productItemSize.Height;
            nudTableItemHeight.Value = tableItemSize.Height;

            nudAreaItemWidth.Value = areaItemSize.Width;
            nudCategoryItemWidth.Value = categoryItemSize.Width;
            nudProductItemWidth.Value = productItemSize.Width;
            nudTableItemWidth.Value = tableItemSize.Width;

            LoadAreaItemIllustration();
            LoadTableItemIllustration();
            LoadCategoryItemIllustration();
            LoadProductItemIllustration();
        }

        private void LoadAreaItemIllustration()
        {
            fpnlAreaItemIllustration.Controls.Clear();
            AreaModel areaModel = new AreaModel(InterfaceRm.GetString("AreaModel", Culture));
            AreaItem areaItem = new AreaItem(areaModel);
            areaItem.Size = BackupSetting.AreaItemSize;
            fpnlAreaItemIllustration.Controls.Add(areaItem);
        }

        private void LoadTableItemIllustration()
        {
            fpnlTableItemIllustration.Controls.Clear();
            TableModel tableModel = new TableModel(InterfaceRm.GetString("TableModel", Culture), Guid.Empty);
            TableItem tableItem = new TableItem(tableModel);
            tableItem.Size = BackupSetting.TableItemSize;
            fpnlTableItemIllustration.Controls.Add(tableItem);
        }

        private void LoadCategoryItemIllustration()
        {
            fpnlCategoryItemIllustration.Controls.Clear();
            CategoryModel categoryModel = new CategoryModel(InterfaceRm.GetString("CategoryModel", Culture));
            CategoryItem categoryItem = new CategoryItem(categoryModel);
            categoryItem.Size = BackupSetting.CategoryItemSize;
            fpnlCategoryItemIllustration.Controls.Add(categoryItem);
        }

        private void LoadProductItemIllustration()
        {
            string runningPath = AppDomain.CurrentDomain.BaseDirectory; 
            string fileName = string.Format("{0}Resources\\NoImage.png", Path.GetFullPath(Path.Combine(runningPath, @"..\..\")));
            fpnlProductItemIllustration.Controls.Clear();
            ProductModel productModel = new ProductModel(InterfaceRm.GetString("ProductModel", Culture), DataTypeConvertor.Instance.GetBytesFromImage(fileName), Guid.Empty);
            ProductItem productItem = new ProductItem(productModel);
            productItem.Size = BackupSetting.ProductItemSize;
            fpnlProductItemIllustration.Controls.Add(productItem);
        }
        #endregion

        #region Area
        private void NudAreaItemWidth_ValueChanged(object sender, EventArgs e)
        {
            Size areaItemSize = BackupSetting.AreaItemSize;
            areaItemSize.Width = (int)(sender as NumericUpDown).Value;
            BackupSetting.AreaItemSize = areaItemSize;
            LoadAreaItemIllustration();
        }

        private void NudAreaItemHeight_ValueChanged(object sender, EventArgs e)
        {
            Size areaItemSize = BackupSetting.AreaItemSize;
            areaItemSize.Height = (int)(sender as NumericUpDown).Value;
            BackupSetting.AreaItemSize = areaItemSize;
            LoadAreaItemIllustration();
        }
        #endregion

        #region Table
        private void NudTableItemWidth_ValueChanged(object sender, EventArgs e)
        {
            Size tableItemSize = BackupSetting.TableItemSize;
            tableItemSize.Width = (int)(sender as NumericUpDown).Value;
            BackupSetting.TableItemSize = tableItemSize;
            LoadTableItemIllustration();
        }

        private void NudTableItemHeight_ValueChanged(object sender, EventArgs e)
        {
            Size tableItemSize = BackupSetting.TableItemSize;
            tableItemSize.Height = (int)(sender as NumericUpDown).Value;
            BackupSetting.TableItemSize = tableItemSize;
            LoadTableItemIllustration();
        }
        #endregion

        #region Category
        private void NudCategoryItemWidth_ValueChanged(object sender, EventArgs e)
        {
            Size categoryItemSize = BackupSetting.CategoryItemSize;
            categoryItemSize.Width = (int)(sender as NumericUpDown).Value;
            BackupSetting.CategoryItemSize = categoryItemSize;
            LoadCategoryItemIllustration();
        }

        private void NudCategoryItemHeight_ValueChanged(object sender, EventArgs e)
        {
            Size categoryItemSize = BackupSetting.CategoryItemSize;
            categoryItemSize.Height = (int)(sender as NumericUpDown).Value;
            BackupSetting.CategoryItemSize = categoryItemSize;
            LoadCategoryItemIllustration();
        }
        #endregion

        #region Product
        private void NudProductItemWidth_ValueChanged(object sender, EventArgs e)
        {
            Size productItemSize = BackupSetting.ProductItemSize;
            productItemSize.Width = (int)(sender as NumericUpDown).Value;
            BackupSetting.ProductItemSize = productItemSize;
            LoadProductItemIllustration();
        }

        private void NudProductItemHeight_ValueChanged(object sender, EventArgs e)
        {
            Size productItemSize = BackupSetting.ProductItemSize;
            productItemSize.Height = (int)(sender as NumericUpDown).Value;
            BackupSetting.ProductItemSize = productItemSize;
            LoadProductItemIllustration();
        }
        #endregion
    }
}
