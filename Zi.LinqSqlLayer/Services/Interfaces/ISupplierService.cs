using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface ISupplierService
    {
        Paginator<SupplierDTO> GetSuppliers(SupplierFilter filter);
        bool AddSupplier(SupplierDTO obj);
        bool UpdateSupplier(SupplierDTO obj);
        bool DeleteSupplier(Guid supplierId);
    }
}
