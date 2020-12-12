using FIT.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Services.Communication
{
    public class ScheduleResponse : BaseResponse
    {
        public Schedule Schedule { get; private set; }

        private ScheduleResponse(bool success, string message, Schedule schedule) : base(success, message)
        {
            Schedule = schedule;
        }

        public ScheduleResponse(Schedule schedule) : this(true, string.Empty, schedule)
        {

        }

        public ScheduleResponse(string message) : this(false, message, null)
        {

        }
    }
}
