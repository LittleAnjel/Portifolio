using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiHortifruti.Data.Repository;

public class HistoricoProdutoRepository : IHistoricoProdutoRepository
{
    private readonly AppDbContext _context;

    public HistoricoProdutoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<HistoricoProduto>> ObterTodosAsync()
    {
        return await _context.HistoricoProduto.ToListAsync();
    }

    public async Task<HistoricoProduto?> ObterPorIdAsync(int id)
    {
        return await _context.HistoricoProduto.FindAsync(id);
    }

    public async Task<HistoricoProduto> AdicionarAsync(HistoricoProduto historicoProduto)
    {
        _context.HistoricoProduto.Add(historicoProduto);
        await _context.SaveChangesAsync();
        return historicoProduto;
    }

    public async Task AtualizarAsync(HistoricoProduto historicoProduto)
    {
        _context.Entry(historicoProduto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var historicoProduto = await ObterPorIdAsync(id);
        
        if (historicoProduto != null)
        {
            _context.HistoricoProduto.Remove(historicoProduto);
            await _context.SaveChangesAsync();
        }
    }
}