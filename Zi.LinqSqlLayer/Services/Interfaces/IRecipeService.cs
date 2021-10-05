using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IRecipeService
    {
        Paginator<RecipeDTO> GetRecipes(RecipeFilter filter);
        bool AddRecipe(RecipeDTO obj);
        bool UpdateRecipe(RecipeDTO obj);
        bool DeleteRecipe(Guid recipeId);
    }
}
