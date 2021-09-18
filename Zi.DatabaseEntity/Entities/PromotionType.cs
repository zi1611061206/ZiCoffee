using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class PromotionType
    {
        public Guid PromotionTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //FK 1-n
        public ICollection<Promotion> Promotions { get; set; }
    }
}
