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
    public class DiscountDetailService : IDiscountDetailService
    {
        #region Instance
        private static DiscountDetailService instance;
        public static DiscountDetailService Instance
        {
            get { if (instance == null) instance = new DiscountDetailService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private DiscountDetailService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(DiscountDetailModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var discountDetail = new DiscountDetail()
                {
                    BillId = model.BillId,
                    PromotionId = model.PromotionId
                };
                context.DiscountDetails.InsertOnSubmit(discountDetail);

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

        public Tuple<bool, object> Delete(Guid billId, Guid promotionId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var discountDetail = context.DiscountDetails
                    .Where(x => x.BillId.CompareTo(billId) == 0 && x.PromotionId.CompareTo(promotionId) == 0)
                    .FirstOrDefault();
                if (discountDetail == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture));
                }
                context.DiscountDetails.DeleteOnSubmit(discountDetail);

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

        public Tuple<bool, object> Read(DiscountDetailFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.DiscountDetails.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new DiscountDetailModel()
                {
                    BillId = x.BillId,
                    PromotionId = x.PromotionId
                });
                var result = new Paginator<DiscountDetailModel>()
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
        private IQueryable<DiscountDetail> GettingBy(IQueryable<DiscountDetail> query, DiscountDetailFilter filter)
        {
            if (filter.BillId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.BillId.CompareTo(filter.BillId) == 0);
            }
            if (filter.PromotionId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.PromotionId.CompareTo(filter.PromotionId) == 0);
            }
            return query;
        }

        private IQueryable<DiscountDetail> Searching(IQueryable<DiscountDetail> query, DiscountDetailFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.BillId.ToString().Contains(filter.Keyword) ||
                        x.PromotionId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.BillId.ToString().Equals(filter.Keyword) ||
                        x.PromotionId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<DiscountDetail> Paging(IQueryable<DiscountDetail> query, DiscountDetailFilter filter)
        {
            if (filter.PageSize != 0)
            {
                int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
                query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            }
            return query;
        }

        private IQueryable<DiscountDetail> Sorting(IQueryable<DiscountDetail> query, DiscountDetailFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.BillId);
            }
            else
            {
                query = query.OrderByDescending(x => x.BillId);
            }
            return query;
        }
        #endregion
    }
}
