using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.DebtMovement
{
    public class CreateDebtMovementDto
    {

        public decimal? CapitalAmount { get; set; }
        public decimal? InterestAmount { get; set; }

    }
}