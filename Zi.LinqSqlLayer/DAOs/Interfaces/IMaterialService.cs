using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IMaterialService
    {
        Tuple<bool, object> Read(MaterialFilter filter, string cultureName);
        Tuple<bool, object> Create(MaterialModel model, string cultureName);
        Tuple<bool, object> Update(MaterialModel model, string cultureName);
        Tuple<bool, object> Delete(Guid materialId, string cultureName);
    }
}
