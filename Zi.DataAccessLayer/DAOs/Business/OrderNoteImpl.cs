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
    public class OrderNoteImpl : IOrderNote
    {
        #region package_OrderNoteImpl
        private static OrderNoteImpl instance;

        public static OrderNoteImpl Instance
        {
            get { if (instance == null) instance = new OrderNoteImpl(); return instance; }
            private set { instance = value; }
        }

        private OrderNoteImpl() { }
        #endregion

        public bool AddOrderNote(OrderNote note)
        {
            string query = "insert into PhieuGoiBan(MaBan, MaHoaDon, TenDangNhap)" +
                " values( @MaBan , @MaHoaDon , @TenDangNhap )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] 
            { 
                note.TableId, 
                note.BillId, 
                note.Username 
            });
            return result > 0;
        }

        public DataTable GetAllOrderNote()
        {
            string query = "select * from PhieuGoiBan";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public OrderNote GetOrderNoteById(int noteId)
        {
            string query = "select * from PhieuGoiBan where MaPhieu = " + noteId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return new OrderNote(data.Rows[0]);
        }

        public DataTable GetAllOrderNoteOfTable(int tableId)
        {
            string query = "select * from PhieuGoiBan where MaBan = " + tableId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllOrderNoteOfBill(int billId)
        {
            string query = "select * from PhieuGoiBan where MaHoaDon = " + billId;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAllOrderNoteOfAccount(string username)
        {
            string query = "select * from PhieuGoiBan where TenDangNhap = '" + username + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateOrderNote(OrderNote note)
        {
            string query = "update PhieuGoiBan set " +
                "MaBan = @MaBan , " +
                "MaHoaDon = @MaHoaDon , " +
                "TenDangNhap = '@TenDangNhap' " +
                "where MaPhieu = " + note.OrderNoteId;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                note.TableId,
                note.BillId,
                note.Username
            });
            return result > 0;
        }

        public bool DeleteAllOrderNote()
        {
            string query = "delete from PhieuGoiBan";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteOrderNoteById(int noteId)
        {
            string query = "delete from PhieuGoiBan where MaPhieu = " + noteId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllOrderNoteOfTable(int tableId)
        {
            string query = "delete from PhieuGoiBan where MaBan = " + tableId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllOrderNoteOfBill(int billId)
        {
            string query = "delete from PhieuGoiBan where MaHoaDon = " + billId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAllOrderNoteOfAccount(string username)
        {
            string query = "delete from PhieuGoiBan where TenDangNhap = '" + username + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int CountAllOrderNote()
        {
            string query = "select count(*) from PhieuGoiBan";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable SearchOrderNote(int noteId)
        {
            throw new NotImplementedException();
        }
    }
}
