using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataTransferLayer.DTOs
{
    public class DiscountNote
    {
        public int DiscountNoteId { get; set; }
        public int ProgramId { get; set; }
        public DiscountNoteStatus Status { get; set; }

        public DiscountNote(int discountNoteId, int programId, DiscountNoteStatus status)
        {
            DiscountNoteId = discountNoteId;
            ProgramId = programId;
            Status = status;
        }

        public DiscountNote(DataRow row)
        {
            DiscountNoteId = (int)row["MaPhieu"];
            ProgramId = (int)row["MaChuongTrinh"];
            Status = (DiscountNoteStatus)Enum.Parse(typeof(DiscountNoteStatus), row["TrangThai"].ToString(), true);
        }
    }
}
