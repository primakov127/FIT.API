using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Domain.Services.Communication
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; private set; }

        private LoginResponse(bool success, string message, string token) : base(success, message)
        {
            Token = token;
        }

        public LoginResponse(string token) : this(true, string.Empty, token)
        {

        }

        public LoginResponse(bool success, string message) : this(success, message, string.Empty)
        {

        }
    }
}
