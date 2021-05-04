using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zi.ZiCoffee.GUIs.CustomControls
{
    public class ItemRoundPicture : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(path);
            base.OnPaint(pe);
        }
    }
}
