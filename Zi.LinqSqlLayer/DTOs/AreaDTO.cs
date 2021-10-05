using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class AreaDTO
    {
        public Guid AreaId { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }

        public AreaDTO()
        {
        }

        public AreaDTO(string name)
        {
            AreaId = Guid.NewGuid();
            ParentId = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to AreaObj
        /// </summary>
        /// <param name="row"></param>
        public AreaDTO(DataRow row)
        {
            AreaId = Guid.Parse(row["AreaId"].ToString());
            Name = row["Name"].ToString();
            ParentId = row["ParentId"].ToString();
        }
    }
}
