using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMappers
    {
        
        public static CategoryDto ToCategoryDTO(this Category category)
        {
            return new CategoryDto
            {
                Description = category.Description
            };
        }

    }
}