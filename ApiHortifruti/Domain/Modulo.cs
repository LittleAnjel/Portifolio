using System.Text.Json.Serialization;

namespace ApiHortifruti.Domain;

/// <summary>
/// Tabela fixa (&quot;chumbada&quot;) com os registros dos módulos do sistema.
/// 
/// ex: Produto, Venda, Relatório, Funcionário etc.
/// </summary>
public partial class Modulo
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public bool Ativo { get; set; }

    [JsonIgnore]
    public virtual ICollection<Permissao> Permissao { get; set; } = new List<Permissao>();
}
