using System;
using System.Data;
using Zi.Utilities.Enumerators;

namespace Zi.LinqSqlLayer.DTOs
{
    public class TableModel
    {
        public Guid TableId { get; set; }
        public string Name { get; set; }
        public TableStatus Status { get; set; }
        public Guid AreaId { get; set; }

        public TableModel()
        {
        }

        public TableModel(string name, Guid areaId)
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
        public TableModel(DataRow row)
        {
            TableId = Guid.Parse(row["TableId"].ToString());
            Name = row["Name"].ToString();
            Status = (TableStatus)row["Status"];
            AreaId = Guid.Parse(row["AreaId"].ToString());
        }
    }
}
