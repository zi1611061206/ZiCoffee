using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using Zi.SalesModule.Settings;

namespace Zi.SalesModule.PartialForms
{
    public partial class FormSound : Form
    {
        #region Attributes
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        public BackupSetting BackupSetting { get; set; }
        #endregion

        public FormSound(BackupSetting backupSetting)
        {
            InitializeComponent();
            BackupSetting = backupSetting;
        }

        #region Initial
        private void FormSound_Load(object sender, EventArgs e)
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
            InterfaceRm = new ResourceManager(BaseName, typeof(FormSound).Assembly);
        }

        private void SetStaticText()
        {
            grbSounds.Text = InterfaceRm.GetString("GrbSounds", Culture);
            grbVoice.Text = InterfaceRm.GetString("GrbVoice", Culture);

            lbAppearanceSound.Text = InterfaceRm.GetString("LbAppearanceSound", Culture);
            lbClickSound.Text = InterfaceRm.GetString("LbClickSound", Culture);
            lbSayBye.Text = InterfaceRm.GetString("LbSayBye", Culture);
            lbScanSound.Text = InterfaceRm.GetString("LbScanSound", Culture);
            lbSoundtrack.Text = InterfaceRm.GetString("LbSoundtrack", Culture);
            lbSoundtrackFileName.Text = InterfaceRm.GetString("LbSoundtrackFileName", Culture);
            lbVoiceRate.Text = InterfaceRm.GetString("LbVoiceRate", Culture);
            lbVoiceVolumn.Text = InterfaceRm.GetString("LbVoiceVolumn", Culture);
            lbVoiceGender.Text = InterfaceRm.GetString("LbVoiceGender", Culture);
            lbVoiceAge.Text = InterfaceRm.GetString("LbVoiceAge", Culture);
        }

        private void SetColor()
        {
            BackColor = BackupSetting.BodyBackColor;
            // Label
            lbAppearanceSound.ForeColor
                = lbClickSound.ForeColor
                = lbSayBye.ForeColor
                = lbScanSound.ForeColor
                = lbSoundtrack.ForeColor
                = lbSoundtrackFileName.ForeColor
                = lbTrackbarValue.ForeColor
                = lbVoiceRate.ForeColor
                = lbVoiceVolumn.ForeColor
                = lbVoiceGender.ForeColor
                = lbVoiceAge.ForeColor
                = BackupSetting.BaseTextColor;
            // GroupBox
            grbSounds.ForeColor
                = grbVoice.ForeColor
                = BackupSetting.BaseTextColor;
        }

        private void LoadContent()
        {
            ckbAppearanceSound.Checked = BackupSetting.AllowInitSound;
            ckbClickSound.Checked = BackupSetting.AllowClickSound;
            ckbSayBye.Checked = BackupSetting.AllowSayBye;
            ckbScanSound.Checked = BackupSetting.AllowScanDetectedSound;
            ckbSoundtrack.Checked = BackupSetting.AllowSoundtrack;

            txbSoundtrackFileName.Text = BackupSetting.SoundtrackFileName;
            trackBarVoiceVolumn.Value = BackupSetting.VoiceBotVolumn;
            nudVoiceRate.Value = BackupSetting.VoiceBotSpeakerRate;

            cbVoiceGender.Items.Add(InterfaceRm.GetString("NotSet", Culture));
            cbVoiceGender.Items.Add(InterfaceRm.GetString("Male", Culture));
            cbVoiceGender.Items.Add(InterfaceRm.GetString("Female", Culture));
            cbVoiceGender.Items.Add(InterfaceRm.GetString("Neutral", Culture));
            cbVoiceGender.SelectedIndex = BackupSetting.VoiceGender;

            cbVoiceAge.Items.Add(InterfaceRm.GetString("NotSet", Culture));
            cbVoiceAge.Items.Add(InterfaceRm.GetString("Child", Culture));
            cbVoiceAge.Items.Add(InterfaceRm.GetString("Teen", Culture));
            cbVoiceAge.Items.Add(InterfaceRm.GetString("Adult", Culture));
            cbVoiceAge.Items.Add(InterfaceRm.GetString("Senior", Culture));
            switch (BackupSetting.VoiceAge)
            {
                case 0:
                    cbVoiceAge.SelectedIndex = 0;
                    break;
                case 10:
                    cbVoiceAge.SelectedIndex = 1;
                    break;
                case 15:
                    cbVoiceAge.SelectedIndex = 2;
                    break;
                case 30:
                    cbVoiceAge.SelectedIndex = 3;
                    break;
                case 65:
                    cbVoiceAge.SelectedIndex = 4;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Change sounds
        private void CkbSoundtrack_CheckedChanged(object sender, EventArgs e)
        {
            BackupSetting.AllowSoundtrack = (sender as CheckBox).Checked;
        }

        private void CkbAppearanceSound_CheckedChanged(object sender, EventArgs e)
        {
            BackupSetting.AllowInitSound = (sender as CheckBox).Checked;
        }

        private void CkbClickSound_CheckedChanged(object sender, EventArgs e)
        {
            BackupSetting.AllowClickSound = (sender as CheckBox).Checked;
        }

        private void CkbScanSound_CheckedChanged(object sender, EventArgs e)
        {
            BackupSetting.AllowScanDetectedSound = (sender as CheckBox).Checked;
        }

        private void CkbSayBye_CheckedChanged(object sender, EventArgs e)
        {
            BackupSetting.AllowSayBye = (sender as CheckBox).Checked;
        }

        private void NudVoiceRate_ValueChanged(object sender, EventArgs e)
        {
            BackupSetting.VoiceBotSpeakerRate = (int)(sender as NumericUpDown).Value;
        }

        private void TrackBarVoiceVolumn_ValueChanged(object sender, EventArgs e)
        {
            int volumn = (sender as TrackBar).Value;
            BackupSetting.VoiceBotVolumn = volumn;
            lbTrackbarValue.Text = volumn + " %";
        }

        private void CbVoiceGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            BackupSetting.VoiceGender = (sender as ComboBox).SelectedIndex;
        }

        private void CbVoiceAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    BackupSetting.VoiceAge = 0;
                    break;
                case 1:
                    BackupSetting.VoiceAge = 10;
                    break;
                case 2:
                    BackupSetting.VoiceAge = 15;
                    break;
                case 3:
                    BackupSetting.VoiceAge = 30;
                    break;
                case 4:
                    BackupSetting.VoiceAge = 65;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
