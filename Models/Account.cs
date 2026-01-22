using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public string Name { get; set; } = string.Empty;

        public TypeAccountEnum TypeAccount { get; set; }

        public int CoinTypeId { get; set; }
        public CoinType CoinType { get; set; } = null!;

        [Precision(18, 2)]
        public decimal OpeningBalance { get; set; }
        public DateOnly DateOpeningBalance { get; set; }
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Update_at { get; set; } = DateTime.UtcNow;

        public List<JournalLine> JournalLines { get; set; } = new List<JournalLine>();

    }
}