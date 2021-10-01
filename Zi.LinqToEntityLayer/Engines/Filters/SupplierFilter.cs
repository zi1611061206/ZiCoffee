using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
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
