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
    public class ActualScheduleService : IActualScheduleService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IActualScheduleRepository _actualScheduleRepository;

        public ActualScheduleService(UserManager<IdentityUser> userManager, IActualScheduleRepository actualScheduleRepository)
        {
            _userManager = userManager;
            _actualScheduleRepository = actualScheduleRepository;
        }

        public async Task<IEnumerable<ViewActualSchedule>> ListByDateAsync(DateTime date, string userEmail)
        {
            var currentUser = await _userManager.FindByEmailAsync(userEmail);

            if (await _userManager.IsInRoleAsync(currentUser, "TEACHER"))
            {
                return await _actualScheduleRepository.FindTeacherByDate(date, currentUser.Id);
            }
            else if (await _userManager.IsInRoleAsync(currentUser, "STUDENT"))
            {
                return await _actualScheduleRepository.FindStudentByDate(date, currentUser.Id);
            }
            else
            {
                return new List<ViewActualSchedule>();
            }
        }
    }
}
