using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DebtMovement;
namespace api.Dtos.Debt
{
    public class CreateDebtDto
    {

        public int? BusinessID { get; set; }

        public string Creditor { get; set; } = string.Empty;

        public decimal CantInit { get; set; }

        public decimal CurrentBalance { get; set; }
        public DateOnly StratDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public string Description { get; set; } = string.Empty;

        public List<DebtMovementDto> DebtMovements { get; set; } = new List<DebtMovementDto>();

    }
}