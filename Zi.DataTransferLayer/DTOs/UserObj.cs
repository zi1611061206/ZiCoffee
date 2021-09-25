using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace DataTransferLayer.DTOs
{
    public class UserObj : User
    {
        public string FullName { get { return FirstName + " " + MiddleName + " " + LastName; } }

        public UserObj()
        {
            UserId = Guid.NewGuid();
        }

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
            int genderType = (int)row["Gender"];
            Gender = (Genders)genderType;
            Avatar = (byte[])row["Avatar"];
            CitizenId = row["CitizenId"].ToString();
            Address = row["Address"].ToString();
            Salt = row["Salt"].ToString();
        }
    }
}
