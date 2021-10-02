using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
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
