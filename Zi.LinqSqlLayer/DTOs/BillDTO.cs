using System;
using System.Data;
using Zi.LinqSqlLayer.Enumerators;

namespace Zi.LinqSqlLayer.DTOs
{
    public class BillDTO
    {
        public Guid BillId { get; set; }
        public DateTime CreatedDate { get; set; }
        public float Total { get; set; }
        public float Vat { get; set; }
        public float AfterVat { get; set; }
        public float RealPay { get; set; }
        public BillStatus Status { get; set; }
        public DateTime LastedModify { get; set; }
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }

        public BillDTO()
        {
        }

        public BillDTO(Guid userId, Guid tableId)
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
        public BillDTO(DataRow row)
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
