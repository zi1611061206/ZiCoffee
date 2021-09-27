using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace DataTransferLayer.DTOs
{
    public class BillObj : Bill
    {
        public BillObj(Guid userId, Guid tableId)
        {
            BillId = Guid.NewGuid();
            Total = 0;
            Vat = 0;
            AfterVat = 0;
            RealPay = 0;
            Status = BillStatus.UnPay;
            UserId = userId;
            TableId = tableId;
        }

        /// <summary>
        /// Mapping data to BillObj
        /// </summary>
        /// <param name="row"></param>
        public BillObj(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            if (DateTime.TryParse(row["CreatedDate"].ToString(), out DateTime result1))
            {
                CreatedDate = result1;
            }
            Total = (float)row["Total"];
            Vat = (float)row["Vat"];
            AfterVat = (float)row["AfterVat"];
            RealPay = (float)row["RealPay"];
            Status = (BillStatus)row["Status"];
            if (DateTime.TryParse(row["LastedModify"].ToString(), out DateTime result2))
            {
                LastedModify = result2;
            }
            UserId = Guid.Parse(row["UserId"].ToString());
            TableId = Guid.Parse(row["TableId"].ToString());
        }
    }
}
