using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class EventFilter : PaginatorConfiguration
    {
        public Guid EventId { get; set; }

        public EventFilter()
        {
            EventId = Guid.Empty;
        }
    }
}
