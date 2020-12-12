using FIT.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Services.Communication
{
    public class SaveScheduleResponse : BaseResponse
    {
        public Schedule Schedule { get; private set; }

        private SaveScheduleResponse(bool success, string message, Schedule schedule) : base(success, message)
        {
            Schedule = schedule;
        }

        public SaveScheduleResponse(Schedule schedule) : this(true, string.Empty, schedule)
        {

        }

        public SaveScheduleResponse(string message) : this(false, message, null)
        {

        }
    }
}
