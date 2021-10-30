using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class BillDetailFilter : PaginatorConfiguration
    {
        public Guid BillId { get; set; }
        public Guid ProductId { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }
        public float PromotionValueMin { get; set; }
        public float PromotionValueMax { get; set; }
        public float IntoMoneyMin { get; set; }
        public float IntoMoneyMax { get; set; }

        public BillDetailFilter()
        {
            BillId = Guid.Empty;
            ProductId = Guid.Empty;
            QuantityMin = 0;
            QuantityMax = 0;
            PromotionValueMin = 0;
            PromotionValueMax = 0;
            IntoMoneyMin = 0;
            IntoMoneyMax = 0;
        }
    }
}
