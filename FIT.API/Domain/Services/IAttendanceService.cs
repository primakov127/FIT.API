using FIT.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Services
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AllLessonAttendance>> ListAllLessonsAsync(long actualScheduleId);
        Task<IEnumerable<OneLessonAttendance>> ListOneLessonAsync(string teacherEmail, long actualScheduleId);
    }
}
