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
    public interface IStockReceiptNote
    {
        bool AddStockReceiptNote(StockReceiptNote note);

        DataTable GetAllStockReceiptNote();

        StockReceiptNote GetStockReceiptNoteById(int noteId);

        DataTable GetAllStockReceiptNoteByStage(DateTime start, DateTime end);

        DataTable GetAllStockReceiptNoteOfSupplier(int supplierId);

        bool UpdateStockReceiptNote(StockReceiptNote note);

        bool DeleteAllStockReceiptNote();

        bool DeleteStockReceiptNoteById(int noteId);

        bool DeleteAllStockReceiptNoteOfSupplier(int supplierId);

        int CountAllStockReceiptNote();

        DataTable SearchStockReceiptNote(int noteId);
    }
}
