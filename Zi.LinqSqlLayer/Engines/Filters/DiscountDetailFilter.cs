using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
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
