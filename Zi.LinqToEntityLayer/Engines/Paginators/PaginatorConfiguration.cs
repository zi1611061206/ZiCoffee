using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.LinqToEntityLayer.Engines.Searchers;

namespace Zi.LinqToEntityLayer.Engines.Paginators
{
    public class PaginatorConfiguration : Searcher
    {
        public int PageSize { get; set; }
        public int CurrentPageIndex { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalRecords / PageSize);
            }
        }
        public int TotalRecordsLastPage
        {
            get
            {
                return TotalRecords - PageSize * (TotalPages - 1);
            }
        }

        public PaginatorConfiguration(int pageSize = 25, int currentPageIndex = 1)
        {
            PageSize = pageSize;
            CurrentPageIndex = currentPageIndex;
        }
    }
}
