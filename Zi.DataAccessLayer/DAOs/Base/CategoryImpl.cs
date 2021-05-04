using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Base;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.DAOs
{
    public class CategoryImpl : ICategory
    {
        #region Package_CategoryImpl
        private static CategoryImpl instance;

        public static CategoryImpl Instance
        {
            get { if (instance == null) instance = new CategoryImpl(); return instance; }
            private set { instance = value; }
        }

        private CategoryImpl() { }
        #endregion

        public bool AddCategory(Category category)
        {
            string query = "insert into DanhMuc(TenDanhMuc) values (N'" + category.CategoryName + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable GetAllCategory()
        {
            string query = "select * from DanhMuc";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Category GetCategoryById(int categoryId)
        {
            string query = "select * from DanhMuc where MaDanhMuc = " + categoryId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Category(data.Rows[0]);
        }

        public bool UpdateCategory(Category category)
        {
            string query = "update DanhMuc set TenDanhMuc = N'" + category.CategoryName + "' where MaDanhMuc = " + category.CategoryId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllCategory()
        {
            string query = "delete from DanhMuc";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteCategoryById(int categoryId)
        {
            string query = "delete from DanhMuc where MaDanhMuc = " + categoryId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckCategoryName(string categoryName)
        {
            string query = "select * from DanhMuc where TenDanhMuc = N'" + categoryName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public int CountAllCategory()
        {
            string query = "select count(*) from DanhMuc";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchCategory(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
