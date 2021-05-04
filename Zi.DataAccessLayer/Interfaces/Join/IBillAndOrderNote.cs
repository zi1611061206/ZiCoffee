using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.DTOs;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataAccessLayer.Interfaces.Join
{
    public interface IBillAndOrderNote
    {
        Bill GetBillOfCurrentTable(int tableId, BillStatus billStatus);
    }
}
