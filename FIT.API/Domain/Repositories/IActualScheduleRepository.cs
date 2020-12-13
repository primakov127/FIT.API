using FIT.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Repositories
{
    public interface IActualScheduleRepository
    {
        Task<IEnumerable<ViewActualSchedule>> FindStudentByDate(DateTime date, string userId);
        Task<IEnumerable<ViewActualSchedule>> FindTeacherByDate(DateTime date, string userId);
    }
}
