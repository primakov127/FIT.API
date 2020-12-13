using FIT.API.Domain.Models;
using FIT.API.Domain.Services.Communication;
using FIT.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Services
{
    public interface IUserService
    {
        Task SaveAsync(SaveUserResource user);
        Task<LoginResponse> LoginUserAsync(LoginResource resource);
    }
}
