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
        public int PositionId { get; set; }
        public string PositionName { get; set; }

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
