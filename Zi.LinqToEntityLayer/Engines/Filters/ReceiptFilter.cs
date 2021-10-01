using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class ReceiptFilter : PaginatorConfiguration
    {
        public Guid ReceiptId { get; set; }
        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }
        public Guid SupplierId { get; set; }

        public ReceiptFilter()
        {
            ReceiptId = Guid.Empty;
            SupplierId = Guid.Empty;
            CreatedDateFrom = DateTime.MinValue;
            CreatedDateTo = DateTime.MaxValue;
        }
    }
}
