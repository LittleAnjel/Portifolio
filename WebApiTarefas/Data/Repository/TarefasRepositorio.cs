using Microsoft.EntityFrameworkCore;
using ApiDeTarefasMySql.Domain;

namespace ApiDeTarefasMySql.Data.Repository;

public class TarefaRepositorio : ITarefaRepositorio
{
    private readonly AppDbContext _contexto;

    public TarefaRepositorio(AppDbContext contexto)
    {
        _contexto = contexto;
    }
    
    public async Task<IEnumerable<Tarefa>> ObterTodasAsync()
    {
        return await _contexto.Tarefas.ToListAsync();
    }

    public async Task<Tarefa?> ObterPorIdAsync(int id)
    {
        return await _contexto.Tarefas.FindAsync(id);
    }

    public async Task<Tarefa> AdicionarAsync(Tarefa tarefa)
    {
        _contexto.Tarefas.Add(tarefa);
        await _contexto.SaveChangesAsync();
        return tarefa;
    }

    public async Task AtulizarAsync(Tarefa tarefa)
    {
        _contexto.Entry(tarefa).State = EntityState.Modified;
        await _contexto.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var tarefa = await ObterPorIdAsync(id);
        
        if (tarefa != null)
        {
            _contexto.Tarefas.Remove(tarefa);
            await _contexto.SaveChangesAsync();
        }
    }
}

