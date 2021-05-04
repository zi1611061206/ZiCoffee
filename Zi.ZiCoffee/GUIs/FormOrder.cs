using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Runtime.InteropServices;
using System.Media;
using System.Globalization;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;
using Zi.DataAccessLayer.DAOs;
using Zi.DataAccessLayer.DAOs.Join;
using Zi.ZiCoffee.GUIs.CustomControls;
using Zi.ZiCoffee.Engines.TempleSetting;
using Zi.ZiCoffee.Engines.Converter;

namespace Zi.ZiCoffee.GUIs
{
    public partial class FormOrder : Form
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
        public NumberFormatInfo LocalFormat { get; set; }
        public Table ChoosingTable { get; set; }
        public Account CurrentAccount { get; set; }
        public Stream StreamOpen { get; set; }
        public Stream StreamClick { get; set; }
        public TempleSetting Temple { get; set; }
        #endregion

        public FormOrder(Table choosingTable, Account currentAccount)
        {
            LocalFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            LocalFormat.CurrencySymbol = Properties.Settings.Default.currencySymbol;
            LocalFormat.CurrencyPositivePattern = 3;
            LocalFormat.CurrencyDecimalDigits = 0;

            InitializeComponent();
            this.ChoosingTable = choosingTable;
            this.CurrentAccount = currentAccount;
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            pnlCart.Hide();
            txbTotal.Clear();
            lbCartAmount.Text = "0";
            lsvCart.Items.Clear();
            btnCartConfirm.Enabled = false;

            LoadSetting();
            LoadCategories();
        }

        private void LoadCategories()
        {
            fpnlCategories.Controls.Clear();
            DataTable categories = CategoryImpl.Instance.GetAllCategory();
            foreach(DataRow row in categories.Rows)
            {
                Category category = new Category(row);
                int serviceCounter = ServiceImpl.Instance.CountAllServiceOfCategory(category.CategoryId);
                Size btnSize = new Size(fpnlCategories.Width, 35);
                CustomSquareIconButton cbtn = new CustomSquareIconButton()
                {
                    Size = btnSize,
                    TabStop = false,
                    ForeColor = Properties.Settings.Default.MainFore,
                    Cursor = Cursors.Hand,
                    Tag = category.CategoryId
                };
                cbtn.ZiPicIcon.Visible = false;
                cbtn.ZiBtnItem.Text = category.CategoryName + " ("+ serviceCounter +")";
                cbtn.ZiPnlRight.Visible = false;
                cbtn.ZiPnlLeft.Size = new Size(15, btnSize.Height);
                cbtn.ZiClick += CbtnCategories_ZiClick;
                cbtn.ZiMouseHover += CbtnCategories_ZiMouseHover;
                cbtn.ZiMouseLeave += CbtnCategories_ZiMouseLeave;
                fpnlCategories.Controls.Add(cbtn);
            }
        }

        private void CbtnCategories_ZiClick(object sender, EventArgs e)
        {
            int categoryId = (int)((sender as CustomSquareIconButton).Tag);
            DataTable services = ServiceImpl.Instance.GetAllServiceOfCategory(categoryId);
            LoadServices(services);
        }

        private void LoadServices(DataTable services)
        {
            Temple = new TempleSetting();
            fpnlServices.Controls.Clear();
            foreach (DataRow row in services.Rows)
            {
                Service service = new Service(row);
                DrawServiceItem(service);
            }
        }

        private void DrawServiceItem(Service service)
        {
            ItemCornerPanel pnlService = new ItemCornerPanel()
            {
                Width = Temple.ServiceItemWidth,
                Height = Temple.ServiceItemHeigh,
                BackColor = service.UsedStatus == ServiceStatus.Available ? Temple.ServiceItemEnabledBack : Temple.ServiceItemDisabledBack,
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
                Cursor = Cursors.Hand,
                Text = service.ServiceName,
                Padding = new Padding(0, 3, 0, 3),
                Tag = service
            };
            Label lbPrice = new Label()
            {
                ForeColor = Temple.ServiceItemPriceFore,
                Font = new Font("Arial", 10.0f, FontStyle.Italic),
                Dock = DockStyle.Bottom,
                Text = service.Price.ToString("c0", LocalFormat),
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
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Image = DataTypeConverter.Instance.ConvertByteArrayToImage(service.Image),
                BorderStyle = BorderStyle.None,
                Tag = service
            };

            picImage.MouseDown += PicImage_MouseDown;
            lbName.Click += LbName_Click;

            pnlService.Controls.Add(picImage);
            pnlInfo.Controls.Add(lbName);
            pnlInfo.Controls.Add(lbPrice);
            pnlService.Controls.Add(pnlInfo);

            fpnlServices.Controls.Add(pnlService);
        }

        private void LbName_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PicImage_MouseDown(object sender, MouseEventArgs e)
        {
            ItemCornerPicture pic = sender as ItemCornerPicture;
            Service service = pic.Tag as Service;
            if(service.UsedStatus == ServiceStatus.NotAvailable)
            {
                return;
            }
            else
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        AddServices(service);
                        break;
                    case MouseButtons.Right:
                        SubServices(service);
                        break;
                    default: break;
                }
                LoadTotalCart();
            }
        }

        private void LoadTotalCart()
        {
            int cartAmount = 0;
            double total = 0.0f;
            foreach (ListViewItem item in lsvCart.Items)
            {
                cartAmount += int.Parse(item.SubItems[1].Text);
                total += Convert.ToDouble(item.SubItems[3].Text);
            }
            txbTotal.Text = total.ToString("c0", LocalFormat);

            string text = cartAmount + "";
            for(int i=10; i<=90; i+=10)
            {
                if(cartAmount > 90)
                {
                    text = "90+";
                    break;
                }
                else if(cartAmount > i && cartAmount < i+10)
                {
                    text = i + "+";
                    break;
                }
            }
            lbCartAmount.Text = text;
        }

        private void SubServices(Service service)
        {
            if(lsvCart.Items.Count <= 0)
            {
                return;
            }
            else
            {
                foreach (ListViewItem item in lsvCart.Items)
                {
                    if (Convert.ToInt32(item.SubItems[4].Text) == service.ServiceId)
                    {
                        int amount = int.Parse(item.SubItems[1].Text) - 1;
                        double price = Convert.ToDouble(item.SubItems[2].Text);
                        if (amount != 0)
                        {
                            item.SubItems[1].Text = amount + "";
                            item.SubItems[3].Text = (price * amount).ToString("n0", LocalFormat);
                        }
                        else
                        {
                            lsvCart.Items.Remove(item);
                        }
                        return;
                    }
                }
            }
        }

        private void AddServices(Service service)
        {
            int itemCounter = lsvCart.Items.Count;
            if (itemCounter > 0)
            {
                foreach (ListViewItem item in lsvCart.Items)
                {
                    if (Convert.ToInt32(item.SubItems[4].Text)==service.ServiceId)
                    {
                        int amount = int.Parse(item.SubItems[1].Text) + 1;
                        double price = Convert.ToDouble(item.SubItems[2].Text);
                        item.SubItems[1].Text = amount + "";
                        item.SubItems[3].Text = (price * amount).ToString("n0", LocalFormat);
                        return;
                    }
                }
                AddNewItem(service, lsvCart);

                if (itemCounter % 2 == 0)
                    lsvCart.Items[itemCounter].BackColor = Properties.Settings.Default.MainBack;
                else
                    lsvCart.Items[itemCounter].BackColor = Properties.Settings.Default.HighlightEffectBack;
            }
            else
            {
                AddNewItem(service, lsvCart);
            }
        }

        private void AddNewItem(Service service, ListView lsvCart)
        {
            ListViewItem newItem = new ListViewItem(service.ServiceName);
            newItem.SubItems.Add("1");
            newItem.SubItems.Add(service.Price.ToString("n0", LocalFormat));
            newItem.SubItems.Add(service.Price.ToString("n0", LocalFormat)); // *1
            newItem.SubItems.Add(service.ServiceId.ToString());
            lsvCart.Items.Add(newItem);
        }

        private void CbtnCategories_ZiMouseLeave(object sender, EventArgs e)
        {
            (sender as CustomSquareIconButton).BackColor = Color.Transparent;
        }

        private void CbtnCategories_ZiMouseHover(object sender, EventArgs e)
        {
            (sender as CustomSquareIconButton).BackColor = Properties.Settings.Default.ButtonBackNavHover;
        }

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

        private void SettingTheme()
        {
            // BackColor
            (this as Form).BackColor
                = fpnlCategories.BackColor
                = pnlFormOptions.BackColor
                = Properties.Settings.Default.MainBack;
            pnlTitle.BackColor = Properties.Settings.Default.HFBack;
            pnlWinState.BackColor = Properties.Settings.Default.WinStateBack;
            pnlCart.BackColor
                = fpnlServices.BackColor
                = lsvCart.BackColor
                = Properties.Settings.Default.ContentBack;
            btnCancel.BackColor
                = btnCartConfirm.BackColor
                = Properties.Settings.Default.ButtonBackBorder;

            // ForeColor
            (this as Form).ForeColor
                = lbTitle.ForeColor
                = lsvCart.ForeColor
                = Properties.Settings.Default.MainFore;
            btnCancel.ForeColor
                = btnCartConfirm.ForeColor
                = Properties.Settings.Default.ButtonForeBorder;
        }

        private void SettingLanguage()
        {
            string cultureName = Properties.Settings.Default.CultureName;
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            ResourceManager rm = new ResourceManager("Zi.ZiCoffee.Engines.Lang.ResourceLang", typeof(FormOrder).Assembly);
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            PicClose_Click(this, new EventArgs());
        }

        private void PicViewCart_Click(object sender, EventArgs e)
        {
            if (pnlCart.Visible)
            {
                pnlCart.Hide();
            }
            else
            {
                pnlCart.Show();
            }
        }

        private void PnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            //Áp dụng di chuyển form cho pnlTitle
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void BtnCartConfirm_Click(object sender, EventArgs e)
        {
            Bill bill;
            if (ChoosingTable.UsedStatus == TableStatus.Available)
            {
                // Tạo bill
                BillImpl.Instance.AddBill();
                bill = BillImpl.Instance.GetNewestBill();
                OrderNoteImpl.Instance.AddOrderNote(new OrderNote(ChoosingTable.TableId, bill.BillId, CurrentAccount.Username));
            }
            else
            {
                // Lấy bill
                bill = BillAndOrderNoteImpl.Instance.GetBillOfCurrentTable(ChoosingTable.TableId, BillStatus.UnPaid);
            }

            if(bill != null)
            {
                foreach (ListViewItem item in lsvCart.Items)
                {
                    int serviceId = Int32.Parse(item.SubItems[4].Text);
                    int amount = Int32.Parse(item.SubItems[1].Text);
                    BillDetail billDetail = new BillDetail(bill.BillId, serviceId, amount);
                    BillDetailImpl.Instance.AddBillDetail(billDetail);
                }
                this.Close();
            }
        }

        private void LbCartAmount_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as Label).Text;
            if (text.Equals("0"))
            {
                btnCartConfirm.Enabled = false;
            }
            else
            {
                btnCartConfirm.Enabled = true;
            }    
        }
    }
}
