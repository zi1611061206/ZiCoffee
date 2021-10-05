using System;
using System.Data;
using Zi.LinqSqlLayer.Enumerators;

namespace Zi.LinqSqlLayer.DTOs
{
    public class TableDTO
    {
        public Guid TableId { get; set; }
        public string Name { get; set; }
        public TableStatus Status { get; set; }
        public Guid AreaId { get; set; }

        public TableDTO()
        {
        }

        public TableDTO(string name, Guid areaId)
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
        public TableDTO(DataRow row)
        {
            TableId = Guid.Parse(row["TableId"].ToString());
            Name = row["Name"].ToString();
            Status = (TableStatus)row["Status"];
            AreaId = Guid.Parse(row["AreaId"].ToString());
        }
    }
}
