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
    public class ProductService : IProductService
    {
        public async Task<bool> AddProduct(Product product)
        {
            using (var context = new ZiDbContext())
            {
                context.Products.Add(product);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            using (var context = new ZiDbContext())
            {
                var product = await context.Products.FindAsync(productId);
                context.Products.Remove(product);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Product>> GetProducts(ProductFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Products;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Use to mapping data
                var data = query.Select(x => new Product()
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status,
                    Thumnail = x.Thumnail,
                    Price = x.Price,
                    PromotionVulue = x.PromotionVulue,
                    CategoryId = x.CategoryId
                });
                var result = new Paginator<Product>()
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
        private DbSet<Product> GettingBy(DbSet<Product> query, ProductFilter filter)
        {
            if (filter.ProductId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.ProductId.CompareTo(filter.ProductId) == 0);
            }
            return query;
        }

        private DbSet<Product> Filtering(DbSet<Product> query, ProductFilter filter)
        {
            if (filter.Status.HasValue)
            {
                query.Where(x => x.Status.CompareTo(filter.Status) == 0);
            }
            query.Where(x => x.Price >= filter.PriceMin);
            if (filter.PriceMax > filter.PriceMin)
            {
                query.Where(x => x.Price <= filter.PriceMax);
            }
            query.Where(x => x.PromotionVulue >= filter.PromotionVulueMin);
            if (filter.PromotionVulueMax > filter.PriceMin)
            {
                query.Where(x => x.PromotionVulue <= filter.PromotionVulueMax);
            }
            if (filter.CategoryId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.CategoryId.CompareTo(filter.CategoryId) == 0);
            }
            return query;
        }

        private DbSet<Product> Searching(DbSet<Product> query, ProductFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.ProductId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword) ||
                        x.CategoryId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.ProductId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword) ||
                        x.CategoryId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<Product> Paging(DbSet<Product> query, ProductFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Product> Sorting(DbSet<Product> query, ProductFilter filter)
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

        public async Task<bool> UpdateProduct(Product product)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Products.FindAsync(product.ProductId);
                data.Name = product.Name;
                data.Description = product.Description;
                data.Status = product.Status;
                data.Thumnail = product.Thumnail;
                data.Price = product.Price;
                data.PromotionVulue = product.PromotionVulue;
                data.CategoryId = product.CategoryId;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
