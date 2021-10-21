using System;
using System.Collections.Generic;
using Zi.DatabaseEntity.Entities;
using Zi.Utilities.Constants;

namespace Zi.DatabaseEntity.Seeders
{
    public class UserRoleSeeder
    {
        public UserRoleSeeder(ZiDbContext context)
        {
            IList<UserRole> userRoles = new List<UserRole>
            {
                new UserRole()
                {
                    UserId = Guid.Parse(GuidConstants.UserId1),
                    RoleId = Guid.Parse(GuidConstants.RoleIdAdministrator)
                },
                new UserRole()
                {
                    UserId = Guid.Parse(GuidConstants.UserId2),
                    RoleId = Guid.Parse(GuidConstants.RoleIdCashier)
                },
                new UserRole()
                {
                    UserId = Guid.Parse(GuidConstants.UserId3),
                    RoleId = Guid.Parse(GuidConstants.RoleIdBasic)
                }
            };

            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();
        }
    }
}
