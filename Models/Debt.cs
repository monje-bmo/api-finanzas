using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Debt
    {
        public int Id { get; set; }

        //fk user
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // fk business
        public int? BusinessID { get; set; }
        public Business? Business { get; set; }

        public string Creditor { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal CantInit { get; set; }

        [Precision(18, 2)]
        public decimal CurrentBalance { get; set; }
        public DateOnly StratDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

        public List<DebtMovement> DebtMovements { get; set; } = new List<DebtMovement>();

    }
}