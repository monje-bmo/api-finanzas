using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Dtos.User;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/account")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepo repo;
        public AccountController(AccountRepo r)
        {
            repo = r;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var ac = await repo.GetByIdAsync(id);
            if (ac == null) return NotFound("Cuenta no encontrada.");

            return Ok(ac.ToAccountDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();

            var accounts = await repo.GetAllAsync();

            return Ok(accounts.Select(a => a.ToAccountDto()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user_id = User.GetUserId();
            if (string.IsNullOrEmpty(user_id)) return Unauthorized("No se encontro el id del usuario.");

            var account = new Account
            {
                UserId = user_id,
                Name = dto.Name,
                TypeAccount = dto.TypeAccount,
                CoinTypeId = dto.CoinTypeId,
                OpeningBalance = dto.OpeningBalance,
                DateOpeningBalance = dto.DateOpeningBalance,
            };

            await repo.CreateAsync(account);

            return CreatedAtAction(
                nameof(GetById),
                new { id = account.Id },
                account.ToAccountDto()
            );
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAccountDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var account = await repo.UpdateAsync(id, dto);
            if (account == null) return NotFound("No se encontro la cuenta a editar.");

            return Ok(account.ToAccountDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var a = await repo.DeleteAsync(id);
            if (a == null) return NotFound("Cuenta no encontrada.");

            return NoContent();
        }

    }
}