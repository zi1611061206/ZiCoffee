using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Paginator<Category>> GetCategories(CategoryFilter filter);
        Task<bool> AddCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCategory(Guid categoryId);
    }
}
