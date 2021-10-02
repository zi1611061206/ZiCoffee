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
    public class RecipeDetailService : IRecipeDetailService
    {
        public async Task<bool> AddRecipeDetail(RecipeDetail recipeDetail)
        {
            using (var context = new ZiDbContext())
            {
                context.RecipeDetails.Add(recipeDetail);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteRecipeDetail(Guid recipeId, Guid materialId)
        {
            using (var context = new ZiDbContext())
            {
                var recipeDetail = (from detail in context.RecipeDetails
                                    where detail.RecipeId.CompareTo(recipeId) == 0 && detail.MaterialId.CompareTo(materialId) == 0
                                    select detail).First();
                context.RecipeDetails.Remove(recipeDetail);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<RecipeDetail>> GetRecipeDetails(RecipeDetailFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.RecipeDetails;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new RecipeDetail()
                {
                    RecipeId = x.RecipeId,
                    MaterialId = x.MaterialId,
                    Quantitative = x.Quantitative
                });
                var result = new Paginator<RecipeDetail>()
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
        private DbSet<RecipeDetail> GettingBy(DbSet<RecipeDetail> query, RecipeDetailFilter filter)
        {
            if (filter.RecipeId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.RecipeId.CompareTo(filter.RecipeId) == 0);
            }
            if (filter.MaterialId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.MaterialId.CompareTo(filter.MaterialId) == 0);
            }
            return query;
        }

        private DbSet<RecipeDetail> Filtering(DbSet<RecipeDetail> query, RecipeDetailFilter filter)
        {
            query.Where(x => x.Quantitative >= filter.QuantitativeMin);
            if (filter.QuantitativeMax > filter.QuantitativeMin)
            {
                query.Where(x => x.Quantitative <= filter.QuantitativeMax);
            }
            return query;
        }

        private DbSet<RecipeDetail> Searching(DbSet<RecipeDetail> query, RecipeDetailFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.RecipeId.ToString().Contains(filter.Keyword) ||
                        x.MaterialId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.RecipeId.ToString().Equals(filter.Keyword) ||
                        x.MaterialId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<RecipeDetail> Paging(DbSet<RecipeDetail> query, RecipeDetailFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<RecipeDetail> Sorting(DbSet<RecipeDetail> query, RecipeDetailFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.RecipeId);
            }
            else
            {
                query.OrderByDescending(x => x.RecipeId);
            }
            return query;
        }
        #endregion

        public async Task<bool> UpdateRecipeDetail(RecipeDetail recipeDetail)
        {
            using (var context = new ZiDbContext())
            {
                var data = (from detail in context.RecipeDetails
                            where detail.RecipeId.CompareTo(recipeDetail.RecipeId) == 0 && detail.MaterialId.CompareTo(recipeDetail.MaterialId) == 0
                            select detail).First();
                data.Quantitative = recipeDetail.Quantitative;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
