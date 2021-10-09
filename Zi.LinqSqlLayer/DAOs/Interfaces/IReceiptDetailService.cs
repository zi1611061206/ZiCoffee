using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IReceiptDetailService
    {
        Tuple<bool, object> Read(ReceiptDetailFilter filter, string cultureName);
        Tuple<bool, object> Create(ReceiptDetailModel model, string cultureName);
        Tuple<bool, object> Update(ReceiptDetailModel model, string cultureName);
        Tuple<bool, object> Delete(Guid receiptId, Guid materialId, string cultureName);
    }
}
