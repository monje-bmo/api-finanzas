using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.DebtMovement
{
    public class DebtMovementDto
    {
        public int Id { get; set; }

        // fk debt
        public int DebtId { get; set; }

        // fk JournalHeader
        public int JournalHeaderId { get; set; }

        public decimal? CapitalAmount { get; set; }
        public decimal? InterestAmount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}