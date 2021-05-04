using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataTransferLayer.DTOs
{
    public class StockReceiptNote
    {
        private int noteId;
        private int supplierId;
        private DateTime createdDate;

        public int NoteId { get => noteId; set => noteId = value; }
        public int SupplierId { get => supplierId; set => supplierId = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public StockReceiptNote(int noteId, int supplierId, DateTime createdDate)
        {
            this.NoteId = noteId;
            this.SupplierId = supplierId;
            this.CreatedDate = createdDate;
        }

        public StockReceiptNote(DataRow row)
        {
            this.NoteId = (int)row["MaPhieu"];
            this.SupplierId = (int)row["MaNhaCungCap"];
            DateTime result;
            if (DateTime.TryParse(row["Ngay"].ToString(), out result))
                this.CreatedDate = result;
        }
    }
}
