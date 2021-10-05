using System;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Enumerators;
using Zi.LinqSqlLayer.Providers.LinqToSql;
using Zi.LinqSqlLayer.Services.Interfaces;

namespace Zi.LinqSqlLayer.Services
{
    public class BillService : IBillService
    {
        public bool AddBill(BillDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var bill = new Bill()
                {
                    BillId = obj.BillId,
                    Total = obj.Total,
                    Vat = obj.Vat,
                    AfterVat = obj.AfterVat,
                    RealPay = obj.RealPay,
                    Status = (int)obj.Status,
                    UserId = obj.UserId,
                    TableId = obj.TableId
                };
                context.Bills.InsertOnSubmit(bill);
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

        public bool DeleteBill(Guid billId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var bill = context.Bills.Where(x=>x.BillId.CompareTo(billId)==0).FirstOrDefault();
                context.Bills.DeleteOnSubmit(bill);
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

        public Paginator<BillDTO> GetBills(BillFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Bills;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Filtering(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new BillDTO()
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
                var result = new Paginator<BillDTO>()
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
        private Table<Bill> GettingBy(Table<Bill> query, BillFilter filter)
        {
            if (filter.BillId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.BillId.CompareTo(filter.BillId) == 0);
            }
            return query;
        }

        private Table<Bill> Filtering(Table<Bill> query, BillFilter filter)
        {
            query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateFrom) >= 0);
            if (DateTime.Compare(filter.LastedModifyTo, filter.LastedModifyFrom) > 0)
            {
                query.Where(x => x.CreatedDate.CompareTo(filter.CreatedDateTo) <= 0);
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
            query.Where(x => x.LastedModify.CompareTo(filter.LastedModifyFrom) >= 0);
            if (DateTime.Compare(filter.LastedModifyTo, filter.LastedModifyFrom) > 0)
            {
                query.Where(x => x.LastedModify.CompareTo(filter.LastedModifyTo) <= 0);
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

        private Table<Bill> Searching(Table<Bill> query, BillFilter filter)
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

        private Table<Bill> Paging(Table<Bill> query, BillFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Bill> Sorting(Table<Bill> query, BillFilter filter)
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

        public bool UpdateBill(BillDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var bill = context.Bills.Where(x => x.BillId.CompareTo(obj.BillId) == 0).FirstOrDefault();
                bill.Total = obj.Total;
                bill.Vat = obj.Vat;
                bill.AfterVat = obj.AfterVat;
                bill.RealPay = obj.RealPay;
                bill.Status = (int)obj.Status;
                bill.LastedModify = obj.LastedModify;
                bill.UserId = obj.UserId;
                bill.TableId = obj.TableId;
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
