using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class PromotionTypeFilter : PaginatorConfiguration
    {
        public Guid PromotionTypeId { get; set; }

        public PromotionTypeFilter()
        {
            PromotionTypeId = Guid.Empty;
        }
    }
}
