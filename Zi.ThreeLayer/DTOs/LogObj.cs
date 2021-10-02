using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.ThreeLayer.DTOs
{
    public class LogObj : Log
    {
        public LogObj(Guid userId, Guid eventId)
        {
            LogId = Guid.NewGuid();
            UserId = userId;
            EventId = eventId;
        }

        /// <summary>
        /// Mapping data to LogObj
        /// </summary>
        public LogObj(DataRow row)
        {
            LogId = Guid.Parse(row["LogId"].ToString());
            UserId = Guid.Parse(row["UserId"].ToString());
            EventId = Guid.Parse(row["EventId"].ToString());
            if (DateTime.TryParse(row["Time"].ToString(), out DateTime result))
            {
                Time = result;
            }
        }
    }
}
