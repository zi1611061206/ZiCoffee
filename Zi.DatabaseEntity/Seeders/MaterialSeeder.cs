using System;
using System.Collections.Generic;
using Zi.DatabaseEntity.Entities;
using Zi.Utilities.Constants;

namespace Zi.DatabaseEntity.Seeders
{
    public class MaterialSeeder
    {
        public MaterialSeeder(ZiDbContext context)
        {
            IList<Material> materials = new List<Material>();

            #region // Kg
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId01),
                Name = "Roasted Coffee Powder",
                Unit = "Kg",
                Quantity = 10
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId02),
                Name = "Pure Voi Coffee",
                Unit = "Kg",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId03),
                Name = "Milo Powder",
                Unit = "Kg",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId04),
                Name = "Cocoa Powder",
                Unit = "Kg",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId05),
                Name = "Milk Tea Powder",
                Unit = "Kg",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId06),
                Name = "Matcha Powder",
                Unit = "Kg",
                Quantity = 5
            });
            #endregion

            #region // Bottle
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId07),
                Name = "Blueberry Syrup",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId08),
                Name = "Strawberry Syrup",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId09),
                Name = "Blue Sky Syrup",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId10),
                Name = "Rose Syrup",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId11),
                Name = "Vanile Syrup",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId12),
                Name = "Lemon Syrup",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId13),
                Name = "Mango Syrup",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId14),
                Name = "Peach Syrup",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId15),
                Name = "Sting",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId16),
                Name = "Number One",
                Unit = "Bottle",
                Quantity = 5
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId17),
                Name = "Coca",
                Unit = "Bottle",
                Quantity = 5
            });
            #endregion

            #region // Fruit
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId18),
                Name = "Orange",
                Unit = "Fruit",
                Quantity = 12
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId19),
                Name = "Melon",
                Unit = "Fruit",
                Quantity = 2
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId20),
                Name = "Passion Fruit",
                Unit = "Fruit",
                Quantity = 2
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId21),
                Name = "Mango Fruit",
                Unit = "Fruit",
                Quantity = 2
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId22),
                Name = "Apple Fruit",
                Unit = "Fruit",
                Quantity = 2
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId23),
                Name = "Lemon Fruit",
                Unit = "Fruit",
                Quantity = 2
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId24),
                Name = "Peach Fruit",
                Unit = "Fruit",
                Quantity = 2
            });
            #endregion

            #region // Can
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId25),
                Name = "'Ông Thọ'Condensed Milk",
                Unit = "Can",
                Quantity = 10
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId26),
                Name = "Star Condensed Milk",
                Unit = "Can",
                Quantity = 10
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId27),
                Name = "Redbull",
                Unit = "Can",
                Quantity = 5
            });
            #endregion

            #region // Box
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId28),
                Name = "Vinamilk Fresh Milk",
                Unit = "Box",
                Quantity = 12
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId29),
                Name = "Vinamilk Fresh Milk (No Sugar)",
                Unit = "Box",
                Quantity = 12
            });
            #endregion

            #region // Bag
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId30),
                Name = "Incense Tea",
                Unit = "Bag",
                Quantity = 12
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId31),
                Name = "Lipton Tea",
                Unit = "Bag",
                Quantity = 12
            });
            materials.Add(new Material()
            {
                MaterialId = Guid.Parse(GuidConstants.MaterialId32),
                Name = "Lotus Tea",
                Unit = "Bag",
                Quantity = 12
            });
            #endregion

            context.Materials.AddRange(materials);
            context.SaveChanges();
        }
    }
}
