using FIT.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddUserStudentAsync(SaveUser user);
        Task AddUserTeacherAsync(SaveUser user);
    }
}
