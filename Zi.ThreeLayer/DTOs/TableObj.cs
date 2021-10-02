using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.ThreeLayer.DTOs
{
    public class TableObj : Table
    {
        public TableObj(string name, Guid areaId)
        {
            TableId = Guid.NewGuid();
            Status = TableStatus.Ready;
            Name = name;
            AreaId = areaId;
        }

        /// <summary>
        /// Mapping data to TableObj
        /// </summary>
        /// <param name="row"></param>
        public TableObj(DataRow row)
        {
            TableId = Guid.Parse(row["TableId"].ToString());
            Name = row["Name"].ToString();
            Status = (TableStatus)row["Status"];
            AreaId = Guid.Parse(row["AreaId"].ToString());
        }
    }
}
