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
    public interface IReceiptDetailService
    {
        Paginator<ReceiptDetail> GetReceiptDetails(ReceiptDetailFilter filter);
        Task<bool> AddReceiptDetail(ReceiptDetail receiptDetail);
        Task<bool> UpdateReceiptDetail(ReceiptDetail receiptDetail);
        Task<bool> DeleteReceiptDetail(Guid receiptId, Guid materialId);
    }
}
