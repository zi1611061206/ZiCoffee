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
        public CustomTextBox()
        {
            InitializeComponent();
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
        public Label ZiLabel { get { return this.lbLabel; } set { value = this.lbLabel; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPanel { get { return this.pnlGroupBox; } set { value = this.pnlGroupBox; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TextBox ZiTextBox { get { return this.txbTextContent; } set { value = this.txbTextContent; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Label ZiValidate { get { return this.lbValidator; } set { value = this.lbValidator; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiTop { get { return this.pnlTop; } set { value = this.pnlTop; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiBottom { get { return this.pnlBottom; } set { value = this.pnlBottom; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiLeft { get { return this.pnlLeft; } set { value = this.pnlLeft; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiRight { get { return this.pnlRight; } set { value = this.pnlRight; } }
        #endregion
    }
}
