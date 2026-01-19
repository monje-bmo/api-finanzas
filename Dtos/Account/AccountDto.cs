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
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public TypeAccountEnum TypeAccount { get; set; }
        public int CoinTypeId { get; set; }
        public decimal OpeningBalance { get; set; }
        public DateOnly DateOpeningBalance { get; set; }
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Update_at { get; set; } = DateTime.UtcNow;

        public List<JournalLineDto> JournalLines { get; set; }
        
    }
}