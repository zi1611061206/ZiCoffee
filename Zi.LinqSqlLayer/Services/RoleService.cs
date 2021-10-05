using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class RoleService : IRoleService
    {
        public bool AddRole(RoleDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var role = new Role()
                {
                    RoleId = obj.RoleId,
                    Name = obj.Name,
                    Description = obj.Description
                };
                context.Roles.InsertOnSubmit(role);
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

        public bool DeleteRole(Guid roleId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var role = context.Roles.Where(x => x.RoleId.CompareTo(roleId) == 0).FirstOrDefault();
                context.Roles.DeleteOnSubmit(role);
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

        public Paginator<RoleDTO> GetRoles(RoleFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Roles;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new RoleDTO()
                {
                    RoleId = x.RoleId,
                    Name = x.Name,
                    Description = x.Description
                });
                var result = new Paginator<RoleDTO>()
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
        private Table<Role> GettingBy(Table<Role> query, RoleFilter filter)
        {
            if (filter.RoleId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.RoleId.CompareTo(filter.RoleId) == 0);
            }
            return query;
        }

        private Table<Role> Searching(Table<Role> query, RoleFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.RoleId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.RoleId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Role> Paging(Table<Role> query, RoleFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Role> Sorting(Table<Role> query, RoleFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.Name);
            }
            else
            {
                query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public bool UpdateRole(RoleDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var role = context.Roles.Where(x => x.RoleId.CompareTo(obj.RoleId) == 0).FirstOrDefault();
                role.Name = obj.Name;
                role.Description = obj.Description;
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
    }
}
