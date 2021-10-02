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
    public interface IUserRoleService
    {
        Task<Paginator<UserRole>> GetUserRoles(UserRoleFilter filter);
        Task<bool> AddUserRole(UserRole userRole);
        Task<bool> DeleteUserRole(Guid userId, Guid roleId);
    }
}
