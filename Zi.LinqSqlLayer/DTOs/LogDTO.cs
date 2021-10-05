using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class LogDTO
    {
        public Guid LogId { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTime Time { get; set; }

        public LogDTO()
        {
        }

        public LogDTO(Guid userId, Guid eventId)
        {
            LogId = Guid.NewGuid();
            UserId = userId;
            EventId = eventId;
        }

        /// <summary>
        /// Mapping data to LogObj
        /// </summary>
        public LogDTO(DataRow row)
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
