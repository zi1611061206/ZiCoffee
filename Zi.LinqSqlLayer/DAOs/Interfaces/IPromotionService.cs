using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IPromotionService
    {
        Tuple<bool, object> Read(PromotionFilter filter, string cultureName);
        Tuple<bool, object> Create(PromotionModel model, string cultureName);
        Tuple<bool, object> Update(PromotionModel model, string cultureName);
        Tuple<bool, object> Delete(Guid promotionId, string cultureName);
    }
}
