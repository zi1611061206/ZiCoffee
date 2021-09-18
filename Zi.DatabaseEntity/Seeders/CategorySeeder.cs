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
    public class CategorySeeder
    {
        public CategorySeeder(ZiDbContext context)
        {
            IList<Category> categories = new List<Category>();

            categories.Add(new Category() { 
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCoffee),
                Name = "Coffees",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilk),
                Name = "Milks",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea),
                Name = "Teas",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake),
                Name = "MilkShakes",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice),
                Name = "Juices",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdFruit),
                Name = "Fruits",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater),
                Name = "Bottled Waters",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake),
                Name = "Cakes",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSmoothie),
                Name = "Smoothies",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCream),
                Name = "Creams",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSoda),
                Name = "Sodas",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherServices),
                Name = "Other Services",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Empty
            });

            #region // Coffee's children
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee),
                Name = "Traditional Coffee",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Parse(GuidConstants.CategoryIdCoffee)
            });
            categories.Add(new Category()
            {
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherCoffee),
                Name = "Other Coffee",
                Description = string.Empty,
                Status = CategoryStatus.Availabled,
                ParentId = Guid.Parse(GuidConstants.CategoryIdCoffee)
            });
            #endregion

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
