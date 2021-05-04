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
        private int discountNoteId;
        private int programId;
        private DiscountNoteStatus status;

        public int DiscountNoteId { get => discountNoteId; set => discountNoteId = value; }
        public int ProgramId { get => programId; set => programId = value; }
        public DiscountNoteStatus Status { get => status; set => status = value; }

        public DiscountNote(int discountNoteId, int programId, DiscountNoteStatus status)
        {
            this.DiscountNoteId = discountNoteId;
            this.ProgramId = programId;
            this.Status = status;
        }

        public DiscountNote(DataRow row)
        {
            this.DiscountNoteId = (int)row["MaPhieu"];
            this.ProgramId = (int)row["MaChuongTrinh"];
            this.Status = (DiscountNoteStatus)Enum.Parse(typeof(DiscountNoteStatus), row["TrangThai"].ToString(), true);
        }
    }
}
