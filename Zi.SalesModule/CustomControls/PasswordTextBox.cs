using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zi.SalesModule.CustomControls
{
    public partial class PasswordTextBox : UserControl
    {
        public event EventHandler ZiTxbClick;
        public event EventHandler ZiTxbKeyPress;
        public event EventHandler ZiIpicClick;

        public PasswordTextBox()
        {
            InitializeComponent();
        }

        public virtual void TxbInput_Click(object sender, EventArgs e)
        {
            ZiTxbClick?.Invoke(this, e);
        }

        public virtual void TxbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            ZiTxbKeyPress?.Invoke(this, e);
        }

        public virtual void IpicEndIcon_Click(object sender, EventArgs e)
        {
            ZiIpicClick?.Invoke(this, e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color ZiBorderColor
        {
            set
            {
                pnlBorderTop.BackColor
                    = pnlBorderBottom.BackColor
                    = pnlBorderLeft.BackColor
                    = pnlBorderRight.BackColor
                    = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int ZiBorderSize
        {
            set
            {
                Size horizontalSize = pnlBorderTop.Size;
                Size verticalSize = pnlBorderLeft.Size;
                horizontalSize.Height = value;
                verticalSize.Width = value;
                pnlBorderBottom.Size = pnlBorderTop.Size = horizontalSize;
                pnlBorderLeft.Size = pnlBorderRight.Size = verticalSize;
            }
        }

        #region Design Attributes
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlMarginTop { get { return pnlMarginTop; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlMarginBottom { get { return pnlMarginBottom; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlCenter { get { return pnlCenter; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlBorderTop { get { return pnlBorderTop; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlBorderBottom { get { return pnlBorderBottom; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlBorderLeft { get { return pnlBorderLeft; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlBorderRight { get { return pnlBorderRight; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlTextBox { get { return pnlTextBox; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlInput { get { return pnlInput; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlStartIcon { get { return pnlStartIcon; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlEndIcon { get { return pnlEndIcon; } set { } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Label ZiLbLabel { get { return lbLabel; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Label ZiLbError { get { return lbError; } set { } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public IconPictureBox ZiIpicStartIcon { get { return ipicStartIcon; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public IconPictureBox ZiIpicEndIcon { get { return ipicEndIcon; } set { } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TextBox ZiTxbInput { get { return txbInput; } set { } }
        #endregion
    }
}
