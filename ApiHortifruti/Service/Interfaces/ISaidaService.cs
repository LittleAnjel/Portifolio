using ApiHortifruti.Domain;

namespace ApiHortifruti.Service.Interfaces;

public interface ISaidaService
{
    Task<IEnumerable<Saida>> ObterTodosSaidasAsync();
    Task<Saida?> ObterSaidaPorIdAsync(int id);
    Task<Saida> CriarSaidaAsync(Saida saida);
    Task AtualizarSaidaAsync(int id, Saida saida);
    Task DeletarSaidaAsync(int id);
}