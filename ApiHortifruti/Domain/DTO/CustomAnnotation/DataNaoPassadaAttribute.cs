using System.ComponentModel.DataAnnotations;

namespace ApiHortifruti.Domain.DTO.CustomAnnotation;

public class DataNaoPassadaAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateOnly dateOnly)
        {
            if (dateOnly < DateOnly.FromDateTime(DateTime.Today))
            {
                return new ValidationResult(ErrorMessage ?? "A data não pode ser uma data passada.");
            }
        }
        return ValidationResult.Success;
    }
}
