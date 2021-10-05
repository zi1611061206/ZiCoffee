using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IReceiptDetailService
    {
        Paginator<ReceiptDetailDTO> GetReceiptDetails(ReceiptDetailFilter filter);
        bool AddReceiptDetail(ReceiptDetailDTO obj);
        bool UpdateReceiptDetail(ReceiptDetailDTO obj);
        bool DeleteReceiptDetail(Guid receiptId, Guid materialId);
    }
}
