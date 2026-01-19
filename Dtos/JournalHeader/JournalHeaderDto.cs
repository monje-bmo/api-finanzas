using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DebtMovement;
using api.Dtos.JournalLine;
using api.Enums;

namespace api.Dtos.JournalHeader
{
    public class JournalHeaderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateMove { get; set; }
        public TypeMove TypeMoves { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }


    }
}