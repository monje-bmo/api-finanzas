using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.Account
{
    public class UpdateAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public TypeAccountEnum TypeAccount { get; set; }
        public int CoinTypeId { get; set; }
        public decimal OpeningBalance { get; set; }
        public DateOnly DateOpeningBalance { get; set; }
        public bool State { get; set; } = true;
    }
}