using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class Area
    {
        private int areaId;
        private string areaName;

        public int AreaId { get => areaId; set => areaId = value; }
        public string AreaName { get => areaName; set => areaName = value; }

        public Area(int areaId, string areaName)
        {
            AreaId = areaId;
            AreaName = areaName;
        }

        public Area(DataRow row)
        {
            AreaId = (int)row["MaKhuVuc"];
            AreaName = row["TenKhuVuc"].ToString(); ;
        }
    }
}
