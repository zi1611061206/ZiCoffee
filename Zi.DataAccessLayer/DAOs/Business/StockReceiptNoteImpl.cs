using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Business;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;

namespace Zi.DataAccessLayer.DAOs
{
    public class StockReceiptNoteImpl : IStockReceiptNote
    {
        #region Package_StockReceiptNoteImpl
        private static StockReceiptNoteImpl instance;

        public static StockReceiptNoteImpl Instance
        {
            get { if (instance == null) instance = new StockReceiptNoteImpl(); return instance; }
            private set { instance = value; }
        }

        private StockReceiptNoteImpl() { }
        #endregion

        public bool AddStockReceiptNote(StockReceiptNote note)
        {
            string query = "insert into PhieuNhap(MaNhaCungCap) values( @MaNhaCungCap )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { note.SupplierId });
            return result > 0;
        }

        public DataTable GetAllStockReceiptNote()
        {
            string query = "select * from PhieuNhap";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public StockReceiptNote GetStockReceiptNoteById(int noteId)
        {
            string query = "select * from PhieuNhap where MaPhieu = " + noteId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new StockReceiptNote(data.Rows[0]);
        }

        public DataTable GetAllStockReceiptNoteByStage(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllStockReceiptNoteOfSupplier(int supplierId)
        {
            string query = "select * from PhieuNhap where MaNhaCungCap = " + supplierId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateStockReceiptNote(StockReceiptNote note)
        {
            string query = "update PhieuNhap set " +
                "MaNhaCungCap = @MaNhaCungCap " +
                "where MaPhieu = " + note.NoteId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                note.SupplierId
            });
            return result > 0;
        }

        public bool DeleteAllStockReceiptNote()
        {
            string query = "delete from PhieuNhap";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteStockReceiptNoteById(int noteId)
        {
            string query = "delete from PhieuNhap where MaPhieu = " + noteId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllStockReceiptNoteOfSupplier(int supplierId)
        {
            string query = "delete from PhieuNhap where MaNhaCungCap = " + supplierId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllStockReceiptNote()
        {
            string query = "select count(*) from PhieuNhap";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchStockReceiptNote(int noteId)
        {
            throw new NotImplementedException();
        }
    }
}
