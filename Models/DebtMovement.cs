using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class DebtMovement
    {
        public int Id { get; set; }

        // fk debt
        public int DebtId { get; set; }
        public Debt Debt { get; set; } = null!;

        // fk JournalHeader
        public int JournalHeaderId { get; set; }
        public JournalHeader JournalHeader { get; set; } = null!;

        [Precision(18, 2)]
        public decimal? CapitalAmount { get; set; }
        [Precision(18, 2)]
        public decimal? InterestAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}