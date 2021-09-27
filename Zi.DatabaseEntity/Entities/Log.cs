using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DatabaseEntity.Entities
{
    public class Log
    {
        public Guid LogId { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTime Time { get; set; }

        //FK n-1
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
