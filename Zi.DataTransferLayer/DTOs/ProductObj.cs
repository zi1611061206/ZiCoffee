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
        public ProductObj()
        {
            ProductId = Guid.NewGuid();
        }

        public ProductObj(DataRow row)
        {
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            int productStatus = (int)row["Status"];
            Status = (ProductStatus)productStatus;
            Thumnail = (byte[])row["Thumnail"];
            Price = (float)row["Price"];
            PromotionVulue = (float)row["PromotionVulue"];
            CategoryId = Guid.Parse(row["CategoryId"].ToString());
        }
    }
}
