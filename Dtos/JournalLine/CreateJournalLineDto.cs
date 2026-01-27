using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.JournalLine
{
    public class CreateJournalLineDto
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public int? BusinessId { get; set; }
        [MaxLength(50, ErrorMessage = "no se aceptan mas de 50 caracteres.")]
        public string? Note { get; set; }
    }
}