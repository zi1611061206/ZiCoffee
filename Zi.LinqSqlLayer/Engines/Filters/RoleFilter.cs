using System;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class RoleFilter : PaginatorConfiguration
    {
        public Guid RoleId { get; set; }
        public AccessLevels? AccessLevel { get; set; }

        public RoleFilter()
        {
            RoleId = Guid.Empty;
            AccessLevel = null;
        }
    }
}
