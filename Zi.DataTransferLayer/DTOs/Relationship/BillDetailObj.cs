using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs.Relationship
{
    public class BillDetailObj : BillDetail
    {
        public BillDetailObj(Guid billId, Guid productId)
        {
            BillId = billId;
            ProductId = productId;
            Quantity = 1;
            IntoMoney = 0;
        }

        /// <summary>
        /// Mapping data to BillDetailObj
        /// </summary>
        /// <param name="row"></param>
        public BillDetailObj(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Quantity = (int)row["Quantity"];
            IntoMoney = (float)row["IntoMoney"];
        }
    }
}
