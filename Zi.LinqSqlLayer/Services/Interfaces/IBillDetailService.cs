using System;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IBillDetailService
    {
        Paginator<BillDetailDTO> GetBillDetails(BillDetailFilter filter);
        bool AddBillDetail(BillDetailDTO obj);
        bool UpdateBillDetail(BillDetailDTO obj);
        bool DeleteBillDetail(Guid billId, Guid productId);
    }
}
