using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Seeders
{
    public class UserRoleSeeder
    {
        public UserRoleSeeder(ZiDbContext context)
        {
            IList<UserRole> userRoles = new List<UserRole>();

            userRoles.Add(new UserRole() { 
                UserId = Guid.Parse(GuidConstants.UserId1),
                RoleId = Guid.Parse(GuidConstants.RoleIdAdministrator)
            });
            userRoles.Add(new UserRole()
            {
                UserId = Guid.Parse(GuidConstants.UserId2),
                RoleId = Guid.Parse(GuidConstants.RoleIdCashier)
            });
            userRoles.Add(new UserRole()
            {
                UserId = Guid.Parse(GuidConstants.UserId3),
                RoleId = Guid.Parse(GuidConstants.RoleIdBasic)
            });

            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();
        }
    }
}
