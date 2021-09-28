using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs.Relationship
{
    public class UserRoleObj : UserRole
    {
        public UserRoleObj(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// Mapping data to UserRoleObj
        /// </summary>
        /// <param name="row"></param>
        public UserRoleObj(DataRow row)
        {
            UserId = Guid.Parse(row["UserId"].ToString());
            RoleId = Guid.Parse(row["RoleId"].ToString());
        }
    }
}
