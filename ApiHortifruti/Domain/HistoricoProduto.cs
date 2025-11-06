namespace ApiHortifruti.Domain;

/// <summary>
/// Talvez mudar a estrutura para conseguir armazenar alterações em nomes (e/ou código) também (não só em valor):
/// 
/// valor_original
/// valor_alterado
/// tipo_alteracao (ENUM(&quot;Valor&quot;,&quot;Nome&quot;,&quot;Codigo&quot;))
/// </summary>
public partial class HistoricoProduto
{
    public int Id { get; set; }

    public int ProdutoId { get; set; }

    public decimal PrecoProduto { get; set; }

    public DateOnly DataAlteracao { get; set; }

    public int FuncionarioId { get; set; }

    public virtual Funcionario Funcionario { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}
