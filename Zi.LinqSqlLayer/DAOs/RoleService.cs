using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.DAOs
{
    public class RoleService : IRoleService
    {
        #region Instance
        private static RoleService instance;
        public static RoleService Instance
        {
            get { if (instance == null) instance = new RoleService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private RoleService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(RoleModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var role = new Role()
                {
                    RoleId = model.RoleId,
                    Name = model.Name,
                    Description = model.Description,
                    AccessLevel = (int)model.AccessLevel
                };
                context.Roles.InsertOnSubmit(role);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, role.RoleId);
            }
        }

        public Tuple<bool, object> Delete(Guid roleId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var role = context.Roles
                    .Where(x => x.RoleId.CompareTo(roleId) == 0)
                    .FirstOrDefault();
                if (role == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + roleId);
                }
                context.Roles.DeleteOnSubmit(role);

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

        public Tuple<bool, object> Read(RoleFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Roles.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new RoleModel()
                {
                    RoleId = x.RoleId,
                    Name = x.Name,
                    Description = x.Description,
                    AccessLevel = (AccessLevels)x.AccessLevel
                });
                var result = new Paginator<RoleModel>()
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
        private IQueryable<Role> GettingBy(IQueryable<Role> query, RoleFilter filter)
        {
            if (filter.RoleId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.RoleId.CompareTo(filter.RoleId) == 0);
            }
            return query;
        }

        private IQueryable<Role> Filtering(IQueryable<Role> query, RoleFilter filter)
        {
            if (filter.AccessLevel.HasValue)
            {
                query = query.Where(x => x.AccessLevel.CompareTo(filter.AccessLevel) == 0);
            }
            return query;
        }

        private IQueryable<Role> Searching(IQueryable<Role> query, RoleFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.RoleId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.RoleId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Role> Paging(IQueryable<Role> query, RoleFilter filter)
        {
            if (filter.PageSize != 0)
            {
                int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
                query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            }
            return query;
        }

        private IQueryable<Role> Sorting(IQueryable<Role> query, RoleFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.Name);
            }
            else
            {
                query = query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(RoleModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var role = context.Roles
                    .Where(x => x.RoleId.CompareTo(model.RoleId) == 0)
                    .FirstOrDefault();
                if (role == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.RoleId);
                }
                role.Name = model.Name;
                role.Description = model.Description;
                role.AccessLevel = (int)model.AccessLevel;

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedUpdate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, null);
            }
        }
    }
}
