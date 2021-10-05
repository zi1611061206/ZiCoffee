using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IPromotionService
    {
        Paginator<PromotionDTO> GetPromotions(PromotionFilter filter);
        bool AddPromotion(PromotionDTO obj);
        bool UpdatePromotion(PromotionDTO obj);
        bool DeletePromotion(Guid promotionId);
    }
}
