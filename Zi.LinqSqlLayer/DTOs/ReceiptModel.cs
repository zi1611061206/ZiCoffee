using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class ReceiptModel
    {
        public Guid ReceiptId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid SupplierId { get; set; }

        public ReceiptModel()
        {
        }

        public ReceiptModel(Guid supplierId)
        {
            ReceiptId = Guid.NewGuid();
            SupplierId = supplierId;
        }

        /// <summary>
        /// Mapping data to ReceiptObj
        /// </summary>
        /// <param name="row"></param>
        public ReceiptModel(DataRow row)
        {
            ReceiptId = Guid.Parse(row["ReceiptId"].ToString());
            if (DateTime.TryParse(row["CreatedDate"].ToString(), out DateTime result))
            {
                CreatedDate = result;
            }
            SupplierId = Guid.Parse(row["SupplierId"].ToString());
        }
    }
}
