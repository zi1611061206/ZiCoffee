using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.DatabaseEntity.Seeders
{
    public class ProductSeeder
    {
        public ProductSeeder(ZiDbContext context)
        {
            IList<Product> products = new List<Product>();

            #region // Make default "NoImage"
            string startupPath = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(startupPath).Parent.FullName;
            string imagePath = projectDirectory + @"\Resources\no_image.png";
            FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] binaryArray = new byte[fs.Length];
            fs.Read(binaryArray, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            #endregion

            #region // Traditional Coffee
            products.Add(new Product() {
                ProductId = Guid.Parse(GuidConstants.ProductId001),
                Name = "Black Filter Coffee",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId002),
                Name = "Milk Filter Coffee",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 5,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId003),
                Name = "Sugar Filter Coffee",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 10,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId004),
                Name = "Hot Milk Coffee",
                Description = string.Empty,
                Status = ProductStatus.NotAvailabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId005),
                Name = "Iced Milk Coffee",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId006),
                Name = "Hot Bac Xiu",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId007),
                Name = "Iced Bac Xiu",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId008),
                Name = "Black Coffee",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId009),
                Name = "White Coffee",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId010),
                Name = "Egg Coffee",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTraditionalCoffee)
            });
            #endregion

            #region // Other Coffee
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId011),
                Name = "Espresso",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 35000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId012),
                Name = "Capuchino",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 35000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId013),
                Name = "Americano",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 35000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId014),
                Name = "Latte",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 35000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId015),
                Name = "Mocha",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 35000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId016),
                Name = "Macchiato",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 35000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherCoffee)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId017),
                Name = "Irish",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 35000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherCoffee)
            });
            #endregion

            #region // Milks
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId018),
                Name = "Hot Milk",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilk)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId019),
                Name = "Iced Milk",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilk)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId020),
                Name = "Fresh Milk",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilk)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId021),
                Name = "Green Bean Milk",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilk)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId022),
                Name = "Soya Milk",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilk)
            });
            #endregion

            #region // Teas
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId023),
                Name = "Mango Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId024),
                Name = "Strawberry Orange Lychee Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId025),
                Name = "Peach Orange Lemongrass Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId026),
                Name = "Honey Grapefruit Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId027),
                Name = "Green Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId028),
                Name = "Red Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId029),
                Name = "Lychee Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId030),
                Name = "Peach Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId031),
                Name = "Lemon Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdTea)
            });
            #endregion

            #region // MilkShakes
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId032),
                Name = "Pearl Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId033),
                Name = "Black Sugar Pearl Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId034),
                Name = "White Pearl Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId035),
                Name = "Oreo Cake Cream Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId036),
                Name = "Taro Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId037),
                Name = "Matcha Red Bean Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId038),
                Name = "Oreo Chocolate Cream Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId039),
                Name = "Red Bean Pudding Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId040),
                Name = "'Sương Sáo' Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId041),
                Name = "Earl Grey Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId042),
                Name = "Caramel Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId043),
                Name = "Coffee Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId044),
                Name = "Cheese Milk Foam Milk Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 45000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdMilkshake)
            });
            #endregion

            #region // Juices
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId045),
                Name = "Orange Juice",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId046),
                Name = "Lemon Juice",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId047),
                Name = "Strawberry Juice",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId048),
                Name = "Apple Juice",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId049),
                Name = "Carrot Juice",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId050),
                Name = "Mango Juice",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId051),
                Name = "Melon Juice",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId052),
                Name = "Tomato Juice",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdJuice)
            });
            #endregion

            #region // Fruits
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId053),
                Name = "Fruit Bowl Size S",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdFruit)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId054),
                Name = "Fruit Bowl Size M",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdFruit)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId055),
                Name = "Fruit Bowl Size L",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdFruit)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId056),
                Name = "Fruit Bucket",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdFruit)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId057),
                Name = "Fruit Hot Pot",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdFruit)
            });
            #endregion

            #region // Bottled Waters
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId058),
                Name = "Sting",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId059),
                Name = "Number One",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId060),
                Name = "Coca",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId061),
                Name = "Pepsi",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId062),
                Name = "Redbull",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId063),
                Name = "C2",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId064),
                Name = "Zero Degree Green Tea",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId065),
                Name = "Revive",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId066),
                Name = "7up",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId067),
                Name = "Fanta",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId068),
                Name = "Sprite",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId069),
                Name = "TH True Milk",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId070),
                Name = "Pocari Sweet",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId071),
                Name = "Mirinda",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId072),
                Name = "Twister",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 15000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId073),
                Name = "Aquafina",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 7000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId074),
                Name = "Lavie",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 7000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId075),
                Name = "Dasani",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 7000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdBottledWater)
            });
            #endregion

            #region // Cakes
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId076),
                Name = "Flan",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId077),
                Name = "Tiramisu",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId078),
                Name = "Cookies",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId079),
                Name = "Macaron",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId080),
                Name = "Muffin",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId081),
                Name = "Cupcake",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId082),
                Name = "Chocolate Tart",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId083),
                Name = "Cheesecake",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId084),
                Name = "Hummus Wrap",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId085),
                Name = "Nama Chocolate",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId086),
                Name = "Pana Cotta",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 20000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCake)
            });
            #endregion

            #region // Smoothies
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId087),
                Name = "Carrot Smoothies",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSmoothie)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId088),
                Name = "Butter Smoothies",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSmoothie)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId089),
                Name = "Strawberry Smoothies",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSmoothie)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId090),
                Name = "Mango Smoothies",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSmoothie)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId091),
                Name = "Sapote Smoothies",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 30000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSmoothie)
            });
            #endregion

            #region // Creams
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId092),
                Name = "Gelato Cream (Italy)",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCream)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId093),
                Name = "Mochi Cream (Japan)",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCream)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId094),
                Name = "Helado Cream (Argentina)",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCream)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId095),
                Name = "Ais Kacang Cream (Malaysia)",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCream)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId096),
                Name = "Ben & Jerry's Cream (America)",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCream)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId097),
                Name = "Halva Cream (Israel)",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 40000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdCream)
            });
            #endregion

            #region // Sodas
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId098),
                Name = "Strawberry Soda",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSoda)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId099),
                Name = "Blueberry Soda",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSoda)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId100),
                Name = "Honey Soda",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 25000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdSoda)
            });
            #endregion

            #region // Other Services
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId101),
                Name = "Wet Tissue",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 10000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherServices)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId102),
                Name = "Dried Tissue",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 10000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherServices)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId103),
                Name = "More Pearl",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 10000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherServices)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId104),
                Name = "More Sugar",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 10000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherServices)
            });
            products.Add(new Product()
            {
                ProductId = Guid.Parse(GuidConstants.ProductId105),
                Name = "More Milk",
                Description = string.Empty,
                Status = ProductStatus.Availabled,
                Thumnail = binaryArray,
                Price = 10000,
                PromotionVulue = 0,
                CategoryId = Guid.Parse(GuidConstants.CategoryIdOtherServices)
            });
            #endregion

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
