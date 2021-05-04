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
        private int materialId;
        private string materialName;
        private int stockAmount;
        private string unit;

        public int MaterialId { get => materialId; set => materialId = value; }
        public string MaterialName { get => materialName; set => materialName = value; }
        public int StockAmount { get => stockAmount; set => stockAmount = value; }
        public string Unit { get => unit; set => unit = value; }

        public Material(int materialId, string materialName, int stockAmount, string unit)
        {
            this.MaterialId = materialId;
            this.MaterialName = materialName;
            this.StockAmount = stockAmount;
            this.Unit = unit;
        }

        public Material(DataRow row)
        {
            materialId = (int)row["MaNguyenLieu"];
            materialName = row["TenNguyenLieu"].ToString();
            stockAmount = (int)row["SoLuongTon"];
            unit = row["DonViTinh"].ToString();
        }
    }
}
