using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Services.Interfaces
{
    public interface ISupplierService
    {
        Paginator<Supplier> GetSuppliers(SupplierFilter filter);
        Task<bool> AddSupplier(Supplier supplier);
        Task<bool> UpdateSupplier(Supplier supplier);
        Task<bool> DeleteSupplier(Guid supplierId);
    }
}
