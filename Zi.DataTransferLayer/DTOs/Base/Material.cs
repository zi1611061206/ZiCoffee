using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int StockAmount { get; set; }
        public string Unit { get; set; }

        public Material(int materialId, string materialName, int stockAmount, string unit)
        {
            MaterialId = materialId;
            MaterialName = materialName;
            StockAmount = stockAmount;
            Unit = unit;
        }

        public Material(DataRow row)
        {
            MaterialId = (int)row["MaNguyenLieu"];
            MaterialName = row["TenNguyenLieu"].ToString();
            StockAmount = (int)row["SoLuongTon"];
            Unit = row["DonViTinh"].ToString();
        }
    }
}
