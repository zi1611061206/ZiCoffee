using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace DataTransferLayer.DTOs
{
    public class EventObj : Event
    {
        public EventObj(string name)
        {
            EventId = Guid.NewGuid();
            Description = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to EventObj
        /// </summary>
        /// <param name="row"></param>
        public EventObj(DataRow row)
        {
            EventId = Guid.Parse(row["EventId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
