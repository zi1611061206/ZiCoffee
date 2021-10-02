using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
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
