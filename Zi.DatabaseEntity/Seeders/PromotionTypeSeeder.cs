using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Constants;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Seeders
{
    public class PromotionTypeSeeder
    {
        public PromotionTypeSeeder(ZiDbContext context)
        {
            IList<PromotionType> promotionTypes = new List<PromotionType>();

            promotionTypes.Add(new PromotionType(){
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId1),
                Name = "Discount",
                Description = string.Empty
            });
            promotionTypes.Add(new PromotionType()
            {
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId2),
                Name = "Coupon",
                Description = string.Empty
            });
            promotionTypes.Add(new PromotionType()
            {
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId3),
                Name = "Voucher",
                Description = string.Empty
            });
            promotionTypes.Add(new PromotionType()
            {
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId4),
                Name = "Cash Back",
                Description = string.Empty
            });
            promotionTypes.Add(new PromotionType()
            {
                PromotionTypeId = Guid.Parse(GuidConstants.PromotionTypeId5),
                Name = "Member Point",
                Description = string.Empty
            });

            context.PromotionTypes.AddRange(promotionTypes);
            context.SaveChanges();
        }
    }
}
