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
    public interface IRecipeDetailService
    {
        Task<Paginator<RecipeDetail>> GetRecipeDetails(RecipeDetailFilter filter);
        Task<bool> AddRecipeDetail(RecipeDetail recipeDetail);
        Task<bool> UpdateRecipeDetail(RecipeDetail recipeDetail);
        Task<bool> DeleteRecipeDetail(Guid recipeId, Guid materialId);
    }
}
