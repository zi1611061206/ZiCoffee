using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class UserRoleService : IUserRoleService
    {
        public bool AddUserRole(UserRoleDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var userRole = new UserRole()
                {
                    UserId = obj.UserId,
                    RoleId = obj.RoleId
                };
                context.UserRoles.InsertOnSubmit(userRole);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool DeleteUserRole(Guid userId, Guid roleId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var userRole = context.UserRoles
                    .Where(x => x.UserId.CompareTo(userId) == 0 && x.RoleId.CompareTo(roleId) == 0)
                    .FirstOrDefault();
                context.UserRoles.DeleteOnSubmit(userRole);
                try
                {
                    context.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<UserRoleDTO> GetUserRoles(UserRoleFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.UserRoles;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new UserRoleDTO()
                {
                    UserId = x.UserId,
                    RoleId = x.RoleId
                });
                var result = new Paginator<UserRoleDTO>()
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
        private Table<UserRole> GettingBy(Table<UserRole> query, UserRoleFilter filter)
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

        private Table<UserRole> Searching(Table<UserRole> query, UserRoleFilter filter)
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

        private Table<UserRole> Paging(Table<UserRole> query, UserRoleFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<UserRole> Sorting(Table<UserRole> query, UserRoleFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.UserId);
            }
            else
            {
                query.OrderByDescending(x => x.UserId);
            }
            return query;
        }
        #endregion
    }
}
