using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.DatabaseEntity.Seeders
{
    public class PromotionSeeder
    {
        public PromotionSeeder(ZiDbContext context)
        {
            IList<Promotion> promotions = new List<Promotion>();

            #region // Discount
            promotions.Add(new Promotion() { 
                PromotionId = Guid.Parse(GuidConstants.PromotionId1),
                Description = DateTime.Now.Month + " Sale",
                IsActived = PromotionActived.NotActivated,
                IsAutoApply = PromotionAutoApply.Auto,
                IsPercent = PromotionPercent.Percent,
                Value = 10,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(10),
                MinValue = 50000,
                CodeList = string.Empty,
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId1)
            });
            promotions.Add(new Promotion()
            {
                PromotionId = Guid.Parse(GuidConstants.PromotionId2),
                Description = "Valentine's Day Sale",
                IsActived = PromotionActived.Activated,
                IsAutoApply = PromotionAutoApply.Auto,
                IsPercent = PromotionPercent.Normal,
                Value = 10000,
                StartTime = DateTime.Parse("14/02/2022"),
                EndTime = DateTime.Parse("14/02/2022").AddDays(2),
                MinValue = 50000,
                CodeList = string.Empty,
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId1)
            });
            #endregion

            #region // Coupon
            promotions.Add(new Promotion()
            {
                PromotionId = Guid.Parse(GuidConstants.PromotionId3),
                Description = "Coupon for families",
                IsActived = PromotionActived.Activated,
                IsAutoApply = PromotionAutoApply.Manual,
                IsPercent = PromotionPercent.Percent,
                Value = 5,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMonths(5),
                MinValue = 100000,
                CodeList = CodeGenerator(10),
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId2)
            });
            #endregion

            #region // Voucher
            promotions.Add(new Promotion()
            {
                PromotionId = Guid.Parse(GuidConstants.PromotionId4),
                Description = "Voucher for Students",
                IsActived = PromotionActived.Activated,
                IsAutoApply = PromotionAutoApply.Manual,
                IsPercent = PromotionPercent.Percent,
                Value = 5,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMonths(5),
                MinValue = 100000,
                CodeList = CodeGenerator(10),
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId3)
            });
            #endregion

            context.Promotions.AddRange(promotions);
            context.SaveChanges();
        }

        private string CodeGenerator(int quantity = 5)
        {
            string codeList = string.Empty;
            for(int i = 0; i < quantity; i++)
            {
                string guidString = new Guid().ToString().Replace("-", "");
                if (i != quantity - 1)
                {
                    codeList += guidString + ",";
                }
                codeList += guidString;
            }
            return codeList;
        } 
    }
}
