using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public int TypeBusinessId { get; set; }
        public TypeBusiness TypeBusiness { get; set; } = null!;

        public string? Description { get; set; }
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Update_at { get; set; } = DateTime.UtcNow;

        public List<JournalLine> JournalLines { get; set; } = new List<JournalLine>();

    }
}