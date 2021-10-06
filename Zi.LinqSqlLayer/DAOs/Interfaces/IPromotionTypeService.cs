using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IPromotionTypeService
    {
        Tuple<bool, object> Read(PromotionTypeFilter filter, string cultureName);
        Tuple<bool, object> Create(PromotionTypeModel model, string cultureName);
        Tuple<bool, object> Update(PromotionTypeModel model, string cultureName);
        Tuple<bool, object> Delete(Guid promotionTypeId, string cultureName);
    }
}
