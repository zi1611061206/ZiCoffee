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
    public class BillService : IBillService
    {
        public async Task<bool> AddBill(Bill bill)
        {
            using (var context = new ZiDbContext())
            {
                context.Bills.Add(bill);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteBill(Guid billId)
        {
            using (var context = new ZiDbContext())
            {
                var bill = await context.Bills.FindAsync(billId);
                context.Bills.Remove(bill);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<Bill> GetBills(BillFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Bills;
                query = GettingBy(query, filter);
                query = Filtering(query, filter);
                query = Searching(query, filter);
                query = Paging(query, filter);
                query = Sorting(query, filter);
                // Mapping data
                var data = query.Select(x => new Bill()
                {
                    BillId = x.BillId,
                    CreatedDate = x.CreatedDate,
                    Total = x.Total,
                    Vat = x.Vat,
                    AfterVat = x.AfterVat,
                    RealPay = x.RealPay,
                    Status = x.Status,
                    LastedModify = x.LastedModify,
                    UserId = x.UserId,
                    TableId = x.TableId
                });
                var result = new Paginator<Bill>()
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
        private DbSet<Bill> GettingBy(DbSet<Bill> query, BillFilter filter)
        {
            if (filter.BillId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.BillId.CompareTo(filter.BillId) == 0);
            }
            return query;
        }

        private DbSet<Bill> Filtering(DbSet<Bill> query, BillFilter filter)
        {
            if (filter.CreatedDateFrom.HasValue && filter.CreatedDateTo.HasValue)
            {
                query.Where(
                    x => x.CreatedDate.CompareTo(filter.CreatedDateFrom) >= 0
                    && x.CreatedDate.CompareTo(filter.CreatedDateTo) <= 0);
            }
            query.Where(x => x.Total >= filter.TotalMin);
            if (filter.TotalMax > filter.TotalMin)
            {
                query.Where(x => x.Total <= filter.TotalMax);
            }
            query.Where(x => x.Vat >= filter.VatMin);
            if (filter.VatMax > filter.VatMin)
            {
                query.Where(x => x.Vat <= filter.VatMax);
            }
            query.Where(x => x.AfterVat >= filter.AfterVatMin);
            if (filter.AfterVatMax > filter.AfterVatMin)
            {
                query.Where(x => x.AfterVat <= filter.AfterVatMax);
            }
            query.Where(x => x.RealPay >= filter.RealPayMin);
            if (filter.RealPayMax > filter.RealPayMin)
            {
                query.Where(x => x.RealPay <= filter.RealPayMax);
            }
            if (filter.Status.HasValue)
            {
                query.Where(x => x.Status.CompareTo(filter.Status) == 0);
            }
            if (filter.LastedModifyFrom.HasValue && filter.LastedModifyTo.HasValue)
            {
                query.Where(
                    x => x.LastedModify.CompareTo(filter.LastedModifyFrom) >= 0
                    && x.LastedModify.CompareTo(filter.LastedModifyTo) <= 0);
            }
            if (filter.UserId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.UserId.CompareTo(filter.UserId) == 0);
            }
            if (filter.TableId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.TableId.CompareTo(filter.TableId) == 0);
            }
            return query;
        }

        private DbSet<Bill> Searching(DbSet<Bill> query, BillFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.BillId.ToString().Contains(filter.Keyword) ||
                        x.UserId.ToString().Contains(filter.Keyword) ||
                        x.TableId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.BillId.ToString().Equals(filter.Keyword) ||
                        x.UserId.ToString().Equals(filter.Keyword) ||
                        x.TableId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<Bill> Paging(DbSet<Bill> query, BillFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Bill> Sorting(DbSet<Bill> query, BillFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.CreatedDate);
            }
            else
            {
                query.OrderByDescending(x => x.CreatedDate);
            }
            return query;
        }
        #endregion

        public async Task<bool> UpdateBill(Bill bill)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Bills.FindAsync(bill.BillId);
                data.Total = bill.Total;
                data.Vat = bill.Vat;
                data.AfterVat = bill.AfterVat;
                data.RealPay = bill.RealPay;
                data.Status = bill.Status;
                data.LastedModify = bill.LastedModify;
                data.UserId = bill.UserId;
                data.TableId = bill.TableId;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
