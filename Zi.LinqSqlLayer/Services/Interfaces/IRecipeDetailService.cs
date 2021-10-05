using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IRecipeDetailService
    {
        Paginator<RecipeDetailDTO> GetRecipeDetails(RecipeDetailFilter filter);
        bool AddRecipeDetail(RecipeDetailDTO obj);
        bool UpdateRecipeDetail(RecipeDetailDTO obj);
        bool DeleteRecipeDetail(Guid recipeId, Guid materialId);
    }
}
