using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.Category
{
    public class UpdateCategoryDto
    {

        [Required]
        [MaxLength(15, ErrorMessage = "No se acepta mayores a 15 caracteres")]
        public string? Description { get; set; }

        [Required]
        public TypeCategorieEnum Type_category { get; set; }

        public bool State { get; set; } = true;

    }
}