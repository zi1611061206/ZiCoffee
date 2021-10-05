using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class RecipeDTO
    {
        public Guid RecipeId { get; set; }
        public Guid ProductId { get; set; }
        public string Guide { get; set; }

        public RecipeDTO()
        {
        }

        public RecipeDTO(Guid productId)
        {
            RecipeId = Guid.NewGuid();
            Guide = string.Empty;
            ProductId = productId;
        }

        /// <summary>
        /// Mapping data to RecipeObj
        /// </summary>
        /// <param name="row"></param>
        public RecipeDTO(DataRow row)
        {
            RecipeId = Guid.Parse(row["RecipeId"].ToString());
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Guide = row["Guide"].ToString();
        }
    }
}
