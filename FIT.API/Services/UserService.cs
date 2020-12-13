using FIT.API.Domain.Models;
using FIT.API.Domain.Repositories;
using FIT.API.Domain.Services;
using FIT.API.Domain.Services.Communication;
using FIT.API.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FIT.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;

        public UserService(UserManager<IdentityUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginResource resource)
        {
            

            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user == null)
            {
                return new LoginResponse(false, "Invalid Email or password!");
            }

            var result = await _userManager.CheckPasswordAsync(user, resource.Password);

            if (!result)
            {
                return new LoginResponse(false, "Invalid Email or password!");
            }

            var claims = new[]
            {
                new Claim("Email", resource.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the key that we will use in the encryption"));

            var token = new JwtSecurityToken(
                issuer: "FIT.API",
                audience: "FIT.Front",
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResponse(tokenString);
        }

        public async Task SaveAsync(SaveUserResource user)
        {
            
        }
    }
}
