using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Models
{
    public class ViewActualSchedule
    {
        public long ActualScheduleId { get; set; }
        public DateTime LessonTime { get; set; }
        public string SubjectName { get; set; }
        public int RoomNum { get; set; }
        public int HullNum { get; set; }
    }
}
