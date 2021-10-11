using System.Data.Linq;
using System.Drawing;
using System.IO;

namespace Zi.LinqSqlLayer.Engines.Convertors
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
            return GetBytesFromImage(imagePath);
        }

        public byte[] EncryptDefaultImage()
        {
            string startupPath = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(startupPath).Parent.FullName;
            string imagePath = projectDirectory + noImage;
            return GetBytesFromImage(imagePath);
        }

        public byte[] GetBytesFromImage(string imagePath)
        {
            FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] binaryArray = new byte[fs.Length];
            fs.Read(binaryArray, 0, (int)fs.Length);
            fs.Close();
            return binaryArray;
        }

        public Image GetImageFromBytes(byte[] source)
        {
            MemoryStream memoryStream = new MemoryStream(source);
            return Image.FromStream(memoryStream);
        }
    }
}
