using ApiDeTarefasMySql.Domain;

namespace ApiDeTarefasMySql.Data.Repository;

public interface ITarefaRepositorio
{
    Task<IEnumerable<Tarefa>> ObterTodasAsync();
    Task<Tarefa?> ObterPorIdAsync(int id);
    Task<Tarefa> AdicionarAsync(Tarefa tarefa);
    Task AtulizarAsync(Tarefa tarefa);
    Task DeletarAsync(int id);
}