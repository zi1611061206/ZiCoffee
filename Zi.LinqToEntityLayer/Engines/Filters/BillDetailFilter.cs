using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class BillDetailFilter : PaginatorConfiguration
    {
        public Guid BillId { get; set; }
        public Guid ProductId { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }
        public float IntoMoneyMin { get; set; }
        public float IntoMoneyMax { get; set; }

        public BillDetailFilter()
        {
            BillId = Guid.Empty;
            ProductId = Guid.Empty;
            QuantityMin = 0;
            QuantityMax = 0;
            IntoMoneyMin = 0;
            IntoMoneyMax = 0;
        }
    }
}
