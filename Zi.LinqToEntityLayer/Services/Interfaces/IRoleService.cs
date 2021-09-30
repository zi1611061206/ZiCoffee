using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Services.Interfaces
{
    public interface IRoleService
    {
        Paginator<Role> GetRoles(RoleFilter filter);
        Task<bool> AddRole(Role role);
        Task<bool> UpdateRole(Role role);
        Task<bool> DeleteRole(Guid roleId);
    }
}
