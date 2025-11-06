using ApiHortifruti.Domain;

namespace ApiHortifruti.Service.Interfaces;

public interface IFornecedorProdutoService
{
    Task<IEnumerable<FornecedorProduto>> ObterTodosFornecedorProdutosAsync();
    Task<FornecedorProduto?> ObterFornecedorProdutoPorIdAsync(int fornecedorId, int produtoId);
    Task<FornecedorProduto> CriarFornecedorProdutoAsync(FornecedorProduto categoria);
    Task AtualizarFornecedorProdutoAsync(int fornecedorId, int produtoId, FornecedorProduto categoria);
    Task DeletarFornecedorProdutoAsync(int fornecedorId, int produtoId);
}