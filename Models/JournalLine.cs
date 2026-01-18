using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class JournalLine
    {
        public int Id { get; set; }
        public int JournalHeaderId { get; set; }
        public JournalHeader JournalHeader { get; set; } = null!;
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        [Precision(18,2)]
        public decimal Amount { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? BusinessId { get; set; }
        public Business? Business { get; set; }
        public string? Note { get; set; }
    }
}