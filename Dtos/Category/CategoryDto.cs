using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalLine;
using api.Enums;

namespace api.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string? Description { get; set; }

        public TypeCategorieEnum Type_category { get; set; }

        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }

        public List<JournalLineDto> JournalLines { get; set; }

    }
}