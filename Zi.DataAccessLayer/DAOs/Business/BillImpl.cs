using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Business;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.DAOs
{
    public class BillImpl : IBill
    {
        #region Package_BillImpl
        private static BillImpl instance;

        public static BillImpl Instance
        {
            get { if (instance == null) instance = new BillImpl(); return instance; }
            private set { instance = value; }
        }

        private BillImpl() { }
        #endregion

        public bool AddBill()
        {
            string query = "insert into HoaDon default values";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable GetAllBill()
        {
            string query = "select * from HoaDon";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Bill GetBillById(int billId)
        {
            string query = "select * from HoaDon where MaHoaDon = " + billId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Bill(data.Rows[0]);
        }

        public DataTable GetAllBillByStage(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllBillByStatus(BillStatus status)
        {
            string query = "select * from HoaDon where TrangThaiThanhToan = " + status;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllBillOfDiscountNote(int discountNoteId)
        {
            string query = "select * from HoaDon where MaPhieuGiamGia = " + discountNoteId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllBillOfPromotionProgram(int programId)
        {
            string query = "select * from HoaDon where MaChuongTrinhKhuyenMai = " + programId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateBill(Bill bill)
        {
            string query = "update HoaDon set " +
                "TrangThaiThanhToan = @TrangThaiThanhToan, " +
                "ThucThu = @ThucThu , " +
                "VAT = @VAT , " +
                "MaPhieuGiamGia = @MaPhieuGiamGia , " +
                "MaChuongTrinhKhuyenMai = @MaChuongTrinhKhuyenMai , " +
                "ThanhTien = @ThanhTien , " +
                "GiaTriSauThue = @GiaTriSauThue " +
                "where MaHoaDon = " + bill.BillId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                bill.PayStatus,
                bill.RealPay,
                bill.Vat,
                bill.DiscountNoteId,
                bill.PromotionProgramId,
                bill.Total,
                bill.AfterVAT
            });
            return result > 0;
        }

        public bool DeleteAllBill()
        {
            string query = "delete from HoaDon";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteBillById(int billId)
        {
            string query = "delete from HoaDon where MaHoaDon = " + billId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllBillByStatus(BillStatus status)
        {
            string query = "delete from HoaDon where TrangThaiThanhToan = " + status;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllBillOfDiscountNote(int discountNoteId)
        {
            string query = "delete from HoaDon where MaPhieuGiamGia = " + discountNoteId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllBillOfPromotionProgram(int programId)
        {
            string query = "delete from HoaDon where MaChuongTrinhKhuyenMai = " + programId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllBill()
        {
            string query = "select count(*) from HoaDon";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchBill(int billId)
        {
            throw new NotImplementedException();
        }

        public Bill GetNewestBill()
        {
            string query = "select max(MaHoaDon) from HoaDon";
            int id = (int)DataProvider.Instance.ExecuteScalar(query);
            query = "select * from HoaDon where MaHoaDon = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new Bill(data.Rows[0]);
        }
    }
}
