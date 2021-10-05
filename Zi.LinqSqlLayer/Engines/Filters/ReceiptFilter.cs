using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class ReceiptFilter : PaginatorConfiguration
    {
        public Guid ReceiptId { get; set; }
        public DateTime CreatedDateFrom { get; set; }
        public DateTime CreatedDateTo { get; set; }
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
