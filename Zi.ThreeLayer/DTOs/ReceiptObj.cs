using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.ThreeLayer.DTOs
{
    public class ReceiptObj : Receipt
    {
        public ReceiptObj(Guid supplierId)
        {
            ReceiptId = Guid.NewGuid();
            SupplierId = supplierId;
        }

        /// <summary>
        /// Mapping data to ReceiptObj
        /// </summary>
        /// <param name="row"></param>
        public ReceiptObj(DataRow row)
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
