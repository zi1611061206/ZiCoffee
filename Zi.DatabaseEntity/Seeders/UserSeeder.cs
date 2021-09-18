using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.DatabaseEntity.Seeders
{
    public class UserSeeder
    {
        public UserSeeder(ZiDbContext context)
        {
            IList<User> users = new List<User>();

            #region // Constants
            const string PASSWORD1 = "Hh123456789@";
            const string PASSWORD2 = "Hh987654321@";
            const string PASSWORD3 = "Hh000000000@";
            #endregion

            #region // Generate salt using BCrypt
            string salt1 = BCrypt.Net.BCrypt.GenerateSalt();
            string salt2 = BCrypt.Net.BCrypt.GenerateSalt();
            string salt3 = BCrypt.Net.BCrypt.GenerateSalt();
            #endregion

            #region // Hash Password using BCrypt
            string hashed1 = BCrypt.Net.BCrypt.HashPassword(PASSWORD1, salt1);
            string hashed2 = BCrypt.Net.BCrypt.HashPassword(PASSWORD2, salt2);
            string hashed3 = BCrypt.Net.BCrypt.HashPassword(PASSWORD3, salt3);
            #endregion

            #region // Make default "NoAvatar"
            string startupPath = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(startupPath).Parent.FullName;
            string imagePath = projectDirectory + @"\Resources\Noavatar.jpg";
            FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] binaryArray = new byte[fs.Length];
            fs.Read(binaryArray, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            #endregion

            users.Add(new User()
            {
                UserId = Guid.Parse(GuidConstants.UserId1),
                FirstName = "Nguyễn",
                MiddleName = "Ngọc",
                LastName = "Hiếu",
                Username = "zitech",
                DisplayName = "Hiếu Nguyễn",
                PhoneNumber = "0943144178",
                Email = "zitech.dev@gmail.com",
                DateOfBirth = DateTime.Parse("05/02/1998"),
                CreatedDate = DateTime.Now,
                Gender = Genders.Male,
                CitizenId = "123456798000",
                Address = "Điện Biên Phủ - P.25 - Bình Thạnh - TP.HCM",
                Salt = salt1,
                PasswordHash = hashed1,
                Avatar = binaryArray
            });
            users.Add(new User()
            {
                UserId = Guid.Parse(GuidConstants.UserId2),
                FirstName = "Trần",
                MiddleName = "Thị Anh",
                LastName = "Thư",
                Username = "anhthu",
                DisplayName = "Thư Trần",
                PhoneNumber = "0941234178",
                Email = "thutran@gmail.com",
                DateOfBirth = DateTime.Parse("28/09/2002"),
                CreatedDate = DateTime.Now,
                Gender = Genders.Female,
                CitizenId = "123128000",
                Address = "36/1 Nguyễn Gia Trí - P.25 - Bình Thạnh - TP.HCM",
                Salt = salt2,
                PasswordHash = hashed2,
                Avatar = binaryArray
            });
            users.Add(new User()
            {
                UserId = Guid.Parse(GuidConstants.UserId3),
                FirstName = "Phạm",
                MiddleName = "",
                LastName = "Hùng",
                Username = "hungpham",
                DisplayName = "Hùng Phạm",
                PhoneNumber = "0943141234",
                Email = "hungpham@gmail.com",
                DateOfBirth = DateTime.Parse("15/06/2000"),
                CreatedDate = DateTime.Now,
                Gender = Genders.Male,
                CitizenId = "12345678900",
                Address = "1 Thống Nhất - P.10 - Gò Vấp - TP.HCM",
                Salt = salt3,
                PasswordHash = hashed3,
                Avatar = binaryArray
            });

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
