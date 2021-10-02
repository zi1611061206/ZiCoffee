using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Sorters;

namespace Zi.LinqToEntityLayer.Engines.Searchers
{
    public class Searcher : Sorter
    {
        public string Keyword { get; set; }

        public bool IsRoughly { get; set; }

        public Searcher()
        {
            Keyword = string.Empty;
            IsRoughly = true;
        }
    }
}
