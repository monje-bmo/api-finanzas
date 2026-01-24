using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _token;

        private readonly SignInManager<User> signInManager;

        public AuthController(UserManager<User> user, ITokenService token, SignInManager<User> signIn)
        {
            _userManager = user;
            _token = token;
            signInManager = signIn;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var usr = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);
            if (usr == null) return NotFound("No se encontro al usuario.");

            var result = await signInManager.CheckPasswordSignInAsync(usr, loginDto.Password, false);
            if(!result.Succeeded) return Unauthorized("el username o password, son incorrectos.");

            return Ok(
                new NewUserDTO
                {
                    Email = usr.Email,
                    UserName = usr.UserName,
                    Token = _token.CreateToken(usr)
                }
            );

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new User
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email
                };


                var createUser = await _userManager.CreateAsync(user, registerDTO.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDTO
                            {
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = _token.CreateToken(user)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }

                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    error = "Unexpected error",
                    datail = e.Message
                });
            }
        }


    }
}