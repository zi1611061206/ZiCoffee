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
    public interface IMaterialService
    {
        Paginator<Material> GetMaterials(MaterialFilter filter);
        Task<bool> AddMaterial(Material material);
        Task<bool> UpdateMaterial(Material material);
        Task<bool> DeleteMaterial(Guid materialId);
    }
}
