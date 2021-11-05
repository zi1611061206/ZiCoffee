using System;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class ProductFilter : PaginatorConfiguration
    {
        public Guid ProductId { get; set; }
        public ProductStatus? Status { get; set; }
        public float PriceMin { get; set; }
        public float PriceMax { get; set; }
        public float PromotionValueMin { get; set; }
        public float PromotionValueMax { get; set; }
        public Guid CategoryId { get; set; }

        public ProductFilter()
        {
            ProductId = Guid.Empty;
            Status = null;
            PriceMin = 0;
            PriceMax = 0;
            PromotionValueMin = 0;
            PromotionValueMax = 0;
            CategoryId = Guid.Empty;
        }
    }
}
