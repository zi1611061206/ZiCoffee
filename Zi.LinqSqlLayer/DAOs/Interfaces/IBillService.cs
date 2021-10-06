using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IBillService
    {
        Tuple<bool, object> Read(BillFilter filter, string cultureName);
        Tuple<bool, object> Create(BillModel model, string cultureName);
        Tuple<bool, object> Update(BillModel model, string cultureName);
        Tuple<bool, object> Delete(Guid billId, string cultureName);
    }
}
