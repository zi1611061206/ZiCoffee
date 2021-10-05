using System;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class BillFilter : PaginatorConfiguration
    {
        public Guid BillId { get; set; }
        public DateTime CreatedDateFrom { get; set; }
        public DateTime CreatedDateTo { get; set; }
        public float TotalMin { get; set; }
        public float TotalMax { get; set; }
        public float VatMin { get; set; }
        public float VatMax { get; set; }
        public float AfterVatMin { get; set; }
        public float AfterVatMax { get; set; }
        public float RealPayMin { get; set; }
        public float RealPayMax { get; set; }
        public BillStatus? Status { get; set; }
        public DateTime LastedModifyFrom { get; set; }
        public DateTime LastedModifyTo { get; set; }
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }

        public BillFilter()
        {
            BillId = Guid.Empty;
            CreatedDateFrom = DateTime.MinValue;
            CreatedDateTo = DateTime.MaxValue;
            TotalMin = 0;
            TotalMax = 0;
            VatMin = 0;
            VatMax = 0;
            AfterVatMin = 0;
            AfterVatMax = 0;
            RealPayMin = 0;
            RealPayMax = 0;
            Status = null;
            LastedModifyFrom = DateTime.MinValue;
            LastedModifyTo = DateTime.MaxValue;
            UserId = Guid.Empty;
            TableId = Guid.Empty;
        }
    }
}
