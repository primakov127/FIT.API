using FIT.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> ListAsync();
        Task AddOneInTwoWeekAsync(SaveSchedule saveSchedule);
        Task AddTwoInTwoWeekAsync(SaveSchedule saveSchedule);
        Task<Schedule> FindByIdAsync(long id);
    }
}
