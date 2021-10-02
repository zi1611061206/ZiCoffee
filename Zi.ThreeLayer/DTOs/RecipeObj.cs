using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.ThreeLayer.DTOs
{
    public class RecipeObj : Recipe
    {
        public RecipeObj(Guid productId)
        {
            RecipeId = Guid.NewGuid();
            Guide = string.Empty;
            ProductId = productId;
        }

        /// <summary>
        /// Mapping data to RecipeObj
        /// </summary>
        /// <param name="row"></param>
        public RecipeObj(DataRow row)
        {
            RecipeId = Guid.Parse(row["RecipeId"].ToString());
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Guide = row["Guide"].ToString();
        }
    }
}
