using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Convertors;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class ProductService : IProductService
    {
        public bool AddProduct(ProductDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var product = new Product()
                {
                    ProductId = obj.ProductId,
                    Name = obj.Name,
                    Description = obj.Description,
                    Status = (int)obj.Status,
                    Thumnail = obj.Thumnail,
                    Price = obj.Price,
                    PromotionVulue = obj.PromotionVulue,
                    CategoryId = obj.CategoryId
                };
                context.Products.InsertOnSubmit(product);
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

        public bool DeleteProduct(Guid productId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var product = context.Products.Where(x => x.ProductId.CompareTo(productId) == 0).FirstOrDefault();
                context.Products.DeleteOnSubmit(product);
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

        public Paginator<ProductDTO> GetProducts(ProductFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Products;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Use to mapping data
                var data = query.Select(x => new ProductDTO()
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Description = x.Description,
                    Status = (ProductStatus)x.Status,
                    Thumnail = x.Thumnail.ToArray(),
                    Price = x.Price,
                    PromotionVulue = x.PromotionVulue,
                    CategoryId = x.CategoryId
                });
                var result = new Paginator<ProductDTO>()
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
        private Table<Product> GettingBy(Table<Product> query, ProductFilter filter)
        {
            if (filter.ProductId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.ProductId.CompareTo(filter.ProductId) == 0);
            }
            return query;
        }

        private Table<Product> Filtering(Table<Product> query, ProductFilter filter)
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

        private Table<Product> Searching(Table<Product> query, ProductFilter filter)
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

        private Table<Product> Paging(Table<Product> query, ProductFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Product> Sorting(Table<Product> query, ProductFilter filter)
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

        public bool UpdateProduct(ProductDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var product = context.Products.Where(x => x.ProductId.CompareTo(obj.ProductId) == 0).FirstOrDefault();
                product.Name = obj.Name;
                product.Description = obj.Description;
                product.Status = (int)obj.Status;
                product.Thumnail = obj.Thumnail;
                product.Price = obj.Price;
                product.PromotionVulue = obj.PromotionVulue;
                product.CategoryId = obj.CategoryId;
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
