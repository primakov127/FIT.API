using FIT.API.Domain.Models;
using FIT.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Controllers
{
    [Route("/api/[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            var schedules = await _scheduleService.ListAsync();
            return schedules;
        }
    }
}
