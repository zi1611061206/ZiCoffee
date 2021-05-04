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
    public interface IBillDetail
    {
        bool AddBillDetail(BillDetail detail);

        DataTable GetAllBillDetail();

        DataTable GetAllBillDetailOfService(int serviceId);

        DataTable GetAllBillDetailOfBill(int billId);

        bool UpdateBillDetail(BillDetail detail);

        bool DeleteAllBillDetail();

        bool DeleteBillDetailById(int serviceId, int billId);

        bool DeleteAllBillDetailOfService(int serviceId);

        bool DeleteAllBillDetailOfBill(int billId);

        int CountAllBillDetail();
    }
}
