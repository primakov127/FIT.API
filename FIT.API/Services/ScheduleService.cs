using FIT.API.Domain.Models;
using FIT.API.Domain.Repositories;
using FIT.API.Domain.Services;
using FIT.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _scheduleRepository.ListAsync();
        }

        public async Task<ScheduleResponse> SaveAsync(SaveSchedule schedule)
        {
            try
            {
                if (schedule.Week == 0)
                    await _scheduleRepository.AddTwoInTwoWeekAsync(schedule);
                else
                    await _scheduleRepository.AddOneInTwoWeekAsync(schedule);

                Schedule savedSchedule = await _scheduleRepository.FindByIdAsync(schedule.ScheduleId);
                return new ScheduleResponse(savedSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error occurred when saving the schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> DeleteAsync(long id)
        {
            var existingSchedule = await _scheduleRepository.FindByIdAsync(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found.");

            try
            {
                _scheduleRepository.Remove(existingSchedule);

                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
