using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class ReceiptService : IReceiptService
    {
        #region Instance
        private static ReceiptService instance;
        public static ReceiptService Instance
        {
            get { if (instance == null) instance = new ReceiptService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private ReceiptService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(ReceiptModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var receipt = new Receipt()
                {
                    ReceiptId = model.ReceiptId,
                    SupplierId = model.SupplierId,
                    CreatedDate = DateTime.Now
                };
                context.Receipts.InsertOnSubmit(receipt);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, receipt.ReceiptId);
            }
        }

        public Tuple<bool, object> Delete(Guid receiptId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var receipt = context.Receipts
                    .Where(x => x.ReceiptId.CompareTo(receiptId) == 0)
                    .FirstOrDefault();
                if (receipt == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + receiptId);
                }
                context.Receipts.DeleteOnSubmit(receipt);

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

        public Tuple<bool, object> Read(ReceiptFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Receipts.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                int totalRecords = query.Select(x => x).ToList().Count();
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new ReceiptModel()
                {
                    ReceiptId = x.ReceiptId,
                    CreatedDate = x.CreatedDate,
                    SupplierId = x.SupplierId
                });
                var result = new Paginator<ReceiptModel>()
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
        private IQueryable<Receipt> GettingBy(IQueryable<Receipt> query, ReceiptFilter filter)
        {
            if (filter.ReceiptId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.ReceiptId.CompareTo(filter.ReceiptId) == 0);
            }
            return query;
        }

        private IQueryable<Receipt> Filtering(IQueryable<Receipt> query, ReceiptFilter filter)
        {
            if (filter.SupplierId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.SupplierId.CompareTo(filter.SupplierId) == 0);
            }
            query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateFrom) >= 0);
            if (DateTime.Compare(filter.CreatedDateTo, filter.CreatedDateFrom) > 0)
            {
                query = query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateTo) <= 0);
            }
            return query;
        }

        private IQueryable<Receipt> Searching(IQueryable<Receipt> query, ReceiptFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.ReceiptId.ToString().Contains(filter.Keyword) ||
                        x.SupplierId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.ReceiptId.ToString().Equals(filter.Keyword) ||
                        x.SupplierId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Receipt> Paging(IQueryable<Receipt> query, ReceiptFilter filter)
        {
            if (filter.PageSize != 0)
            {
                int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
                query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            }
            return query;
        }

        private IQueryable<Receipt> Sorting(IQueryable<Receipt> query, ReceiptFilter filter)
        {
            if (filter.IsAscending)
            {
                query = query.OrderBy(x => x.CreatedDate);
            }
            else
            {
                query = query.OrderByDescending(x => x.CreatedDate);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(ReceiptModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var receipt = context.Receipts
                    .Where(x => x.ReceiptId.CompareTo(model.ReceiptId) == 0)
                    .FirstOrDefault();
                if (receipt == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.ReceiptId);
                }

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
