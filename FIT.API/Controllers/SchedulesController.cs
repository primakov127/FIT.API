using AutoMapper;
using FIT.API.Domain.Models;
using FIT.API.Domain.Services;
using FIT.API.Extensions;
using FIT.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;

        public SchedulesController(IScheduleService scheduleService, IMapper mapper)
        {
            _scheduleService = scheduleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ScheduleResource>> GetAllAsync()
        {
            var schedules = await _scheduleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleResource>>(schedules);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveScheduleResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var saveSchedule = _mapper.Map<SaveScheduleResource, SaveSchedule>(resource);
            var result = await _scheduleService.SaveAsync(saveSchedule);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Schedule);
            return Ok(scheduleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _scheduleService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Schedule);
            return Ok(scheduleResource);
        }
    }
}
