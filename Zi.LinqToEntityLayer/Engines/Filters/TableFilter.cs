using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Enumerators;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class TableFilter : PaginatorConfiguration
    {
        public Guid TableId { get; set; }
        public TableStatus? Status { get; set; }
        public Guid AreaId { get; set; }

        public TableFilter()
        {
            TableId = Guid.Empty;
            Status = null;
            AreaId = Guid.Empty;
        }
    }
}
