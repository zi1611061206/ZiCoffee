using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.ThreeLayer.DTOs
{
    public class UserObj : User
    {
        public string FullName { get { return FirstName + " " + MiddleName + " " + LastName; } }

        public UserObj(
            string firstName,
            string middleName,
            string lastName,
            string username,
            string displayName,
            string phoneNumber,
            string email,
            DateTime dateOfBirth,
            byte[] avatar,
            string address,
            string salt,
            string passwordHash)
        {
            UserId = Guid.NewGuid();
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Username = username;
            DisplayName = string.IsNullOrEmpty(displayName) ? username : displayName;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = Genders.Male;
            Avatar = avatar;
            CitizenId = string.Empty;
            Address = address;
            Salt = salt;
            PasswordHash = passwordHash;
        }


        /// <summary>
        /// Mapping data to UserObj
        /// </summary>
        /// <param name="row"></param>
        public UserObj(DataRow row)
        {
            UserId = Guid.Parse(row["UserId"].ToString());
            FirstName = row["FirstName"].ToString();
            MiddleName = row["MiddleName"].ToString();
            LastName = row["LastName"].ToString();
            Username = row["Username"].ToString();
            DisplayName = row["DisplayName"].ToString();
            PhoneNumber = row["PhoneNumber"].ToString();
            Email = row["Email"].ToString();
            if (DateTime.TryParse(row["DateOfBirth"].ToString(), out DateTime result1))
            {
                DateOfBirth = result1;
            }
            if (DateTime.TryParse(row["CreatedDate"].ToString(), out DateTime result2))
            {
                CreatedDate = result2;
            }
            PasswordHash = row["PasswordHash"].ToString();
            Gender = (Genders)row["Gender"];
            Avatar = (byte[])row["Avatar"];
            CitizenId = row["CitizenId"].ToString();
            Address = row["Address"].ToString();
            Salt = row["Salt"].ToString();
        }
    }
}
