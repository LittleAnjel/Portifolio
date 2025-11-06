using ApiHortifruti.Domain;

namespace ApiHortifruti.Service.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> ObterTodosProdutoAsync();
    Task<Produto?> ObterProdutoPorIdAsync(int id);
    Task<Produto> CriarProdutoAsync(Produto produto);
    Task AtualizarProdutoAsync(int id, Produto produto);
    Task DeletarProdutoAsync(int id);
}