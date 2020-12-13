using FIT.API.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Services
{
    public interface IActualScheduleService
    {
        Task<IEnumerable<ViewActualSchedule>> ListByDateAsync(DateTime date, string userEmail);
    }
}
