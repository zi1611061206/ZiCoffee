using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IRoleService
    {
        Paginator<RoleDTO> GetRoles(RoleFilter filter);
        bool AddRole(RoleDTO obj);
        bool UpdateRole(RoleDTO obj);
        bool DeleteRole(Guid roleId);
    }
}
