using System;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.DAOs.Interfaces
{
    public interface IAreaService
    {
        Tuple<bool, object> Read(AreaFilter filter, string cultureName);
        Tuple<bool, object> Create(AreaModel model, string cultureName);
        Tuple<bool, object> Update(AreaModel model, string cultureName);
        Tuple<bool, object> Delete(Guid areaId, string cultureName);
    }
}
