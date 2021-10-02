using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
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
