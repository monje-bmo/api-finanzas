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
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var email = User.GetUserEmail();
            if (string.IsNullOrEmpty(email)) return Unauthorized("Inicie sesion de nuevo.");
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("Usuario no encontrado.");

            var movementDaily = await repo.GetById(user.Id.ToString(), id);
            if (movementDaily == null) return NotFound("Movimineto no encontrado.");

            return Ok(movementDaily.toMovementDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJournalHeaderDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var email = User.GetUserEmail();
            if(string.IsNullOrEmpty(email)) return Unauthorized("Inicie sesion de nuevo.");
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("Usuario no encontrado.");

            var dailyMovementModel = new JournalHeader
            {
                UserId = user.Id,
                DateMove = dto.DateMove,
                TypeMoves = dto.TypeMoves,
                Description = dto.Description,
                JournalLines = dto.journalLineDtos.Select(
                    l => new JournalLine
                    {
                        AccountId = l.AccountId,
                        Amount = l.Amount,
                        CategoryId = l.CategoryId,
                        BusinessId = l.BusinessId,
                        Note = l.Note
                    }
                ).ToList()
            };

            var dailyMovement = await repo.AddAsync(dailyMovementModel);

            return CreatedAtAction(
                nameof(GetById),
                new {id = dailyMovement.Id},
                dailyMovement.toMovementDto()
            );

        }

    }
}