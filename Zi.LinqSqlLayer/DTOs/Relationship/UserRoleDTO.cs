using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs.Relationship
{
    public class UserRoleDTO
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public UserRoleDTO()
        {
        }

        public UserRoleDTO(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// Mapping data to UserRoleObj
        /// </summary>
        /// <param name="row"></param>
        public UserRoleDTO(DataRow row)
        {
            UserId = Guid.Parse(row["UserId"].ToString());
            RoleId = Guid.Parse(row["RoleId"].ToString());
        }
    }
}
