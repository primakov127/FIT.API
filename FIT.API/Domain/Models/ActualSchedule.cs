using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Models
{
    public class ActualSchedule
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public long ScheduleId { get; set; }
        public string TeacherId { get; set; }
    }
}
