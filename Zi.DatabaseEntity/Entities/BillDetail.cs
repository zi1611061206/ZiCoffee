using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class BillDetail
    {
        public Guid BillId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float PromotionValue { get; set; }
        public float IntoMoney { get; set; }

        //FK m-n
        public Bill Bill { get; set; }
        public Product Product { get; set; }
    }
}
