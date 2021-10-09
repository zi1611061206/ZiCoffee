using System;
using System.Data;

namespace Zi.LinqSqlLayer.DTOs
{
    public class EventModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EventModel()
        {
        }

        public EventModel(string name)
        {
            EventId = Guid.NewGuid();
            Description = string.Empty;
            Name = name;
        }

        /// <summary>
        /// Mapping data to EventObj
        /// </summary>
        /// <param name="row"></param>
        public EventModel(DataRow row)
        {
            EventId = Guid.Parse(row["EventId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
