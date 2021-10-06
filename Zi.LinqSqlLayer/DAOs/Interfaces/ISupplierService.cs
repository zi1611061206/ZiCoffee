using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface ISupplierService
    {
        Tuple<bool, object> Read(SupplierFilter filter, string cultureName);
        Tuple<bool, object> Create(SupplierModel model, string cultureName);
        Tuple<bool, object> Update(SupplierModel model, string cultureName);
        Tuple<bool, object> Delete(Guid supplierId, string cultureName);
    }
}
