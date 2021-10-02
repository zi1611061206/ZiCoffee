using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class MaterialFilter : PaginatorConfiguration
    {
        public Guid MaterialId { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }

        public MaterialFilter()
        {
            MaterialId = Guid.Empty;
            QuantityMin = 0;
            QuantityMax = 0;
        }
    }
}
