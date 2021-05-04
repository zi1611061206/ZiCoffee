using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class OrderNote
    {
        private int orderNoteId;
        private int tableId;
        private int billId;
        private string username;

        public int OrderNoteId { get => orderNoteId; set => orderNoteId = value; }
        public int TableId { get => tableId; set => tableId = value; }
        public int BillId { get => billId; set => billId = value; }
        public string Username { get => username; set => username = value; }

        public OrderNote(int tableId, int billId, string username)
        {
            TableId = tableId;
            BillId = billId;
            Username = username;
        }

        public OrderNote(int orderNoteId, int tableId, int billId, string username)
        {
            OrderNoteId = orderNoteId;
            TableId = tableId;
            BillId = billId;
            Username = username;
        }

        public OrderNote(DataRow row)
        {
            OrderNoteId = (int)row["MaPhieu"];
            TableId = (int)row["MaBan"];
            BillId = (int)row["MaHoaDon"];
            Username = row["TenDangNhap"].ToString();
        }
    }
}
