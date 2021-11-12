using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class DiscountDetailModel
    {
        public Guid BillId { get; set; }
        public Guid PromotionId { get; set; }
        public string Code { get; set; }
        public DateTime AppliedTime { get; set; }

        public DiscountDetailModel()
        {
        }

        public DiscountDetailModel(Guid billId, Guid promotionId)
        {
            BillId = billId;
            PromotionId = promotionId;
            Code = string.Empty;
        }

        /// <summary>
        /// Mapping data to DiscountDetailObj
        /// </summary>
        /// <param name="row"></param>
        public DiscountDetailModel(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            PromotionId = Guid.Parse(row["PromotionId"].ToString());
            Code = row["Code"].ToString();
            if (DateTime.TryParse(row["AppliedTime"].ToString(), out DateTime result1))
            {
                AppliedTime = result1;
            }
        }
    }
}
