using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs
{
    public class RoleObj : Role
    {
        public RoleObj(string name)
        {
            RoleId = Guid.NewGuid();
            Description = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to RoleObj
        /// </summary>
        /// <param name="row"></param>
        public RoleObj(DataRow row)
        {
            RoleId = Guid.Parse(row["RoleId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
