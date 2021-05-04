using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zi.ZiCoffee.Engines.Theme;

namespace Zi.ZiCoffee.Engines.TempleSetting
{
    public class TempleSetting
    {
        #region Temple Setting Attributes
        // Theme
        public bool IsDarkTheme { get; set; }
        public bool IsLightTheme { get; set; }
        // Sound
        public bool IsGreeting { get; set; }
        public bool IsBye { get; set; }
        public bool IsSoundTrack { get; set; }
        public bool IsClick { get; set; }
        public bool IsAppearance { get; set; }
        public bool IsNotification { get; set; }
        // Language
        public string CultureName { get; set; }
        // Table
        public int TableItemWidth { get; set; }
        public int TableItemHeigh { get; set; }
        public Color TableItemTempBack { get; set; }
        public Color TableItemUsingBack { get; set; }
        public Color TableItemFore { get; set; }
        // Service
        public int ServiceItemWidth { get; set; }
        public int ServiceItemHeigh { get; set; }
        public Color ServiceItemEnabledBack { get; set; }
        public Color ServiceItemDisabledBack { get; set; }
        public Color ServiceItemNameFore { get; set; }
        public Color ServiceItemPriceFore { get; set; }
        #endregion

        public TempleSetting()
        {
            GetCurrentTheme();
            GetCurrentSound();
            GetCurrentLanguage();
            GetCurrentTableObject();
            GetCurrentServiceObject();
        }

        public void GetCurrentServiceObject()
        {
            ServiceItemWidth = Properties.Settings.Default.ServiceItemWidth;
            ServiceItemHeigh = Properties.Settings.Default.ServiceItemHeigh;
            ServiceItemEnabledBack = Properties.Settings.Default.ServiceItemEnabledBack;
            ServiceItemDisabledBack = Properties.Settings.Default.ServiceItemDisabledBack;
            ServiceItemNameFore = Properties.Settings.Default.ServiceItemNameFore;
            ServiceItemPriceFore = Properties.Settings.Default.ServiceItemPriceFore;
        }

        public void GetCurrentTableObject()
        {
            TableItemWidth = Properties.Settings.Default.TableItemWidth;
            TableItemHeigh = Properties.Settings.Default.TableItemHeigh;
            TableItemTempBack = Properties.Settings.Default.TableItemTempBack;
            TableItemUsingBack = Properties.Settings.Default.TableItemUsingBack;
            TableItemFore = Properties.Settings.Default.TableItemFore;
        }

        public void GetCurrentLanguage()
        {
            CultureName = Properties.Settings.Default.CultureName;
        }

        public void GetCurrentSound()
        {
            IsGreeting = Properties.Settings.Default.IsGreeting;
            IsBye = Properties.Settings.Default.IsBye;
            IsSoundTrack = Properties.Settings.Default.IsSoundTrack;
            IsClick = Properties.Settings.Default.IsClick;
            IsAppearance = Properties.Settings.Default.IsAppearance;
            IsNotification = Properties.Settings.Default.IsNotification;
        }

        public void GetCurrentTheme()
        {
            IsDarkTheme = Properties.Settings.Default.IsDarkTheme;
            IsLightTheme = Properties.Settings.Default.IsLightTheme;
        }

        public bool SaveSetting()
        {
            Properties.Settings.Default.IsDarkTheme = IsDarkTheme;
            Properties.Settings.Default.IsLightTheme = IsLightTheme;
            if (IsDarkTheme)
            {
                new DarkTheme().SetTheme();
            }
            else if (IsLightTheme)
            {
                new LightTheme().SetTheme();
            }
            Properties.Settings.Default.IsGreeting = IsGreeting;
            Properties.Settings.Default.IsBye = IsBye;
            Properties.Settings.Default.IsSoundTrack = IsSoundTrack;
            Properties.Settings.Default.IsClick = IsClick;
            Properties.Settings.Default.IsAppearance = IsAppearance;
            Properties.Settings.Default.IsNotification = IsNotification;
            Properties.Settings.Default.CultureName = CultureName;
            Properties.Settings.Default.TableItemWidth = TableItemWidth;
            Properties.Settings.Default.TableItemHeigh = TableItemHeigh;
            Properties.Settings.Default.TableItemTempBack = TableItemTempBack;
            Properties.Settings.Default.TableItemUsingBack = TableItemUsingBack;
            Properties.Settings.Default.TableItemFore = TableItemFore;
            Properties.Settings.Default.ServiceItemWidth = ServiceItemWidth;
            Properties.Settings.Default.ServiceItemHeigh = ServiceItemHeigh;
            Properties.Settings.Default.ServiceItemEnabledBack = ServiceItemEnabledBack;
            Properties.Settings.Default.ServiceItemDisabledBack = ServiceItemDisabledBack;
            Properties.Settings.Default.ServiceItemNameFore = ServiceItemNameFore;
            Properties.Settings.Default.ServiceItemPriceFore = ServiceItemPriceFore;
            return true;
        }

        public bool SetDafault()
        {
            Properties.Settings.Default.IsDarkTheme = false;
            Properties.Settings.Default.IsLightTheme = true;
            if (IsDarkTheme)
            {
                new DarkTheme().SetTheme();
            }
            else if (IsLightTheme)
            {
                new LightTheme().SetTheme();
            }

            Properties.Settings.Default.IsGreeting = true;
            Properties.Settings.Default.IsBye = true;
            Properties.Settings.Default.IsSoundTrack = true;
            Properties.Settings.Default.IsClick = true;
            Properties.Settings.Default.IsAppearance = true;
            Properties.Settings.Default.IsNotification = true;

            Properties.Settings.Default.CultureName = "vi-VN";

            Properties.Settings.Default.TableItemWidth = 133;
            Properties.Settings.Default.TableItemHeigh = 133;

            Properties.Settings.Default.ServiceItemWidth = 163;
            Properties.Settings.Default.ServiceItemHeigh = 210;

            Properties.Settings.Default.TableItemTempBack = Color.FromArgb(0, 168, 255);
            Properties.Settings.Default.TableItemUsingBack = Color.Orange;
            Properties.Settings.Default.TableItemFore = Color.Black;

            Properties.Settings.Default.ServiceItemEnabledBack = Color.Yellow;
            Properties.Settings.Default.ServiceItemDisabledBack = Color.Gray;
            Properties.Settings.Default.ServiceItemNameFore = Color.Green;
            Properties.Settings.Default.ServiceItemPriceFore = Color.Red;
            return true;
        }
    }
}
