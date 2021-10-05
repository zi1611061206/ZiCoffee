using System;
using System.Data;
using Zi.LinqSqlLayer.Enumerators;

namespace Zi.LinqSqlLayer.DTOs
{
    public class PromotionDTO
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

        public PromotionDTO()
        {
        }

        public PromotionDTO(DateTime startTime, DateTime endTime, Guid promotionTypeId)
        {
            PromotionId = Guid.NewGuid();
            Description = string.Empty;
            IsActived = PromotionActived.NotActivated;
            IsAutoApply = PromotionAutoApply.Manual;
            IsPercent = PromotionPercent.Normal;
            Value = 1;
            MinValue = 0;
            CodeList = string.Empty;
            StartTime = startTime;
            EndTime = endTime;
            PromotionTypeId = promotionTypeId;
        }

        /// <summary>
        /// Mapping data to PromotionObj
        /// </summary>
        /// <param name="row"></param>
        public PromotionDTO(DataRow row)
        {
            PromotionId = Guid.Parse(row["PromotionId"].ToString());
            Description = row["Description"].ToString();
            IsActived = (PromotionActived)row["IsActived"];
            IsAutoApply = (PromotionAutoApply)row["IsAutoApply"];
            IsPercent = (PromotionPercent)row["IsPercent"];
            Value = (float)row["Value"];
            if (DateTime.TryParse(row["StartTime"].ToString(), out DateTime result1))
            {
                StartTime = result1;
            }
            if (DateTime.TryParse(row["EndTime"].ToString(), out DateTime result2))
            {
                EndTime = result2;
            }
            MinValue = (float)row["MinValue"];
            CodeList = row["CodeList"].ToString();
            PromotionTypeId = Guid.Parse(row["PromotionTypeId"].ToString());
        }
    }
}
