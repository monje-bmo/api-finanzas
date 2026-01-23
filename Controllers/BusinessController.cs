using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business;
using api.Helpers;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/business")]
    [Authorize]
    public class BusinessController : ControllerBase
    {

        private readonly BusinessRepository repo;

        public BusinessController(BusinessRepository r)
        {
            repo = r;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var business = await repo.GetById(id);
            if (business == null) return NotFound("Negocio no encontrado.");

            return Ok(business.ToBusinessDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();

            var business = await repo.GetAllBussinesAsync();

            return Ok(business.Select(b => b.ToBusinessAllDto()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBusinessDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userId = User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return Unauthorized("no se encontro al usuario.");

            var business = new Business
            {
                UserId = userId,
                Description = dto.Description,
                TypeBusinessId = dto.TypeBusinessId
            };

            await repo.CreateBussinesAsync(business);
            return CreatedAtAction(
                nameof(GetById),
                new { id = business.Id },
                business.ToBusinessDto()
            );

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBusinessDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var business = await repo.UpdateBussinesAsync(id, dto);
            if (business == null) return NotFound("Negocio no encontrado.");

            return Ok(business.ToBusinessDto());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var business = await repo.DeleteBussinesAsync(id);
            if (business == null) return NotFound("Negocio no encontrado.");

            return NoContent();
        }




    }
}