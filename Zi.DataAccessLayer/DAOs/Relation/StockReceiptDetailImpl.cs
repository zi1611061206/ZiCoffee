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
    public class StockReceiptDetailImpl : IStockReceiptDetail
    {
        #region package_StockReceiptDetailImpl
        private static StockReceiptDetailImpl instance;

        public static StockReceiptDetailImpl Instance
        {
            get { if (instance == null) instance = new StockReceiptDetailImpl(); return instance; }
            private set { instance = value; }
        }

        private StockReceiptDetailImpl() { }
        #endregion

        public bool AddStockReceiptDetail(StockReceiptDetail detail)
        {
            string query = "insert into ChiTietPhieuNhap(MaPhieu, MaNguyenLieu, SoLuongNhap, DonGiaNhap) " +
                "values( @MaPhieu , @MaNguyenLieu , @SoLuongNhap , @DonGiaNhap )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                detail.NoteId,
                detail.MaterialId,
                detail.Quantity,
                detail.Price
            });
            return result > 0;
        }

        public DataTable GetAllStockReceiptDetail()
        {
            string query = "select * from ChiTietPhieuNhap";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllStockReceiptDetailOfNote(int noteId)
        {
            string query = "select * from ChiTietPhieuNhap where MaPhieu = " + noteId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllStockReceiptDetailOfMaterial(int materialId)
        {
            string query = "select * from ChiTietPhieuNhap where MaNguyenLieu = " + materialId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateStockReceiptDetail(StockReceiptDetail detail)
        {
            string query = "update ChiTietPhieuNhap set " +
                "SoLuongNhap = @SoLuongNhap , " +
                "DonGiaNhap = @DonGiaNhap " +
                "where MaPhieu = @MaPhieu and MaNguyenLieu = @MaNguyenLieu ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                detail.Quantity,
                detail.Price,
                detail.NoteId,
                detail.MaterialId
            });
            return result > 0;
        }

        public bool DeleteAllStockReceiptDetail()
        {
            string query = "delete from ChiTietPhieuNhap";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteStockReceiptDetailById(int noteId, int materialId)
        {
            string query = "delete from ChiTietPhieuNhap where MaPhieu = @MaPhieu and MaNguyenLieu = @MaNguyenLieu ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                noteId, materialId
            });
            return result > 0;
        }

        public bool DeleteAllStockReceiptDetailOfNote(int noteId)
        {
            string query = "delete from ChiTietPhieuNhap where MaPhieu = " + noteId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllStockReceiptDetailOfMaterial(int materialId)
        {
            string query = "delete from ChiTietPhieuNhap where MaNguyenLieu = " + materialId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllStockReceiptDetail()
        {
            string query = "select count(*) from ChiTietPhieuNhap";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }
    }
}
