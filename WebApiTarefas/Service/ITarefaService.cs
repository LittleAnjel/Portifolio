using ApiDeTarefasMySql.Domain;

namespace ApiDeTarefasMySql.Service;

public interface ITarefaService
{
    Task<IEnumerable<Tarefa>> ObterTodasTarefasAsync();
    Task<Tarefa?> ObterTarefaPorIdAsync(int id);
    Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);
    Task AtulizarTarefaAsync(int id, Tarefa tarefa);
    Task DeletarTarefaAsync(int id);
}