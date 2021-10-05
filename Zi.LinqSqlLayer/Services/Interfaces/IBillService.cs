using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IBillService
    {
        Paginator<BillDTO> GetBills(BillFilter filter);
        bool AddBill(BillDTO obj);
        bool UpdateBill(BillDTO obj);
        bool DeleteBill(Guid billId);
    }
}
