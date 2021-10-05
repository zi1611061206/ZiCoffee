using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class RoleFilter : PaginatorConfiguration
    {
        public Guid RoleId { get; set; }

        public RoleFilter()
        {
            RoleId = Guid.Empty;
        }
    }
}
