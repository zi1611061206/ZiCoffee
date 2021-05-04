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
        private int billId;
        private int serviceId;
        private int amount;
        private float total;

        public int BillId { get => billId; set => billId = value; }
        public int ServiceId { get => serviceId; set => serviceId = value; }
        public int Amount { get => amount; set => amount = value; }
        public float Total { get => total; set => total = value; }

        public BillDetail(int billId, int serviceId, int amount)
        {
            this.BillId = billId;
            this.ServiceId = serviceId;
            this.Amount = amount;
        }

        public BillDetail(int billId, int serviceId, int amount, float total)
        {
            this.BillId = billId;
            this.ServiceId = serviceId;
            this.Amount = amount;
            this.Total = total;
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
