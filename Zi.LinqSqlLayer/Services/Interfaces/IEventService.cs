using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IEventService
    {
        Paginator<EventDTO> GetEvents(EventFilter filter);
        bool AddEvent(EventDTO obj);
        bool UpdateEvent(EventDTO obj);
        bool DeleteEvent(Guid eventId);
    }
}
