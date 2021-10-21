using System;
using System.Collections.Generic;
using Zi.DatabaseEntity.Entities;
using Zi.Utilities.Constants;

namespace Zi.DatabaseEntity.Seeders
{
    public class SupplierSeeder
    {
        public SupplierSeeder(ZiDbContext context)
        {
            IList<Supplier> suppliers = new List<Supplier>
            {
                new Supplier()
                {
                    SupplierId = Guid.Parse(GuidConstants.SupplierId1),
                    Name = "Coca Corp HCM",
                    Address = "11 Nguyễn Xí, phường 26, quận Bình Thạnh, TP.HCM",
                    PhoneNumber = "0123546987",
                    Email = "coca.corp@gmail.com"
                },
                new Supplier()
                {
                    SupplierId = Guid.Parse(GuidConstants.SupplierId2),
                    Name = "Monster Co",
                    Address = "456 Bạch Đằng, phường 24, quận Bình Thạnh, TP.HCM",
                    PhoneNumber = "0123000070",
                    Email = "monster.co@gmail.com"
                },
                new Supplier()
                {
                    SupplierId = Guid.Parse(GuidConstants.SupplierId3),
                    Name = "Thủ Đức Wholesale Markets",
                    Address = "141 QL1A, Tam Binh, TP Thủ Đức, TP.HCM",
                    PhoneNumber = string.Empty,
                    Email = string.Empty
                }
            };

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }
    }
}
