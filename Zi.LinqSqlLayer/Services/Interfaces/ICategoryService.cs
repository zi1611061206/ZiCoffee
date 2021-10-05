using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Paginator<CategoryDTO> GetCategories(CategoryFilter filter);
        bool AddCategory(CategoryDTO obj);
        bool UpdateCategory(CategoryDTO obj);
        bool DeleteCategory(Guid categoryId);
    }
}
