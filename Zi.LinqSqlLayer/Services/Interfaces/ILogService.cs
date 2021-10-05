using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface ILogService
    {
        Paginator<LogDTO> GetLogs(LogFilter filter);
        bool AddLog(LogDTO obj);
        bool UpdateLog(LogDTO obj);
        bool DeleteLog(Guid logId);
    }
}
