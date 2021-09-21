using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class RecipeDetail
    {
        public Guid RecipeId { get; set; }
        public Guid MaterialId { get; set; }
        public float Quantitative { get; set; }

        //FK m-n
        public Recipe Recipe { get; set; }
        public Material Material { get; set; }
    }
}
