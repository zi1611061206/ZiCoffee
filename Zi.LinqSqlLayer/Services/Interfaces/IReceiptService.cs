using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IReceiptService
    {
        Paginator<ReceiptDTO> GetReceipts(ReceiptFilter filter);
        bool AddReceipt(ReceiptDTO obj);
        bool UpdateReceipt(ReceiptDTO obj);
        bool DeleteReceipt(Guid receiptId);
    }
}
