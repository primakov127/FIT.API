using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Models
{
    public class Schedule
    {
        public long Id { get; set; }
        public int Week { get; set; }

        public int SubjectId { get; set; }
        public string TeacherId { get; set; }
        public int RoomId { get; set; }
        public int ActualGroupId { get; set; }
        public int SubGroupId { get; set; }
        public int WeekDayId { get; set; }
        public int LessonNumId { get; set; }
    }
}
