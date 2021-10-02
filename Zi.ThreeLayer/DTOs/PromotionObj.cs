using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.ThreeLayer.DTOs
{
    public class PromotionObj : Promotion
    {
        public PromotionObj(DateTime startTime, DateTime endTime, Guid promotionTypeId)
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
        public PromotionObj(DataRow row)
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
