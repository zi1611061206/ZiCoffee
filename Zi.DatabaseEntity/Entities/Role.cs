using System;
using System.Collections.Generic;
using Zi.Utilities.Enumerators;

namespace Zi.DatabaseEntity.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AccessLevels AccessLevel { get; set; }

        //FK 1-n (m-n)
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
