using FIT.API.Domain.Services;
using FIT.API.Extensions;
using FIT.API.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]SaveUserResource resource)
        {
            await _userService.SaveAsync(resource);
            return Ok(resource);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _userService.LoginUserAsync(resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Token);
        }
    }
}
