using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Models
{
    public class SaveSchedule
    {
        public long ScheduleId { get; set; }
        public int SubjectId { get; set; }
        public string TeacherId { get; set; }
        public int RoomId { get; set; }
        public int Week { get; set; }
        public int WeekDay { get; set; }
        public int LessonNum { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public int SubGroup { get; set; }
    }
}
