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
        private int noteId;
        private int materialId;
        private int quantity;
        private float price;

        public int NoteId { get => noteId; set => noteId = value; }
        public int MaterialId { get => materialId; set => materialId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Price { get => price; set => price = value; }

        public StockReceiptDetail(int noteId, int materialId, int quantity, float price)
        {
            this.NoteId = noteId;
            this.MaterialId = materialId;
            this.Quantity = quantity;
            this.Price = price;
        }

        public StockReceiptDetail(DataRow row)
        {
            this.NoteId = (int)row["MaPhieu"];
            this.MaterialId = (int)row["MaNguyenLieu"];
            this.Quantity = (int)row["SoLuongNhap"];
            this.Price = float.Parse(row["DonGiaNhap"].ToString());
        }
    }
}
