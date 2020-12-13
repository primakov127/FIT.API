using FIT.API.Domain.Models;
using FIT.API.Domain.Repositories;
using FIT.API.Domain.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public AttendanceService(IAttendanceRepository attendanceRepository, UserManager<IdentityUser> userManager)
        {
            _attendanceRepository = attendanceRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<AllLessonAttendance>> ListAllLessonsAsync(long actualScheduleId)
        {
            return await _attendanceRepository.FindAllLessonsAsync(actualScheduleId);
        }

        public async Task<IEnumerable<OneLessonAttendance>> ListOneLessonAsync(string teacherEmail, long actualScheduleId)
        {
            var currentUser = await _userManager.FindByEmailAsync(teacherEmail);
            if (await _userManager.IsInRoleAsync(currentUser, "TEACHER"))
            {
                return await _attendanceRepository.FindOneLessonAsync(currentUser.Id, actualScheduleId);
            }

            return new List<OneLessonAttendance>();
        }
    }
}
