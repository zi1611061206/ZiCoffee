using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IReceiptService
    {
        Tuple<bool, object> Read(ReceiptFilter filter, string cultureName);
        Tuple<bool, object> Create(ReceiptModel model, string cultureName);
        Tuple<bool, object> Update(ReceiptModel model, string cultureName);
        Tuple<bool, object> Delete(Guid receiptId, string cultureName);
    }
}
