using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataTransferLayer.DTOs
{
    public class Service
    {
        private int serviceId;
        private int categoryId;
        private string serviceName;
        private byte[] image;
        private float price;
        private ServiceStatus usedStatus;
        private string description;

        public int ServiceId { get => serviceId; set => serviceId = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string ServiceName { get => serviceName; set => serviceName = value; }
        public byte[] Image { get => image; set => image = value; }
        public float Price { get => price; set => price = value; }
        public ServiceStatus UsedStatus { get => usedStatus; set => usedStatus = value; }
        public string Description { get => description; set => description = value; }

        public Service(int serviceId, int categoryId, string serviceName, byte[] image, float price, ServiceStatus usedStatus, string description)
        {
            ServiceId = serviceId;
            CategoryId = categoryId;
            ServiceName = serviceName;
            Image = image;
            Price = price;
            UsedStatus = usedStatus;
            Description = description;
        }

        public Service(DataRow row)
        {
            ServiceId = (int)row["MaDichVu"];
            CategoryId = (int)row["MaDanhMuc"];
            ServiceName = row["TenDichVu"].ToString();
            Image = (byte[])row["HinhAnh"];
            Price = (float)Convert.ToDouble(row["DonGia"].ToString());
            int status = Convert.ToInt32(row["TinhTrangSuDung"]);
            UsedStatus = (ServiceStatus) status;
            Description = row["MoTa"].ToString();
        }
    }
}
