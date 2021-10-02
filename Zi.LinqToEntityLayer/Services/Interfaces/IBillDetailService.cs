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
    public interface IBillDetailService
    {
        Task<Paginator<BillDetail>> GetBillDetails(BillDetailFilter filter);
        Task<bool> AddBillDetail(BillDetail billDetail);
        Task<bool> UpdateBillDetail(BillDetail billDetail);
        Task<bool> DeleteBillDetail(Guid billId, Guid productId);
    }
}
