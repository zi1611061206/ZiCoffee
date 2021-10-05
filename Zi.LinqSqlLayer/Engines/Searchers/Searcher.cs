using Zi.LinqSqlLayer.Engines.Sorters;

namespace Zi.LinqSqlLayer.Engines.Searchers
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
