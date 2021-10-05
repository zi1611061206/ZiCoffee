using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class DiscountDetailService : IDiscountDetailService
    {
        public bool AddDiscountDetail(DiscountDetailDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var discountDetail = new DiscountDetail()
                {
                    BillId = obj.BillId,
                    PromotionId = obj.PromotionId
                };
                context.DiscountDetails.InsertOnSubmit(discountDetail);
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

        public bool DeleteDiscountDetail(Guid billId, Guid promotionId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var discountDetail = context.DiscountDetails
                    .Where(x => x.BillId.CompareTo(billId) == 0 && x.PromotionId.CompareTo(promotionId) == 0)
                    .FirstOrDefault();
                context.DiscountDetails.DeleteOnSubmit(discountDetail);
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

        public Paginator<DiscountDetailDTO> GetDiscountDetails(DiscountDetailFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.DiscountDetails;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new DiscountDetailDTO()
                {
                    BillId = x.BillId,
                    PromotionId = x.PromotionId
                });
                var result = new Paginator<DiscountDetailDTO>()
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
        private Table<DiscountDetail> GettingBy(Table<DiscountDetail> query, DiscountDetailFilter filter)
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

        private Table<DiscountDetail> Searching(Table<DiscountDetail> query, DiscountDetailFilter filter)
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

        private Table<DiscountDetail> Paging(Table<DiscountDetail> query, DiscountDetailFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<DiscountDetail> Sorting(Table<DiscountDetail> query, DiscountDetailFilter filter)
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
