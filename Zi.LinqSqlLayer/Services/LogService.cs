using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class LogService : ILogService
    {
        public bool AddLog(LogDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var log = new Log()
                {
                    LogId = obj.LogId,
                    EventId = obj.EventId,
                    UserId = obj.UserId
                };
                context.Logs.InsertOnSubmit(log);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool DeleteLog(Guid logId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var log = context.Logs.Where(x => x.LogId.CompareTo(logId) == 0).FirstOrDefault();
                context.Logs.DeleteOnSubmit(log);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<LogDTO> GetLogs(LogFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Logs;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new LogDTO()
                {
                    LogId = x.LogId,
                    UserId = x.UserId,
                    EventId = x.EventId,
                    Time = x.Time
                });
                var result = new Paginator<LogDTO>()
                {
                    TotalRecords = data.Count(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                return result;
            }
        }

        #region Engines
        private Table<Log> GettingBy(Table<Log> query, LogFilter filter)
        {
            if (filter.LogId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.LogId.CompareTo(filter.LogId) == 0);
            }
            return query;
        }

        private Table<Log> Filtering(Table<Log> query, LogFilter filter)
        {
            if (filter.UserId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.UserId.CompareTo(filter.UserId) == 0);
            }
            if (filter.EventId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.EventId.CompareTo(filter.EventId) == 0);
            }
            query.Where(x => x.Time.CompareTo(filter.TimeFrom) >= 0);
            if (DateTime.Compare(filter.TimeTo, filter.TimeFrom) > 0)
            {
                query.Where(x => x.Time.CompareTo(filter.TimeTo) <= 0);
            }
            return query;
        }

        private Table<Log> Searching(Table<Log> query, LogFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.LogId.ToString().Contains(filter.Keyword) ||
                        x.UserId.ToString().Contains(filter.Keyword) ||
                        x.EventId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.LogId.ToString().Equals(filter.Keyword) ||
                        x.UserId.ToString().Equals(filter.Keyword) ||
                        x.EventId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Log> Paging(Table<Log> query, LogFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Log> Sorting(Table<Log> query, LogFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.Time);
            }
            else
            {
                query.OrderByDescending(x => x.Time);
            }
            return query;
        }
        #endregion

        public bool UpdateLog(LogDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var log = context.Logs.Where(x => x.LogId.CompareTo(obj.LogId) == 0).FirstOrDefault();
                log.EventId = obj.EventId;
                log.UserId = obj.UserId;
                log.Time = obj.Time;
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
    }
}
