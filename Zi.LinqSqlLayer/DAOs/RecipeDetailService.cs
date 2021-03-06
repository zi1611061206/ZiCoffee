using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class RecipeDetailService : IRecipeDetailService
    {
        #region Instance
        private static RecipeDetailService instance;
        public static RecipeDetailService Instance
        {
            get { if (instance == null) instance = new RecipeDetailService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private RecipeDetailService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(RecipeDetailModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var recipeDetail = new RecipeDetail()
                {
                    RecipeId = model.RecipeId,
                    MaterialId = model.MaterialId,
                    Quantitative = model.Quantitative
                };
                context.RecipeDetails.InsertOnSubmit(recipeDetail);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> Delete(Guid recipeId, Guid materialId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var recipeDetail = context.RecipeDetails
                    .Where(x => x.RecipeId.CompareTo(recipeId) == 0 && x.MaterialId.CompareTo(materialId) == 0)
                    .FirstOrDefault();
                if (recipeDetail == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                context.RecipeDetails.DeleteOnSubmit(recipeDetail);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedDelete", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> Read(RecipeDetailFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.RecipeDetails.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new RecipeDetailModel()
                {
                    RecipeId = x.RecipeId,
                    MaterialId = x.MaterialId,
                    Quantitative = x.Quantitative
                });
                var result = new Paginator<RecipeDetailModel>()
                {
                    TotalRecords = totalRecords,
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                if (data.Count() <= 0)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                return new Tuple<bool, object>(true, result);
            }
        }

        #region Engines
        private IQueryable<RecipeDetail> GettingBy(IQueryable<RecipeDetail> query, RecipeDetailFilter filter)
        {
            if (filter.RecipeId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.RecipeId.CompareTo(filter.RecipeId) == 0);
            }
            if (filter.MaterialId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.MaterialId.CompareTo(filter.MaterialId) == 0);
            }
            return query;
        }

        private IQueryable<RecipeDetail> Filtering(IQueryable<RecipeDetail> query, RecipeDetailFilter filter)
        {
            query = query.Where(x => x.Quantitative >= filter.QuantitativeMin);
            if (filter.QuantitativeMax > filter.QuantitativeMin)
            {
                query = query.Where(x => x.Quantitative <= filter.QuantitativeMax);
            }
            return query;
        }

        private IQueryable<RecipeDetail> Searching(IQueryable<RecipeDetail> query, RecipeDetailFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.RecipeId.ToString().Contains(filter.Keyword) ||
                        x.MaterialId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.RecipeId.ToString().Equals(filter.Keyword) ||
                        x.MaterialId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<RecipeDetail> Paging(IQueryable<RecipeDetail> query, RecipeDetailFilter filter)
        {
            if (filter.PageSize != 0)
            {
                int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
                query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            }
            return query;
        }

        private IQueryable<RecipeDetail> Sorting(IQueryable<RecipeDetail> query, RecipeDetailFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.RecipeId);
            }
            else
            {
                query = query.OrderByDescending(x => x.RecipeId);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(RecipeDetailModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var recipeDetail = context.RecipeDetails
                    .Where(x => x.RecipeId.CompareTo(model.RecipeId) == 0 && x.MaterialId.CompareTo(model.MaterialId) == 0)
                    .FirstOrDefault();
                if (recipeDetail == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                recipeDetail.Quantitative = model.Quantitative;

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedUpdate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }
    }
}
