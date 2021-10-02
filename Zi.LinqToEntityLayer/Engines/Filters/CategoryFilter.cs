using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Enumerators;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Engines.Filters
{
    public class CategoryFilter : PaginatorConfiguration
    {
        public Guid CategoryId { get; set; }
        public CategoryStatus? Status { get; set; }
        public string ParentId { get; set; }

        public CategoryFilter()
        {
            CategoryId = Guid.Empty;
            Status = null;
            ParentId = string.Empty;
        }
    }
}
