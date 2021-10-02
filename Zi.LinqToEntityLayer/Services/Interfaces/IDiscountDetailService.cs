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
    public interface IDiscountDetailService
    {
        Task<Paginator<DiscountDetail>> GetDiscountDetails(DiscountDetailFilter filter);
        Task<bool> AddDiscountDetail(DiscountDetail discountDetail);
        Task<bool> DeleteDiscountDetail(Guid billId, Guid promotionId);
    }
}
