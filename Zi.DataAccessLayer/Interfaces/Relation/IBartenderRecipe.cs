using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.Interfaces.Relation
{
    public interface IBartenderRecipe
    {
        bool AddBartenderRecipe(BartenderRecipe recipe);

        DataTable GetAllBartenderRecipe();

        DataTable GetAllBartenderRecipeOfService(int serviceId);

        DataTable GetAllBartenderRecipeOfMaterial(int materialId);

        bool UpdateBartenderRecipeQty(BartenderRecipe recipe);

        bool DeleteAllBartenderRecipe();

        bool DeleteBartenderRecipeById(int serviceId, int materialId);

        bool DeleteAllBartenderRecipeOfService(int serviceId);

        bool DeleteAllBartenderRecipeOfMaterial(int materialId);

        int CountAllBartenderRecipe();
    }
}
