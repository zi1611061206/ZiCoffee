using System;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class RecipeService : IRecipeService
    {
        #region Instance
        private static RecipeService instance;
        public static RecipeService Instance
        {
            get { if (instance == null) instance = new RecipeService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private RecipeService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(RecipeModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var recipe = new Recipe()
                {
                    RecipeId = model.RecipeId,
                    ProductId = model.ProductId,
                    Guide = model.Guide
                };
                context.Recipes.InsertOnSubmit(recipe);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, recipe.RecipeId);
            }
        }

        public Tuple<bool, object> Delete(Guid recipeId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var recipe = context.Recipes
                    .Where(x => x.RecipeId.CompareTo(recipeId) == 0)
                    .FirstOrDefault();
                if (recipe == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + recipeId);
                }
                context.Recipes.DeleteOnSubmit(recipe);

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

        public Tuple<bool, object> Read(RecipeFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Recipes;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new RecipeModel()
                {
                    RecipeId = x.RecipeId,
                    ProductId = x.ProductId,
                    Guide = x.Guide
                });
                var result = new Paginator<RecipeModel>()
                {
                    TotalRecords = data.Count(),
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

        public Tuple<bool, object> Update(RecipeModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var recipe = context.Recipes
                    .Where(x => x.RecipeId.CompareTo(model.RecipeId) == 0)
                    .FirstOrDefault();
                if (recipe == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.RecipeId);
                }
                recipe.ProductId = model.ProductId;
                recipe.Guide = model.Guide;

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
