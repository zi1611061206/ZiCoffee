using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class Material
    {
        public Guid MaterialId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }

        //FK 1-n (m-n)
        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }

        //FK 1-n (m-n)
        public ICollection<RecipeDetail> RecipeDetails { get; set; }
    }
}
