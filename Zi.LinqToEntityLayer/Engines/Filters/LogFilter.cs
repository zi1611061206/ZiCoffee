using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class LogFilter : PaginatorConfiguration
    {
        public Guid LogId { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }

        public LogFilter()
        {
            LogId = Guid.Empty;
            UserId = Guid.Empty;
            EventId = Guid.Empty;
            TimeFrom = DateTime.MinValue;
            TimeTo = DateTime.MaxValue;
        }
    }
}
