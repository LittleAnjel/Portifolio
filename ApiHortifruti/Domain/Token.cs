namespace ApiHortifruti.Domain;

public partial class Token
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public int FuncionarioId { get; set; }

    public DateOnly DataGeracao { get; set; }

    public TimeOnly HoraGeracao { get; set; }

    public virtual Funcionario Funcionario { get; set; } = null!;
}
