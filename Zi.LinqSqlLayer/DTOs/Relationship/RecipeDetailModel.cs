using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class RecipeDetailModel
    {
        public Guid RecipeId { get; set; }
        public Guid MaterialId { get; set; }
        public float Quantitative { get; set; }

        public RecipeDetailModel()
        {
        }

        public RecipeDetailModel(Guid recipeId, Guid materialId)
        {
            RecipeId = recipeId;
            MaterialId = materialId;
            Quantitative = 1;
        }

        /// <summary>
        /// Mapping data to RecipeDetailObj
        /// </summary>
        public RecipeDetailModel(DataRow row)
        {
            RecipeId = Guid.Parse(row["RecipeId"].ToString());
            MaterialId = Guid.Parse(row["MaterialId"].ToString());
            Quantitative = (float)row["Quantitative"];
        }
    }
}
