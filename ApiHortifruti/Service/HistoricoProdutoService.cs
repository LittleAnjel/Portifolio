using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;


public class HistoricoProdutoService : IHistoricoProdutoService
{
    private readonly IHistoricoProdutoRepository _historicoProdutoRepository;

    public HistoricoProdutoService(IHistoricoProdutoRepository historicoProdutoRepository)
    {
        _historicoProdutoRepository = historicoProdutoRepository;
    }

    public async Task<IEnumerable<HistoricoProduto>> ObterTodosHistoricoProdutosAsync()
    {
        return await _historicoProdutoRepository.ObterTodosAsync();
    }

    public async Task<HistoricoProduto?> ObterHistoricoProdutoPorIdAsync(int id)
    {
        return await _historicoProdutoRepository.ObterPorIdAsync(id);
    }

    public async Task<HistoricoProduto> CriarHistoricoProdutoAsync(HistoricoProduto historicoProduto)
    {
        return await _historicoProdutoRepository.AdicionarAsync(historicoProduto);
    }

    public async Task AtualizarHistoricoProdutoAsync(int id, HistoricoProduto historicoProduto)
    {
        if (id != historicoProduto.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _historicoProdutoRepository.AtualizarAsync(historicoProduto);
    }

    public async Task DeletarHistoricoProdutoAsync(int id)
    {
        await _historicoProdutoRepository.DeletarAsync(id);
    }
}

