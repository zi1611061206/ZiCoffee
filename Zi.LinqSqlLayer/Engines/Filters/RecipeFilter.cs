using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class RecipeFilter : PaginatorConfiguration
    {
        public Guid RecipeId { get; set; }
        public Guid ProductId { get; set; }

        public RecipeFilter()
        {
            RecipeId = Guid.Empty;
            ProductId = Guid.Empty;
        }
    }
}
