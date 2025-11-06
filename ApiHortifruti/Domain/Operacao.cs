using System.Text.Json.Serialization;

namespace ApiHortifruti.Domain;

/// <summary>
/// Tabela fixa (&quot;chumbada&quot;) com as operações do banco (CRUD)
/// </summary>
public partial class Operacao
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Permissao> Permissao { get; set; } = new List<Permissao>();
}
