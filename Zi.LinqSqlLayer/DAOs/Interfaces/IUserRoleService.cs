using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IUserRoleService
    {
        Tuple<bool, object> Read(UserRoleFilter filter, string cultureName);
        Tuple<bool, object> Create(UserRoleModel model, string cultureName);
        Tuple<bool, object> Delete(Guid userId, Guid roleId, string cultureName);
    }
}
