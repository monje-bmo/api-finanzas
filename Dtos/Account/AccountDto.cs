using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalLine;
using api.Enums;

namespace api.Dtos.Account
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TypeAccountEnum TypeAccount { get; set; }
        public int CoinTypeId { get; set; }
        public decimal OpeningBalance { get; set; }
        public DateOnly DateOpeningBalance { get; set; }

    }
}