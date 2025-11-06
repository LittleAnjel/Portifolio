using System.Text.Json.Serialization;

namespace ApiHortifruti.Domain;

public partial class Fornecedor
{
    public int Id { get; set; }

    public string NomeFantasia { get; set; } = null!;

    public string CadastroPessoa { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string? TelefoneExtra { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly DataRegistro { get; set; }

    [JsonIgnore]
    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    [JsonIgnore]
    public virtual ICollection<FornecedorProduto> FornecedorProduto { get; set; } = new List<FornecedorProduto>();
}
