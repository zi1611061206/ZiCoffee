using System;
using System.Collections.Generic;
using System.Data;
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
    public class AreaService : IAreaService
    {
        public async Task<bool> AddArea(Area area)
        {
            using (var context = new ZiDbContext())
            {
                context.Areas.Add(area);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteArea(Guid areaId)
        {
            using (var context = new ZiDbContext())
            {
                Area area = await context.Areas.FindAsync(areaId);
                context.Areas.Remove(area);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<Area> GetAreas(AreaFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Areas;
                query = GettingBy(query, filter);
                query = Filtering(query, filter);
                query = Searching(query, filter);
                query = Paging(query, filter);
                query = Sorting(query, filter);
                // Mapping data
                var data = query.Select(x => new Area()
                {
                    AreaId = x.AreaId,
                    Name = x.Name,
                    ParentId = x.ParentId
                });
                var result = new Paginator<Area>()
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
        private DbSet<Area> GettingBy(DbSet<Area> query, AreaFilter filter)
        {
            if (filter.AreaId.CompareTo(Guid.Empty)!=0)
            {
                query.Where(x => x.AreaId.CompareTo(filter.AreaId)==0);
            }
            return query;
        }

        private DbSet<Area> Filtering(DbSet<Area> query, AreaFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.ParentId))
            {
                query.Where(x => x.ParentId.Equals(filter.ParentId));
            }
            return query;
        }

        private DbSet<Area> Searching(DbSet<Area> query, AreaFilter filter)
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

        private DbSet<Area> Paging(DbSet<Area> query, AreaFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Area> Sorting(DbSet<Area> query, AreaFilter filter)
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

        public async Task<bool> UpdateArea(Area area)
        {
            using (var context = new ZiDbContext())
            {
                Area data = await context.Areas.FindAsync(area.AreaId);
                data.Name = area.Name;
                data.ParentId = area.ParentId;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
