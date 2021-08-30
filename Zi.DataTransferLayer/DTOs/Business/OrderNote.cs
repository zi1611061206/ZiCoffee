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
        public int OrderNoteId { get; set; }
        public int TableId { get; set; }
        public int BillId { get; set; }
        public string Username { get; set; }

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
