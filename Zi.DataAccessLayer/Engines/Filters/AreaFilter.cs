using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Engines.Paginators;

namespace Zi.DataAccessLayer.Engines.Filters
{
    public class AreaFilter : Paginator
    {
        public Guid AreaId { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }

        public AreaFilter()
        {
            AreaId = Guid.NewGuid();
            Name = string.Empty;
            ParentId = string.Empty;
        }
    }
}
