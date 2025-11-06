using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiHortifruti.Data.Repository;

public class UnidadeMedidaRepository : IUnidadeMedidaRepository
{
    private readonly AppDbContext _context;

    public UnidadeMedidaRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<UnidadeMedida>> ObterTodosAsync()
    {
        return await _context.UnidadeMedida.ToListAsync();
    }

    public async Task<UnidadeMedida?> ObterPorIdAsync(int id)
    {
        return await _context.UnidadeMedida.FindAsync(id);
    }

    public async Task<UnidadeMedida> AdicionarAsync(UnidadeMedida unidadeMedida)
    {
        _context.UnidadeMedida.Add(unidadeMedida);
        await _context.SaveChangesAsync();
        return unidadeMedida;
    }

    public async Task AtualizarAsync(UnidadeMedida unidadeMedida)
    {
        _context.Entry(unidadeMedida).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var unidadeMedida = await ObterPorIdAsync(id);

        if (unidadeMedida != null)
        {
            _context.UnidadeMedida.Remove(unidadeMedida);
            await _context.SaveChangesAsync();
        }
    }
}