using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.Interfaces.Base
{
    public interface IArea
    {
        bool AddArea(Area area);

        DataTable GetAllArea();

        Area GetAreaById(int areaId);

        bool UpdateArea(Area area);

        bool DeleteAllArea();

        bool DeleteAreaById(int areaId);

        bool CheckAreaName(string areaName);

        int CountAllArea();

        DataTable SearchArea(string areaName);
    }
}
