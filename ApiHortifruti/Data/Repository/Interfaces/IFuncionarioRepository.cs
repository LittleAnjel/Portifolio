using ApiHortifruti.Domain;

namespace ApiHortifruti.Data.Repository.Interfaces;

 public interface IFuncionarioRepository
{
    Task<IEnumerable<Funcionario>> ObterTodosAsync();
    Task<Funcionario?> ObterPorIdAsync(int id);
    Task<Funcionario> AdicionarAsync(Funcionario funcionario);
    Task AtualizarAsync(Funcionario funcionario);
    Task DeletarAsync(int id);
}
