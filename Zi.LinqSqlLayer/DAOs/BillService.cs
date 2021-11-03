using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.DAOs
{
    public class BillService : IBillService
    {
        #region Instance
        private static BillService instance;
        public static BillService Instance
        {
            get { if (instance == null) instance = new BillService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private BillService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(BillModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var bill = new Bill()
                {
                    BillId = model.BillId,
                    Total = model.Total,
                    Vat = model.Vat,
                    AfterVat = model.AfterVat,
                    RealPay = model.RealPay,
                    Status = (int)model.Status,
                    UserId = model.UserId,
                    TableId = model.TableId,
                    CreatedDate = DateTime.Now,
                    LastedModify = DateTime.Now
                };
                context.Bills.InsertOnSubmit(bill);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, bill.BillId);
            }
        }

        public Tuple<bool, object> Delete(Guid billId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var bill = context.Bills
                    .Where(x => x.BillId.CompareTo(billId) == 0)
                    .FirstOrDefault();
                if (bill == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + billId);
                }
                context.Bills.DeleteOnSubmit(bill);

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

        public Tuple<bool, object> Read(BillFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Bills.Where(x => true);
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new BillModel()
                {
                    BillId = x.BillId,
                    CreatedDate = x.CreatedDate,
                    Total = x.Total,
                    Vat = x.Vat,
                    AfterVat = x.AfterVat,
                    RealPay = x.RealPay,
                    Status = (BillStatus)x.Status,
                    LastedModify = x.LastedModify,
                    UserId = x.UserId,
                    TableId = x.TableId
                });
                var result = new Paginator<BillModel>()
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
        private IQueryable<Bill> GettingBy(IQueryable<Bill> query, BillFilter filter)
        {
            if (filter.BillId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.BillId.CompareTo(filter.BillId) == 0);
            }
            return query;
        }

        private IQueryable<Bill> Filtering(IQueryable<Bill> query, BillFilter filter)
        {
            query = query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateFrom) >= 0);
            if (DateTime.Compare(filter.LastedModifyTo, filter.LastedModifyFrom) > 0)
            {
                query = query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateTo) <= 0);
            }
            query = query.Where(x => x.Total >= filter.TotalMin);
            if (filter.TotalMax > filter.TotalMin)
            {
                query = query.Where(x => x.Total <= filter.TotalMax);
            }
            query = query.Where(x => x.Vat >= filter.VatMin);
            if (filter.VatMax > filter.VatMin)
            {
                query = query.Where(x => x.Vat <= filter.VatMax);
            }
            query = query.Where(x => x.AfterVat >= filter.AfterVatMin);
            if (filter.AfterVatMax > filter.AfterVatMin)
            {
                query = query.Where(x => x.AfterVat <= filter.AfterVatMax);
            }
            query = query.Where(x => x.RealPay >= filter.RealPayMin);
            if (filter.RealPayMax > filter.RealPayMin)
            {
                query = query.Where(x => x.RealPay <= filter.RealPayMax);
            }
            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.Status.CompareTo(filter.Status) == 0);
            }
            query = query.Where(x => x.LastedModify.CompareTo(filter.LastedModifyFrom) >= 0);
            if (DateTime.Compare(filter.LastedModifyTo, filter.LastedModifyFrom) > 0)
            {
                query = query.Where(x => x.LastedModify.CompareTo(filter.LastedModifyTo) <= 0);
            }
            if (filter.UserId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.UserId.CompareTo(filter.UserId) == 0);
            }
            if (filter.TableId.CompareTo(Guid.Empty) != 0)
            {
                query = query.Where(x => x.TableId.CompareTo(filter.TableId) == 0);
            }
            return query;
        }

        private IQueryable<Bill> Searching(IQueryable<Bill> query, BillFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query = query.Where(x => x.BillId.ToString().Contains(filter.Keyword) ||
                        x.UserId.ToString().Contains(filter.Keyword) ||
                        x.TableId.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query = query.Where(x => x.BillId.ToString().Equals(filter.Keyword) ||
                        x.UserId.ToString().Equals(filter.Keyword) ||
                        x.TableId.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private IQueryable<Bill> Paging(IQueryable<Bill> query, BillFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query = query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private IQueryable<Bill> Sorting(IQueryable<Bill> query, BillFilter filter)
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

        public Tuple<bool, object> Update(BillModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var bill = context.Bills
                    .Where(x => x.BillId.CompareTo(model.BillId) == 0)
                    .FirstOrDefault();
                if (bill == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.BillId);
                }
                bill.Total = model.Total;
                bill.Vat = model.Vat;
                bill.AfterVat = model.AfterVat;
                bill.RealPay = model.RealPay;
                bill.Status = (int)model.Status;
                bill.LastedModify = DateTime.Now;
                bill.UserId = model.UserId;
                bill.TableId = model.TableId;

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
