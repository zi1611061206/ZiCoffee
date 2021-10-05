using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class RoleDTO
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public RoleDTO()
        {
        }

        public RoleDTO(string name)
        {
            RoleId = Guid.NewGuid();
            Description = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to RoleObj
        /// </summary>
        /// <param name="row"></param>
        public RoleDTO(DataRow row)
        {
            RoleId = Guid.Parse(row["RoleId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
