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
        private int supplierId;
        private string supplierName;
        private string supplierAddress;
        private string supplierPhone;
        private string supplierEmail;

        public int SupplierId { get => supplierId; set => supplierId = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }
        public string SupplierAddress { get => supplierAddress; set => supplierAddress = value; }
        public string SupplierPhone { get => supplierPhone; set => supplierPhone = value; }
        public string SupplierEmail { get => supplierEmail; set => supplierEmail = value; }

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
