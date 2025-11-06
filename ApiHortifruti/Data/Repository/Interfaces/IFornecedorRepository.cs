using ApiHortifruti.Domain;

namespace ApiHortifruti.Data.Repository.Interfaces;

 public interface IFornecedorRepository
{
    Task<IEnumerable<Fornecedor>> ObterTodosAsync();
    Task<Fornecedor?> ObterPorIdAsync(int id);
    Task<Fornecedor> AdicionarAsync(Fornecedor fornecedor);
    Task AtualizarAsync(Fornecedor fornecedor);
    Task DeletarAsync(int id);
}
