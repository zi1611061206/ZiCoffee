using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class AreaFilter : PaginatorConfiguration
    {
        public Guid AreaId { get; set; }
        public string ParentId { get; set; }

        public AreaFilter()
        {
            AreaId = Guid.Empty;
            ParentId = string.Empty;
        }
    }
}
