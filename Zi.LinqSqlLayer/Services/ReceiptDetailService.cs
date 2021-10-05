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
    public class ReceiptDetailService : IReceiptDetailService
    {
        public bool AddReceiptDetail(ReceiptDetailDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var receiptDetail = new ReceiptDetail()
                {
                    ReceiptId = obj.ReceiptId,
                    MaterialId = obj.MaterialId,
                    Quantity = obj.Quantity,
                    ImportPrice = obj.ImportPrice
                };
                context.ReceiptDetails.InsertOnSubmit(receiptDetail);
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

        public bool DeleteReceiptDetail(Guid receiptId, Guid materialId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var receiptDetail = context.ReceiptDetails
                    .Where(x => x.ReceiptId.CompareTo(receiptId) == 0 && x.MaterialId.CompareTo(materialId) == 0)
                    .FirstOrDefault();
                context.ReceiptDetails.DeleteOnSubmit(receiptDetail);
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

        public Paginator<ReceiptDetailDTO> GetReceiptDetails(ReceiptDetailFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.ReceiptDetails;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new ReceiptDetailDTO()
                {
                    ReceiptId = x.ReceiptId,
                    MaterialId = x.MaterialId,
                    Quantity = x.Quantity,
                    ImportPrice = x.ImportPrice
                });
                var result = new Paginator<ReceiptDetailDTO>()
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
        private Table<ReceiptDetail> GettingBy(Table<ReceiptDetail> query, ReceiptDetailFilter filter)
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

        private Table<ReceiptDetail> Filtering(Table<ReceiptDetail> query, ReceiptDetailFilter filter)
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

        private Table<ReceiptDetail> Searching(Table<ReceiptDetail> query, ReceiptDetailFilter filter)
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

        private Table<ReceiptDetail> Paging(Table<ReceiptDetail> query, ReceiptDetailFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<ReceiptDetail> Sorting(Table<ReceiptDetail> query, ReceiptDetailFilter filter)
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

        public bool UpdateReceiptDetail(ReceiptDetailDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var receiptDetail = context.ReceiptDetails
                    .Where(x => x.ReceiptId.CompareTo(obj.ReceiptId) == 0 && x.MaterialId.CompareTo(obj.MaterialId) == 0)
                    .FirstOrDefault();
                receiptDetail.Quantity = obj.Quantity;
                receiptDetail.ImportPrice = obj.ImportPrice;
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
