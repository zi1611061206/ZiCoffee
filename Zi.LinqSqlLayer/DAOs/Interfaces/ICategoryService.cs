using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface ICategoryService
    {
        Tuple<bool, object> Read(CategoryFilter filter, string cultureName);
        Tuple<bool, object> Create(CategoryModel model, string cultureName);
        Tuple<bool, object> Update(CategoryModel model, string cultureName);
        Tuple<bool, object> Delete(Guid categoryId, string cultureName);
    }
}
