using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalLine;
using api.Enums;

namespace api.Dtos.JournalHeader
{
    public class MovementDto
    {
        public int Id { get; set; }
        public DateTime DateMove { get; set; } = DateTime.UtcNow;
        public TypeMove TypeMoves { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<JournalLineDto> JournalLines { get; set; } = new List<JournalLineDto>();

    }
}