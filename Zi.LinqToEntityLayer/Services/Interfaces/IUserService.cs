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
    public interface IUserService
    {
        Task<Paginator<User>> GetUsers(UserFilter filter);
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(Guid userId);
        Task<bool> UpdatePassword(Guid userId, string password);
        Task<bool> CheckPassword(string username, string password);
        Task<bool> UpdateAvatar(Guid userId, string avatarPath);
    }
}
