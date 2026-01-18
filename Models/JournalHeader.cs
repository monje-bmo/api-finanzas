using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Models
{
    public class JournalHeader
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime DateMove { get; set; } = DateTime.UtcNow;
        public TypeMove TypeMoves { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Update_at { get; set; } = DateTime.UtcNow;

        public List<JournalLine> JournalLines { get; set; } = new List<JournalLine>();
    }
}