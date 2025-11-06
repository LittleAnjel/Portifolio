using System.ComponentModel.DataAnnotations;

public class PostCategoriaDTO
{
    [Required(ErrorMessage = "O nome da categoria é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome da categoria não pode exceder 50 caracteres")]
    public string Nome { get; set; }
}