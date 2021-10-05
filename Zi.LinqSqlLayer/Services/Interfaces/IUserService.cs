using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IUserService
    {
        Paginator<UserDTO> GetUsers(UserFilter filter);
        bool AddUser(UserDTO obj);
        bool UpdateUser(UserDTO obj);
        bool DeleteUser(Guid userId);
        bool UpdatePassword(Guid userId, string password);
        bool CheckPassword(string username, string password);
        bool UpdateAvatar(Guid userId, string avatarPath);
    }
}
