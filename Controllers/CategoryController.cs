using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Helpers;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _repo;
        public CategoryController(CategoryRepository categoryRepository)
        {
            _repo = categoryRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _repo.GetCategoryByIdAsync(id);
            if (category == null) 
                return NotFound("Categoria no encontrada");
            
            return Ok(category.ToCategoryDTO());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            var userId = User.GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("No se encontró el UserId en el token.");

            var category = new Category
            {
                UserId = userId,
                Description = createCategoryDto.Description,
                Type_category = createCategoryDto.Type_category,
            };

            await _repo.CreateCategoryAsync(category);

            return CreatedAtAction(
                nameof(GetById),
                new{id = category.Id},
                category
            );

        }

    }
}