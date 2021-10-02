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
    public interface IPromotionTypeService
    {
        Task<Paginator<PromotionType>> GetAreaPromotionTypes(PromotionTypeFilter filter);
        Task<bool> AddPromotionType(PromotionType promotionType);
        Task<bool> UpdatePromotionType(PromotionType promotionType);
        Task<bool> DeletePromotionType(Guid promotionTypeId);
    }
}
