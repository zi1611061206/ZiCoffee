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
    public interface IBillService
    {
        Paginator<Bill> GetBills(BillFilter filter);
        Task<bool> AddBill(Bill bill);
        Task<bool> UpdateBill(Bill bill);
        Task<bool> DeleteBill(Guid billId);
    }
}
