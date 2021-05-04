using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.Interfaces.Business
{
    public interface IDiscountNote
    {
        bool AddDiscountNote(DiscountNote note);

        DataTable GetAllDiscountNote();

        DiscountNote GetDiscountNoteById(int noteId);

        DataTable GetAllDiscountNoteByProgram(int programId);

        DataTable GetAllDiscountNoteByStatus(DiscountNoteStatus status);

        bool UpdateDiscountNote(DiscountNote note);

        bool DeleteAllDiscountNote();

        bool DeleteDiscountNoteById(int noteId);

        bool DeleteAllDiscountNoteByStatus(DiscountNoteStatus status);

        bool DeleteAllDiscountNoteOfProgram(int programId);

        int CountAllDiscountNote();

        DataTable SearchDiscountNote(int noteId);
    }
}
