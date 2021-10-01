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
    public interface IEventService
    {
        Paginator<Event> GetEvents(EventFilter filter);
        Task<bool> AddEvent(Event e);
        Task<bool> UpdateEvent(Event e);
        Task<bool> DeleteEvent(Guid eventId);
    }
}
