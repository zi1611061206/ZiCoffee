using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace DataTransferLayer.DTOs
{
    public class ProductObj : Product
    {
        public ProductObj(string name, byte[] thumnail, Guid categoryId)
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
        public ProductObj(DataRow row)
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
