using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string? UserId { get; set; }
        public User User { get; set; } = null!;

        public string? Description { get; set; }

        public TypeCategorieEnum Type_category { get; set; }

        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Update_at { get; set; } = DateTime.UtcNow;

        public List<JournalLine> JournalLines { get; set; } = new List<JournalLine>();

    }
}