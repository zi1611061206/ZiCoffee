using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.LinqToEntityLayer.Engines.Filters;
using Zi.LinqToEntityLayer.Engines.Paginators;

namespace Zi.LinqToEntityLayer.Services.Interfaces
{
    public interface IAreaService
    {
        Task<Paginator<Area>> GetAreas(AreaFilter filter);
        Task<bool> AddArea(Area area);
        Task<bool> UpdateArea(Area area);
        Task<bool> DeleteArea(Guid areaId);
    }
}
