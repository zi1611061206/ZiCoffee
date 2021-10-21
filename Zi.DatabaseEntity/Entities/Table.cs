using System;
using System.Collections.Generic;
using Zi.Utilities.Enumerators;

namespace Zi.DatabaseEntity.Entities
{
    public class Table
    {
        public Guid TableId { get; set; }
        public string Name { get; set; }
        public TableStatus Status { get; set; }
        public Guid AreaId { get; set; }

        //FK n-1
        public Area Area { get; set; }

        //FK 1-n
        public ICollection<Bill> Bills { get; set; }
    }
}
