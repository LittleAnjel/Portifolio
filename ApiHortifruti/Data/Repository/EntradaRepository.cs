using Microsoft.EntityFrameworkCore;
using ApiHortifruti.Domain;
using ApiHortifruti.Data.Repository.Interfaces;

namespace ApiHortifruti.Data.Repository;

public class EntradaRepository : IEntradaRepository
{
    private readonly AppDbContext _context;

    public EntradaRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Entrada>> ObterTodosAsync()
    {
        return await _context.Entrada.ToListAsync();
    }

    public async Task<Entrada?> ObterPorIdAsync(int id)
    {
        return await _context.Entrada.FindAsync(id);
    }

    public async Task<Entrada?> ObterPorNumeroNotaAsync(string numeroNota, int fornecedorId)
    {
        return await _context.Entrada
            .FirstOrDefaultAsync(e => e.NumeroNota == numeroNota && e.FornecedorId == fornecedorId);
    }

    public async Task AdicionarAsync(Entrada entrada)
    {
        _context.Entrada.Add(entrada);
        // await _context.SaveChangesAsync();
        // return entrada;
    }

    public async Task AtualizarAsync(Entrada entrada)
    {
        _context.Entry(entrada).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var entrada = await ObterPorIdAsync(id);
        
        if (entrada != null)
        {
            _context.Entrada.Remove(entrada);
            await _context.SaveChangesAsync();
        }
    }
}