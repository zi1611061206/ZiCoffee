using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace DataTransferLayer.DTOs
{
    public class PromotionObj : Promotion
    {
        public PromotionObj()
        {
            PromotionId = Guid.NewGuid();
        }

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
