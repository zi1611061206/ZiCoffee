using System;
using Zi.LinqToEntityLayer.Engines.Paginators;
using Zi.Utilities.Enumerators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class PromotionFilter : PaginatorConfiguration
    {
        public Guid PromotionId { get; set; }
        public PromotionActived? IsActived { get; set; }
        public PromotionAutoApply? IsAutoApply { get; set; }
        public PromotionPercent? IsPercent { get; set; }
        public float ValueFrom { get; set; }
        public float ValueTo { get; set; }
        public DateTime? StartTimeFilter { get; set; }
        public DateTime? EndTimeFilter { get; set; }
        public float MinValueFrom { get; set; }
        public float MinValueTo { get; set; }
        public Guid PromotionTypeId { get; set; }

        public PromotionFilter()
        {
            PromotionId = Guid.Empty;
            IsActived = null;
            IsAutoApply = null;
            IsPercent = null;
            ValueFrom = 0;
            ValueTo = 0;
            StartTimeFilter = DateTime.MinValue;
            EndTimeFilter = DateTime.MaxValue;
            MinValueFrom = 0;
            MinValueTo = 0;
            PromotionTypeId = Guid.Empty;
        }
    }
}
