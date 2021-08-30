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
        public int NoteId { get; set; }
        public int SupplierId { get; set; }
        public DateTime CreatedDate { get; set; }

        public StockReceiptNote(int noteId, int supplierId, DateTime createdDate)
        {
            NoteId = noteId;
            SupplierId = supplierId;
            CreatedDate = createdDate;
        }

        public StockReceiptNote(DataRow row)
        {
            NoteId = (int)row["MaPhieu"];
            SupplierId = (int)row["MaNhaCungCap"];
            if (DateTime.TryParse(row["Ngay"].ToString(), out DateTime result))
            {
                CreatedDate = result;
            }
        }
    }
}
