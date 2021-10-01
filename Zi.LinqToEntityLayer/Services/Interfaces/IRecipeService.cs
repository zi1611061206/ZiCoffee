using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Services.Interfaces
{
    public interface IRecipeService
    {
        Paginator<Recipe> GetRecipes(RecipeFilter filter);
        Task<bool> AddRecipe(Recipe recipe);
        Task<bool> UpdateRecipe(Recipe recipe);
        Task<bool> DeleteRecipe(Guid recipeId);
    }
}
