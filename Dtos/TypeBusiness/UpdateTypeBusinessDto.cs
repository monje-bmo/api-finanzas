using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TypeBusiness
{
    public class UpdateTypeBusinessDto
    {
        [MaxLength(10, ErrorMessage = "no se aceptan mas de 10 caracteres.")]
        public string Description { get; set; } = string.Empty;

        public bool State { get; set; }
    }
}