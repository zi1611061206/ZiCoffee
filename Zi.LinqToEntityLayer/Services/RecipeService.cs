using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;
using Zi.LinqToEntityLayer.Services.Interfaces;

namespace Zi.LinqToEntityLayer.Services
{
    public class RecipeService : IRecipeService
    {
        public async Task<bool> AddRecipe(Recipe recipe)
        {
            using (var context = new ZiDbContext())
            {
                context.Recipes.Add(recipe);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteRecipe(Guid recipeId)
        {
            using (var context = new ZiDbContext())
            {
                var recipe = await context.Recipes.FindAsync(recipeId);
                context.Recipes.Remove(recipe);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Recipe>> GetRecipes(RecipeFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Recipes;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new Recipe()
                {
                    RecipeId = x.RecipeId,
                    ProductId = x.ProductId,
                    Guide = x.Guide
                });
                var result = new Paginator<Recipe>()
                {
                    TotalRecords = await data.CountAsync(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = await data.ToListAsync()
                };
                return result;
            }
        }

        #region Engines
        private DbSet<Recipe> GettingBy(DbSet<Recipe> query, RecipeFilter filter)
        {
            if (filter.RecipeId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.RecipeId.CompareTo(filter.RecipeId) == 0);
            }
            return query;
        }

        private DbSet<Recipe> Filtering(DbSet<Recipe> query, RecipeFilter filter)
        {
            if (filter.ProductId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.ProductId.CompareTo(filter.ProductId) == 0);
            }
            return query;
        }

        private DbSet<Recipe> Searching(DbSet<Recipe> query, RecipeFilter filter)
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

        private DbSet<Recipe> Paging(DbSet<Recipe> query, RecipeFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Recipe> Sorting(DbSet<Recipe> query, RecipeFilter filter)
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

        public async Task<bool> UpdateRecipe(Recipe recipe)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Recipes.FindAsync(recipe.RecipeId);
                data.ProductId = recipe.ProductId;
                data.Guide = recipe.Guide;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
