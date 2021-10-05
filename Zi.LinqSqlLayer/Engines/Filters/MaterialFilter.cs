using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
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
