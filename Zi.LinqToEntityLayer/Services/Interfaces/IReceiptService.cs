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
    public interface IReceiptService
    {
        Task<Paginator<Receipt>> GetReceipts(ReceiptFilter filter);
        Task<bool> AddReceipt(Receipt receipt);
        Task<bool> UpdateReceipt(Receipt receipt);
        Task<bool> DeleteReceipt(Guid receiptId);
    }
}
