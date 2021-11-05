using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class BillDetailModel
    {
        public Guid BillId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float PromotionValue { get; set; }
        public float IntoMoney { get; set; }

        public BillDetailModel()
        {
        }

        public BillDetailModel(Guid billId, Guid productId)
        {
            BillId = billId;
            ProductId = productId;
            Quantity = 1;
            PromotionValue = 0;
            IntoMoney = 0;
        }

        /// <summary>
        /// Mapping data to BillDetailObj
        /// </summary>
        /// <param name="row"></param>
        public BillDetailModel(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Quantity = (int)row["Quantity"];
            PromotionValue = (float)row["PromotionValue"];
            IntoMoney = (float)row["IntoMoney"];
        }
    }
}
