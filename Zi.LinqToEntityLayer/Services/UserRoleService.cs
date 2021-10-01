using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;
using Zi.LinqToEntityLayer.Services.Interfaces;

namespace Zi.LinqToEntityLayer.Services
{
    public class UserRoleService : IUserRoleService
    {
        public async Task<bool> AddUserRole(UserRole userRole)
        {
            using (var context = new ZiDbContext())
            {
                context.UserRoles.Add(userRole);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteUserRole(Guid userId, Guid roleId)
        {
            using (var context = new ZiDbContext())
            {
                var userRole = (from ur in context.UserRoles
                               where ur.UserId.CompareTo(userId) == 0 && ur.RoleId.CompareTo(roleId) == 0
                               select ur).First();
                context.UserRoles.Remove(userRole);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<UserRole> GetUserRoles(UserRoleFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.UserRoles;
                query = GettingBy(query, filter);
                //query = Filtering(query, filter);
                query = Searching(query, filter);
                query = Paging(query, filter);
                //query = Sorting(query, filter);
                // Mapping data
                var data = query.Select(x => new UserRole()
                {
                    UserId = x.UserId,
                    RoleId = x.RoleId
                });
                var result = new Paginator<UserRole>()
                {
                    TotalRecords = data.Count(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                return result;
            }
        }

        #region Engines
        private DbSet<UserRole> GettingBy(DbSet<UserRole> query, UserRoleFilter filter)
        {
            if (filter.UserId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.UserId.CompareTo(filter.UserId) == 0);
            }
            if (filter.RoleId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.RoleId.CompareTo(filter.RoleId) == 0);
            }
            return query;
        }

        private DbSet<UserRole> Searching(DbSet<UserRole> query, UserRoleFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.UserId.ToString().Contains(filter.Keyword) ||
                        x.RoleId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.UserId.ToString().Equals(filter.Keyword) ||
                        x.RoleId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<UserRole> Paging(DbSet<UserRole> query, UserRoleFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }
        #endregion

        public async Task<bool> UpdateUserRole(UserRole userRole)
        {
            using (var context = new ZiDbContext())
            {
                var data = (from ur in context.UserRoles
                            where ur.UserId.CompareTo(userRole.UserId) == 0 && ur.RoleId.CompareTo(userRole.RoleId) == 0
                            select ur).First();
                data.UserId = userRole.UserId;
                data.RoleId = userRole.RoleId;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
