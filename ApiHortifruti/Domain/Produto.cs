using System.Text.Json.Serialization;

namespace ApiHortifruti.Domain;

public partial class Produto
{
    public int Id { get; set; }

    public int CategoriaId { get; set; }

    public int UnidadeMedidaId { get; set; }

    public string Nome { get; set; }

    public string Codigo { get; set; }
        
    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public decimal QuantidadeAtual { get; set; } = 0;

    public decimal QuantidadeMinima { get; set; }

    /// <summary>
    /// Talvez alterar quant. máx para permitir NULL?
    /// </summary>

    public virtual Categoria? Categoria { get; set; }
 
    public virtual UnidadeMedida? UnidadeMedida { get; set; }

    [JsonIgnore]
    public virtual ICollection<FornecedorProduto> FornecedorProduto { get; set; } = new List<FornecedorProduto>();

    [JsonIgnore]
    public virtual ICollection<HistoricoProduto> HistoricoProduto { get; set; } = new List<HistoricoProduto>();

    [JsonIgnore]
    public virtual ICollection<ItemEntrada> ItemEntrada { get; set; } = new List<ItemEntrada>();

    [JsonIgnore]
    public virtual ICollection<ItemSaida> ItemSaida { get; set; } = new List<ItemSaida>();
}
