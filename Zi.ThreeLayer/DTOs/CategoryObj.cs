using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.ThreeLayer.DTOs
{
    public class CategoryObj : Category
    {
        public CategoryObj(string name)
        {
            CategoryId = Guid.NewGuid();
            Description = string.Empty;
            Status = CategoryStatus.Availabled;
            ParentId = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to CategoryObj
        /// </summary>
        /// <param name="row"></param>
        public CategoryObj(DataRow row)
        {
            CategoryId = Guid.Parse(row["CategoryId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            Status = (CategoryStatus)row["Status"];
            ParentId = row["ParentId"].ToString();
        }
    }
}
