using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zi.ZiCoffee.Engines.Theme;

namespace Zi.ZiCoffee.GUIs.CustomControls
{
    public partial class CustomTextBox : UserControl
    {
        public event EventHandler ZiClick;
        public event EventHandler ZiKeyPress;

        public CustomTextBox()
        {
            InitializeComponent();
        }

        public virtual void TxbTextContent_Click(object sender, EventArgs e)
        {
            ZiClick?.Invoke(this, e);
        }

        public virtual void TxbTextContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            ZiKeyPress?.Invoke(this, e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color ZiBorderColor 
        {
            set
            {
                pnlBottom.BackColor
                    = pnlTop.BackColor
                    = pnlLeft.BackColor
                    = pnlRight.BackColor
                    = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int ZiBorderSize
        {
            set
            {
                Size horizontalSize = pnlTop.Size;
                Size verticalSize = pnlLeft.Size;
                horizontalSize.Height = value;
                verticalSize.Width = value;
                pnlBottom.Size = pnlTop.Size = horizontalSize;
                pnlLeft.Size = pnlRight.Size = verticalSize;
            }
        }

        #region Design Attributes
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Label ZiLabel { get { return lbLabel; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPanel { get { return pnlGroupBox; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TextBox ZiTextBox { get { return txbTextContent; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Label ZiValidate { get { return lbValidator; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiTop { get { return pnlTop; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiBottom { get { return pnlBottom; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiLeft { get { return pnlLeft; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiRight { get { return pnlRight; } set { } }
        #endregion
    }
}
