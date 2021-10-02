using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.ThreeLayer.DTOs.Relationship
{
    public class ReceiptDetailObj : ReceiptDetail
    {
        public ReceiptDetailObj(Guid receiptId, Guid materialId)
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
        public ReceiptDetailObj(DataRow row)
        {
            ReceiptId = Guid.Parse(row["ReceiptId"].ToString());
            MaterialId = Guid.Parse(row["MaterialId"].ToString());
            Quantity = (int)row["Quantity"];
            ImportPrice = (float)row["ImportPrice"];
        }
    }
}
