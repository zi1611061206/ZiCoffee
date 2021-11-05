using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class LogService : ILogService
    {
        #region Instance
        private static LogService instance;
        public static LogService Instance
        {
            get { if (instance == null) instance = new LogService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private LogService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(LogModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var log = new Log()
                {
                    LogId = model.LogId,
                    EventId = model.EventId,
                    UserId = model.UserId,
                    Content = model.Content,
                    Time = DateTime.Now
                };
                context.Logs.InsertOnSubmit(log);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, log.LogId);
            }
        }

        public Tuple<bool, object> Delete(Guid logId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var log = context.Logs
                    .Where(x => x.LogId.CompareTo(logId) == 0)
                    .FirstOrDefault();
                if (log == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + logId);
                }
                context.Logs.DeleteOnSubmit(log);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedDelete", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> Read(LogFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Logs.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new LogModel()
                {
                    LogId = x.LogId,
                    UserId = x.UserId,
                    EventId = x.EventId,
                    Time = x.Time,
                    Content = x.Content
                });
                var result = new Paginator<LogModel>()
                {
                    TotalRecords = totalRecords,
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                if (data.Count() <= 0)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                return new Tuple<bool, object>(true, result);
            }
        }

        #region Engines
        private IQueryable<Log> GettingBy(IQueryable<Log> query, LogFilter filter)
        {
            if (filter.LogId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.LogId.CompareTo(filter.LogId) == 0);
            }
            return query;
        }

        private IQueryable<Log> Filtering(IQueryable<Log> query, LogFilter filter)
        {
            if (filter.UserId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.UserId.CompareTo(filter.UserId) == 0);
            }
            if (filter.EventId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.EventId.CompareTo(filter.EventId) == 0);
            }
            query.Where(x => x.Time.CompareTo(filter.TimeFrom) >= 0);
            if (DateTime.Compare(filter.TimeTo, filter.TimeFrom) > 0)
            {
                query = query.Where(x => x.Time.CompareTo(filter.TimeTo) <= 0);
            }
            return query;
        }

        private IQueryable<Log> Searching(IQueryable<Log> query, LogFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.LogId.ToString().Contains(filter.Keyword) ||
                        x.UserId.ToString().Contains(filter.Keyword) ||
                        x.Content.ToString().Contains(filter.Keyword) ||
                        x.EventId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.LogId.ToString().Equals(filter.Keyword) ||
                        x.UserId.ToString().Equals(filter.Keyword) ||
                        x.Content.ToString().Equals(filter.Keyword) ||
                        x.EventId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Log> Paging(IQueryable<Log> query, LogFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Log> Sorting(IQueryable<Log> query, LogFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.Time);
            }
            else
            {
                query = query.OrderByDescending(x => x.Time);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(LogModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var log = context.Logs
                    .Where(x => x.LogId.CompareTo(model.LogId) == 0)
                    .FirstOrDefault();
                if (log == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.LogId);
                }
                log.EventId = model.EventId;
                log.UserId = model.UserId;
                log.Time = model.Time;
                log.Content = model.Content;

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedUpdate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }
    }
}
