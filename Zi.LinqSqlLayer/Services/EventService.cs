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
    public class EventService : IEventService
    {
        public bool AddEvent(EventDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var e = new Event()
                {
                    EventId = obj.EventId,
                    Name = obj.Name,
                    Description = obj.Description
                };
                context.Events.InsertOnSubmit(e);
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

        public bool DeleteEvent(Guid eventId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var e = context.Events.Where(x => x.EventId.CompareTo(eventId) == 0).FirstOrDefault();
                context.Events.DeleteOnSubmit(e);
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

        public Paginator<EventDTO> GetEvents(EventFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Events;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new EventDTO()
                {
                    EventId = x.EventId,
                    Name = x.Name,
                    Description = x.Description
                });
                var result = new Paginator<EventDTO>()
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
        private Table<Event> GettingBy(Table<Event> query, EventFilter filter)
        {
            if (filter.EventId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.EventId.CompareTo(filter.EventId) == 0);
            }
            return query;
        }

        private Table<Event> Searching(Table<Event> query, EventFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.EventId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.EventId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Event> Paging(Table<Event> query, EventFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Event> Sorting(Table<Event> query, EventFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.Name);
            }
            else
            {
                query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public bool UpdateEvent(EventDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var e = context.Events.Where(x => x.EventId.CompareTo(obj.EventId) == 0).FirstOrDefault();
                e.Name = obj.Name;
                e.Description = obj.Description;
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
