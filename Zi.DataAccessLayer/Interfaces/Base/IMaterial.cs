using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.Interfaces.Base
{
    public interface IMaterial
    {
        bool AddMaterial(Material material);

        DataTable GetAllMaterial();

        Material GetMaterialById(int materialId);

        bool UpdateMaterial(Material material);

        bool DeleteAllMaterial();

        bool DeleteMaterialById(int materialId);

        bool CheckMaterialName(string materialName);

        int CountAllMaterial();

        DataTable SearchMaterial(string materialName);
    }
}
