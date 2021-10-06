using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IProductService
    {
        Tuple<bool, object> Read(ProductFilter filter, string cultureName);
        Tuple<bool, object> Create(ProductModel model, string cultureName);
        Tuple<bool, object> Update(ProductModel model, string cultureName);
        Tuple<bool, object> Delete(Guid productId, string cultureName);
    }
}
