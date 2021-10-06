using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface ITableService
    {
        Tuple<bool, object> Read(TableFilter filter, string cultureName);
        Tuple<bool, object> Create(TableModel model, string cultureName);
        Tuple<bool, object> Update(TableModel model, string cultureName);
        Tuple<bool, object> Delete(Guid tableId, string cultureName);
    }
}
