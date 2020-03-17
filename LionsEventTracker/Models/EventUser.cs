using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LionsEventTracker.Models
{
    public class EventUser
    {
        public int userId { get; set; }
        public User Users { get; set; }
        public int eventId { get; set; }
        public Event Events { get; set; }

    }
}
