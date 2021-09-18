using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //FK 1-n (m-n)
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
