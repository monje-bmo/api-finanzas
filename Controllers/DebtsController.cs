using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/debts")]
    [Authorize]
    public class DebtsController : ControllerBase
    {

        private readonly IDebtsInterface repo;
        private readonly UserManager<User> userManager;
        public DebtsController(IDebtsInterface debts, UserManager<User> user)
        {
            repo = debts;
            userManager = user;
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid) return BadRequest();
            var email = User.GetUserEmail();
            if(string.IsNullOrEmpty(email)) return Unauthorized("inicie sesion.");
            
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();

            var model = await repo.GetById(user.Id, id);
            if (model == null) return NotFound("Debito no encontrado.");

            return Ok(model.ToDebtDto());

        }


    }
}