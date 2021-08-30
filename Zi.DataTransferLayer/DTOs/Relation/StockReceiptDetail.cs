using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class StockReceiptDetail
    {
        public int NoteId { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public StockReceiptDetail(int noteId, int materialId, int quantity, float price)
        {
            NoteId = noteId;
            MaterialId = materialId;
            Quantity = quantity;
            Price = price;
        }

        public StockReceiptDetail(DataRow row)
        {
            NoteId = (int)row["MaPhieu"];
            MaterialId = (int)row["MaNguyenLieu"];
            Quantity = (int)row["SoLuongNhap"];
            Price = float.Parse(row["DonGiaNhap"].ToString());
        }
    }
}
