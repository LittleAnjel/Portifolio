using System.ComponentModel.DataAnnotations;

public class ValidacaoCampoPrecoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("O preço não pode ser nulo");

        if (value is decimal preco)
        {
            // Verifica se tem no máximo 2 casas decimais
            decimal rounded = Math.Round(preco, 2);
            if (preco != rounded)
                return new ValidationResult("O preço deve ter no máximo 2 casas decimais");

            // Verifica se está dentro do intervalo permitido
            if (preco <= 0 || preco > 99999999.99m)
                return new ValidationResult("O preço deve ser maior que zero e menor que 99.999.999,99");

            return ValidationResult.Success;
        }

        return new ValidationResult("Valor não é um preço válido");
    }
}