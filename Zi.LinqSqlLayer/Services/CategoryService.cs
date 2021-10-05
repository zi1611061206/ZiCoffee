using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class CategoryService : ICategoryService
    {
        public bool AddCategory(CategoryDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var category = new Category()
                {
                    CategoryId = obj.CategoryId,
                    Description = obj.Description,
                    Status = (int)obj.Status,
                    ParentId = obj.ParentId,
                    Name = obj.Name
                };
                context.Categories.InsertOnSubmit(category);
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

        public bool DeleteCategory(Guid categoryId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var category = context.Categories.Where(x => x.CategoryId.CompareTo(categoryId) == 0).FirstOrDefault();
                context.Categories.DeleteOnSubmit(category);
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

        public Paginator<CategoryDTO> GetCategories(CategoryFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Categories;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new CategoryDTO()
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Description = x.Description,
                    Status = (CategoryStatus)x.Status,
                    ParentId = x.ParentId
                });
                var result = new Paginator<CategoryDTO>()
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
        private Table<Category> GettingBy(Table<Category> query, CategoryFilter filter)
        {
            if (filter.CategoryId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.CategoryId.CompareTo(filter.CategoryId) == 0);
            }
            return query;
        }

        private Table<Category> Filtering(Table<Category> query, CategoryFilter filter)
        {
            if (filter.Status.HasValue)
            {
                query.Where(x => x.Status.CompareTo(filter.Status) == 0);
            }
            if (!string.IsNullOrEmpty(filter.ParentId))
            {
                query.Where(x => x.ParentId.Equals(filter.ParentId));
            }
            return query;
        }

        private Table<Category> Searching(Table<Category> query, CategoryFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.CategoryId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword) ||
                        x.ParentId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.CategoryId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword) ||
                        x.ParentId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Category> Paging(Table<Category> query, CategoryFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Category> Sorting(Table<Category> query, CategoryFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.Name);
            }
            else
            {
                query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public bool UpdateCategory(CategoryDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var category = context.Categories.Where(x => x.CategoryId.CompareTo(obj.CategoryId) == 0).FirstOrDefault();
                category.Name = obj.Name;
                category.Description = obj.Description;
                category.Status = (int)obj.Status;
                category.ParentId = obj.ParentId;
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
