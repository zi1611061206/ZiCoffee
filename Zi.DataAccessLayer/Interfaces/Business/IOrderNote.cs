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
    public interface IOrderNote
    {
        bool AddOrderNote(OrderNote note);

        DataTable GetAllOrderNote();

        OrderNote GetOrderNoteById(int noteId);

        DataTable GetAllOrderNoteOfTable(int tableId);

        DataTable GetAllOrderNoteOfBill(int billId);

        DataTable GetAllOrderNoteOfAccount(string username);

        bool UpdateOrderNote(OrderNote note);

        bool DeleteAllOrderNote();

        bool DeleteOrderNoteById(int noteId);

        bool DeleteAllOrderNoteOfTable(int tableId);

        bool DeleteAllOrderNoteOfBill(int billId);

        bool DeleteAllOrderNoteOfAccount(string username);

        int CountAllOrderNote();

        DataTable SearchOrderNote(int noteId);
    }
}
