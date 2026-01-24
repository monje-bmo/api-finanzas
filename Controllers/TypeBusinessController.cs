using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Repository;
using api.Dtos.TypeBusiness;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Helpers;

namespace api.Controllers
{
    [ApiController]
    [Route("api/typeBusiness")]
    public class TypeBusinessController : ControllerBase
    {
        private readonly ITypeBusinessRepo repo;
        public TypeBusinessController(ITypeBusinessRepo repoTB)
        {
            repo = repoTB;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var typeBusiness = await repo.GetByIdTypeBusinessAsync(id);

            if (typeBusiness == null) return NotFound("Tipo de categoria no encontrado.");

            return Ok(typeBusiness.TypeBusinessDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest();

            var types = await repo.GetAllTypeBusinessAsync();

            return Ok(types.Select(t => t.TypeBusinessDto()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTypeBusinessDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var typeBusinnes = dto.CreateDtoToTypeBusiness();

            await repo.CreateTypeBusinnesAsync(typeBusinnes);

            return CreatedAtAction(
                nameof(GetByID),
                new { id = typeBusinnes.Id },
                typeBusinnes.TypeBusinessDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTypeBusinessDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var type = await repo.UpdateTypeBusinessAsync(id, dto);
            if (type == null) return NotFound("no se encontro el tipo de negocio");

            return Ok(type.TypeBusinessDto());
        }

        [HttpDelete]
        [Route("id:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var type = await repo.DeleteTypeBusinessAsync(id);
            if (type == null) return NotFound("No se encontro el tipo de negocio.");

            return NoContent();
        }


    }
}