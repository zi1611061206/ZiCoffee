using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.ThreeLayer.DTOs
{
    public class AreaObj : Area
    {
        public AreaObj(string name)
        {
            AreaId = Guid.NewGuid();
            ParentId = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to AreaObj
        /// </summary>
        /// <param name="row"></param>
        public AreaObj(DataRow row)
        {
            AreaId = Guid.Parse(row["AreaId"].ToString());
            Name = row["Name"].ToString();
            ParentId = row["ParentId"].ToString();
        }
    }
}
