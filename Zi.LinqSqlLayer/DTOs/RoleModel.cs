using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class RoleModel
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public RoleModel()
        {
        }

        public RoleModel(string name)
        {
            RoleId = Guid.NewGuid();
            Description = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to RoleObj
        /// </summary>
        /// <param name="row"></param>
        public RoleModel(DataRow row)
        {
            RoleId = Guid.Parse(row["RoleId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
