using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class DiscountDetailFilter : PaginatorConfiguration
    {
        public Guid BillId { get; set; }
        public Guid PromotionId { get; set; }

        public DiscountDetailFilter()
        {
            BillId = Guid.Empty;
            PromotionId = Guid.Empty;
        }
    }
}
