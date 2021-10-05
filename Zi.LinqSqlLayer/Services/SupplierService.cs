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
    public class SupplierService : ISupplierService
    {
        public bool AddSupplier(SupplierDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var supplier = new Supplier()
                {
                    SupplierId = obj.SupplierId,
                    Name = obj.Name,
                    Address = obj.Address,
                    PhoneNumber = obj.PhoneNumber,
                    Email = obj.Email
                };
                context.Suppliers.InsertOnSubmit(supplier);
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

        public bool DeleteSupplier(Guid supplierId)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var supplier = context.Suppliers.Where(x => x.SupplierId.CompareTo(supplierId) == 0).FirstOrDefault();
                context.Suppliers.DeleteOnSubmit(supplier);
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

        public Paginator<SupplierDTO> GetSuppliers(SupplierFilter filter)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var query = context.Suppliers;
                query = query.Count() > 0 ? GettingBy(query, filter) : query;
                query = query.Count() > 1 ? Searching(query, filter) : query;
                query = query.Count() > filter.PageSize ? Paging(query, filter) : query;
                query = query.Count() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new SupplierDTO()
                {
                    SupplierId = x.SupplierId,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    Email = x.Email
                });
                var result = new Paginator<SupplierDTO>()
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

        public bool UpdateSupplier(SupplierDTO obj)
        {
            using (var context = new ZiCoffeeDataContext())
            {
                var supplier = context.Suppliers.Where(x => x.SupplierId.CompareTo(obj.SupplierId) == 0).FirstOrDefault();
                supplier.Name = obj.Name;
                supplier.Address = obj.Address;
                supplier.PhoneNumber = obj.PhoneNumber;
                supplier.Email = obj.Email;
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
