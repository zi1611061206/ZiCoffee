using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class BillDetail
    {
        public int BillId { get; set; }
        public int ServiceId { get; set; }
        public int Amount { get; set; }
        public float Total { get; set; }

        public BillDetail(int billId, int serviceId, int amount)
        {
            BillId = billId;
            ServiceId = serviceId;
            Amount = amount;
        }

        public BillDetail(int billId, int serviceId, int amount, float total)
        {
            BillId = billId;
            ServiceId = serviceId;
            Amount = amount;
            Total = total;
        }

        public BillDetail(DataRow row)
        {
            BillId = (int)row["MaHoaDon"];
            ServiceId = (int)row["MaDichVu"];
            Amount = (int)row["SoLuong"];
            Total = float.Parse(row["ThanhTien"].ToString());
        }
    }
}
