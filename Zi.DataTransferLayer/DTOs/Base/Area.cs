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
        public int AreaId { get; set; }
        public string AreaName { get; set; }

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
