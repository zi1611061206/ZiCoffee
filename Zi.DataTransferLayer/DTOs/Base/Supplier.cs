using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }

        public Supplier(int supplierId, string supplierName, string supplierAddress, string supplierPhone, string supplierEmail)
        {
            SupplierId = supplierId;
            SupplierName = supplierName;
            SupplierAddress = supplierAddress;
            SupplierPhone = supplierPhone;
            SupplierEmail = supplierEmail;
        }

        public Supplier(DataRow row)
        {
            SupplierId = (int)row["MaNhaCungCap"];
            SupplierName = row["TenNhaCungCap"].ToString();
            SupplierAddress = row["DiaChi"].ToString();
            SupplierPhone = row["SoDienThoai"].ToString();
            SupplierEmail = row["Email"].ToString();
        }
    }
}
