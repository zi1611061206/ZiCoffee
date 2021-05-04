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
        private int serviceId;
        private int materialId;
        private float quantity;

        public int ServiceId { get => serviceId; set => serviceId = value; }
        public int MaterialId { get => materialId; set => materialId = value; }
        public float Quantity { get => quantity; set => quantity = value; }

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
