    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Models
{
    public class AllLessonAttendance
    {
        public long AttendanceId { get; set; }
        public string UserLastName { get; set; }
        public bool? IsPresent { get; set; }
        public int? Mark { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
