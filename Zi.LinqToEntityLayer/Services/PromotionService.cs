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
    public class PromotionService : IPromotionService
    {
        public async Task<bool> AddPromotion(Promotion promotion)
        {
            using (var context = new ZiDbContext())
            {
                context.Promotions.Add(promotion);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeletePromotion(Guid promotionId)
        {
            using (var context = new ZiDbContext())
            {
                var promotion = await context.Promotions.FindAsync(promotionId);
                context.Promotions.Remove(promotion);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Promotion>> GetPromotions(PromotionFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Promotions;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new Promotion()
                {
                    PromotionId = x.PromotionId,
                    Description = x.Description,
                    IsActived = x.IsActived,
                    IsAutoApply = x.IsAutoApply,
                    IsPercent = x.IsPercent,
                    Value = x.Value,
                    MinValue = x.MinValue,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    CodeList = x.CodeList,
                    PromotionTypeId = x.PromotionTypeId
                });
                var result = new Paginator<Promotion>()
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
        private DbSet<Promotion> GettingBy(DbSet<Promotion> query, PromotionFilter filter)
        {
            if (filter.PromotionId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.PromotionId.CompareTo(filter.PromotionId) == 0);
            }
            return query;
        }

        private DbSet<Promotion> Filtering(DbSet<Promotion> query, PromotionFilter filter)
        {
            if (filter.IsActived.HasValue)
            {
                query.Where(x => x.IsActived.CompareTo(filter.IsActived) == 0);
            }
            if (filter.IsAutoApply.HasValue)
            {
                query.Where(x => x.IsAutoApply.CompareTo(filter.IsAutoApply) == 0);
            }
            if (filter.IsPercent.HasValue)
            {
                query.Where(x => x.PromotionId.CompareTo(filter.IsPercent) == 0);
            }
            query.Where(x => x.Value >= filter.ValueFrom);
            if (filter.ValueTo > filter.ValueFrom)
            {
                query.Where(x => x.Value <= filter.ValueTo);
            }
            query.Where(x => x.MinValue >= filter.MinValueFrom);
            if (filter.MinValueTo > filter.MinValueFrom)
            {
                query.Where(x => x.MinValue <= filter.MinValueTo);
            }
            if (filter.StartTimeFilter.HasValue)
            {
                query.Where(x => x.StartTime.CompareTo(filter.StartTimeFilter) >= 0);
            }
            if (filter.EndTimeFilter.HasValue)
            {
                query.Where(x => x.EndTime.CompareTo(filter.EndTimeFilter) <= 0);
            }
            if (filter.PromotionTypeId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.PromotionTypeId.CompareTo(filter.PromotionTypeId) == 0);
            }
            return query;
        }

        private DbSet<Promotion> Searching(DbSet<Promotion> query, PromotionFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.PromotionId.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword) ||
                        x.CodeList.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.PromotionId.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword) ||
                        x.CodeList.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<Promotion> Paging(DbSet<Promotion> query, PromotionFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Promotion> Sorting(DbSet<Promotion> query, PromotionFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.StartTime);
            }
            else
            {
                query.OrderByDescending(x => x.StartTime);
            }
            return query;
        }
        #endregion

        public async Task<bool> UpdatePromotion(Promotion promotion)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Promotions.FindAsync(promotion.PromotionId);
                data.Description = promotion.Description;
                data.IsActived = promotion.IsActived;
                data.IsAutoApply = promotion.IsAutoApply;
                data.IsPercent = promotion.IsPercent;
                data.Value = promotion.Value;
                data.MinValue = promotion.MinValue;
                data.StartTime = promotion.StartTime;
                data.EndTime = promotion.EndTime;
                data.CodeList = promotion.CodeList;
                data.PromotionTypeId = promotion.PromotionTypeId;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
