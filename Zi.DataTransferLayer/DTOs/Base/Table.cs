using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DataTransferLayer.Enums;

namespace Zi.DataTransferLayer.DTOs
{
    public class Table
    {
        public int TableId { get; set; }
        public int AreaId { get; set; }
        public string TableName { get; set; }
        public TableStatus UsedStatus { get; set; }

        public string FullName { get { return $"{TableName} - khu vực: {AreaId}"; } }

        public Table(int tableId, int areaId, string tableName, TableStatus usedStatus)
        {
            TableId = tableId;
            AreaId = areaId;
            TableName = tableName;
            UsedStatus = usedStatus;
        }

        public Table(DataRow row)
        {
            TableId = (int)row["MaBan"];
            AreaId = (int)row["MakhuVuc"];
            TableName = row["TenBan"].ToString();
            int statusData = Convert.ToInt32(row["trangthaisudung"]);
            UsedStatus = (TableStatus)statusData;
        }
    }
}
