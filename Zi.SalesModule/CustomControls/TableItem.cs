using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using Zi.LinqSqlLayer.DTOs;
using Zi.Utilities.Enumerators;

namespace Zi.SalesModule.CustomControls
{
    public partial class TableItem : RoundedIconButton
    {
        #region Attributes
        public TableModel Table { get; set; }
        public DateTime BillCreatedDate { get; set; }
        public Timer TimerCountTime { get; set; }
        public double TotalSeconds { get; set; }
        public string CultureName { get; set; }
        public ResourceManager InterfaceRm { get; set; }
        public CultureInfo Culture { get; set; }
        #endregion

        public TableItem(TableModel table, DateTime? billCreatedDate = null)
        {
            InitializeComponent();
            Table = table;
            if (billCreatedDate != null)
            {
                BillCreatedDate = (DateTime)billCreatedDate;
            }
            TimerCountTime = new Timer()
            {
                Interval = 1000,
            };
            LoadSetting();
            LoadContent();
        }

        #region Initial
        private void LoadSetting()
        {
            CultureName = Properties.Settings.Default.CultureName;
            Culture = CultureInfo.CreateSpecificCulture(CultureName);
            string BaseName = "Zi.SalesModule.Lang.ItemResource";
            InterfaceRm = new ResourceManager(BaseName, typeof(TableItem).Assembly);
        }

        private void LoadContent()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = new Font("Arial", 12, FontStyle.Bold);
            IconChar = IconChar.Chair;
            TextImageRelation = TextImageRelation.ImageAboveText;
            Margin = new Padding(10, 10, 10, 10);
            Text = Table.Name;
            BackColor = Properties.Settings.Default.BaseItemColor;
            Size = Properties.Settings.Default.TableItemSize;
            Tag = Table;

            if (Table.Status.CompareTo(TableStatus.Using) == 0)
            {
                ForeColor = Properties.Settings.Default.ErrorTextColor;
                IconColor = Properties.Settings.Default.ErrorTextColor;
                Text += Environment.NewLine + InterfaceRm.GetString("UsingTable", Culture) + Environment.NewLine + "- TimeCouter";
                TimeSpan timeSpan = DateTime.Now.Subtract(BillCreatedDate);
                TotalSeconds = timeSpan.TotalSeconds;
                CalculateTimeBySeconds();
                TimerCountTime.Start();
                TimerCountTime.Tick += TimerCountTime_Tick;
            }
            else if (Table.Status.CompareTo(TableStatus.Pending) == 0)
            {
                ForeColor = Properties.Settings.Default.WarningTextColor;
                IconColor = Properties.Settings.Default.WarningTextColor;
                Text += Environment.NewLine + InterfaceRm.GetString("PendingTable", Culture);
            }
            else
            {
                ForeColor = Properties.Settings.Default.SuccessTextColor;
                IconColor = Properties.Settings.Default.SuccessTextColor;
                Text += Environment.NewLine + InterfaceRm.GetString("ReadyTable", Culture);
            }
        }

        private void TimerCountTime_Tick(object sender, EventArgs e)
        {
            TotalSeconds++;
            CalculateTimeBySeconds();
        }

        private void CalculateTimeBySeconds()
        {
            string newText = Text.Split('-')[0] + "-" + Environment.NewLine;

            if (TotalSeconds < 3600)
            {
                if (TotalSeconds < 60)
                {
                    newText += "00:00:" + HandleFormat((int)TotalSeconds);
                }
                else
                {
                    int minutes = (int)(TotalSeconds / 60);
                    int seconds = (int)(TotalSeconds - minutes * 60);
                    newText += "00:" + HandleFormat(minutes) + ":" + HandleFormat(seconds);
                }
            }
            else
            {
                int hours = (int)(TotalSeconds / 3600);
                int minutes = (int)((TotalSeconds - hours * 3600) / 60);
                int seconds = (int)(TotalSeconds - hours * 3600 - minutes * 60);
                newText += HandleFormat(hours) + ":" + HandleFormat(minutes) + ":" + HandleFormat(seconds);
            }
            Text = newText;
        }

        private string HandleFormat(int number)
        {
            return number < 10 ? "0" + number : number.ToString();
        }
        #endregion
    }
}
