using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IRecipeService
    {
        Tuple<bool, object> Read(RecipeFilter filter, string cultureName);
        Tuple<bool, object> Create(RecipeModel model, string cultureName);
        Tuple<bool, object> Update(RecipeModel model, string cultureName);
        Tuple<bool, object> Delete(Guid recipeId, string cultureName);
    }
}
