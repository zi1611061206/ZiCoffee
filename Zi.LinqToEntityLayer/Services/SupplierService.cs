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
    public class SupplierService : ISupplierService
    {
        public async Task<bool> AddSupplier(Supplier supplier)
        {
            using (var context = new ZiDbContext())
            {
                context.Suppliers.Add(supplier);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> DeleteSupplier(Guid supplierId)
        {
            using (var context = new ZiDbContext())
            {
                var supplier = await context.Suppliers.FindAsync(supplierId);
                context.Suppliers.Remove(supplier);
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<Paginator<Supplier>> GetSuppliers(SupplierFilter filter)
        {
            using (var context = new ZiDbContext())
            {
                var query = context.Suppliers;
                query = await query.CountAsync() > 0 ? GettingBy(query, filter) : query;
                query = await query.CountAsync() > 1 ? Searching(query, filter) : query;
                query = await query.CountAsync() > filter.PageSize ? Paging(query, filter) : query;
                query = await query.CountAsync() > 1 ? Sorting(query, filter) : query;
                // Mapping data
                var data = query.Select(x => new Supplier()
                {
                    SupplierId = x.SupplierId,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    Email = x.Email
                });
                var result = new Paginator<Supplier>()
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
        private DbSet<Supplier> GettingBy(DbSet<Supplier> query, SupplierFilter filter)
        {
            if (filter.SupplierId.CompareTo(Guid.Empty) != 0)
            {
                query.Where(x => x.SupplierId.CompareTo(filter.SupplierId) == 0);
            }
            return query;
        }

        private DbSet<Supplier> Searching(DbSet<Supplier> query, SupplierFilter filter)
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

        private DbSet<Supplier> Paging(DbSet<Supplier> query, SupplierFilter filter)
        {
            int firstIndexOfPage = (filter.CurrentPageIndex - 1) * filter.PageSize;
            query.Skip(firstIndexOfPage).Take(filter.PageSize);
            return query;
        }

        private DbSet<Supplier> Sorting(DbSet<Supplier> query, SupplierFilter filter)
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

        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            using (var context = new ZiDbContext())
            {
                var data = await context.Suppliers.FindAsync(supplier.SupplierId);
                data.Name = supplier.Name;
                data.Address = supplier.Address;
                data.PhoneNumber = supplier.PhoneNumber;
                data.Email = supplier.Email;
                if (await context.SaveChangesAsync() <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
