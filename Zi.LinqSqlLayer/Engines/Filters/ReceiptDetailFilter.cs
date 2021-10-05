using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class ReceiptDetailFilter : PaginatorConfiguration
    {
        public Guid ReceiptId { get; set; }
        public Guid MaterialId { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }
        public float ImportPriceMin { get; set; }
        public float ImportPriceMax { get; set; }

        public ReceiptDetailFilter()
        {
            ReceiptId = Guid.Empty;
            MaterialId = Guid.Empty;
            QuantityMin = 0;
            QuantityMax = 0;
            ImportPriceMin = 0;
            ImportPriceMax = 0;
        }
    }
}
