using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.RelationshipDTOs
{
    public class RecipeDetailObj : RecipeDetail
    {
        public RecipeDetailObj(Guid recipeId, Guid materialId)
        {
            RecipeId = recipeId;
            MaterialId = materialId;
            Quantitative = 1;
        }

        /// <summary>
        /// Mapping data to RecipeDetailObj
        /// </summary>
        public RecipeDetailObj(DataRow row)
        {
            RecipeId = Guid.Parse(row["RecipeId"].ToString());
            MaterialId = Guid.Parse(row["MaterialId"].ToString());
            Quantitative = (float)row["Quantitative"];
        }
    }
}
