using System;
using System.Data;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.DTOs
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; }
        public byte[] Thumnail { get; set; }
        public float Price { get; set; }
        public float PromotionVulue { get; set; }
        public Guid CategoryId { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(string name, byte[] thumnail, Guid categoryId)
        {
            ProductId = Guid.NewGuid();
            Description = string.Empty;
            Status = ProductStatus.Availabled;
            Price = 0;
            PromotionVulue = 0;
            Name = name;
            Thumnail = thumnail;
            CategoryId = categoryId;
        }

        /// <summary>
        /// Mapping data to ProductObj
        /// </summary>
        /// <param name="row"></param>
        public ProductModel(DataRow row)
        {
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            Status = (ProductStatus)row["Status"];
            Thumnail = (byte[])row["Thumnail"];
            Price = (float)row["Price"];
            PromotionVulue = (float)row["PromotionVulue"];
            CategoryId = Guid.Parse(row["CategoryId"].ToString());
        }
    }
}
