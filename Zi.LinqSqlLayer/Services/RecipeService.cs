using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class RecipeService : IRecipeService
    {
        public bool AddRecipe(RecipeDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var recipe = new Recipe()
                {
                    RecipeId = obj.RecipeId,
                    ProductId = obj.ProductId,
                    Guide = obj.Guide
                };
                context.Recipes.InsertOnSubmit(recipe);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool DeleteRecipe(Guid recipeId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var recipe = context.Recipes.Where(x => x.RecipeId.CompareTo(recipeId) == 0).FirstOrDefault();
                context.Recipes.DeleteOnSubmit(recipe);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<RecipeDTO> GetRecipes(RecipeFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Recipes;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new RecipeDTO()
                {
                    RecipeId = x.RecipeId,
                    ProductId = x.ProductId,
                    Guide = x.Guide
                });
                var result = new Paginator<RecipeDTO>()
                {
                    TotalRecords = data.Count(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                return result;
            }
        }

        #region Engines
        private Table<Recipe> GettingBy(Table<Recipe> query, RecipeFilter filter)
        {
            if (filter.RecipeId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.RecipeId.CompareTo(filter.RecipeId) == 0);
            }
            return query;
        }

        private Table<Recipe> Filtering(Table<Recipe> query, RecipeFilter filter)
        {
            if (filter.ProductId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.ProductId.CompareTo(filter.ProductId) == 0);
            }
            return query;
        }

        private Table<Recipe> Searching(Table<Recipe> query, RecipeFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.RecipeId.ToString().Contains(filter.Keyword) ||
                        x.ProductId.ToString().Contains(filter.Keyword) ||
                        x.Guide.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.RecipeId.ToString().Equals(filter.Keyword) ||
                        x.ProductId.ToString().Equals(filter.Keyword) ||
                        x.Guide.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Recipe> Paging(Table<Recipe> query, RecipeFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Recipe> Sorting(Table<Recipe> query, RecipeFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.ProductId);
            }
            else
            {
                query.OrderByDescending(x => x.ProductId);
            }
            return query;
        }
        #endregion

        public bool UpdateRecipe(RecipeDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var recipe = context.Recipes.Where(x => x.RecipeId.CompareTo(obj.RecipeId) == 0).FirstOrDefault();
                recipe.ProductId = obj.ProductId;
                recipe.Guide = obj.Guide;
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
    }
}
