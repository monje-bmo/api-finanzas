using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalHeader;
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
    [Route("api/dailyMovement")]
    [Authorize]
    public class DailyMovementController : ControllerBase
    {

        private readonly IDailyMovement repo;
        private readonly UserManager<User> userManager;
        public DailyMovementController(IDailyMovement dailyMovement, UserManager<User> user)
        {
            repo = dailyMovement;
            userManager = user;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromBody] int id)
        {

            var email = User.GetUserEmail();
            if (string.IsNullOrEmpty(email)) return Unauthorized("Inicie sesion de nuevo.");
            var user = userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("Usuario no encontrado.");

            var movementDaily = await repo.GetById(user.Id.ToString(), id);
            if (movementDaily == null) return NotFound("Movimineto no encontrado.");

            return Ok(movementDaily.toMovementDto());
        }


        // public async Task<IActionResult> Create(CreateJournalHeaderDto dto)
        // {

        // }

    }
}