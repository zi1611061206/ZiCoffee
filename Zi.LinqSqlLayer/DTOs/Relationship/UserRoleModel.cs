using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class UserRoleModel
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public UserRoleModel()
        {
        }

        public UserRoleModel(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// Mapping data to UserRoleObj
        /// </summary>
        /// <param name="row"></param>
        public UserRoleModel(DataRow row)
        {
            UserId = Guid.Parse(row["UserId"].ToString());
            RoleId = Guid.Parse(row["RoleId"].ToString());
        }
    }
}
