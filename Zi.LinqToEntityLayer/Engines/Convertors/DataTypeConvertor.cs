using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.LinqToEntityLayer.Engines.Convertors
{
    public class DataTypeConvertor
    {
        #region Instance
        private static DataTypeConvertor instance;
        public static DataTypeConvertor Instance
        {
            get { if (instance == null) instance = new DataTypeConvertor(); return instance; }
            private set { instance = value; }
        }
        private DataTypeConvertor() { }
        #endregion

        private const string noAvatar = @"\Resources\NoAvatar.jpg";
        private const string noImage = @"\Resources\NoImage.jpg";

        public byte[] EncryptDefaultAvatar()
        {
            string startupPath = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(startupPath).Parent.FullName;
            string imagePath = projectDirectory + noAvatar;
            return GetImageFromBytes(imagePath);
        }

        public byte[] EncryptDefaultImage()
        {
            string startupPath = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(startupPath).Parent.FullName;
            string imagePath = projectDirectory + noImage;
            return GetImageFromBytes(imagePath);
        }

        public byte[] GetImageFromBytes(string imagePath)
        {
            FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] binaryArray = new byte[fs.Length];
            fs.Read(binaryArray, 0, (int)fs.Length);
            fs.Close();
            return binaryArray;
        }

        public Image GetBytesFromImage(byte[] source)
        {
            MemoryStream memoryStream = new MemoryStream(source);
            return Image.FromStream(memoryStream);
        }
    }
}
