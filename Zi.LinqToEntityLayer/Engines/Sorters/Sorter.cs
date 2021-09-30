using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.LinqToEntityLayer.Engines.Sorters
{
    public class Sorter
    {
        public bool IsAscending { get; set; }

        public Sorter()
        {
            IsAscending = true;
        }
    }
}
