using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class Recipe
    {
        public Guid RecipeId { get; set; }
        public Guid ProductId { get; set; }
        public string Guide { get; set; }

        //FK n-1
        public Product Product { get; set; }

        //FK 1-n (m-n)
        public ICollection<RecipeDetail> RecipeDetails { get; set; }
    }
}
