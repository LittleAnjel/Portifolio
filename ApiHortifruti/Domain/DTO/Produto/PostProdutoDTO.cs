using System.ComponentModel.DataAnnotations;

public class PostProdutoDTO
{
    // ADICIONAR CAMPO DE TIPO DE MEDIDA (UNIDADE OU PESO)? SE FOR UNIDADE IMPEDIR VALORES DECIMAIS ENQUANTO QUE PESO PERMITE INTEIRO E DECIMAL
    // QUANTIDADES JÁ FORAM ALTERADAS PARA DECIMAL NO BANCO DE DADOS. QUANTIDADE MÁXIMA FOI REMOVIDA

    [Required(ErrorMessage = "Por favor, informe uma categoria")]
    public int CategoriaId { get; set; }


    [Required(ErrorMessage = "Por favor, informe uma unidade de medida")]
    public int UnidadeMedidaId { get; set; }


    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [StringLength(75, ErrorMessage = "O nome do produto não pode exceder 75 caracteres")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O código do produto é obrigatório")]
    public string Codigo { get; set; }


    [StringLength(150, ErrorMessage = "A descrição do produto não pode exceder 150 caracteres")]
    public string? Descricao { get; set; }


    [Required(ErrorMessage = "O preço do produto é obrigatório")]
    [ValidacaoCampoPreco(ErrorMessage = "Preço do produto inválido")]
    public decimal Preco { get; set; }


    [Range(0, 0, ErrorMessage = "Tentativa de criação do produto com quantidade inicial diferente de zero")] // JÁ QUE SERA MUDADA PARA DECIMAL. USAR STRING NO RANGE?
    public decimal QuantidadeAtual { get; set; }


    [Range(0, double.MaxValue, ErrorMessage = "A quantidade mínima não pode ser negativa")]
    public decimal QuantidadeMinima { get; set; }
}