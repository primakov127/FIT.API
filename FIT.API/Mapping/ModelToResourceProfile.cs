using AutoMapper;
using FIT.API.Domain.Models;
using FIT.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Schedule, ScheduleResource>();
        }
    }
}
