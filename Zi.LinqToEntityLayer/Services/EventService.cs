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
    public class EventService : IEventService
    {
        public async Task<bool> AddEvent(Event e)
        {
            using (var context = new ZiDbContext())
            {
                context.Events.Add(e);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteEvent(Guid eventId)
        {
            using (var context = new ZiDbContext())
            {
                var e = await context.Events.FindAsync(eventId);
                context.Events.Remove(e);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Event>> GetEvents(EventFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Events;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new Event()
                {
                    EventId = x.EventId,
                    Name = x.Name,
                    Description = x.Description
                });
                var result = new Paginator<Event>()
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
        private DbSet<Event> GettingBy(DbSet<Event> query, EventFilter filter)
        {
            if (filter.EventId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.EventId.CompareTo(filter.EventId) == 0);
            }
            return query;
        }

        private DbSet<Event> Searching(DbSet<Event> query, EventFilter filter)
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

        private DbSet<Event> Paging(DbSet<Event> query, EventFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Event> Sorting(DbSet<Event> query, EventFilter filter)
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

        public async Task<bool> UpdateEvent(Event e)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Events.FindAsync(e.EventId);
                data.Name = e.Name;
                data.Description = e.Description;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
