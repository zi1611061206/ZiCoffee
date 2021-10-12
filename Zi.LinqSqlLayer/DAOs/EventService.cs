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
    public class EventService : IEventService
    {
        #region Instance
        private static EventService instance;
        public static EventService Instance
        {
            get { if (instance == null) instance = new EventService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private EventService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(EventModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var e = new Event()
                {
                    EventId = model.EventId,
                    Name = model.Name,
                    Description = model.Description
                };
                context.Events.InsertOnSubmit(e);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, e.EventId);
            }
        }

        public Tuple<bool, object> Delete(Guid eventId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var e = context.Events
                    .Where(x => x.EventId.CompareTo(eventId) == 0)
                    .FirstOrDefault();
                if (e == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + eventId);
                }
                context.Events.DeleteOnSubmit(e);

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

        public Tuple<bool, object> Read(EventFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Events.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new EventModel()
                {
                    EventId = x.EventId,
                    Name = x.Name,
                    Description = x.Description
                });
                var result = new Paginator<EventModel>()
                {
                    TotalRecords = data.Count(),
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
        private IQueryable<Event> GettingBy(IQueryable<Event> query, EventFilter filter)
        {
            if (filter.EventId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.EventId.CompareTo(filter.EventId) == 0);
            }
            return query;
        }

        private IQueryable<Event> Searching(IQueryable<Event> query, EventFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.EventId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.EventId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Event> Paging(IQueryable<Event> query, EventFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Event> Sorting(IQueryable<Event> query, EventFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.Name);
            }
            else
            {
                query = query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(EventModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var e = context.Events
                    .Where(x => x.EventId.CompareTo(model.EventId) == 0)
                    .FirstOrDefault();
                if (e == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.EventId);
                }
                e.Name = model.Name;
                e.Description = model.Description;

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
