using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class SupplierFilter : PaginatorConfiguration
    {
        public Guid SupplierId { get; set; }

        public SupplierFilter()
        {
            SupplierId = Guid.Empty;
        }
    }
}
