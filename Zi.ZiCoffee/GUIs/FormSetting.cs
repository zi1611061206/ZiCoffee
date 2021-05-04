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
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.DataTransferLayer.Enums;
using Zi.ZiCoffee.Engines.TempleSetting;
using Zi.ZiCoffee.GUIs.CustomControls;

namespace Zi.ZiCoffee.GUIs
{
    public partial class FormSetting : Form
    {
        #region Form Corner
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        #endregion

        #region Form Move
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Attributes
        public Stream StreamOpen { get; set; }
        public Stream StreamClick { get; set; }
        public SoundPlayer Player { get; set; }
        public SpeechSynthesizer Speaker { get; set; }
        public TempleSetting Temple { get; set; }
        public TempleSetting TempleCompare { get; set; }
        #endregion

        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlObjectModifier.Hide();
            LoadSetting();
            Temple = new TempleSetting();
            TempleCompare = new TempleSetting();
            LoadContent();
        }

        // LoadContent
        private void LoadContent()
        {
            LoadThemeOptions();
            LoadSoundChecker();
            LoadLanguageSelector();
        }

        private void LoadLanguageSelector()
        {
            List<CultureDetail> cultures = new List<CultureDetail>() {
                new CultureDetail(Properties.Resources.vi, "vi-VN", "Tiếng Việt"),
                new CultureDetail(Properties.Resources.en, "en-US", "Tiếng Anh")
            };

            foreach(var item in cultures.Select((value, index) => (value, index)))
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem
                {
                    Name = "item" + item.index,
                    Text = item.value.LanguageName,
                    Image = item.value.FlagIcon,
                    Tag = item.value.CultureChar
                };
                menuItem.Click += MenuItem_Click;
                cmsLanguage.Items.Add(menuItem);

                if (Temple.CultureName.Equals(item.value.CultureChar))
                {
                    picFlag.Image = item.value.FlagIcon;
                }
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            picFlag.Image = menuItem.Image;
            Temple.CultureName = menuItem.Tag.ToString();
        }

        private void LoadSoundChecker()
        {
            ckbSoundGreeting.Checked = Temple.IsGreeting;
            ckbSoundBye.Checked = Temple.IsBye;
            ckbSoundTrack.Checked = Temple.IsSoundTrack;
            ckbSoundClick.Checked = Temple.IsClick;
            ckbSoundAppearance.Checked = Temple.IsAppearance;
            ckbSoundNotification.Checked = Temple.IsNotification;
        }

        private void LoadThemeOptions()
        {
            Point point = new Point();
            if (Temple.IsDarkTheme)
            {
                point = cpicDarkTheme.Location;
            }
            else if (Temple.IsLightTheme)
            {
                point = cpicLightTheme.Location;
            }    
            point.X += 10;
            point.Y += 10;
            picSelected.Location = point;
        }

        // LoadSetting
        private void LoadSetting()
        {
            // Language settings
            SettingLanguage();
            // Theme settings
            SettingTheme();
            // Audio settings
            SettingAudio();
        }

        private void SettingAudio()
        {
            // Âm thanh khởi tạo
            if (Properties.Settings.Default.IsAppearance)
            {
                StreamOpen = Properties.Resources.open;
            }
            else
            {
                StreamOpen = null;
            }

            if (StreamOpen != null)
            {
                SoundPlayer sound = new SoundPlayer
                {
                    Stream = StreamOpen
                };
                sound.Play();
            }

            // Âm thanh Click chuột
            if (Properties.Settings.Default.IsClick)
            {
                StreamClick = Properties.Resources.clickOK;
            }
            else
            {
                StreamClick = null;
            }
        }

        private void SettingLanguage()
        {
            string cultureName = Properties.Settings.Default.CultureName;
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            ResourceManager rm = new ResourceManager("Zi.ZiCoffee.Engines.Lang.ResourceLang", typeof(FormSetting).Assembly);
        }

        private void SettingTheme()
        {
            // BackColor
            (this as Form).BackColor = Properties.Settings.Default.MainBack;
            pnlTitle.BackColor = Properties.Settings.Default.HFBack;
            pnlWinState.BackColor = Properties.Settings.Default.WinStateBack;
            btnCancel.BackColor
                = btnDefault.BackColor
                = btnSave.BackColor
                = Properties.Settings.Default.ButtonBackBorder;

            // ForeColor
            (this as Form).ForeColor
                = lbTitle.ForeColor
                = lbThemeTitle.ForeColor
                = lbSoundTitle.ForeColor
                = lbObjectTitle.ForeColor
                = lbLanguageTitle.ForeColor
                = ckbSoundAppearance.ForeColor
                = ckbSoundBye.ForeColor
                = ckbSoundClick.ForeColor
                = ckbSoundGreeting.ForeColor
                = ckbSoundNotification.ForeColor
                = ckbSoundTrack.ForeColor
                = Properties.Settings.Default.MainFore;
            btnCancel.ForeColor
                = btnDefault.ForeColor
                = btnSave.ForeColor
                = Properties.Settings.Default.ButtonForeBorder;
        }

        private void PicClose_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.BackColor = Properties.Settings.Default.CloseBack;
        }

        private void PicClose_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.BackColor = Color.Transparent;
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            //Áp dụng di chuyển form cho pnlTitle
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            PicClose_Click(this, new EventArgs());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Temple.SaveSetting())
            {
                MessageBox.Show("Lưu cài đặt thành công", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lưu cài đặt thất bại", "Thông báo");
            }
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thao tác này sẽ đưa toàn bộ cài đặt về cài đặt gốc, bạn chắc chắn chứ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.No)
            {
                if (Temple.SetDafault())
                {
                    MessageBox.Show("Đã khôi phục cài đặt gốc", "Thông báo");
                    LoadSetting();
                }
            }
            else
            {
                MessageBox.Show("Lưu cài đặt thất bại", "Thông báo");
            }
        }

        private void PicThemeSelector_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            Point point = pic.Location;
            point.X += 10;
            point.Y += 10;
            picSelected.Location = point;

            if (pic.Name.Equals("cpicDarkTheme"))
            {
                Temple.IsDarkTheme = true;
                Temple.IsLightTheme = false;
            }
            else if (pic.Name.Equals("cpicLightTheme"))
            {
                Temple.IsLightTheme = true;
                Temple.IsDarkTheme = false;
            }
        }

        private void AllCheckBoxSound_MouseHover(object sender, EventArgs e)
        {
            Speaker = new SpeechSynthesizer
            {
                Volume = Properties.Settings.Default.SpeakerVolumn
            };
            Speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
            Speaker.Rate = Properties.Settings.Default.SpeakerRate;
            switch ((sender as CheckBox).Name)
            {
                case "ckbSoundClick":
                    PlaySound(Properties.Resources.clickOK);
                    break;
                case "ckbSoundTrack":
                    break;
                case "ckbSoundAppearance":
                    PlaySound(Properties.Resources.open);
                    break;
                case "ckbSoundNotification":
                    break;
                case "ckbSoundGreeting":
                    Speaker.Speak("Welcome to Coffee Shop Managerment. How are you ,today?");
                    break;
                case "ckbSoundBye":
                    Speaker.Speak("Good bye. See you later");
                    break;
                default: break;
            }
        }

        private void PlaySound(UnmanagedMemoryStream soundStream)
        {
            Player = new SoundPlayer
            {
                Stream = soundStream
            };
            Player.Play();
        }

        private void AllCheckBoxSound_MouseLeave(object sender, EventArgs e)
        {
            if (Player != null)
            {
                Player.Stop();
                Player.Stream.Dispose();
            }
            if(Speaker != null)
            {
                Speaker.Pause();
                Speaker.Dispose();
            }
        }

        private void AllCheckBoxSound_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckb = sender as CheckBox;
            switch (ckb.Name)
            {
                case "ckbSoundClick":
                    Temple.IsClick = ckb.Checked;
                    break;
                case "ckbSoundTrack":
                    Temple.IsSoundTrack = ckb.Checked;
                    break;
                case "ckbSoundAppearance":
                    Temple.IsAppearance = ckb.Checked;
                    break;
                case "ckbSoundNotification":
                    Temple.IsNotification = ckb.Checked;
                    break;
                case "ckbSoundGreeting":
                    Temple.IsGreeting = ckb.Checked;
                    break;
                case "ckbSoundBye":
                    Temple.IsBye = ckb.Checked;
                    break;
                default:
                    break;
            }
        }

        private void AllButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && StreamClick != null)
            {
                SoundPlayer sound = new SoundPlayer();
                StreamClick.Position = 0;
                sound.Stream = null;
                sound.Stream = StreamClick;
                sound.Play();
            }
        }

        private void CbObjectSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem.ToString().Equals("Bàn"))
            {
                LoadTablePreview();
                LoadTableModifier();
            }
            else if (cb.SelectedItem.ToString().Equals("Dịch vụ"))
            {
                LoadServicePreview();
                LoadServiceModifier();
            }
        }

        private void LoadServiceModifier()
        {
            CleanLateEvent();
            nudWidth.Value = Temple.ServiceItemWidth;
            nudHeight.Value = Temple.ServiceItemHeigh;
            pnlOnBackColor.BackColor = Temple.ServiceItemEnabledBack;
            pnlOffBackColor.BackColor = Temple.ServiceItemDisabledBack;
            pnlMainFore.BackColor = Temple.ServiceItemNameFore;
            pnlSubFore.BackColor = Temple.ServiceItemPriceFore;
            InitLateEvent();
        }

        private void LoadTableModifier()
        {
            CleanLateEvent();
            nudWidth.Value = Temple.TableItemWidth;
            nudHeight.Value = Temple.TableItemHeigh;
            pnlOnBackColor.BackColor = Temple.TableItemTempBack;
            pnlOffBackColor.BackColor = Temple.TableItemUsingBack;
            pnlMainFore.BackColor = Temple.TableItemFore;
            InitLateEvent();
        }

        private void CleanLateEvent()
        {
            nudWidth.ValueChanged -= NudWidth_ValueChanged;
            nudHeight.ValueChanged -= NudHeight_ValueChanged;
            pnlOnBackColor.BackColorChanged -= PnlOnBackColor_BackColorChanged;
            pnlOffBackColor.BackColorChanged -= PnlOffBackColor_BackColorChanged;
            pnlMainFore.BackColorChanged -= PnlMainFore_BackColorChanged;
            pnlSubFore.BackColorChanged -= PnlSubFore_BackColorChanged;
        }

        private void InitLateEvent()
        {
            nudWidth.ValueChanged += NudWidth_ValueChanged;
            nudHeight.ValueChanged += NudHeight_ValueChanged;
            pnlOnBackColor.BackColorChanged += PnlOnBackColor_BackColorChanged;
            pnlOffBackColor.BackColorChanged += PnlOffBackColor_BackColorChanged;
            pnlMainFore.BackColorChanged += PnlMainFore_BackColorChanged;
            pnlSubFore.BackColorChanged += PnlSubFore_BackColorChanged;
        }

        private void LoadServicePreview()
        {
            pnlSubFore.Show();
            pnlObjectModifier.Hide();

            pnlPreview.Controls.Clear();
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                SizeMode = TabSizeMode.Fixed
            };

            List<ServiceStatus> statusList = Enum.GetValues(typeof(ServiceStatus)).Cast<ServiceStatus>().ToList();
            foreach (ServiceStatus item in statusList)
            {
                TabPage tp = new TabPage
                {
                    Name = item.ToString().Equals("Available") ? "tpEnabled" : "tpDisabled",
                    Text = item.ToString().Equals("Available") ? "Bật" : "Tắt",
                    BackColor = Properties.Settings.Default.ContentBack,
                    ForeColor = Properties.Settings.Default.ContentFore
                };
                tabControl.TabPages.Add(tp);
            }

            TabPage tpDefault = tabControl.SelectedTab = tabControl.TabPages["tpDisabled"];
            DrawServiceSample(tpDefault);
            pnlObjectModifier.Tag = tpDefault;
            tabControl.Selecting += TcServiceSample_Selecting;
            pnlPreview.Controls.Add(tabControl);
        }

        private void TcServiceSample_Selecting(object sender, TabControlCancelEventArgs e)
        {
            pnlObjectModifier.Hide();
            TabPage tp = (sender as TabControl).SelectedTab;
            pnlObjectModifier.Tag = tp;
            DrawServiceSample(tp);
        }

        private void DrawServiceSample(TabPage tp)
        {
            tp.Controls.Clear();

            Panel pnlContainer = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                TabStop = false
            };
            ItemCornerPanel pnlService = new ItemCornerPanel()
            {
                Width = Temple.ServiceItemWidth,
                Height = Temple.ServiceItemHeigh,
                BackColor = tp.Text.Equals("Bật") ? Temple.ServiceItemEnabledBack : Temple.ServiceItemDisabledBack,
                TabStop = false,
                BorderStyle = BorderStyle.None
            };
            Label lbName = new Label()
            {
                ForeColor = Temple.ServiceItemNameFore,
                Font = new Font("Arial", 12.0f, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                MaximumSize = new System.Drawing.Size(pnlService.Width, 0),
                AutoSize = true,
                Text = "Tên dịch vụ",
                Padding = new Padding(0, 3, 0, 3)
            };
            Label lbPrice = new Label()
            {
                ForeColor = Temple.ServiceItemPriceFore,
                Font = new Font("Arial", 10.0f, FontStyle.Italic),
                Dock = DockStyle.Bottom,
                Text = "0 VND",
                Padding = new Padding(0, 3, 0, 3)
            };
            Panel pnlInfo = new Panel()
            {
                Dock = DockStyle.Bottom,
                Height = lbName.Height + lbPrice.Height,
                AutoSize = true
            };
            ItemCornerPicture picImage = new ItemCornerPicture()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Tag = tp.Text,
                Image = Properties.Resources.no_image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.None
            };

            picImage.Click += PicImage_Click;

            pnlService.Controls.Add(picImage);
            pnlInfo.Controls.Add(lbName);
            pnlInfo.Controls.Add(lbPrice);
            pnlService.Controls.Add(pnlInfo);
            pnlContainer.Controls.Add(pnlService);

            tp.Controls.Add(pnlContainer);
        }

        private void PicImage_Click(object sender, EventArgs e)
        {
            pnlObjectModifier.Show();
            ItemCornerPicture pic = sender as ItemCornerPicture;
            if (pic.Tag.ToString().Equals("Bật"))
            {
                pnlOffBackColor.Hide();
                pnlOnBackColor.Show();
            }
            else
            {
                pnlOnBackColor.Hide();
                pnlOffBackColor.Show();
            }
        }

        private void LoadTablePreview()
        {
            pnlSubFore.Hide();
            pnlObjectModifier.Hide();

            pnlPreview.Controls.Clear();
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                SizeMode = TabSizeMode.Fixed
            };

            List<TableStatus> statusList = Enum.GetValues(typeof(TableStatus)).Cast<TableStatus>().ToList();
            foreach (TableStatus item in statusList)
            {
                TabPage tp = new TabPage
                {
                    Name = item.ToString().Equals("Available") ? "tpTemp" : "tpUsing",
                    Text = item.ToString().Equals("Available") ? "Trống" : "Đang sử dụng",
                    BackColor = Properties.Settings.Default.ContentBack,
                    ForeColor = Properties.Settings.Default.ContentFore
                };
                tabControl.TabPages.Add(tp);
            }

            TabPage tpDefault = tabControl.SelectedTab = tabControl.TabPages["tpTemp"];
            DrawTableSample(tpDefault);
            pnlObjectModifier.Tag = tpDefault;
            tabControl.Selecting += TcTableSample_Selecting;
            pnlPreview.Controls.Add(tabControl);
        }

        private void TcTableSample_Selecting(object sender, TabControlCancelEventArgs e)
        {
            pnlObjectModifier.Hide();
            TabPage tp = (sender as TabControl).SelectedTab;
            pnlObjectModifier.Tag = tp;
            DrawTableSample(tp);
        }

        private void DrawTableSample(TabPage tp)
        {
            tp.Controls.Clear();

            Panel pnlContainer = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                TabStop = false
            };
            ItemCornerButton btnTable = new ItemCornerButton()
            {
                Width = Temple.TableItemWidth,
                Height = Temple.TableItemHeigh,
                Text = "Bàn mẫu" + Environment.NewLine + tp.Text,
                BackColor = tp.Text.Equals("Trống") ? Temple.TableItemTempBack : Temple.TableItemUsingBack,
                ForeColor = Temple.TableItemFore,
                FlatStyle = FlatStyle.Flat,
                Tag = tp.Text,
                TabStop = false
            };
            btnTable.FlatAppearance.BorderSize = 0;
            btnTable.Click += BtnTable_Click;
            pnlContainer.Controls.Add(btnTable);

            tp.Controls.Add(pnlContainer);
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            pnlObjectModifier.Show();
            ItemCornerButton btn = sender as ItemCornerButton;
            if (btn.Tag.ToString().Equals("Trống"))
            {
                pnlOffBackColor.Hide();
                pnlOnBackColor.Show();
            }
            else
            {
                pnlOnBackColor.Hide();
                pnlOffBackColor.Show();
            }
        }

        private void PicFlag_Click(object sender, EventArgs e)
        {
            if (cmsLanguage.Visible == false)
            {
                cmsLanguage.Show(picFlag, 0, picFlag.Height);
            }
            else
            {
                cmsLanguage.Visible = false;
            }
        }

        private void NudWidth_ValueChanged(object sender, EventArgs e)
        {
            TabPage tp = pnlObjectModifier.Tag as TabPage;
            if (cbObjectSelector.Text.Equals("Bàn"))
            {
                Temple.TableItemWidth = (int)nudWidth.Value;
                DrawTableSample(tp);
            }
            else
            {
                Temple.ServiceItemWidth = (int)nudWidth.Value;
                DrawServiceSample(tp);
            }
        }

        private void NudHeight_ValueChanged(object sender, EventArgs e)
        {
            TabPage tp = pnlObjectModifier.Tag as TabPage;
            if (cbObjectSelector.Text.Equals("Bàn"))
            {
                Temple.TableItemHeigh = (int)nudHeight.Value;
                DrawTableSample(tp);
            }
            else
            {
                Temple.ServiceItemHeigh = (int)nudHeight.Value;
                DrawServiceSample(tp);
            }
        }

        private void PnlOnBackColor_BackColorChanged(object sender, EventArgs e)
        {
            TabPage tp = pnlObjectModifier.Tag as TabPage;
            if (cbObjectSelector.Text.Equals("Bàn"))
            {
                Temple.TableItemTempBack = pnlOnBackColor.BackColor;
                DrawTableSample(tp);
            }
            else
            {
                Temple.ServiceItemEnabledBack = pnlOnBackColor.BackColor;
                DrawServiceSample(tp);
            }
        }

        private void PnlOffBackColor_BackColorChanged(object sender, EventArgs e)
        {
            TabPage tp = pnlObjectModifier.Tag as TabPage;
            if (cbObjectSelector.Text.Equals("Bàn"))
            {
                Temple.TableItemUsingBack = pnlOffBackColor.BackColor;
                DrawTableSample(tp);
            }
            else
            {
                Temple.ServiceItemDisabledBack = pnlOffBackColor.BackColor;
                DrawServiceSample(tp);
            }
        }

        private void PnlMainFore_BackColorChanged(object sender, EventArgs e)
        {
            TabPage tp = pnlObjectModifier.Tag as TabPage;
            if (cbObjectSelector.Text.Equals("Bàn"))
            {
                Temple.TableItemFore = pnlMainFore.BackColor;
                DrawTableSample(tp);
            }
            else
            {
                Temple.ServiceItemNameFore = pnlMainFore.BackColor;
                DrawServiceSample(tp);
            }
        }

        private void PnlSubFore_BackColorChanged(object sender, EventArgs e)
        {
            TabPage tp = pnlObjectModifier.Tag as TabPage;
            Temple.ServiceItemPriceFore = pnlSubFore.BackColor;
            DrawServiceSample(tp);
        }

        private void PnlOnBackColor_Click(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            if (cldPicker.ShowDialog() == DialogResult.OK)
            {
                pnl.BackColor = cldPicker.Color;
            }
        }
    }
}
