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
        public int ServiceId { get; set; }
        public int CategoryId { get; set; }
        public string ServiceName { get; set; }
        public byte[] Image { get; set; }
        public float Price { get; set; }
        public ServiceStatus UsedStatus { get; set; }
        public string Description { get; set; }

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
