using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class PromotionService : IPromotionService
    {
        #region Instance
        private static PromotionService instance;
        public static PromotionService Instance
        {
            get { if (instance == null) instance = new PromotionService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private PromotionService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(PromotionModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var promotion = new Promotion()
                {
                    PromotionId = model.PromotionId,
                    Description = model.Description,
                    IsActived = (int)model.IsActived,
                    IsAutoApply = (int)model.IsAutoApply,
                    IsPercent = (int)model.IsPercent,
                    Value = model.Value,
                    MinValue = model.MinValue,
                    CodeList = model.CodeList,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    PromotionTypeId = model.PromotionTypeId
                };
                context.Promotions.InsertOnSubmit(promotion);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, promotion.PromotionId);
            }
        }

        public Tuple<bool, object> Delete(Guid promotionId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var promotion = context.Promotions
                    .Where(x => x.PromotionId.CompareTo(promotionId) == 0)
                    .FirstOrDefault();
                if (promotion == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + promotionId);
                }
                context.Promotions.DeleteOnSubmit(promotion);

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

        public Tuple<bool, object> Read(PromotionFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Promotions.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new PromotionModel()
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
                var result = new Paginator<PromotionModel>()
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
        private IQueryable<Promotion> GettingBy(IQueryable<Promotion> query, PromotionFilter filter)
        {
            if (filter.PromotionId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.PromotionId.CompareTo(filter.PromotionId) == 0);
            }
            return query;
        }

        private IQueryable<Promotion> Filtering(IQueryable<Promotion> query, PromotionFilter filter)
        {
            if (filter.IsActived.HasValue)
            {
                query = query.Where(x => x.IsActived.CompareTo(filter.IsActived) == 0);
            }
            if (filter.IsAutoApply.HasValue)
            {
                query = query.Where(x => x.IsAutoApply.CompareTo(filter.IsAutoApply) == 0);
            }
            if (filter.IsPercent.HasValue)
            {
                query = query.Where(x => x.PromotionId.CompareTo(filter.IsPercent) == 0);
            }
            query = query.Where(x => x.Value >= filter.ValueFrom);
            if (filter.ValueTo > filter.ValueFrom)
            {
                query = query.Where(x => x.Value <= filter.ValueTo);
            }
            query = query.Where(x => x.MinValue >= filter.MinValueFrom);
            if (filter.MinValueTo > filter.MinValueFrom)
            {
                query = query.Where(x => x.MinValue <= filter.MinValueTo);
            }
            if (filter.StartTimeFilter.HasValue)
            {
                query = query.Where(x => x.StartTime.CompareTo(filter.StartTimeFilter) >= 0);
            }
            if (filter.EndTimeFilter.HasValue)
            {
                query = query.Where(x => x.EndTime.CompareTo(filter.EndTimeFilter) <= 0);
            }
            if (filter.PromotionTypeId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.PromotionTypeId.CompareTo(filter.PromotionTypeId) == 0);
            }
            return query;
        }

        private IQueryable<Promotion> Searching(IQueryable<Promotion> query, PromotionFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.PromotionId.ToString().Contains(filter.Keyword) ||
                        x.Description.ToString().Contains(filter.Keyword) ||
                        x.CodeList.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.PromotionId.ToString().Equals(filter.Keyword) ||
                        x.Description.ToString().Equals(filter.Keyword) ||
                        x.CodeList.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Promotion> Paging(IQueryable<Promotion> query, PromotionFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Promotion> Sorting(IQueryable<Promotion> query, PromotionFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.StartTime);
            }
            else
            {
                query = query.OrderByDescending(x => x.StartTime);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(PromotionModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var promotion = context.Promotions
                    .Where(x => x.PromotionId.CompareTo(model.PromotionId) == 0)
                    .FirstOrDefault();
                if (promotion == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.PromotionId);
                }
                promotion.Description = model.Description;
                promotion.IsActived = (int)model.IsActived;
                promotion.IsAutoApply = (int)model.IsAutoApply;
                promotion.IsPercent = (int)model.IsPercent;
                promotion.Value = model.Value;
                promotion.MinValue = model.MinValue;
                promotion.CodeList = model.CodeList;
                promotion.StartTime = model.StartTime;
                promotion.EndTime = model.EndTime;
                promotion.PromotionTypeId = model.PromotionTypeId;

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
