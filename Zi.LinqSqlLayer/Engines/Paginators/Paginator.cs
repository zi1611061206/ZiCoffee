using System.Collections.Generic;

namespace Zi.LinqSqlLayer.Engines.Paginators
{
    public class Paginator<T> : PaginatorConfiguration
    {
        public List<T> Item { get; set; }
    }
}
