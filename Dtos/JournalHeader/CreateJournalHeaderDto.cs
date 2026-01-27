using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalLine;
using api.Enums;

namespace api.Dtos.JournalHeader
{
    public class CreateJournalHeaderDto
    {
        [Required]
        public DateTime DateMove { get; set; }
        [Required]
        public TypeMove TypeMoves { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "No se permite mas de 255 caracteres")]
        public string Description { get; set; } = string.Empty;
        public List<CreateJournalLineDto> journalLineDtos { get; set; } = new();

    }
}