using FIT.API.Domain.Models;
using FIT.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> ListAsync();
        Task<SaveScheduleResponse> SaveAsync(SaveSchedule schedule);
    }
}
