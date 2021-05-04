using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.ZiCoffee.Engines.Converter
{
    public class DataTypeConverter
    {
        #region Instance
        private static DataTypeConverter instance;
        public static DataTypeConverter Instance
        {
            get { if (instance == null) instance = new DataTypeConverter(); return instance; }
            private set { instance = value; }
        }
        private DataTypeConverter() { }
        #endregion

        public Image ConvertByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image img = Image.FromStream(ms);
            return img;
        }
    }
}
