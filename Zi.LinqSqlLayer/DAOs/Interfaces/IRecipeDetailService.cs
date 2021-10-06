using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IRecipeDetailService
    {
        Tuple<bool, object> Read(RecipeDetailFilter filter, string cultureName);
        Tuple<bool, object> Create(RecipeDetailModel model, string cultureName);
        Tuple<bool, object> Update(RecipeDetailModel model, string cultureName);
        Tuple<bool, object> Delete(Guid recipeId, Guid materialId, string cultureName);
    }
}
