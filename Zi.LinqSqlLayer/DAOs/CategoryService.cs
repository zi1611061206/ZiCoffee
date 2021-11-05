using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.DAOs
{
    public class CategoryService : ICategoryService
    {
        #region Instance
        private static CategoryService instance;
        public static CategoryService Instance
        {
            get { if (instance == null) instance = new CategoryService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private CategoryService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(CategoryModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var category = new Category()
                {
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    Status = (int)model.Status,
                    ParentId = model.ParentId,
                    Name = model.Name
                };
                context.Categories.InsertOnSubmit(category);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, category.CategoryId);
            }
        }

        public Tuple<bool, object> Delete(Guid categoryId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var category = context.Categories
                    .Where(x => x.CategoryId.CompareTo(categoryId) == 0)
                    .FirstOrDefault();
                if (category == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + categoryId);
                }
                context.Categories.DeleteOnSubmit(category);

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

        public Tuple<bool, object> Read(CategoryFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Categories.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new CategoryModel()
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Description = x.Description,
                    Status = (CategoryStatus)x.Status,
                    ParentId = x.ParentId
                });
                var result = new Paginator<CategoryModel>()
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
        private IQueryable<Category> GettingBy(IQueryable<Category> query, CategoryFilter filter)
        {
            if (filter.CategoryId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.CategoryId.CompareTo(filter.CategoryId) == 0);
            }
            return query;
        }

        private IQueryable<Category> Filtering(IQueryable<Category> query, CategoryFilter filter)
        {
            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.Status.CompareTo(filter.Status) == 0);
            }
            if (!string.IsNullOrEmpty(filter.ParentId))
            {
                query = query.Where(x => x.ParentId.ToLower().Equals(filter.ParentId.ToLower()));
            }
            return query;
        }

        private IQueryable<Category> Searching(IQueryable<Category> query, CategoryFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.CategoryId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword) ||
                        x.ParentId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.CategoryId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword) ||
                        x.ParentId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Category> Paging(IQueryable<Category> query, CategoryFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Category> Sorting(IQueryable<Category> query, CategoryFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.Name);
            }
            else
            {
                query = query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(CategoryModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var category = context.Categories
                    .Where(x => x.CategoryId.CompareTo(model.CategoryId) == 0)
                    .FirstOrDefault();
                if (category == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.CategoryId);
                }
                category.Name = model.Name;
                category.Description = model.Description;
                category.Status = (int)model.Status;
                category.ParentId = model.ParentId;

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
