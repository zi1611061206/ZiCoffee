using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Seeders
{
    public class RoleSeeder
    {
        public RoleSeeder(ZiDbContext context)
        {
            IList<Role> roles = new List<Role>();

            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdS),
                Name = "S",
                Description = "Global permission - Preventive technicians"
            });
            roles.Add(new Role() { 
                RoleId = Guid.Parse(GuidConstants.RoleIdAdministrator),
                Name = "Administrator",
                Description = "Global permission"
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdManager),
                Name = "Manager",
                Description = "Local permission"
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdCashier),
                Name = "Cashier",
                Description = "Shift permission"
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdStocker),
                Name = "Stocker",
                Description = "Warehouse permission"
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdBartender),
                Name = "Bartender",
                Description = "Kitchen permission"
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdBasic),
                Name = "Basic",
                Description = "Basic permission: Service, Security, Sanitation worker, ..."
            });

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}
