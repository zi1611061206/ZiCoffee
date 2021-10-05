using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class ReceiptService : IReceiptService
    {
        public bool AddReceipt(ReceiptDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var receipt = new Receipt()
                {
                    ReceiptId = obj.ReceiptId,
                    SupplierId = obj.SupplierId
                };
                context.Receipts.InsertOnSubmit(receipt);
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

        public bool DeleteReceipt(Guid receiptId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var receipt = context.Receipts.Where(x => x.ReceiptId.CompareTo(receiptId) == 0).FirstOrDefault();
                context.Receipts.DeleteOnSubmit(receipt);
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

        public Paginator<ReceiptDTO> GetReceipts(ReceiptFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Receipts;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new ReceiptDTO()
                {
                    ReceiptId = x.ReceiptId,
                    CreatedDate = x.CreatedDate,
                    SupplierId = x.SupplierId
                });
                var result = new Paginator<ReceiptDTO>()
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
        private Table<Receipt> GettingBy(Table<Receipt> query, ReceiptFilter filter)
        {
            if (filter.ReceiptId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.ReceiptId.CompareTo(filter.ReceiptId) == 0);
            }
            return query;
        }

        private Table<Receipt> Filtering(Table<Receipt> query, ReceiptFilter filter)
        {
            if (filter.SupplierId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.SupplierId.CompareTo(filter.SupplierId) == 0);
            }
            query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateFrom) >= 0);
            if (DateTime.Compare(filter.CreatedDateTo, filter.CreatedDateFrom) > 0)
            {
                query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateTo) <= 0);
            }
            return query;
        }

        private Table<Receipt> Searching(Table<Receipt> query, ReceiptFilter filter)
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

        private Table<Receipt> Paging(Table<Receipt> query, ReceiptFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Receipt> Sorting(Table<Receipt> query, ReceiptFilter filter)
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

        public bool UpdateReceipt(ReceiptDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var receipt = context.Receipts.Where(x => x.ReceiptId.CompareTo(obj.ReceiptId) == 0).FirstOrDefault();
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
