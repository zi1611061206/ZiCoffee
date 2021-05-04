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
    public interface IBill
    {
        bool AddBill();

        DataTable GetAllBill();

        Bill GetBillById(int billId);

        DataTable GetAllBillByStage(DateTime start, DateTime end);

        DataTable GetAllBillByStatus(BillStatus status);

        DataTable GetAllBillOfDiscountNote(int discountNoteId);

        DataTable GetAllBillOfPromotionProgram(int programId);

        bool UpdateBill(Bill bill);

        bool DeleteAllBill();

        bool DeleteBillById(int billId);

        bool DeleteAllBillByStatus(BillStatus status);

        bool DeleteAllBillOfDiscountNote(int discountNoteId);

        bool DeleteAllBillOfPromotionProgram(int programId);

        int CountAllBill();

        DataTable SearchBill(int billId);
    }
}
