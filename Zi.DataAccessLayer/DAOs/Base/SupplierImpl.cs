using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Base;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.DAOs
{
    public class SupplierImpl : ISupplier
    {
        #region package_SupplierImpl
        private static SupplierImpl instance;
        public static SupplierImpl Instance
        {
            get { if (instance == null) instance = new SupplierImpl(); return instance; }
            private set { instance = value; }
        }
        private SupplierImpl() { }
        #endregion

        public bool AddSupplier(Supplier supplier)
        {
            string query = "insert into NhaCungCap(TenNhaCungCap, DiaChi, SoDienThoai, Email) " +
                           "values (N'@TenNhaCungCap', N'@DiaChi', '@SoDienThoai', @Email)";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                supplier.SupplierName,
                supplier.SupplierAddress,
                supplier.SupplierPhone,
                supplier.SupplierEmail
            });
            return result > 0;
        }

        public DataTable GetAllSupplier()
        {
            string query = "select * from NhaCungCap";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Supplier GetSupplierById(int supplierId)
        {
            string query = "select * from NhaCungCap where MaNhaCungCap = " + supplierId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Supplier(data.Rows[0]);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            string query = "update NhaCungCap set " +
                "TenNhaCungCap = N'@TenNhaCungCap', " +
                "DiaChi = N'@DiaChi', " +
                "SoDienThoai = '@SoDienThoai', " +
                "Email = @Email " +
                "where MaNhanVien = " + supplier.SupplierId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                supplier.SupplierName, 
                supplier.SupplierAddress, 
                supplier.SupplierPhone, 
                supplier.SupplierEmail
            });
            return result > 0;
        }

        public bool DeleteAllSupplier()
        {
            string query = "delete from NhaCungCap";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteSupplierById(int supplierId)
        {
            string query = "delete from NhaCungCap where MaNhaCungCap = " + supplierId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckSupplierName(string supplierName)
        {
            string query = "select * from NhaCungCap where TenNhaCungCap = N'" + supplierName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }

        public int CountAllSupplier()
        {
            string query = "select count(*) from NhaCungCap";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchSupplier(string supplierName)
        {
            throw new NotImplementedException();
        }
    }
}
