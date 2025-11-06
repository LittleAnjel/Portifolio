using System.ComponentModel.DataAnnotations;
using ApiHortifruti.Domain.DTO.CustomAnnotation;

namespace ApiHortifruti.Domain.DTO.ItemSaida;

public class ItemSaidaDTO
{
    [Required(ErrorMessage = "O ID do produto é obrigatório no item da saída")]
    public int ProdutoId { get; set; }


    [Required(ErrorMessage = "A quantidade não pode ser nula/vazia")]
    [Range(0, 99999999.99, MinimumIsExclusive = true, ErrorMessage = "A quantidade deve ser maior que zero")]
    public int Quantidade { get; set; }


    [Required(ErrorMessage = "O valor do produto é obrigatório")]
    [Range(0, 99999999.99, MinimumIsExclusive = true, ErrorMessage = "O preço deve ser maior que zero")] // Valor maior que zero
    public decimal Valor { get; set; } // É realmente necessário?
}
