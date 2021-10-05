using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class RecipeDetailService : IRecipeDetailService
    {
        public bool AddRecipeDetail(RecipeDetailDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var recipeDetail = new RecipeDetail()
                {
                    RecipeId = obj.RecipeId,
                    MaterialId = obj.MaterialId,
                    Quantitative = obj.Quantitative
                };
                context.RecipeDetails.InsertOnSubmit(recipeDetail);
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

        public bool DeleteRecipeDetail(Guid recipeId, Guid materialId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var recipeDetail = context.RecipeDetails
                    .Where(x => x.RecipeId.CompareTo(recipeId) == 0 && x.MaterialId.CompareTo(materialId) == 0)
                    .FirstOrDefault();
                context.RecipeDetails.DeleteOnSubmit(recipeDetail);
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

        public Paginator<RecipeDetailDTO> GetRecipeDetails(RecipeDetailFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.RecipeDetails;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new RecipeDetailDTO()
                {
                    RecipeId = x.RecipeId,
                    MaterialId = x.MaterialId,
                    Quantitative = x.Quantitative
                });
                var result = new Paginator<RecipeDetailDTO>()
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
        private Table<RecipeDetail> GettingBy(Table<RecipeDetail> query, RecipeDetailFilter filter)
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

        private Table<RecipeDetail> Filtering(Table<RecipeDetail> query, RecipeDetailFilter filter)
        {
            query.Where(x => x.Quantitative >= filter.QuantitativeMin);
            if (filter.QuantitativeMax > filter.QuantitativeMin)
            {
                query.Where(x => x.Quantitative <= filter.QuantitativeMax);
            }
            return query;
        }

        private Table<RecipeDetail> Searching(Table<RecipeDetail> query, RecipeDetailFilter filter)
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

        private Table<RecipeDetail> Paging(Table<RecipeDetail> query, RecipeDetailFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<RecipeDetail> Sorting(Table<RecipeDetail> query, RecipeDetailFilter filter)
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

        public bool UpdateRecipeDetail(RecipeDetailDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var recipeDetail = context.RecipeDetails
                    .Where(x => x.RecipeId.CompareTo(obj.RecipeId) == 0 && x.MaterialId.CompareTo(obj.MaterialId) == 0)
                    .FirstOrDefault();
                recipeDetail.Quantitative = obj.Quantitative;
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
