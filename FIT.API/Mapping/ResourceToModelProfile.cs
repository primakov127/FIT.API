using AutoMapper;
using FIT.API.Domain.Models;
using FIT.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveScheduleResource, SaveSchedule>();
        }
    }
}
