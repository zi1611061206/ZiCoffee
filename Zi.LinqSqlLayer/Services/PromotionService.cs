using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class PromotionService : IPromotionService
    {
        public bool AddPromotion(PromotionDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var promotion = new Promotion()
                {
                    PromotionId = obj.PromotionId,
                    Description = obj.Description,
                    IsActived = (int)obj.IsActived,
                    IsAutoApply = (int)obj.IsAutoApply,
                    IsPercent = (int)obj.IsPercent,
                    Value = obj.Value,
                    MinValue = obj.MinValue,
                    CodeList = obj.CodeList,
                    StartTime = obj.StartTime,
                    EndTime = obj.EndTime,
                    PromotionTypeId = obj.PromotionTypeId
                };
                context.Promotions.InsertOnSubmit(promotion);
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

        public bool DeletePromotion(Guid promotionId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var promotion = context.Promotions.Where(x => x.PromotionId.CompareTo(promotionId) == 0).FirstOrDefault();
                context.Promotions.DeleteOnSubmit(promotion);
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

        public Paginator<PromotionDTO> GetPromotions(PromotionFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Promotions;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new PromotionDTO()
                {
                    PromotionId = x.PromotionId,
                    Description = x.Description,
                    IsActived = (PromotionActived)x.IsActived,
                    IsAutoApply = (PromotionAutoApply)x.IsAutoApply,
                    IsPercent = (PromotionPercent)x.IsPercent,
                    Value = x.Value,
                    MinValue = x.MinValue,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    CodeList = x.CodeList,
                    PromotionTypeId = x.PromotionTypeId
                });
                var result = new Paginator<PromotionDTO>()
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
        private Table<Promotion> GettingBy(Table<Promotion> query, PromotionFilter filter)
        {
            if (filter.PromotionId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.PromotionId.CompareTo(filter.PromotionId) == 0);
            }
            return query;
        }

        private Table<Promotion> Filtering(Table<Promotion> query, PromotionFilter filter)
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

        private Table<Promotion> Searching(Table<Promotion> query, PromotionFilter filter)
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

        private Table<Promotion> Paging(Table<Promotion> query, PromotionFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Promotion> Sorting(Table<Promotion> query, PromotionFilter filter)
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

        public bool UpdatePromotion(PromotionDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var promotion = context.Promotions.Where(x => x.PromotionId.CompareTo(obj.PromotionId) == 0).FirstOrDefault();
                promotion.Description = obj.Description;
                promotion.IsActived = (int)obj.IsActived;
                promotion.IsAutoApply = (int)obj.IsAutoApply;
                promotion.IsPercent = (int)obj.IsPercent;
                promotion.Value = obj.Value;
                promotion.MinValue = obj.MinValue;
                promotion.CodeList = obj.CodeList;
                promotion.StartTime = obj.StartTime;
                promotion.EndTime = obj.EndTime;
                promotion.PromotionTypeId = obj.PromotionTypeId;
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
