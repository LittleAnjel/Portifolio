using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;


public class FornecedorProdutoService : IFornecedorProdutoService
{
    private readonly IFornecedorProdutoRepository _fornecedorProdutoRepository;

    public FornecedorProdutoService(IFornecedorProdutoRepository fornecedorProdutoRepository)
    {
        _fornecedorProdutoRepository = fornecedorProdutoRepository;
    }

    public async Task<IEnumerable<FornecedorProduto>> ObterTodosFornecedorProdutosAsync()
    {
        return await _fornecedorProdutoRepository.ObterTodosAsync();
    }

    public async Task<FornecedorProduto?> ObterFornecedorProdutoPorIdAsync(int fornecedorId, int produtoId)
    {
        return await _fornecedorProdutoRepository.ObterPorIdAsync(fornecedorId, produtoId);
    }

    public async Task<FornecedorProduto> CriarFornecedorProdutoAsync(FornecedorProduto fornecedorProduto)
    {
        return await _fornecedorProdutoRepository.AdicionarAsync(fornecedorProduto);
    }

    public async Task AtualizarFornecedorProdutoAsync(int fornecedorId, int produtoId, FornecedorProduto fornecedorProduto)
    {
        if (fornecedorId != fornecedorProduto.FornecedorId || produtoId != fornecedorProduto.ProdutoId)
        {
            // Lançar erro/exceção | [new argumentexception]?
            return;
        }
        await _fornecedorProdutoRepository.AtualizarAsync(fornecedorProduto);
    }

    public async Task DeletarFornecedorProdutoAsync(int fornecedorId, int produtoId)
    {
        await _fornecedorProdutoRepository.DeletarAsync(fornecedorId, produtoId);
    }
}

