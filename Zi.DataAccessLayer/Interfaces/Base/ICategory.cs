using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.Interfaces.Base
{
    public interface ICategory
    {
        bool AddCategory(Category category);

        DataTable GetAllCategory();

        Category GetCategoryById(int categoryId);

        bool UpdateCategory(Category category);

        bool DeleteAllCategory();

        bool DeleteCategoryById(int categoryId);

        bool CheckCategoryName(string categoryName);

        int CountAllCategory();

        DataTable SearchCategory(string categoryName);
    }
}
