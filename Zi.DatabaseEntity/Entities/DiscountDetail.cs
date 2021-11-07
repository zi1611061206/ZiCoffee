using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class DiscountDetail
    {
        public Guid BillId { get; set; }
        public Guid PromotionId { get; set; }
        public string Code { get; set; }
        public DateTime AppliedTime { get; set; }

        //FK m-n
        public Bill Bill { get; set; }
        public Promotion Promotion { get; set; }
    }
}
