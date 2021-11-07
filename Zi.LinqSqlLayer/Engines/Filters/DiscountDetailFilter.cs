using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class DiscountDetailFilter : PaginatorConfiguration
    {
        public Guid BillId { get; set; }
        public Guid PromotionId { get; set; }
        public string Code { get; set; }
        public DateTime AppliedTimeFrom { get; set; }
        public DateTime AppliedTimeTo { get; set; }

        public DiscountDetailFilter()
        {
            BillId = Guid.Empty;
            PromotionId = Guid.Empty;
            Code = string.Empty;
            AppliedTimeFrom = DateTime.MinValue;
            AppliedTimeTo = DateTime.MaxValue;
        }
    }
}
