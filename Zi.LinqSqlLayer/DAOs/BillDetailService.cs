using System;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs.Relationship;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class BillDetailService : IBillDetailService
    {
        #region Instance
        private static BillDetailService instance;
        public static BillDetailService Instance
        {
            get { if (instance == null) instance = new BillDetailService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private BillDetailService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(BillDetailModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var billDetail = new BillDetail()
                {
                    BillId = model.BillId,
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    IntoMoney = model.IntoMoney
                };
                context.BillDetails.InsertOnSubmit(billDetail);

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

        public Tuple<bool, object> Delete(Guid billId, Guid productId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var billDetail = context.BillDetails
                    .Where(x => x.BillId.CompareTo(billId) == 0 && x.ProductId.CompareTo(productId) == 0)
                    .FirstOrDefault();
                context.BillDetails.DeleteOnSubmit(billDetail);

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

        public Tuple<bool, object> Read(BillDetailFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.BillDetails;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new BillDetailModel()
                {
                    BillId = x.BillId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    IntoMoney = x.IntoMoney
                });
                var result = new Paginator<BillDetailModel>()
                {
                    TotalRecords = data.Count(),
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

        public Tuple<bool, object> Update(BillDetailModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var billDetail = context.BillDetails
                    .Where(x => x.BillId.CompareTo(model.BillId) == 0 && x.ProductId.CompareTo(model.ProductId) == 0)
                    .FirstOrDefault();
                billDetail.Quantity = model.Quantity;
                billDetail.IntoMoney = model.IntoMoney;

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
