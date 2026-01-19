using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class ResponseLoginDto
    {
        public string Token { get; set; } = string.Empty;
    }
}