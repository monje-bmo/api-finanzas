using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.Category
{
    public class CreateCategoryDto
    {

        public string? Description { get; set; }

        public TypeCategorieEnum Type_category { get; set; }

    }
}