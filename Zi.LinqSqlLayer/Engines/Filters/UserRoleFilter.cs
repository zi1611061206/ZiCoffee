using System;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Engines.Filters
{
    public class UserRoleFilter : PaginatorConfiguration
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public UserRoleFilter()
        {
            UserId = Guid.Empty;
            RoleId = Guid.Empty;
        }
    }
}
