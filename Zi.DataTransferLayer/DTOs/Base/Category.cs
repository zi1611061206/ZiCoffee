using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class Category
    {
        private int categoryId;
        private string categoryName;

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }

        public Category(int categoryId, string categoryName)
        {
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
        }

        public Category(DataRow row)
        {
            CategoryId = (int)row["MaDanhMuc"];
            CategoryName = row["TenDanhMuc"].ToString();
        }
    }
}
