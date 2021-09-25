using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs
{
    public class PromotionTypeObj : PromotionType
    {
        public PromotionTypeObj()
        {
            PromotionTypeId = Guid.NewGuid();
        }

        public PromotionTypeObj(DataRow row)
        {
            PromotionTypeId = Guid.Parse(row["PromotionTypeId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
