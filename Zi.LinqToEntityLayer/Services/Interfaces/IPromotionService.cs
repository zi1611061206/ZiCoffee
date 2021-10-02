using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<Paginator<Promotion>> GetPromotions(PromotionFilter filter);
        Task<bool> AddPromotion(Promotion promotion);
        Task<bool> UpdatePromotion(Promotion promotion);
        Task<bool> DeletePromotion(Guid promotionId);
    }
}
