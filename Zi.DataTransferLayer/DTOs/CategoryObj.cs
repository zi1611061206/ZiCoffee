using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace DataTransferLayer.DTOs
{
    public class CategoryObj : Category
    {
        public CategoryObj()
        {
            CategoryId = Guid.NewGuid();
        }

        public CategoryObj(DataRow row)
        {
            CategoryId = Guid.Parse(row["CategoryId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            int categoryStatus = (int)row["Status"];
            Status = (CategoryStatus) categoryStatus;
            ParentId = Guid.Parse(row["ParentId"].ToString());
        }
    }
}
