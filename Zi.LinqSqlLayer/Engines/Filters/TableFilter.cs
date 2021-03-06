using System;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.Engines.Filters
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
