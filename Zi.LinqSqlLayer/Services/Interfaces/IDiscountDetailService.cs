using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IDiscountDetailService
    {
        Paginator<DiscountDetailDTO> GetDiscountDetails(DiscountDetailFilter filter);
        bool AddDiscountDetail(DiscountDetailDTO obj);
        bool DeleteDiscountDetail(Guid billId, Guid promotionId);
    }
}
