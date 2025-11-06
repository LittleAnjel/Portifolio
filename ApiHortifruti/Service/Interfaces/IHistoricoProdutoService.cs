using ApiHortifruti.Domain;

namespace ApiHortifruti.Service.Interfaces;

public interface IHistoricoProdutoService
{
    Task<IEnumerable<HistoricoProduto>> ObterTodosHistoricoProdutosAsync();
    Task<HistoricoProduto?> ObterHistoricoProdutoPorIdAsync(int id);
    Task<HistoricoProduto> CriarHistoricoProdutoAsync(HistoricoProduto historicoProduto);
    Task AtualizarHistoricoProdutoAsync(int id, HistoricoProduto historicoProduto);
    Task DeletarHistoricoProdutoAsync(int id);
}