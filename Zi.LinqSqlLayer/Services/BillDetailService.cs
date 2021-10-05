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
    public class BillDetailService : IBillDetailService
    {
        public bool AddBillDetail(BillDetailDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var billDetail = new BillDetail()
                {
                    BillId = obj.BillId,
                    ProductId = obj.ProductId,
                    Quantity = obj.Quantity,
                    IntoMoney = obj.IntoMoney
                };
                context.BillDetails.InsertOnSubmit(billDetail);
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

        public bool DeleteBillDetail(Guid billId, Guid productId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var billDetail = (from bd in context.BillDetails
                                  where bd.BillId.CompareTo(billId) == 0 && bd.ProductId.CompareTo(productId) == 0
                                  select bd).FirstOrDefault();
                context.BillDetails.DeleteOnSubmit(billDetail);
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

        public Paginator<BillDetailDTO> GetBillDetails(BillDetailFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.BillDetails;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new BillDetailDTO()
                {
                    BillId = x.BillId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    IntoMoney = x.IntoMoney
                });
                var result = new Paginator<BillDetailDTO>()
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
        private Table<BillDetail> GettingBy(Table<BillDetail> query, BillDetailFilter filter)
        {
            if (filter.BillId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.BillId.CompareTo(filter.BillId) == 0);
            }
            if (filter.ProductId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.ProductId.CompareTo(filter.ProductId) == 0);
            }
            return query;
        }

        private Table<BillDetail> Filtering(Table<BillDetail> query, BillDetailFilter filter)
        {
            query.Where(x => x.Quantity >= filter.QuantityMin);
            if (filter.QuantityMax > filter.QuantityMin)
            {
                query.Where(x => x.Quantity <= filter.QuantityMax);
            }
            query.Where(x => x.IntoMoney >= filter.IntoMoneyMin);
            if (filter.IntoMoneyMax > filter.IntoMoneyMin)
            {
                query.Where(x => x.IntoMoney <= filter.IntoMoneyMax);
            }
            return query;
        }

        private Table<BillDetail> Searching(Table<BillDetail> query, BillDetailFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.BillId.ToString().Contains(filter.Keyword) ||
                        x.ProductId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.BillId.ToString().Equals(filter.Keyword) ||
                        x.ProductId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<BillDetail> Paging(Table<BillDetail> query, BillDetailFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<BillDetail> Sorting(Table<BillDetail> query, BillDetailFilter filter)
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

        public bool UpdateBillDetail(BillDetailDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var billDetail = (from bd in context.BillDetails
                            where bd.BillId.CompareTo(obj.BillId) == 0 && bd.ProductId.CompareTo(obj.ProductId) == 0
                            select bd).FirstOrDefault();
                billDetail.Quantity = obj.Quantity;
                billDetail.IntoMoney = obj.IntoMoney;
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
