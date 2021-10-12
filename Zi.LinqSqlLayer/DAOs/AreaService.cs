using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class AreaService : IAreaService
    {
        #region Instance
        private static AreaService instance;
        public static AreaService Instance
        {
            get { if (instance == null) instance = new AreaService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private AreaService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(AreaModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var area = new Area()
                {
                    AreaId = model.AreaId,
                    Name = model.Name,
                    ParentId = model.ParentId
                };
                context.Areas.InsertOnSubmit(area);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, area.AreaId);
            }
        }

        public Tuple<bool, object> Delete(Guid areaId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var area = context.Areas
                    .Where(x => x.AreaId.CompareTo(areaId) == 0)
                    .FirstOrDefault();
                if (area == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + areaId);
                }
                context.Areas.DeleteOnSubmit(area);

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

        public Tuple<bool, object> Read(AreaFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Areas.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new AreaModel()
                {
                    AreaId = x.AreaId,
                    Name = x.Name,
                    ParentId = x.ParentId
                });
                var result = new Paginator<AreaModel>()
                {
                    TotalRecords = data.Count(),
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
        private IQueryable<Area> GettingBy(IQueryable<Area> query, AreaFilter filter)
        {
            if (filter.AreaId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.AreaId.CompareTo(filter.AreaId) == 0);
            }
            return query;
        }

        private IQueryable<Area> Filtering(IQueryable<Area> query, AreaFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.ParentId))
            {
                query = query.Where(x => x.ParentId.Equals(filter.ParentId));
            }
            return query;
        }

        private IQueryable<Area> Searching(IQueryable<Area> query, AreaFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.AreaId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.ParentId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.AreaId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.ParentId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Area> Paging(IQueryable<Area> query, AreaFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Area> Sorting(IQueryable<Area> query, AreaFilter filter)
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

        public Tuple<bool, object> Update(AreaModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var area = context.Areas
                    .Where(x => x.AreaId.CompareTo(model.AreaId) == 0)
                    .FirstOrDefault();
                if (area == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.AreaId);
                }
                area.Name = model.Name;
                area.ParentId = model.ParentId;

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
