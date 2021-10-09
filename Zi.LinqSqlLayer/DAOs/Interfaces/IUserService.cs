using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IUserService
    {
        Tuple<bool, object> Read(UserFilter filter, string cultureName);
        Tuple<bool, object> Create(UserModel model, string cultureName);
        Tuple<bool, object> Update(UserModel model, string cultureName);
        Tuple<bool, object> Delete(Guid userId, string cultureName);
        Tuple<bool, object> UpdatePassword(Guid userId, string password, string cultureName);
        Tuple<bool, object> ExistedUsername(string username, string cultureName);
        Tuple<bool, object> MatchedPassword(string username, string password, string cultureName);
        Tuple<bool, object> ExistedCitizenId(string citizenId, string cultureName);
        Tuple<bool, object> UpdateAvatar(Guid userId, string cultureName, string avatarPath);
    }
}
