using FIT.API.Domain.Models;
using FIT.API.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class ActualSchedulesController : ControllerBase
    {
        private readonly IActualScheduleService _actualScheduleService;

        public ActualSchedulesController(IActualScheduleService actualScheduleService)
        {
            _actualScheduleService = actualScheduleService;
        }

        [HttpGet("{date}")]
        public async Task<IEnumerable<ViewActualSchedule>> GetAsync(DateTime date)
        {
            string userEmail = User.Claims.Where(m => m.Type == "Email").Select(m => m.Value).FirstOrDefault();
            return await _actualScheduleService.ListByDateAsync(date, userEmail);
        }
    }
}
