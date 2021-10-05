using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IUserRoleService
    {
        Paginator<UserRoleDTO> GetUserRoles(UserRoleFilter filter);
        bool AddUserRole(UserRoleDTO obj);
        bool DeleteUserRole(Guid userId, Guid roleId);
    }
}
