using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.DatabaseEntity.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PasswordHash { get; set; }
        public Genders Gender { get; set; }
        public byte[] Avatar { get; set; }
        public string CitizenId { get; set; }
        public string Address { get; set; }
        public string Salt { get; set; }

        //FK 1-n
        public ICollection<Bill> Bills { get; set; }

        //FK 1-n (m-n)
        public ICollection<UserRole> UserRoles { get; set; }

        //FK 1-n
        public ICollection<Log> Logs { get; set; }
    }
}
