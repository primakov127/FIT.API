using FIT.API.Domain.Models;
using FIT.API.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("all/{actualScheduleId}")]
        public async Task<IEnumerable<AllLessonAttendance>> GetAllLessonsAsync(long actualScheduleId)
        {
            return await _attendanceService.ListAllLessonsAsync(actualScheduleId);
        }

        [HttpGet("one/{actualScheduleId}")]
        public async Task<IEnumerable<OneLessonAttendance>> GetOneLessonAsync(long actualScheduleId)
        {
            string userEmail = User.Claims.Where(m => m.Type == "Email").Select(m => m.Value).FirstOrDefault();
            return await _attendanceService.ListOneLessonAsync(userEmail, actualScheduleId);
        }
    }
}
