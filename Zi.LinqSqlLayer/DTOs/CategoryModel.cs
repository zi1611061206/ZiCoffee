using System;
using System.Data;
using Zi.LinqSqlLayer.Enumerators;

namespace Zi.LinqSqlLayer.DTOs
{
    public class CategoryModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryStatus Status { get; set; }
        public string ParentId { get; set; }

        public CategoryModel()
        {
        }

        public CategoryModel(string name)
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
        public CategoryModel(DataRow row)
        {
            CategoryId = Guid.Parse(row["CategoryId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            Status = (CategoryStatus)row["Status"];
            ParentId = row["ParentId"].ToString();
        }
    }
}
