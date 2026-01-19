using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DebtMovement;

namespace api.Dtos.Debt
{
    public class DebtDto
    {
        public int Id { get; set; }

        //fk user
        public int UserId { get; set; }

        // fk business
        public int? BusinessID { get; set; }

        public string Creditor { get; set; } = string.Empty;

        public decimal CantInit { get; set; }

        public decimal CurrentBalance { get; set; }
        public DateOnly StratDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public List<DebtMovementDto> DebtMovements { get; set; }

    }
}