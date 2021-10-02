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
    public class PromotionTypeService : IPromotionTypeService
    {
        public async Task<bool> AddPromotionType(PromotionType promotionType)
        {
            using (var context = new ZiDbContext())
            {
                context.PromotionTypes.Add(promotionType);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeletePromotionType(Guid promotionTypeId)
        {
            using (var context = new ZiDbContext())
            {
                var promotionType = await context.PromotionTypes.FindAsync(promotionTypeId);
                context.PromotionTypes.Remove(promotionType);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<PromotionType>> GetAreaPromotionTypes(PromotionTypeFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.PromotionTypes;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new PromotionType()
                {
                    PromotionTypeId = x.PromotionTypeId,
                    Name = x.Name,
                    Description = x.Description
                });
                var result = new Paginator<PromotionType>()
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
        private DbSet<PromotionType> GettingBy(DbSet<PromotionType> query, PromotionTypeFilter filter)
        {
            if (filter.PromotionTypeId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.PromotionTypeId.CompareTo(filter.PromotionTypeId) == 0);
            }
            return query;
        }

        private DbSet<PromotionType> Searching(DbSet<PromotionType> query, PromotionTypeFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.PromotionTypeId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.PromotionTypeId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<PromotionType> Paging(DbSet<PromotionType> query, PromotionTypeFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<PromotionType> Sorting(DbSet<PromotionType> query, PromotionTypeFilter filter)
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

        public async Task<bool> UpdatePromotionType(PromotionType promotionType)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.PromotionTypes.FindAsync(promotionType.PromotionTypeId);
                data.Name = promotionType.Name;
                data.Description = promotionType.Description;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
