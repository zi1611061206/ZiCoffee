using System;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IBillDetailService
    {
        Tuple<bool, object> Read(BillDetailFilter filter, string cultureName);
        Tuple<bool, object> Create(BillDetailModel model, string cultureName);
        Tuple<bool, object> Update(BillDetailModel model, string cultureName);
        Tuple<bool, object> Delete(BillDetailModel model, string cultureName);
    }
}
