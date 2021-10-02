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
    public class CategoryService : ICategoryService
    {
        public async Task<bool> AddCategory(Category category)
        {
            using (var context = new ZiDbContext())
            {
                context.Categories.Add(category);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            using (var context = new ZiDbContext())
            {
                var category = await context.Categories.FindAsync(categoryId);
                context.Categories.Remove(category);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Category>> GetCategories(CategoryFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Categories;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new Category()
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status,
                    ParentId = x.ParentId
                });
                var result = new Paginator<Category>()
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
        private DbSet<Category> GettingBy(DbSet<Category> query, CategoryFilter filter)
        {
            if (filter.CategoryId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.CategoryId.CompareTo(filter.CategoryId) == 0);
            }
            return query;
        }

        private DbSet<Category> Filtering(DbSet<Category> query, CategoryFilter filter)
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

        private DbSet<Category> Searching(DbSet<Category> query, CategoryFilter filter)
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

        private DbSet<Category> Paging(DbSet<Category> query, CategoryFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Category> Sorting(DbSet<Category> query, CategoryFilter filter)
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

        public async Task<bool> UpdateCategory(Category category)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Categories.FindAsync(category.CategoryId);
                data.Name = category.Name;
                data.Description = category.Description;
                data.Status = category.Status;
                data.ParentId = category.ParentId;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
