using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Debt;
using api.Dtos.DebtMovement;
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
            if (!ModelState.IsValid) return BadRequest();
            var email = User.GetUserEmail();
            if (string.IsNullOrEmpty(email)) return Unauthorized("inicie sesion.");

            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();

            var model = await repo.GetById(user.Id, id);
            if (model == null) return NotFound("Debito no encontrado.");

            return Ok(model.ToDebtDto());

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();

            var email = User.GetUserEmail();

            if (string.IsNullOrWhiteSpace(email)) return Unauthorized("inicie Sesion");

            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("no se encuentra el usuario.");

            var model = await repo.GetAllAsync(user.Id);

            return Ok(model.Select(m => m.ToDebtDto()).ToList());

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var email = User.GetUserEmail();

            if (string.IsNullOrWhiteSpace(email)) return Unauthorized("inicie Sesion");

            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("no se encuentra el usuario.");

            var model = await repo.DeteleAsync(user.Id, id);
            if (model == null) return NotFound("debito no encontrado.");

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDebtDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var email = User.GetUserEmail();

            if (string.IsNullOrWhiteSpace(email)) return Unauthorized("inicie Sesion");

            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("no se encuentra el usuario.");


            var model = await repo.UpdateAsync(user.Id, id, dto);
            if (model == null) return NotFound("no se encuentra el movimiento");

            return Ok(model.ToDebtDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDebtDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var email = User.GetUserEmail();

            if (string.IsNullOrWhiteSpace(email)) return Unauthorized("inicie Sesion");

            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("no se encuentra el usuario.");


            var model = new Debt
            {
                UserId = user.Id,
                BusinessID = dto.BusinessID,
                Creditor = dto.Creditor,
                CantInit = dto.CantInit,
                CurrentBalance = dto.CurrentBalance,
                StratDate = dto.StratDate,
                ExpirationDate = dto.ExpirationDate,
                Description = dto.Description,
                DebtMovements = dto.DebtMovements.Select(
                    d => new DebtMovement
                    {
                        CapitalAmount = d.CapitalAmount,
                        InterestAmount = d.InterestAmount
                    }).ToList()
            };

            await repo.AddAsync(user.Id, model);

            return CreatedAtAction(
                nameof(GetById),
                new {id = model.Id},
                model.ToDebtDto()
            );
        }

    }
}