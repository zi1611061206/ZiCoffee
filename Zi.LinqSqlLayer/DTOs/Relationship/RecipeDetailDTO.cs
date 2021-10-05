using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class RecipeDetailDTO
    {
        public Guid RecipeId { get; set; }
        public Guid MaterialId { get; set; }
        public float Quantitative { get; set; }

        public RecipeDetailDTO()
        {
        }

        public RecipeDetailDTO(Guid recipeId, Guid materialId)
        {
            RecipeId = recipeId;
            MaterialId = materialId;
            Quantitative = 1;
        }

        /// <summary>
        /// Mapping data to RecipeDetailObj
        /// </summary>
        public RecipeDetailDTO(DataRow row)
        {
            RecipeId = Guid.Parse(row["RecipeId"].ToString());
            MaterialId = Guid.Parse(row["MaterialId"].ToString());
            Quantitative = (float)row["Quantitative"];
        }
    }
}
