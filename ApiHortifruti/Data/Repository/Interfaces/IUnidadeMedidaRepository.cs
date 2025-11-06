using ApiHortifruti.Domain;

namespace ApiHortifruti.Data.Repository.Interfaces;

 public interface IUnidadeMedidaRepository
{
    Task<IEnumerable<UnidadeMedida>> ObterTodosAsync();
    Task<UnidadeMedida?> ObterPorIdAsync(int id);
    Task<UnidadeMedida> AdicionarAsync(UnidadeMedida unidadeMedida);
    Task AtualizarAsync(UnidadeMedida unidadeMedida);
    Task DeletarAsync(int id);
}
