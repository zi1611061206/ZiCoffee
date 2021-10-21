using System;
using System.Collections.Generic;
using Zi.Utilities.Enumerators;

namespace Zi.DatabaseEntity.Entities
{
    public class Promotion
    {
        public Guid PromotionId { get; set; }
        public string Description { get; set; }
        public PromotionActived IsActived { get; set; }
        public PromotionAutoApply IsAutoApply { get; set; }
        public PromotionPercent IsPercent { get; set; }
        public float Value { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float MinValue { get; set; }
        public string CodeList { get; set; }
        public Guid PromotionTypeId { get; set; }

        //FK n-1
        public PromotionType PromotionType { get; set; }

        //FK 1-n (m-n)
        public ICollection<DiscountDetail> DiscountDetails { get; set; }
    }
}
