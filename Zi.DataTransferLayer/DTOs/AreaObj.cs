using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs
{
    public class AreaObj : Area
    {
        /// <summary>
        /// A new area without ParentId
        /// </summary>
        /// <param name="name"></param>
        public AreaObj(string name)
        {
            AreaId = Guid.NewGuid();
            Name = name;
            ParentId = Guid.Empty;
        }

        /// <summary>
        /// A new area with ParentId
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentId"></param>
        public AreaObj(string name, Guid parentId)
        {
            AreaId = Guid.NewGuid();
            Name = name;
            ParentId = parentId;
        }

        /// <summary>
        /// Mapping data to AreaObj
        /// </summary>
        /// <param name="row"></param>
        public AreaObj(DataRow row)
        {
            AreaId = Guid.Parse(row["AreaId"].ToString());
            Name = row["Name"].ToString();
            ParentId = Guid.Parse(row["ParentId"].ToString());
        }
    }
}
