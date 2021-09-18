using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.DatabaseEntity.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; }
        public byte[] Thumnail { get; set; }
        public float Price { get; set; }
        public float PromotionVulue { get; set; }
        public Guid CategoryId { get; set; }

        //FK n-1
        public Category Category { get; set; }

        //FK 1-n
        public ICollection<Recipe> Recipes { get; set; }

        //FK 1-n (m-n)
        public ICollection<BillDetail> BillDetails { get; set; }
    }
}
