using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IProductService
    {
        Paginator<ProductDTO> GetProducts(ProductFilter filter);
        bool AddProduct(ProductDTO obj);
        bool UpdateProduct(ProductDTO obj);
        bool DeleteProduct(Guid productId);
    }
}
