using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Relation;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.DAOs
{
    public class BillDetailImpl : IBillDetail
    {
        #region Package_BillDetailImpl
        private static BillDetailImpl instance;

        public static BillDetailImpl Instance
        {
            get { if (instance == null) instance = new BillDetailImpl(); return instance; }
            private set { instance = value; }
        }

        private BillDetailImpl() { }
        #endregion

        public bool AddBillDetail(BillDetail detail)
        {
            string query = "insert into ChiTietHoaDon(MaDichVu, MaHoaDon, SoLuong, ThanhTien) " +
                "values( @MaDichVu , @MaHoaDon , @SoLuong , @ThanhTien )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                detail.ServiceId,
                detail.BillId,
                detail.Amount,
                detail.Total
            });
            return result > 0;
        }

        public DataTable GetAllBillDetail()
        {
            string query = "select * from ChiTietHoaDon";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllBillDetailOfService(int serviceId)
        {
            string query = "select * from ChiTietHoaDon where MaDichVu = " + serviceId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllBillDetailOfBill(int billId)
        {
            string query = "select * from ChiTietHoaDon where MaHoaDon = " + billId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateBillDetail(BillDetail detail)
        {
            string query = "update ChiTietHoaDon set " +
                "SoLuong = @SoLuong , " +
                "ThanhTien = @ThanhTien " +
                "where MaDichVu = @MaDichVu and MaHoaDon = @MaHoaDon ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                detail.Amount,
                detail.Total,
                detail.ServiceId,
                detail.BillId
            });
            return result > 0;
        }

        public bool DeleteAllBillDetail()
        {
            string query = "delete from ChiTietHoaDon";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteBillDetailById(int serviceId, int billId)
        {
            string query = "delete from ChiTietHoaDon where MaDichVu = @MaDichVu and MaHoaDon = @MaHoaDon ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                serviceId,
                billId
            });
            return result > 0;
        }

        public bool DeleteAllBillDetailOfService(int serviceId)
        {
            string query = "delete from ChiTietHoaDon where MaDichVu = " + serviceId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllBillDetailOfBill(int billId)
        {
            string query = "delete from ChiTietHoaDon where MaHoaDon = " + billId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllBillDetail()
        {
            string query = "select count(*) from ChiTietHoaDon";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }
    }
}
