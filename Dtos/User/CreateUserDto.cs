using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password_hash { get; set; } = string.Empty;

    }
}