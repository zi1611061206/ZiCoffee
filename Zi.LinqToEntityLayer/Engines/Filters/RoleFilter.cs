using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
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
