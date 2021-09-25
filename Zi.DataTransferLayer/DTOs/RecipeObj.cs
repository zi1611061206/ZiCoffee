using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs
{
    public class RecipeObj : Recipe
    {
        public RecipeObj()
        {
            RecipeId = Guid.NewGuid();
        }

        public RecipeObj(DataRow row)
        {
            RecipeId = Guid.Parse(row["RecipeId"].ToString());
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Guide = row["Guide"].ToString();
        }
    }
}
