using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class DiscountDetailModel
    {
        public Guid BillId { get; set; }
        public Guid PromotionId { get; set; }

        public DiscountDetailModel()
        {
        }

        public DiscountDetailModel(Guid billId, Guid promotionId)
        {
            BillId = billId;
            PromotionId = promotionId;
        }

        /// <summary>
        /// Mapping data to DiscountDetailObj
        /// </summary>
        /// <param name="row"></param>
        public DiscountDetailModel(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            PromotionId = Guid.Parse(row["PromotionId"].ToString());
        }
    }
}
