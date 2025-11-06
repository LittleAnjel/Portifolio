using Microsoft.EntityFrameworkCore;
using ApiHortifruti.Domain;
using ApiHortifruti.Data.Repository.Interfaces;

namespace ApiHortifruti.Data.Repository;

public class SaidaRepository : ISaidaRepository
{
    private readonly AppDbContext _context;

    public SaidaRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Saida>> ObterTodosAsync()
    {
        return await _context.Saida.ToListAsync();
    }

    public async Task<Saida?> ObterPorIdAsync(int id)
    {
        return await _context.Saida.FindAsync(id);
    }

    public async Task<Saida> AdicionarAsync(Saida saida)
    {
        _context.Saida.Add(saida);
        await _context.SaveChangesAsync();
        return saida;
    }

    public async Task AtualizarAsync(Saida saida)
    {
        _context.Entry(saida).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var saida = await ObterPorIdAsync(id);
        
        if (saida != null)
        {
            _context.Saida.Remove(saida);
            await _context.SaveChangesAsync();
        }
    }
}