using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class DiscountDetailDTO
    {
        public Guid BillId { get; set; }
        public Guid PromotionId { get; set; }

        public DiscountDetailDTO()
        {
        }

        public DiscountDetailDTO(Guid billId, Guid promotionId)
        {
            BillId = billId;
            PromotionId = promotionId;
        }

        /// <summary>
        /// Mapping data to DiscountDetailObj
        /// </summary>
        /// <param name="row"></param>
        public DiscountDetailDTO(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            PromotionId = Guid.Parse(row["PromotionId"].ToString());
        }
    }
}
