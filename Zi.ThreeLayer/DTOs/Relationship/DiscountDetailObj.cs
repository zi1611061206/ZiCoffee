using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.ThreeLayer.DTOs.Relationship
{
    public class DiscountDetailObj : DiscountDetail
    {
        public DiscountDetailObj(Guid billId, Guid promotionId)
        {
            BillId = billId;
            PromotionId = promotionId;
        }

        /// <summary>
        /// Mapping data to DiscountDetailObj
        /// </summary>
        /// <param name="row"></param>
        public DiscountDetailObj(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            PromotionId = Guid.Parse(row["PromotionId"].ToString());
        }
    }
}
