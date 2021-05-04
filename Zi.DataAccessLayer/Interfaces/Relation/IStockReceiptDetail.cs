using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.Interfaces.Relation
{
    public interface IStockReceiptDetail
    {
        bool AddStockReceiptDetail(StockReceiptDetail detail);

        DataTable GetAllStockReceiptDetail();

        DataTable GetAllStockReceiptDetailOfNote(int noteId);

        DataTable GetAllStockReceiptDetailOfMaterial(int materialId);

        bool UpdateStockReceiptDetail(StockReceiptDetail detail);

        bool DeleteAllStockReceiptDetail();

        bool DeleteStockReceiptDetailById(int noteId, int materialId);

        bool DeleteAllStockReceiptDetailOfNote(int noteId);

        bool DeleteAllStockReceiptDetailOfMaterial(int materialId);

        int CountAllStockReceiptDetail();
    }
}
