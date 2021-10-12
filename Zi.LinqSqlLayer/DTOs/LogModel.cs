using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class LogModel
    {
        public Guid LogId { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }

        public LogModel()
        {
        }

        public LogModel(Guid userId, Guid eventId)
        {
            LogId = Guid.NewGuid();
            UserId = userId;
            EventId = eventId;
            Content = string.Empty;
        }

        /// <summary>
        /// Mapping data to LogObj
        /// </summary>
        public LogModel(DataRow row)
        {
            LogId = Guid.Parse(row["LogId"].ToString());
            UserId = Guid.Parse(row["UserId"].ToString());
            EventId = Guid.Parse(row["EventId"].ToString());
            if (DateTime.TryParse(row["Time"].ToString(), out DateTime result))
            {
                Time = result;
            }
            Content = row["Content"].ToString();
        }
    }
}
