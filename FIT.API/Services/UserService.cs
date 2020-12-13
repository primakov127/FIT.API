using FIT.API.Domain.Models;
using FIT.API.Domain.Repositories;
using FIT.API.Domain.Services;
using FIT.API.Resources;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
        }

        public async Task SaveAsync(SaveUserResource user)
        {
            await _roleManager.CreateAsync(new IdentityRole("ADMIN"));
            await _roleManager.CreateAsync(new IdentityRole("TEACHER"));
            await _roleManager.CreateAsync(new IdentityRole("STUDENT"));

            using (StreamReader r = new StreamReader(@"C:\Users\prima\OneDrive\Desktop\PMN-CP\FIT.DataBase\TestData\Json\teachers.json"))
            {
                string json = await r.ReadToEndAsync();
                List<SaveUser> items = JsonConvert.DeserializeObject<List<SaveUser>>(json);
                foreach(var item in items)
                {
                    await _userManager.CreateAsync(new IdentityUser 
                    {
                        Email = item.Id + "@gmail.com",
                        UserName = item.Id
                    }, "123456");
                    IdentityUser identityUser = _userManager.FindByNameAsync(item.Id).Result;
                    item.Id = identityUser.Id;
                    await _userManager.AddToRoleAsync(identityUser, "TEACHER");
                    await _userRepository.AddUserTeacherAsync(item);
                }
            }

            using (StreamReader r = new StreamReader(@"C:\Users\prima\OneDrive\Desktop\PMN-CP\FIT.DataBase\TestData\Json\students.json"))
            {
                string json = await r.ReadToEndAsync();
                List<SaveUser> items = JsonConvert.DeserializeObject<List<SaveUser>>(json);
                foreach(var item in items)
                {
                    await _userManager.CreateAsync(new IdentityUser
                    {
                        Email = item.Id + "@gmail.com",
                        UserName = item.Id
                    }, "123456");
                    IdentityUser identityUser = _userManager.FindByNameAsync(item.Id).Result;
                    item.Id = identityUser.Id;
                    await _userManager.AddToRoleAsync(identityUser, "STUDENT");
                    await _userRepository.AddUserStudentAsync(item);
                }
            }
        }
    }
}
