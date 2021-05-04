using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zi.ZiCoffee.GUIs.CustomControls
{
    public partial class CustomSquareIconButton : UserControl
    {
        public event EventHandler ZiClick;
        public event EventHandler ZiMouseHover;
        public event EventHandler ZiMouseLeave;

        public CustomSquareIconButton()
        {
            InitializeComponent();
        }

        public virtual void PnlLeft_Click(object sender, EventArgs e)
        {
            ZiClick?.Invoke(this, e);
        }

        public virtual void PnlLeft_MouseHover(object sender, EventArgs e)
        {
            ZiMouseHover?.Invoke(this, e);
        }

        public virtual void PnlLeft_MouseLeave(object sender, EventArgs e)
        {
            ZiMouseLeave?.Invoke(this, e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlContainer { get { return pnlContainer; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlLeft { get { return pnlLeft; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlRight { get { return pnlRight; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ZiPnlMiddle { get { return pnlMiddle; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PictureBox ZiPicIcon { get { return picIcon; } set { } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Button ZiBtnItem { get { return btnItem; } set { } }
    }
}
