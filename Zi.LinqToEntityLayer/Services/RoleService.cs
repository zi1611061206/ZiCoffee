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
    public class RoleService : IRoleService
    {
        public async Task<bool> AddRole(Role role)
        {
            using (var context = new ZiDbContext())
            {
                context.Roles.Add(role);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteRole(Guid roleId)
        {
            using (var context = new ZiDbContext())
            {
                var role = await context.Roles.FindAsync(roleId);
                context.Roles.Remove(role);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Role>> GetRoles(RoleFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Roles;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new Role()
                {
                    RoleId = x.RoleId,
                    Name = x.Name,
                    Description = x.Description
                });
                var result = new Paginator<Role>()
                {
                    TotalRecords = await data.CountAsync(),
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = await data.ToListAsync()
                };
                return result;
            }
        }

        #region Engines
        private DbSet<Role> GettingBy(DbSet<Role> query, RoleFilter filter)
        {
            if (filter.RoleId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.RoleId.CompareTo(filter.RoleId) == 0);
            }
            return query;
        }

        private DbSet<Role> Searching(DbSet<Role> query, RoleFilter filter)
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

        private DbSet<Role> Paging(DbSet<Role> query, RoleFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Role> Sorting(DbSet<Role> query, RoleFilter filter)
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

        public async Task<bool> UpdateRole(Role role)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Roles.FindAsync(role.RoleId);
                data.Name = role.Name;
                data.Description = role.Description;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
