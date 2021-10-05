using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IPromotionTypeService
    {
        Paginator<PromotionTypeDTO> GetAreaPromotionTypes(PromotionTypeFilter filter);
        bool AddPromotionType(PromotionTypeDTO obj);
        bool UpdatePromotionType(PromotionTypeDTO obj);
        bool DeletePromotionType(Guid promotionTypeId);
    }
}
