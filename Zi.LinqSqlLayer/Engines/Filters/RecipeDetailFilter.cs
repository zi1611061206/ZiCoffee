using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class RecipeDetailFilter : PaginatorConfiguration
    {
        public Guid RecipeId { get; set; }
        public Guid MaterialId { get; set; }
        public int QuantitativeMin { get; set; }
        public int QuantitativeMax { get; set; }

        public RecipeDetailFilter()
        {
            RecipeId = Guid.Empty;
            MaterialId = Guid.Empty;
            QuantitativeMin = 0;
            QuantitativeMax = 0;
        }
    }
}
