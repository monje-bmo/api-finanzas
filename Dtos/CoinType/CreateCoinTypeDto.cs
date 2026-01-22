using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CoinType
{
    public class CreateCoinTypeDto
    {
        [Required]
        [MaxLength(15, ErrorMessage = "Descripción no puede ser mayor a 15 caracteres")]
        public string Description { get; set; } = string.Empty;
        
    }
}