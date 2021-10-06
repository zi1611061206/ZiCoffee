using System;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DAOs.Interfaces;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;
using Zi.LinqSqlLayer.Providers.LinqToSql;

namespace Zi.LinqSqlLayer.DAOs
{
    public class SupplierService : ISupplierService
    {
        #region Instance
        private static SupplierService instance;
        public static SupplierService Instance
        {
            get { if (instance == null) instance = new SupplierService(); return instance; }
            private set { instance = value; }
        }
        public ResourceManager Rm { get; set; }
        private SupplierService()
        {
            string BaseName = "Zi.LinqSqlLayer.Engines.Translators.MsgResource";
            Rm = new ResourceManager(BaseName, typeof(AreaService).Assembly);
        }
        #endregion

        public Tuple<bool, object> Create(SupplierModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var supplier = new Supplier()
                {
                    SupplierId = model.SupplierId,
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };
                context.Suppliers.InsertOnSubmit(supplier);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("FailedCreate", culture) + ":" + ex.Message);
                }
                return new Tuple<bool, object>(true, supplier.SupplierId);
            }
        }

        public Tuple<bool, object> Delete(Guid supplierId, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var supplier = context.Suppliers
                    .Where(x => x.SupplierId.CompareTo(supplierId) == 0)
                    .FirstOrDefault();
                if (supplier == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + supplierId);
                }
                context.Suppliers.DeleteOnSubmit(supplier);

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

        public Tuple<bool, object> Read(SupplierFilter filter, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Suppliers;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new SupplierModel()
                {
                    SupplierId = x.SupplierId,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    Email = x.Email
                });
                var result = new Paginator<SupplierModel>()
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
        private Table<Supplier> GettingBy(Table<Supplier> query, SupplierFilter filter)
        {
            if (filter.SupplierId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.SupplierId.CompareTo(filter.SupplierId) == 0);
            }
            return query;
        }

        private Table<Supplier> Searching(Table<Supplier> query, SupplierFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                if (filter.IsRoughly)
                {
                    query.Where(x => x.SupplierId.ToString().Contains(filter.Keyword) ||
                        x.Name.ToString().Contains(filter.Keyword) ||
                        x.PhoneNumber.ToString().Contains(filter.Keyword) ||
                        x.Address.ToString().Contains(filter.Keyword) ||
                        x.Email.ToString().Contains(filter.Keyword));
                }
                else
                {
                    query.Where(x => x.SupplierId.ToString().Equals(filter.Keyword) ||
                        x.Name.ToString().Equals(filter.Keyword) ||
                        x.PhoneNumber.ToString().Equals(filter.Keyword) ||
                        x.Address.ToString().Equals(filter.Keyword) ||
                        x.Email.ToString().Equals(filter.Keyword));
                }
            }
            return query;
        }

        private Table<Supplier> Paging(Table<Supplier> query, SupplierFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private Table<Supplier> Sorting(Table<Supplier> query, SupplierFilter filter)
        {
            if (filter.IsAscending)
            {
                query.OrderBy(x => x.Name);
            }
            else
            {
                query.OrderByDescending(x => x.Name);
            }
            return query;
        }
        #endregion

        public Tuple<bool, object> Update(SupplierModel model, string cultureName)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            using (var context = new ZiCoffeeDataContext())
            {
                var supplier = context.Suppliers
                    .Where(x => x.SupplierId.CompareTo(model.SupplierId) == 0)
                    .FirstOrDefault();
                if (supplier == null)
                {
                    return new Tuple<bool, object>(false, Rm.GetString("NotFound", culture) + " " + model.SupplierId);
                }
                supplier.Name = model.Name;
                supplier.Address = model.Address;
                supplier.PhoneNumber = model.PhoneNumber;
                supplier.Email = model.Email;

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
