using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Searchers;

namespace Zi.LinqToEntityLayer.Engines.Paginators
{
    public class Paginator<T> : PaginatorConfiguration
    {
        public List<T> Item { get; set; }
    }
}
