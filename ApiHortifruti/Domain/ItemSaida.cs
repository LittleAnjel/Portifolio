namespace ApiHortifruti.Domain;

public partial class ItemSaida
{
    public int Id { get; set; }

    public int ProdutoId { get; set; }

    public int SaidaId { get; set; }

    public int Quantidade { get; set; }

    public decimal Valor { get; set; }

    public virtual Produto Produto { get; set; } = null!;

    public virtual Saida Saida { get; set; } = null!;
}
