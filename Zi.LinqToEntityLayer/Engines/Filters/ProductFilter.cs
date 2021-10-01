using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Enumerators;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class ProductFilter : PaginatorConfiguration
    {
        public Guid ProductId { get; set; }
        public ProductStatus? Status { get; set; }
        public float PriceMin { get; set; }
        public float PriceMax { get; set; }
        public float PromotionVulueMin { get; set; }
        public float PromotionVulueMax { get; set; }
        public Guid CategoryId { get; set; }

        public ProductFilter()
        {
            ProductId = Guid.Empty;
            Status = null;
            PriceMin = 0;
            PriceMax = 0;
            PromotionVulueMin = 0;
            PromotionVulueMax = 0;
            CategoryId = Guid.Empty;
        }
    }
}
