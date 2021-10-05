using System;
using System.Threading.Tasks;
using Zi.LinqSqlLayer.DTOs;
using Zi.LinqSqlLayer.Engines.Filters;
using Zi.LinqSqlLayer.Engines.Paginators;

namespace Zi.LinqSqlLayer.Services.Interfaces
{
    public interface IMaterialService
    {
        Paginator<MaterialDTO> GetMaterials(MaterialFilter filter);
        bool AddMaterial(MaterialDTO obj);
        bool UpdateMaterial(MaterialDTO obj);
        bool DeleteMaterial(Guid materialId);
    }
}
