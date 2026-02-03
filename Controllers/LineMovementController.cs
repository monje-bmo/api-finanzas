using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalLine;
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
    [Route("api/line")]
    [Authorize]
    public class LineMovementController : ControllerBase
    {
        private readonly IDailyMovement repo;
        private readonly UserManager<User> userManager;

        public LineMovementController(IDailyMovement daily, UserManager<User> user)
        {
            repo = daily;
            userManager = user;
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var email = User.GetUserEmail();
            if (string.IsNullOrEmpty(email)) return Unauthorized("Iniciar Sesion de Nuevo.");
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("Usuario no encontrado.");


            var line = await repo.GetById(user.Id, id);

            if (line == null) return NotFound("linea no encontrada.");

            // create dto response
            return Ok(line);

        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var line = await repo.DeleteLineJournal(id);
            if (line == null) return NotFound("No se encuentra la lineas.");

            return NoContent();
        }


        [HttpPut("id:int")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateJournalLineDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var line = await repo.UpdateLineJournal(id, dto);
            if (line == null) return NotFound("Linea no encontrado.");
            return Ok(line);
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJournalLineDto dto)
        {
            if(!ModelState.IsValid) return BadRequest();
            
            var email = User.GetUserEmail();
            if(string.IsNullOrEmpty(email)) return Unauthorized("Inicie Sesion.");
            
            var user = userManager.FindByEmailAsync(email);
            if(user == null) return NotFound("no esta e usuario.");

            var model = await repo.AddLineAsync(dto.ToDtoJL());

            return CreatedAtAction(
                nameof(GetById),
                new {id = model.Id},
                model.ToJournalLineDto()
            );
        }
    }
}