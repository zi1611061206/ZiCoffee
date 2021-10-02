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
    public class ReceiptDetailService : IReceiptDetailService
    {
        public async Task<bool> AddReceiptDetail(ReceiptDetail receiptDetail)
        {
            using (var context = new ZiDbContext())
            {
                context.ReceiptDetails.Add(receiptDetail);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteReceiptDetail(Guid receiptId, Guid materialId)
        {
            using (var context = new ZiDbContext())
            {
                var receiptDetail = (from detail in context.ReceiptDetails
                                     where detail.ReceiptId.CompareTo(receiptId) == 0 && detail.MaterialId.CompareTo(materialId) == 0
                                     select detail).First();
                context.ReceiptDetails.Remove(receiptDetail);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<ReceiptDetail>> GetReceiptDetails(ReceiptDetailFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.ReceiptDetails;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Filtering(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new ReceiptDetail()
                {
                    ReceiptId = x.ReceiptId,
                    MaterialId = x.MaterialId,
                    Quantity = x.Quantity,
                    ImportPrice = x.ImportPrice
                });
                var result = new Paginator<ReceiptDetail>()
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
        private DbSet<ReceiptDetail> GettingBy(DbSet<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            if (filter.ReceiptId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.ReceiptId.CompareTo(filter.ReceiptId) == 0);
            }
            if (filter.MaterialId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.MaterialId.CompareTo(filter.MaterialId) == 0);
            }
            return query;
        }

        private DbSet<ReceiptDetail> Filtering(DbSet<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            query.Where(x => x.Quantity >= filter.QuantityMin);
            if (filter.QuantityMax > filter.QuantityMin)
            {
                query.Where(x => x.Quantity <= filter.QuantityMax);
            }
            query.Where(x => x.ImportPrice >= filter.ImportPriceMin);
            if (filter.ImportPriceMax > filter.ImportPriceMin)
            {
                query.Where(x => x.ImportPrice <= filter.ImportPriceMax);
            }
            return query;
        }

        private DbSet<ReceiptDetail> Searching(DbSet<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.ReceiptId.ToString().Contains(filter.Keyword) ||
                        x.MaterialId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.ReceiptId.ToString().Equals(filter.Keyword) ||
                        x.MaterialId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private DbSet<ReceiptDetail> Paging(DbSet<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<ReceiptDetail> Sorting(DbSet<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.ReceiptId);
            }
            else
            {
                query.OrderByDescending(x => x.ReceiptId);
            }
            return query;
        }
        #endregion

        public async Task<bool> UpdateReceiptDetail(ReceiptDetail receiptDetail)
        {
            using (var context = new ZiDbContext())
            {
                var data = (from detail in context.ReceiptDetails
                            where detail.ReceiptId.CompareTo(receiptDetail.ReceiptId) == 0 && detail.MaterialId.CompareTo(receiptDetail.MaterialId) == 0
                            select detail).First();
                data.Quantity = receiptDetail.Quantity;
                data.ImportPrice = receiptDetail.ImportPrice;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
