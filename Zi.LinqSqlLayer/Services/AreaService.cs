using System;
using System.Data;
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
    public class AreaService : IAreaService
    {
        public bool AddArea(AreaDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var area = new Area()
                {
                    AreaId = obj.AreaId,
                    Name = obj.Name,
                    ParentId = obj.ParentId
                };
                context.Areas.InsertOnSubmit(area);
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

        public bool DeleteArea(Guid areaId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var area = context.Areas.Where(x=>x.AreaId.CompareTo(areaId)==0).FirstOrDefault();
                context.Areas.DeleteOnSubmit(area);
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

        public Paginator<AreaDTO> GetAreas(AreaFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Areas;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new AreaDTO()
                {
                    AreaId = x.AreaId,
                    Name = x.Name,
                    ParentId = x.ParentId
                });
                var result = new Paginator<AreaDTO>()
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
        private Table<Area> GettingBy(Table<Area> query, AreaFilter filter)
        {
            if (filter.AreaId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.AreaId.CompareTo(filter.AreaId) == 0);
            }
            return query;
        }

        private Table<Area> Filtering(Table<Area> query, AreaFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.ParentId))
            {
                query.Where(x => x.ParentId.Equals(filter.ParentId));
            }
            return query;
        }

        private Table<Area> Searching(Table<Area> query, AreaFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.AreaId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.ParentId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.AreaId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.ParentId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Area> Paging(Table<Area> query, AreaFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Area> Sorting(Table<Area> query, AreaFilter filter)
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

        public bool UpdateArea(AreaDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var area = context.Areas.Where(x=>x.AreaId.CompareTo(obj.AreaId)==0).FirstOrDefault();
                area.Name = obj.Name;
                area.ParentId = obj.ParentId;
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
