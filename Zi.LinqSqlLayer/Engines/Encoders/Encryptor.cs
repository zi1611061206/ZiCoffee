using System;

namespace Zi.LinqSqlLayer.Engines.Encoders
{
    public class Encryptor
    {
        #region Instance
        private static Encryptor instance;
        public static Encryptor Instance
        {
            get { if (instance == null) instance = new Encryptor(); return instance; }
            private set { instance = value; }
        }
        private Encryptor() { }
        #endregion

        public Tuple<string, string> HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return new Tuple<string, string>(salt, hashedPassword);
        }

        public bool IsMatchedPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
