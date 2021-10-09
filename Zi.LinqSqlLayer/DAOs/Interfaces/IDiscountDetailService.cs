using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IDiscountDetailService
    {
        Tuple<bool, object> Read(DiscountDetailFilter filter, string cultureName);
        Tuple<bool, object> Create(DiscountDetailModel model, string cultureName);
        Tuple<bool, object> Delete(Guid billId, Guid promotionId, string cultureName);
    }
}
