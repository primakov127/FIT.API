using FIT.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Repositories
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<AllLessonAttendance>> FindAllLessonsAsync(long actualScheduleId);
        Task<IEnumerable<OneLessonAttendance>> FindOneLessonAsync(string teacherId, long actualScheduleId);
    }
}
