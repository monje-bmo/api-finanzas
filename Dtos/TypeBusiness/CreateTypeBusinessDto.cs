using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TypeBusiness
{
    public class CreateTypeBusinessDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "No se aceptan mas de 10 caracteres.")]
        public string Description { get; set; } = string.Empty;
    }
}