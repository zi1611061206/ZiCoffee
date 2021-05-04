using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class Position
    {
        private int positionId;
        private string positionName;

        public int PositionId { get => positionId; set => positionId = value; }
        public string PositionName { get => positionName; set => positionName = value; }

        public Position(int positionId, string positionName)
        {
            PositionId = positionId;
            PositionName = positionName;
        }

        public Position(DataRow row)
        {
            PositionId = (int)row["MaChucVu"];
            PositionName = row["TenChucVu"].ToString();
        }
    }
}
