using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.SalesModule.Settings
{
    public class BackupSetting
    {
        #region Color Attributes
        public Color BlurTextColor { get; set; }
        public Color RightSideBarBackColor { get; set; }
        public Color BodyBackColor { get; set; }
        public Color FooterBackColor { get; set; }
        public Color InfoTextColor { get; set; }
        public Color LeftSideBarBackColor { get; set; }
        public Color SuccessTextColor { get; set; }
        public Color BaseItemColor { get; set; }
        public Color DropShadowColor { get; set; }
        public Color WarningTextColor { get; set; }
        public Color MsgBackColor { get; set; }
        public Color BaseHoverColor { get; set; }
        public Color BaseBackColor { get; set; }
        public Color HeaderBackColor { get; set; }
        public Color BaseTextColor { get; set; }
        public Color ItemSelectedColor { get; set; }
        public Color ItemHoverColor { get; set; }
        public Color BaseBorderColor { get; set; }
        public Color BaseIconColor { get; set; }
        public Color ErrorTextColor { get; set; }
        #endregion

        #region Sound Attributes
        public bool AllowSoundtrack { get; set; }
        public bool AllowInitSound { get; set; }
        public bool AllowScanDetectedSound { get; set; }
        public bool AllowSayBye { get; set; }
        public bool AllowClickSound { get; set; }
        public int VoiceBotSpeakerRate { get; set; }
        public int VoiceGender { get; set; }
        public int VoiceAge { get; set; }
        public int VoiceBotVolumn { get; set; }
        public string SoundtrackFileName { get; set; }
        #endregion

        #region Language Attributes
        public string CultureName { get; set; }
        #endregion

        #region Size Attributes
        public Size CategoryItemSize { get; set; }
        public Size ProductItemSize { get; set; }
        public Size AreaItemSize { get; set; }
        public Size TableItemSize { get; set; }
        #endregion

        #region Text Attributes
        public string ShopPhone { get; set; }
        public string ShopEmail { get; set; }
        public string ShopAddress { get; set; }
        public string ShopSite { get; set; }
        public string BrandName { get; set; }
        #endregion

        #region Parameter Attributes
        public float DefaultTax { get; set; }
        public int RoundingTo { get; set; }
        public int AlertTimer { get; set; }
        public int CornerRadius { get; set; }
        public int DropShadowDepth { get; set; }
        #endregion

        public BackupSetting()
        {
            GetSetting();
        }

        public void GetSetting()
        {
            BlurTextColor = Properties.Settings.Default.BlurTextColor;
            RightSideBarBackColor = Properties.Settings.Default.RightSideBarBackColor;
            BodyBackColor = Properties.Settings.Default.BodyBackColor;
            FooterBackColor = Properties.Settings.Default.FooterBackColor;
            InfoTextColor = Properties.Settings.Default.InfoTextColor;
            LeftSideBarBackColor = Properties.Settings.Default.LeftSideBarBackColor;
            SuccessTextColor = Properties.Settings.Default.SuccessTextColor;
            BaseItemColor = Properties.Settings.Default.BaseItemColor;
            DropShadowColor = Properties.Settings.Default.DropShadowColor;
            WarningTextColor = Properties.Settings.Default.WarningTextColor;
            MsgBackColor = Properties.Settings.Default.MsgBackColor;
            BaseHoverColor = Properties.Settings.Default.BaseHoverColor;
            BaseBackColor = Properties.Settings.Default.BaseBackColor;
            HeaderBackColor = Properties.Settings.Default.HeaderBackColor;
            BaseTextColor = Properties.Settings.Default.BaseTextColor;
            ItemSelectedColor = Properties.Settings.Default.ItemSelectedColor;
            ItemHoverColor = Properties.Settings.Default.ItemHoverColor;
            BaseBorderColor = Properties.Settings.Default.BaseBorderColor;
            BaseIconColor = Properties.Settings.Default.BaseIconColor;
            ErrorTextColor = Properties.Settings.Default.ErrorTextColor;

            AllowSoundtrack = Properties.Settings.Default.AllowSoundtrack;
            AllowInitSound = Properties.Settings.Default.AllowInitSound;
            AllowScanDetectedSound = Properties.Settings.Default.AllowScanDetectedSound;
            AllowSayBye = Properties.Settings.Default.AllowSayBye;
            AllowClickSound = Properties.Settings.Default.AllowClickSound;
            VoiceBotSpeakerRate = Properties.Settings.Default.VoiceBotSpeakerRate;
            VoiceGender = Properties.Settings.Default.VoiceGender;
            VoiceAge = Properties.Settings.Default.VoiceAge;
            VoiceBotVolumn = Properties.Settings.Default.VoiceBotVolumn;
            SoundtrackFileName = Properties.Settings.Default.SoundtrackFileName;

            CultureName = Properties.Settings.Default.CultureName;

            CategoryItemSize = Properties.Settings.Default.CategoryItemSize;
            ProductItemSize = Properties.Settings.Default.ProductItemSize;
            AreaItemSize = Properties.Settings.Default.AreaItemSize;
            TableItemSize = Properties.Settings.Default.TableItemSize;

            ShopPhone = Properties.Settings.Default.ShopPhone;
            ShopEmail = Properties.Settings.Default.ShopEmail;
            ShopAddress = Properties.Settings.Default.ShopAddress;
            ShopSite = Properties.Settings.Default.ShopSite;
            BrandName = Properties.Settings.Default.BrandName;

            DefaultTax = Properties.Settings.Default.DefaultTax;
            RoundingTo = Properties.Settings.Default.RoundingTo;
            AlertTimer = Properties.Settings.Default.AlertTimer;
            CornerRadius = Properties.Settings.Default.CornerRadius;
            DropShadowDepth = Properties.Settings.Default.DropShadowDepth;
        }

        public void SaveSetting()
        {
            Properties.Settings.Default.BlurTextColor = BlurTextColor;
            Properties.Settings.Default.RightSideBarBackColor = RightSideBarBackColor;
            Properties.Settings.Default.BodyBackColor = BodyBackColor;
            Properties.Settings.Default.FooterBackColor = FooterBackColor;
            Properties.Settings.Default.InfoTextColor = InfoTextColor;
            Properties.Settings.Default.LeftSideBarBackColor = LeftSideBarBackColor;
            Properties.Settings.Default.SuccessTextColor = SuccessTextColor;
            Properties.Settings.Default.BaseItemColor = BaseItemColor;
            Properties.Settings.Default.DropShadowColor = DropShadowColor;
            Properties.Settings.Default.WarningTextColor = WarningTextColor;
            Properties.Settings.Default.MsgBackColor = MsgBackColor;
            Properties.Settings.Default.BaseHoverColor = BaseHoverColor;
            Properties.Settings.Default.BaseBackColor = BaseBackColor;
            Properties.Settings.Default.HeaderBackColor = HeaderBackColor;
            Properties.Settings.Default.BaseTextColor = BaseTextColor;
            Properties.Settings.Default.ItemSelectedColor = ItemSelectedColor;
            Properties.Settings.Default.ItemHoverColor = ItemHoverColor;
            Properties.Settings.Default.BaseBorderColor = BaseBorderColor;
            Properties.Settings.Default.BaseIconColor = BaseIconColor;
            Properties.Settings.Default.ErrorTextColor = ErrorTextColor;

            Properties.Settings.Default.AllowSoundtrack = AllowSoundtrack;
            Properties.Settings.Default.AllowInitSound = AllowInitSound;
            Properties.Settings.Default.AllowScanDetectedSound = AllowScanDetectedSound;
            Properties.Settings.Default.AllowSayBye = AllowSayBye;
            Properties.Settings.Default.AllowClickSound = AllowClickSound;
            Properties.Settings.Default.VoiceBotSpeakerRate = VoiceBotSpeakerRate;
            Properties.Settings.Default.VoiceGender = VoiceGender;
            Properties.Settings.Default.VoiceAge = VoiceAge;
            Properties.Settings.Default.VoiceBotVolumn = VoiceBotVolumn;
            Properties.Settings.Default.SoundtrackFileName = SoundtrackFileName;

            Properties.Settings.Default.CultureName = CultureName;

            Properties.Settings.Default.CategoryItemSize = CategoryItemSize;
            Properties.Settings.Default.ProductItemSize = ProductItemSize;
            Properties.Settings.Default.AreaItemSize = AreaItemSize;
            Properties.Settings.Default.TableItemSize = TableItemSize;

            Properties.Settings.Default.ShopPhone = ShopPhone;
            Properties.Settings.Default.ShopEmail = ShopEmail;
            Properties.Settings.Default.ShopAddress = ShopAddress;
            Properties.Settings.Default.ShopSite = ShopSite;
            Properties.Settings.Default.BrandName = BrandName;

            Properties.Settings.Default.DefaultTax = DefaultTax;
            Properties.Settings.Default.RoundingTo = RoundingTo;
            Properties.Settings.Default.AlertTimer = AlertTimer;
            Properties.Settings.Default.CornerRadius = CornerRadius;
            Properties.Settings.Default.DropShadowDepth = DropShadowDepth;
        }

        public void SetDefault()
        {
            Properties.Settings.Default.BlurTextColor = Color.Silver;
            Properties.Settings.Default.RightSideBarBackColor = Color.FromArgb(46, 61, 74);
            Properties.Settings.Default.BodyBackColor = Color.FromArgb(38, 49, 61);
            Properties.Settings.Default.FooterBackColor = Color.FromArgb(46, 61, 74);
            Properties.Settings.Default.InfoTextColor = Color.Aqua;
            Properties.Settings.Default.LeftSideBarBackColor = Color.FromArgb(46, 61, 74);
            Properties.Settings.Default.SuccessTextColor = Color.FromArgb(0, 192, 0);
            Properties.Settings.Default.BaseItemColor = Color.FromArgb(28, 39, 49);
            Properties.Settings.Default.DropShadowColor = Color.FromArgb(34, 46, 58);
            Properties.Settings.Default.WarningTextColor = Color.FromArgb(255, 128, 0);
            Properties.Settings.Default.MsgBackColor = Color.FromArgb(23, 42, 70);
            Properties.Settings.Default.BaseHoverColor = Color.FromArgb(4, 119, 250);
            Properties.Settings.Default.BaseBackColor = Color.FromArgb(46, 61, 74);
            Properties.Settings.Default.HeaderBackColor = Color.FromArgb(46, 61, 74);
            Properties.Settings.Default.BaseTextColor = Color.Gainsboro;
            Properties.Settings.Default.ItemSelectedColor = Color.FromArgb(4, 119, 250);
            Properties.Settings.Default.ItemHoverColor = Color.FromArgb(33, 46, 58);
            Properties.Settings.Default.BaseBorderColor = Color.FromArgb(79, 202, 178);
            Properties.Settings.Default.BaseIconColor = Color.FromArgb(79, 202, 178);
            Properties.Settings.Default.ErrorTextColor = Color.Red;

            Properties.Settings.Default.AllowSoundtrack = true;
            Properties.Settings.Default.AllowInitSound = true;
            Properties.Settings.Default.AllowScanDetectedSound = true;
            Properties.Settings.Default.AllowSayBye = true;
            Properties.Settings.Default.AllowClickSound = true;
            Properties.Settings.Default.VoiceBotSpeakerRate = 0;
            Properties.Settings.Default.VoiceGender = 1;
            Properties.Settings.Default.VoiceAge = 10;
            Properties.Settings.Default.VoiceBotVolumn = 100;
            Properties.Settings.Default.SoundtrackFileName = "LangQuenChieuThuSoundtrack.wav";

            Properties.Settings.Default.CultureName = "en-US";

            Properties.Settings.Default.CategoryItemSize = new Size(300, 50);
            Properties.Settings.Default.ProductItemSize = new Size(400, 200);
            Properties.Settings.Default.AreaItemSize = new Size(200, 50);
            Properties.Settings.Default.TableItemSize = new Size(200, 200);

            Properties.Settings.Default.ShopPhone = "0943144178";
            Properties.Settings.Default.ShopEmail = "zitech.dev@gmail.com";
            Properties.Settings.Default.ShopAddress = "21bis Điện Biên Phủ - P.25 - Bình Thạnh - TP.HCM";
            Properties.Settings.Default.ShopSite = "https://zitechdev.com";
            Properties.Settings.Default.BrandName = "ZiCoffee";

            Properties.Settings.Default.DefaultTax = 10;
            Properties.Settings.Default.RoundingTo = 1000;
            Properties.Settings.Default.AlertTimer = 2000;
            Properties.Settings.Default.CornerRadius = 20;
            Properties.Settings.Default.DropShadowDepth = 10;
        }
    }
}
