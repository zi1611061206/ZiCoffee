using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class ReceiptDetailDTO
    {
        public Guid ReceiptId { get; set; }
        public Guid MaterialId { get; set; }
        public int Quantity { get; set; }
        public float ImportPrice { get; set; }

        public ReceiptDetailDTO()
        {
        }

        public ReceiptDetailDTO(Guid receiptId, Guid materialId)
        {
            ReceiptId = receiptId;
            MaterialId = materialId;
            Quantity = 1;
            ImportPrice = 0;
        }

        /// <summary>
        /// Mapping data to ReceiptDetailObj
        /// </summary>
        /// <param name="row"></param>
        public ReceiptDetailDTO(DataRow row)
        {
            ReceiptId = Guid.Parse(row["ReceiptId"].ToString());
            MaterialId = Guid.Parse(row["MaterialId"].ToString());
            Quantity = (int)row["Quantity"];
            ImportPrice = (float)row["ImportPrice"];
        }
    }
}
