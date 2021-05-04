using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataAccessLayer.Interfaces.Join;
using Zi.DataAccessLayer.Providers;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.DAOs.Join
{
    public class BillAndOrderNoteImpl : IBillAndOrderNote
    {
        #region Package_BillAndOrderNoteImpl
        private static BillAndOrderNoteImpl instance;

        public static BillAndOrderNoteImpl Instance
        {
            get { if (instance == null) instance = new BillAndOrderNoteImpl(); return instance; }
            private set { instance = value; }
        }

        private BillAndOrderNoteImpl() { }
        #endregion

        public Bill GetBillOfCurrentTable(int tableId, BillStatus billStatus)
        {
            string query = "select * from HoaDon as h, PhieuGoiBan as p where h.MaHoaDon = p.MaHoaDon and p.MaBan = @MaBan and h.TrangThaiThanhToan = @TrangThaiThanhToan ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tableId, billStatus });
            return new Bill(data.Rows[0]);
        }
    }
}
