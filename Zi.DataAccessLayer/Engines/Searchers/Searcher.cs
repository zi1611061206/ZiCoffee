using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataAccessLayer.Engines.Searchers
{
    public class Searcher
    {
        public string Keyword { get; set; }

        public Searcher()
        {
            Keyword = string.Empty;
        }
    }
}
