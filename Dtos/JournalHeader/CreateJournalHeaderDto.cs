using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.JournalHeader
{
    public class CreateJournalHeaderDto
    {
        public DateTime DateMove { get; set; }
        public TypeMove TypeMoves { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}