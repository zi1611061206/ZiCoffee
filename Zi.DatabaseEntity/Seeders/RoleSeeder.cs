using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

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
                Description = "Global permission - Preventive technicians",
                AccessLevel = AccessLevels.S
            });
            roles.Add(new Role() { 
                RoleId = Guid.Parse(GuidConstants.RoleIdAdministrator),
                Name = "Administrator",
                Description = "Global permission",
                AccessLevel = AccessLevels.Administrator
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdManager),
                Name = "Manager",
                Description = "Local permission",
                AccessLevel = AccessLevels.Manager
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdCashier),
                Name = "Cashier",
                Description = "Shift permission",
                AccessLevel = AccessLevels.Cashier
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdStocker),
                Name = "Stocker",
                Description = "Warehouse permission",
                AccessLevel = AccessLevels.Stocker
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdBartender),
                Name = "Bartender",
                Description = "Kitchen permission",
                AccessLevel = AccessLevels.Bartender
            });
            roles.Add(new Role()
            {
                RoleId = Guid.Parse(GuidConstants.RoleIdBasic),
                Name = "Basic",
                Description = "Basic permission: Service, Security, Sanitation worker, ...",
                AccessLevel = AccessLevels.Basic
            });

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}
