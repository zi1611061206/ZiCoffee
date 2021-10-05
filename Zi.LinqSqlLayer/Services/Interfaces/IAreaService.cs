using System;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IAreaService
    {
        Paginator<AreaDTO> GetAreas(AreaFilter filter);
        bool AddArea(AreaDTO obj);
        bool UpdateArea(AreaDTO obj);
        bool DeleteArea(Guid areaId);
    }
}
