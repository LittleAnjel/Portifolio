using ApiDeTarefasMySql.Data.Repository;
using ApiDeTarefasMySql.Domain;

namespace ApiDeTarefasMySql.Service;

public class TarefaServico : ITarefaService
{
    private readonly ITarefaRepositorio _tarefaRepositorio;

    public TarefaServico(ITarefaRepositorio tarefaRepositorio)
    {
        _tarefaRepositorio = tarefaRepositorio;
    }

    public async Task<IEnumerable<Tarefa>> ObterTodasTarefasAsync() => await
        _tarefaRepositorio.ObterTodasAsync();
    

    public async Task<Tarefa?> ObterTarefaPorIdAsync(int id) => await
        _tarefaRepositorio.ObterPorIdAsync(id);
    

    public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa) => await
        _tarefaRepositorio.AdicionarAsync(tarefa);
    

    public async Task AtulizarTarefaAsync(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _tarefaRepositorio.AtulizarAsync(tarefa);
    }
    
    public async Task DeletarTarefaAsync(int id) => await _tarefaRepositorio.DeletarAsync(id);
}