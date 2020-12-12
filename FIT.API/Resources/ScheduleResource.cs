using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Resources
{
    public class ScheduleResource
    {
        public long Id { get; set; }
        public int Week { get; set; }

        public string TeacherId { get; set; }
        public int WeekDayId { get; set; }
        public int LessonNumId { get; set; }
    }
}
