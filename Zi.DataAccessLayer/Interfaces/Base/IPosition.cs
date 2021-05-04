using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.Interfaces.Base
{
    public interface IPosition
    {
        bool AddPosition(Position position);

        DataTable GetAllPosition();

        Position  GetPositionById(int positionId);

        bool UpdatePosition(Position position);

        bool DeleteAllPosition();

        bool DeletePositionById(int positionId);

        bool CheckPositionName(string positionName);

        int CountAllPosition();

        DataTable SearchPosition(string positionName);
    }
}
