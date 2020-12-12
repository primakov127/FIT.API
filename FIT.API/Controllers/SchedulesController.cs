using AutoMapper;
using FIT.API.Domain.Models;
using FIT.API.Domain.Services;
using FIT.API.Resources;
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
    }
}
