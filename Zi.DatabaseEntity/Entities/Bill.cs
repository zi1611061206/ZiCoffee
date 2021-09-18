using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.DatabaseEntity.Entities
{
    public class Bill
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

        //FK n-1
        public User User { get; set; }
        public Table Table { get; set; }

        //FK 1-n (m-n)
        public ICollection<BillDetail> BillDetails { get; set; }

        //FK 1-n (m-n)
        public ICollection<DiscountDetail> DiscountDetails { get; set; }
    }
}
