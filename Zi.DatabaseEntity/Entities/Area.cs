using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class Area
    {
        public Guid AreaId { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        //FK 1-n
        public ICollection<Table> Tables { get; set; }
    }
}
