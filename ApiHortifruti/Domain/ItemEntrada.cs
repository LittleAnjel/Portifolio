namespace ApiHortifruti.Domain;

/// <summary>
/// Não sei como seria o relacionamento. Recebe id de produto (igual a itemSaida?
/// </summary>
public partial class ItemEntrada
{
    public int Id { get; set; }

    public int EntradaId { get; set; }

    public int ProdutoId { get; set; }

    public decimal Quantidade { get; set; }

    public string? Lote { get; set; }

    public decimal PrecoUnitario { get; set; }

    public string? Validade { get; set; }

    public virtual Entrada? Entrada { get; set; } = null!;

    public virtual Produto? Produto { get; set; } = null!;
}
