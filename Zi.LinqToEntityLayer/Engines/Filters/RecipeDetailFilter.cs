using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
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
