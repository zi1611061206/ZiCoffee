using System;
using System.Collections.Generic;
using Zi.DatabaseEntity.Entities;
using Zi.Utilities.Constants;
using Zi.Utilities.Enumerators;

namespace Zi.DatabaseEntity.Seeders
{
    public class RoleSeeder
    {
        public RoleSeeder(ZiDbContext context)
        {
            IList<Role> roles = new List<Role>
            {
                new Role()
                {
                    RoleId = Guid.Parse(GuidConstants.RoleIdS),
                    Name = "S",
                    Description = "Global permission - Preventive technicians",
                    AccessLevel = AccessLevels.S
                },
                new Role()
                {
                    RoleId = Guid.Parse(GuidConstants.RoleIdAdministrator),
                    Name = "Administrator",
                    Description = "Global permission",
                    AccessLevel = AccessLevels.Administrator
                },
                new Role()
                {
                    RoleId = Guid.Parse(GuidConstants.RoleIdManager),
                    Name = "Manager",
                    Description = "Local permission",
                    AccessLevel = AccessLevels.Manager
                },
                new Role()
                {
                    RoleId = Guid.Parse(GuidConstants.RoleIdCashier),
                    Name = "Cashier",
                    Description = "Shift permission",
                    AccessLevel = AccessLevels.Cashier
                },
                new Role()
                {
                    RoleId = Guid.Parse(GuidConstants.RoleIdStocker),
                    Name = "Stocker",
                    Description = "Warehouse permission",
                    AccessLevel = AccessLevels.Stocker
                },
                new Role()
                {
                    RoleId = Guid.Parse(GuidConstants.RoleIdBartender),
                    Name = "Bartender",
                    Description = "Kitchen permission",
                    AccessLevel = AccessLevels.Bartender
                },
                new Role()
                {
                    RoleId = Guid.Parse(GuidConstants.RoleIdBasic),
                    Name = "Basic",
                    Description = "Basic permission: Service, Security, Sanitation worker, ...",
                    AccessLevel = AccessLevels.Basic
                }
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}
