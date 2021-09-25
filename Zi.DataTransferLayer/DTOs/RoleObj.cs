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
        public RoleObj()
        {
            RoleId = Guid.NewGuid();
        }

        public RoleObj(DataRow row)
        {
            RoleId = Guid.Parse(row["RoleId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
