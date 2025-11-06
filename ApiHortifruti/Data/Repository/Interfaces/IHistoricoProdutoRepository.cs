using ApiHortifruti.Domain;

namespace ApiHortifruti.Data.Repository.Interfaces;

public interface IHistoricoProdutoRepository
{
    Task<IEnumerable<HistoricoProduto>> ObterTodosAsync();
    Task<HistoricoProduto?> ObterPorIdAsync(int id);
    Task<HistoricoProduto> AdicionarAsync(HistoricoProduto historicoProduto);
    Task AtualizarAsync(HistoricoProduto historicoProduto);
    Task DeletarAsync(int id);
}