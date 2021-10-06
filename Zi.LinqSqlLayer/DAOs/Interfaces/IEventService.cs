using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IEventService
    {
        Tuple<bool, object> Read(EventFilter filter, string cultureName);
        Tuple<bool, object> Create(EventModel model, string cultureName);
        Tuple<bool, object> Update(EventModel model, string cultureName);
        Tuple<bool, object> Delete(Guid eventId, string cultureName);
    }
}
