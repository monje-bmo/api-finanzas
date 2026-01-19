using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.JournalLine
{
    public class UpdateJournalLineDto
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int? CategoryId { get; set; }
        public int? BusinessId { get; set; }
        public string? Note { get; set; }
    }
}