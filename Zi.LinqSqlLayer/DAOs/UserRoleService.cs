using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class UserRoleService : IUserRoleService
    {
        #region Instance
        private static UserRoleService instance;
        public static UserRoleService Instance
        {
            get { if (instance == null) instance = new UserRoleService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private UserRoleService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(UserRoleModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var userRole = new UserRole()
                {
                    UserId = model.UserId,
                    RoleId = model.RoleId
                };
                context.UserRoles.InsertOnSubmit(userRole);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> Delete(Guid userId, Guid roleId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var userRole = context.UserRoles
                    .Where(x => x.UserId.CompareTo(userId) == 0 && x.RoleId.CompareTo(roleId) == 0)
                    .FirstOrDefault();
                if (userRole == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                context.UserRoles.DeleteOnSubmit(userRole);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedDelete", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }

        public Tuple<bool, object> Read(UserRoleFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.UserRoles.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new UserRoleModel()
                {
                    UserId = x.UserId,
                    RoleId = x.RoleId
                });
                var result = new Paginator<UserRoleModel>()
                {
                    TotalRecords = totalRecords,
                    PageSize = filter.PageSize,
                    CurrentPageIndex = filter.CurrentPageIndex,
                    Item = data.ToList()
                };
                if (data.Count() <= 0)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                return new Tuple<bool, object>(true, result);
            }
        }

        #region Engines
        private IQueryable<UserRole> GettingBy(IQueryable<UserRole> query, UserRoleFilter filter)
        {
            if (filter.UserId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.UserId.CompareTo(filter.UserId) == 0);
            }
            if (filter.RoleId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.RoleId.CompareTo(filter.RoleId) == 0);
            }
            return query;
        }

        private IQueryable<UserRole> Searching(IQueryable<UserRole> query, UserRoleFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.UserId.ToString().Contains(filter.Keyword) ||
                        x.RoleId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.UserId.ToString().Equals(filter.Keyword) ||
                        x.RoleId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<UserRole> Paging(IQueryable<UserRole> query, UserRoleFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<UserRole> Sorting(IQueryable<UserRole> query, UserRoleFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.UserId);
            }
            else
            {
                query = query.OrderByDescending(x => x.UserId);
            }
            return query;
        }
        #endregion
    }
}
