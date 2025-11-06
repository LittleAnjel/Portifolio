using System.ComponentModel.DataAnnotations;

public class PostUnidadeMedidaDTO
{
    [Required(ErrorMessage = "O nome da unidade de medida é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome da unidade de medida não pode exceder 50 caracteres")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O abreviação da unidade de medida é obrigatória")]
    [StringLength(10, ErrorMessage = "O nome da unidade de medida não pode exceder 10 caracteres")]
    public string Abreviacao { get; set; }
}