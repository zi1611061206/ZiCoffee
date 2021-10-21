using System;
using System.Collections.Generic;
using Zi.Utilities.Enumerators;

namespace Zi.DatabaseEntity.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryStatus Status { get; set; }
        public string ParentId { get; set; }

        //FK 1-n
        public ICollection<Product> Products { get; set; }
    }
}
