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
    public class BillDetailService : IBillDetailService
    {
        public async Task<bool> AddBillDetail(BillDetail billDetail)
        {
            using (var context = new ZiDbContext())
            {
                context.BillDetails.Add(billDetail);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteBillDetail(Guid billId, Guid productId)
        {
            using (var context = new ZiDbContext())
            {
                var billDetail = (from bd in context.BillDetails
                                where bd.BillId.CompareTo(billId) == 0 && bd.ProductId.CompareTo(productId) == 0
                                select bd).First();
                context.BillDetails.Remove(billDetail);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<BillDetail> GetBillDetails(BillDetailFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.BillDetails;
                query = GettingBy(query, filter);
                query = Filtering(query, filter);
                query = Searching(query, filter);
                query = Paging(query, filter);
                query = Sorting(query, filter);
                // Mapping data
                var data = query.Select(x => new BillDetail()
                {
                    BillId = x.BillId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    IntoMoney = x.IntoMoney
                });
                var result = new Paginator<BillDetail>()
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
        private DbSet<BillDetail> GettingBy(DbSet<BillDetail> query, BillDetailFilter filter)
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

        private DbSet<BillDetail> Filtering(DbSet<BillDetail> query, BillDetailFilter filter)
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

        private DbSet<BillDetail> Searching(DbSet<BillDetail> query, BillDetailFilter filter)
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

        private DbSet<BillDetail> Paging(DbSet<BillDetail> query, BillDetailFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<BillDetail> Sorting(DbSet<BillDetail> query, BillDetailFilter filter)
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

        public async Task<bool> UpdateBillDetail(BillDetail billDetail)
        {
            using (var context = new ZiDbContext())
            {
                var data = (from bd in context.BillDetails
                                  where bd.BillId.CompareTo(billDetail.BillId) == 0 && bd.ProductId.CompareTo(billDetail.ProductId) == 0
                                  select bd).First();
                data.Quantity = billDetail.Quantity;
                data.IntoMoney = billDetail.IntoMoney;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
