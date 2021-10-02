using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.ThreeLayer.DTOs
{
    public class PromotionTypeObj : PromotionType
    {
        public PromotionTypeObj(string name)
        {
            PromotionTypeId = Guid.NewGuid();
            Description = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to PromotiontypeObj
        /// </summary>
        /// <param name="row"></param>
        public PromotionTypeObj(DataRow row)
        {
            PromotionTypeId = Guid.Parse(row["PromotionTypeId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
