using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Debt
{
    public class UpdateDebtDto
    {


        public int? BusinessID { get; set; }

        public string Creditor { get; set; } = string.Empty;

        public decimal CantInit { get; set; }

        public decimal CurrentBalance { get; set; }
        public DateOnly StratDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;

    }
}