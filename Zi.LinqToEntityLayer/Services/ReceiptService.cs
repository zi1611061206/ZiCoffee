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
    public class ReceiptService : IReceiptService
    {
        public async Task<bool> AddReceipt(Receipt receipt)
        {
            using (var context = new ZiDbContext())
            {
                context.Receipts.Add(receipt);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteReceipt(Guid receiptId)
        {
            using (var context = new ZiDbContext())
            {
                var receipt = await context.Receipts.FindAsync(receiptId);
                context.Receipts.Remove(receipt);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Paginator<Receipt> GetReceipts(ReceiptFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Receipts;
                query = GettingBy(query, filter);
                query = Filtering(query, filter);
                query = Searching(query, filter);
                query = Paging(query, filter);
                query = Sorting(query, filter);
                // Mapping data
                var data = query.Select(x => new Receipt()
                {
                    ReceiptId = x.ReceiptId,
                    CreatedDate = x.CreatedDate,
                    SupplierId = x.SupplierId
                });
                var result = new Paginator<Receipt>()
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
        private DbSet<Receipt> GettingBy(DbSet<Receipt> query, ReceiptFilter filter)
        {
            if (filter.ReceiptId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.ReceiptId.CompareTo(filter.ReceiptId) == 0);
            }
            return query;
        }

        private DbSet<Receipt> Filtering(DbSet<Receipt> query, ReceiptFilter filter)
        {
            if (filter.SupplierId.CompareTo(Guid.Empty)!=0)
            {
                query.Where(x => x.SupplierId.CompareTo(filter.SupplierId)==0);
            }
            if (filter.CreatedDateFrom.HasValue && filter.CreatedDateTo.HasValue)
            {
                query.Where(
                    x => x.CreatedDate.CompareTo(filter.CreatedDateFrom) >= 0
                    && x.CreatedDate.CompareTo(filter.CreatedDateTo) <= 0);
            }
            return query;
        }

        private DbSet<Receipt> Searching(DbSet<Receipt> query, ReceiptFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.ReceiptId.ToString().Contains(filter.Keyword) ||
                        x.SupplierId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.ReceiptId.ToString().Equals(filter.Keyword) ||
                        x.SupplierId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<Receipt> Paging(DbSet<Receipt> query, ReceiptFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Receipt> Sorting(DbSet<Receipt> query, ReceiptFilter filter)
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

        public async Task<bool> UpdateReceipt(Receipt receipt)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Receipts.FindAsync(receipt.ReceiptId);
                data.SupplierId = receipt.SupplierId;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
