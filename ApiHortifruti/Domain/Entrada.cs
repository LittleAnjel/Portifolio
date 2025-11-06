using System.Text.Json.Serialization;

namespace ApiHortifruti.Domain;

public partial class Entrada
{
    public int Id { get; set; }

    public int FornecedorId { get; set; }

    public int MotivoMovimentacaoId { get; set; }

    public decimal PrecoTotal { get; set; }

    public DateOnly DataCompra { get; set; } // DateOnly(Ano, mês, dia)

    public string NumeroNota { get; set; } = null!; // Não pode ser repetida por fornecedor

    // public string NotaFiscal { get; set; } = null!; // Removido

    public virtual Fornecedor? Fornecedor { get; set; } = null!;

    public virtual MotivoMovimentacao? MotivoMovimentacao { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ItemEntrada> ItemEntrada { get; set; } = new List<ItemEntrada>();
}
