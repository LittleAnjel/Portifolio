namespace ApiHortifruti.Domain;

/// <summary>
/// Necessário? Criei mais para registrar o momento que um usuário faz login no sistema, para ter uma ideia
/// </summary>
public partial class LogLogin
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime DataHora { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
