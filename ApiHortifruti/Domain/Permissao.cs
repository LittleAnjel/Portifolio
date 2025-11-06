namespace ApiHortifruti.Domain;

/// <summary>
/// Tabela associando quais operações em quais módulos certo cargo pode acessar
/// 
/// ex: Cargo 1 pode acessar módulo de Funcionários e fazer qualquer tipo de operação
/// 
/// cargo_id | modulo_id | operacao_id | permitido
/// 
///      1	      3	         1              1
///      1	      3	         2              1
///      1	      3	         3              1
///      1	      3	         4              1
/// </summary>
public partial class Permissao
{
    public int Id { get; set; }

    public int CargoId { get; set; }

    public int ModuloId { get; set; }

    public int OperacoesId { get; set; }

    public bool Permitido { get; set; }

    public virtual Cargo? Cargo { get; set; }

    public virtual Modulo? Modulo { get; set; }

    public virtual Operacao? Operacoes { get; set; }
}
