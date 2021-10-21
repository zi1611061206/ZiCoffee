using System;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.Engines.Filters
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
