using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Models
{
    public class Attendance
    {
        public long Id { get; set; }
        public bool IsPresent { get; set; }
        public int Mark { get; set; }
        public string Comment { get; set; }

        public long ActualScheduleId { get; set; }
        public string StudentId { get; set; }
    }
}
