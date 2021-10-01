using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
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
