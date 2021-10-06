using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface ILogService
    {
        Tuple<bool, object> Read(LogFilter filter, string cultureName);
        Tuple<bool, object> Create(LogModel model, string cultureName);
        Tuple<bool, object> Update(LogModel model, string cultureName);
        Tuple<bool, object> Delete(Guid logId, string cultureName);
    }
}
