using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.Account
{
    public class UpdateAccountDto : IValidatableObject
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(20, ErrorMessage = "No se acepta más de 20 caracteres.")]
        [MinLength(1, ErrorMessage = "El nombre no puede estar vacío.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de cuenta es obligatorio.")]
        [EnumDataType(typeof(TypeAccountEnum), ErrorMessage = "Tipo de cuenta inválido.")]
        public TypeAccountEnum TypeAccount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CoinTypeId debe ser mayor que 0.")]
        public int CoinTypeId { get; set; }

        // sin saldos negativos 
        [Range(typeof(decimal), "0", "999999999999", ErrorMessage = "OpeningBalance debe ser >= 0.")]
        public decimal OpeningBalance { get; set; }

        public DateOnly DateOpeningBalance { get; set; }
        public bool State { get; set; } = true;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            if (DateOpeningBalance > today)
                yield return new ValidationResult(
                    "fecha no puede ser una fecha futura.",
                    new[] { nameof(DateOpeningBalance) }
                );
        }
    }
}