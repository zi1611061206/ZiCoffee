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
        private int tableId;
        private int areaId;
        private string tableName;
        private TableStatus usedStatus;

        public int TableId { get => tableId; set => tableId = value; }
        public int AreaId { get => areaId; set => areaId = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public TableStatus UsedStatus { get => usedStatus; set => usedStatus = value; }

        public string fullName => $"{TableName} - khu vực: {AreaId}";

        public Table(int tableId, int areaId, string tableName, TableStatus usedStatus)
        {
            this.TableId = tableId;
            this.AreaId = areaId;
            this.TableName = tableName;
            this.UsedStatus = usedStatus;
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
