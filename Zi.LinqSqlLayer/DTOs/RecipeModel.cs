using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class RecipeModel
    {
        public Guid RecipeId { get; set; }
        public Guid ProductId { get; set; }
        public string Guide { get; set; }

        public RecipeModel()
        {
        }

        public RecipeModel(Guid productId)
        {
            RecipeId = Guid.NewGuid();
            Guide = string.Empty;
            ProductId = productId;
        }

        /// <summary>
        /// Mapping data to RecipeObj
        /// </summary>
        /// <param name="row"></param>
        public RecipeModel(DataRow row)
        {
            RecipeId = Guid.Parse(row["RecipeId"].ToString());
            ProductId = Guid.Parse(row["ProductId"].ToString());
            Guide = row["Guide"].ToString();
        }
    }
}
