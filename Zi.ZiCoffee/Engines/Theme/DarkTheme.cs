using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.ZiCoffee.Engines.Theme
{
    public class DarkTheme
    {
        #region BackColor Attributes
        // Màu nền chủ đạo
        public Color MainBack { get; set; }
        // Màu nền header/footer
        public Color HFBack { get; set; }
        // Màu nền popup
        public Color PopupBack { get; set; }
        // Màu nền nội dung
        public Color ContentBack { get; set; }
        // Màu nền nút bấm
        public Color ButtonBackNoBorder { get; set; }
        public Color ButtonBackBorder { get; set; }
        public Color ButtonBackNavHover { get; set; }
        public Color ButtonBackBlueHover { get; set; }
        // Màu nền Disabled
        public Color DisabledBack { get; set; }
        // Màu nền Minimize
        public Color MinimizeBack { get; set; }
        // Màu nền Maximize / Normal
        public Color MaximizeBack { get; set; }
        // Màu nền Close
        public Color CloseBack { get; set; }
        // Màu nền window state icon
        public Color WinStateBack { get; set; }
        // Màu nền chung hiệu ứng highlight
        public Color HighlightEffectBack { get; set; }
        // Màu nền ReadOnly TextBox
        public Color ReadOnlyTextBoxBack { get; set; }
        #endregion

        #region ForeColor Attributes
        // Màu chữ chủ đạo
        public Color MainFore { get; set; }
        // Màu chữ header/footer
        public Color HFFore { get; set; }
        // Màu chữ popup
        public Color PopupFore { get; set; }
        // Màu chữ nội dung
        public Color ContentFore { get; set; }
        // Màu chữ nút bấm
        public Color ButtonForeNoBorder { get; set; }
        public Color ButtonForeBorder { get; set; }
        // Màu chữ Disabled
        public Color DisabledFore { get; set; }
        // Màu chữ thành công / hoàn thành
        public Color SuccessFore { get; set; }
        // Màu chữ thất bại / lỗi
        public Color ErrorFore { get; set; }
        // Màu chữ cảnh báo
        public Color WarningFore { get; set; }
        // Màu chữ ReadOnly TextBox
        public Color ReadOnlyTextBoxFore { get; set; }
        #endregion

        public DarkTheme()
        {
            MainBack = Color.FromArgb(34, 36, 49);
            HFBack = Color.FromArgb(0, 38, 77);
            PopupBack = Color.Gainsboro;
            ContentBack = Color.Black;
            ButtonBackNoBorder = Color.FromArgb(78, 184, 206);
            ButtonBackBorder = Color.Transparent;
            ButtonBackNavHover = Color.FromArgb(102, 0, 102);
            ButtonBackBlueHover = Color.FromArgb(0, 168, 255);
            DisabledBack = Color.Gray;
            WinStateBack = Color.FromArgb(102, 102, 102);
            HighlightEffectBack = Color.FromArgb(78, 184, 206);

            MinimizeBack = Color.FromArgb(0, 153, 51);
            MaximizeBack = Color.FromArgb(255, 204, 0);
            CloseBack = Color.Red;

            ReadOnlyTextBoxBack = SystemColors.ActiveCaption;

            MainFore = Color.White;
            HFFore = Color.White;
            PopupFore = Color.FromArgb(34, 36, 49);
            ContentFore = Color.White;
            ButtonForeNoBorder = MainBack;
            ButtonForeBorder = Color.FromArgb(78, 184, 206);
            DisabledFore = Color.White;

            SuccessFore = Color.FromArgb(0, 153, 51);
            ErrorFore = Color.Red;
            WarningFore = Color.FromArgb(255, 204, 0);

            ReadOnlyTextBoxFore = Color.Blue;
        }

        public void SetTheme()
        {
            Properties.Settings.Default.MainBack = MainBack;
            Properties.Settings.Default.HFBack = HFBack;
            Properties.Settings.Default.PopupBack = PopupBack;
            Properties.Settings.Default.ContentBack = ContentBack;
            Properties.Settings.Default.ButtonBackNoBorder = ButtonBackNoBorder;
            Properties.Settings.Default.ButtonBackBorder = ButtonBackBorder;
            Properties.Settings.Default.ButtonBackNavHover =  ButtonBackNavHover;
            Properties.Settings.Default.ButtonBackBlueHover = ButtonBackBlueHover;
            Properties.Settings.Default.DisabledBack = DisabledBack;
            Properties.Settings.Default.WinStateBack = WinStateBack;
            Properties.Settings.Default.HighlightEffectBack = HighlightEffectBack;

            Properties.Settings.Default.MinimizeBack = MinimizeBack;
            Properties.Settings.Default.MaximizeBack = MaximizeBack;
            Properties.Settings.Default.CloseBack = CloseBack;

            Properties.Settings.Default.ReadOnlyTextBoxBack = ReadOnlyTextBoxBack;

            Properties.Settings.Default.MainFore = MainFore;
            Properties.Settings.Default.HFFore = HFFore;
            Properties.Settings.Default.PopupFore = PopupFore;
            Properties.Settings.Default.ContentFore = ContentFore;
            Properties.Settings.Default.ButtonForeNoBorder = ButtonForeNoBorder;
            Properties.Settings.Default.ButtonForeBorder = ButtonForeBorder;
            Properties.Settings.Default.DisabledFore = DisabledFore;

            Properties.Settings.Default.SuccessFore = SuccessFore;
            Properties.Settings.Default.ErrorFore = ErrorFore;
            Properties.Settings.Default.WarningFore = WarningFore;

            Properties.Settings.Default.ReadOnlyTextBoxFore = ReadOnlyTextBoxFore;
        }
    }
}
