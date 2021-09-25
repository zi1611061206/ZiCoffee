using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace DataTransferLayer.DTOs
{
    public class TableObj : Table
    {
        public TableObj()
        {
            TableId = Guid.NewGuid();
        }
        public TableObj(DataRow row)
        {
            TableId = Guid.Parse(row["TableId"].ToString());
            Name = row["Name"].ToString();
            int tableStatus = (int)row["Status"];
            Status = (TableStatus)tableStatus;
            AreaId = Guid.Parse(row["AreaId"].ToString());
        }
    }
}
