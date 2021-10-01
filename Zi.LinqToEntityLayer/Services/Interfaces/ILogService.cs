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
    public interface ILogService
    {
        Paginator<Log> GetLogs(LogFilter filter);
        Task<bool> AddLog(Log log);
        Task<bool> UpdateLog(Log log);
        Task<bool> DeleteLog(Guid logId);
    }
}
