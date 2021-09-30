using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
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
