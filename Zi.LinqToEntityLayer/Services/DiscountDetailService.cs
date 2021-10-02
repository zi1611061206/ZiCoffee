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
    public class DiscountDetailService : IDiscountDetailService
    {
        public async Task<bool> AddDiscountDetail(DiscountDetail discountDetail)
        {
            using (var context = new ZiDbContext())
            {
                context.DiscountDetails.Add(discountDetail);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteDiscountDetail(Guid billId, Guid promotionId)
        {
            using (var context = new ZiDbContext())
            {
                var discountDetail = (from dd in context.DiscountDetails
                                      where dd.BillId.CompareTo(billId) == 0 && dd.PromotionId.CompareTo(promotionId) == 0
                                      select dd).First();
                context.DiscountDetails.Remove(discountDetail);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<DiscountDetail>> GetDiscountDetails(DiscountDetailFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.DiscountDetails;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new DiscountDetail()
                {
                    BillId = x.BillId,
                    PromotionId = x.PromotionId
                });
                var result = new Paginator<DiscountDetail>()
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
        private DbSet<DiscountDetail> GettingBy(DbSet<DiscountDetail> query, DiscountDetailFilter filter)
        {
            if (filter.BillId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.BillId.CompareTo(filter.BillId) == 0);
            }
            if (filter.PromotionId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.PromotionId.CompareTo(filter.PromotionId) == 0);
            }
            return query;
        }

        private DbSet<DiscountDetail> Searching(DbSet<DiscountDetail> query, DiscountDetailFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.BillId.ToString().Contains(filter.Keyword) ||
                        x.PromotionId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.BillId.ToString().Equals(filter.Keyword) ||
                        x.PromotionId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<DiscountDetail> Paging(DbSet<DiscountDetail> query, DiscountDetailFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<DiscountDetail> Sorting(DbSet<DiscountDetail> query, DiscountDetailFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.BillId);
            }
            else
            {
                query.OrderByDescending(x => x.BillId);
            }
            return query;
        }
        #endregion
    }
}
