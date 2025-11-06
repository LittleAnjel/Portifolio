using System.Text.Json.Serialization;

namespace ApiHortifruti.Domain;

public partial class Funcionario
{
    public int Id { get; set; }

    public int CargoId { get; set; }

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string? TelefoneExtra { get; set; }

    public string Email { get; set; } = null!;

    public string ContaBancaria { get; set; } = null!;

    public string AgenciaBancaria { get; set; } = null!;

    public bool Ativo { get; set; }

    public virtual Cargo? Cargo { get; set; }

    [JsonIgnore]
    public virtual ICollection<HistoricoProduto> HistoricoProduto { get; set; } = new List<HistoricoProduto>();

    [JsonIgnore]
    public virtual ICollection<Saida> Saida { get; set; } = new List<Saida>();

    [JsonIgnore]
    public virtual ICollection<Token> Token { get; set; } = new List<Token>();

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
