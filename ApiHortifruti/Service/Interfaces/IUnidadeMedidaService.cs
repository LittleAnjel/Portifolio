using ApiHortifruti.Domain;

namespace ApiHortifruti.Service.Interfaces;

public interface IUnidadeMedidaService
{
    Task<IEnumerable<UnidadeMedida>> ObterTodosUnidadeMedidaAsync();
    Task<UnidadeMedida?> ObterUnidadeMedidaPorIdAsync(int id);
    Task<UnidadeMedida> CriarUnidadeMedidaAsync(UnidadeMedida unidadeMedida);
    Task AtualizarUnidadeMedidaAsync(int id, UnidadeMedida unidadeMedida);
    Task DeletarUnidadeMedidaAsync(int id);
}