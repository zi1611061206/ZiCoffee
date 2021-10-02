using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;
using Zi.LinqToEntityLayer.Services.Interfaces;

namespace Zi.LinqToEntityLayer.Services
{
    public class LogService : ILogService
    {
        public async Task<bool> AddLog(Log log)
        {
            using (var context = new ZiDbContext())
            {
                context.Logs.Add(log);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteLog(Guid logId)
        {
            using (var context = new ZiDbContext())
            {
                var log = await context.Logs.FindAsync(logId);
                context.Logs.Remove(log);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Log>> GetLogs(LogFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Logs;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new Log()
                {
                    LogId = x.LogId,
                    UserId = x.UserId,
                    EventId = x.EventId,
                    Time = x.Time
                });
                var result = new Paginator<Log>()
                {
                    TotalRecords = await data.CountAsync(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = await data.ToListAsync()
                };
                return result;
            }
        }

        #region Engines
        private DbSet<Log> GettingBy(DbSet<Log> query, LogFilter filter)
        {
            if (filter.LogId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.LogId.CompareTo(filter.LogId) == 0);
            }
            return query;
        }

        private DbSet<Log> Filtering(DbSet<Log> query, LogFilter filter)
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

        private DbSet<Log> Searching(DbSet<Log> query, LogFilter filter)
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

        private DbSet<Log> Paging(DbSet<Log> query, LogFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Log> Sorting(DbSet<Log> query, LogFilter filter)
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

        public async Task<bool> UpdateLog(Log log)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Logs.FindAsync(log.LogId);
                data.UserId = log.UserId;
                data.EventId = log.EventId;
                data.Time = log.Time;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
