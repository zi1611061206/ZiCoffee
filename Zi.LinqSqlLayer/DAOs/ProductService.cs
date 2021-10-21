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
    public class ProductService : IProductService
    {
        #region Instance
        private static ProductService instance;
        public static ProductService Instance
        {
            get { if (instance == null) instance = new ProductService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private ProductService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(ProductModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var product = new Product()
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    Description = model.Description,
                    Status = (int)model.Status,
                    Thumnail = model.Thumnail,
                    Price = model.Price,
                    PromotionVulue = model.PromotionVulue,
                    CategoryId = model.CategoryId
                };
                context.Products.InsertOnSubmit(product);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, product.ProductId);
            }
        }

        public Tuple<bool, object> Delete(Guid productId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var product = context.Products
                    .Where(x => x.ProductId.CompareTo(productId) == 0)
                    .FirstOrDefault();
                if (product == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + productId);
                }
                context.Products.DeleteOnSubmit(product);

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

        public Tuple<bool, object> Read(ProductFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Products.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Use to mapping data
                var data = query.Select(x => new ProductModel()
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
                var result = new Paginator<ProductModel>()
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
        private IQueryable<Product> GettingBy(IQueryable<Product> query, ProductFilter filter)
        {
            if (filter.ProductId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.ProductId.CompareTo(filter.ProductId) == 0);
            }
            return query;
        }

        private IQueryable<Product> Filtering(IQueryable<Product> query, ProductFilter filter)
        {
            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.Status.CompareTo(filter.Status) == 0);
            }
            query = query.Where(x => x.Price >= filter.PriceMin);
            if (filter.PriceMax > filter.PriceMin)
            {
                query = query.Where(x => x.Price <= filter.PriceMax);
            }
            query = query.Where(x => x.PromotionVulue >= filter.PromotionVulueMin);
            if (filter.PromotionVulueMax > filter.PriceMin)
            {
                query = query.Where(x => x.PromotionVulue <= filter.PromotionVulueMax);
            }
            if (filter.CategoryId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.CategoryId.CompareTo(filter.CategoryId) == 0);
            }
            return query;
        }

        private IQueryable<Product> Searching(IQueryable<Product> query, ProductFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.ProductId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword) ||
                        x.CategoryId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.ProductId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword) ||
                        x.CategoryId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Product> Paging(IQueryable<Product> query, ProductFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Product> Sorting(IQueryable<Product> query, ProductFilter filter)
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

        public Tuple<bool, object> Update(ProductModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var product = context.Products
                    .Where(x => x.ProductId.CompareTo(model.ProductId) == 0)
                    .FirstOrDefault();
                if (product == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.ProductId);
                }
                product.Name = model.Name;
                product.Description = model.Description;
                product.Status = (int)model.Status;
                product.Thumnail = model.Thumnail;
                product.Price = model.Price;
                product.PromotionVulue = model.PromotionVulue;
                product.CategoryId = model.CategoryId;

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
