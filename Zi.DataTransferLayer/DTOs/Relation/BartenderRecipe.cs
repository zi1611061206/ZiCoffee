using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class BartenderRecipe
    {
        public int ServiceId { get; set; }
        public int MaterialId { get; set; }
        public float Quantity { get; set; }

        public BartenderRecipe(int serviceId, int materialId, float quantity)
        {
            ServiceId = serviceId;
            MaterialId = materialId;
            Quantity = quantity;
        }

        public BartenderRecipe(DataRow row)
        {
            ServiceId = (int)row["MaDichVu"];
            MaterialId = (int)row["MaNguyenLieu"];
            Quantity = float.Parse(row["SoLuongPha"].ToString());
        }
    }
}
