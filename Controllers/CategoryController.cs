using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Category;
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
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly UserManager<User> userManager;
        public CategoryController(ICategoryRepository repo, UserManager<User> user)
        {
            _repo = repo;
            userManager = user;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var email = User.GetUserEmail();
            if(string.IsNullOrEmpty(email)) return Unauthorized("Inicie sesion de nuevo.");

            var user = await userManager.FindByEmailAsync(email);

            if (user == null) return NotFound("No se encontro el usuario.");

            var category = await _repo.GetCategoryByIdAsync(user.Id, id);
            if (category == null)
                return NotFound("Categoria no encontrada");

            return Ok(category.ToCategoryDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var email = User.GetUserEmail();
            if(string.IsNullOrEmpty(email)) return Unauthorized("Inicie sesion de nuevo.");

            var user = await userManager.FindByEmailAsync(email);

            if (user == null) return NotFound("No se encontro el usuario.");

            var c = await _repo.GetAllCategoryAsync(user.Id);

            return Ok(c.Select(f => f.ToCategoryDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var email = User.GetUserEmail();
            if(string.IsNullOrEmpty(email)) return Unauthorized("Inicie sesion de nuevo.");

            var user = await userManager.FindByEmailAsync(email);

            if (user == null) return NotFound("No se encontro el usuario.");

            var category = new Category
            {
                UserId = user.Id,
                Description = createCategoryDto.Description,
                Type_category = createCategoryDto.Type_category,
            };

            await _repo.CreateCategoryAsync(category);

            return CreatedAtAction(
                nameof(GetById),
                new { id = category.Id },
                category.ToCategoryDTO()
            );

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var email = User.GetUserEmail();
            if(string.IsNullOrEmpty(email)) return Unauthorized("Inicie sesion de nuevo.");

            var user = await userManager.FindByEmailAsync(email);

            if (user == null) return NotFound("No se encontro el usuario.");

            var category = await _repo.UpdateCategoryAsync(user.Id, id, updateCategoryDto);

            if (category == null)
                return NotFound("No se encontro la categoria.");

            return Ok(category.ToCategoryDTO());

        }

        [HttpDelete]
        [Route("id:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var email = User.GetUserEmail();
            if(string.IsNullOrEmpty(email)) return Unauthorized("Inicie sesion de nuevo.");

            var user = await userManager.FindByEmailAsync(email);

            if (user == null) return NotFound("No se encontro el usuario.");

            var category = await _repo.DeleteCategoryAsync(user.Id, id);
            if (category == null)
                return NotFound("No se encontro la categoria.");

            return NoContent();
        }


    }
}