using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IRoleService
    {
        Tuple<bool, object> Read(RoleFilter filter, string cultureName);
        Tuple<bool, object> Create(RoleModel model, string cultureName);
        Tuple<bool, object> Update(RoleModel model, string cultureName);
        Tuple<bool, object> Delete(Guid roleId, string cultureName);
    }
}
