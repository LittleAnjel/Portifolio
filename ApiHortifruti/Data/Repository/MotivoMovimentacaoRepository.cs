using Microsoft.EntityFrameworkCore;
using ApiHortifruti.Domain;
using ApiHortifruti.Data.Repository.Interfaces;

namespace ApiHortifruti.Data.Repository;

public class MotivoMovimentacaoRepository : IMotivoMovimentacaoRepository
{
    private readonly AppDbContext _context;

    public MotivoMovimentacaoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<MotivoMovimentacao>> ObterTodosAsync()
    {
        return await _context.MotivoMovimentacao.ToListAsync();
    }

    public async Task<MotivoMovimentacao?> ObterPorIdAsync(int id)
    {
        return await _context.MotivoMovimentacao.FindAsync(id);
    }

    public async Task<MotivoMovimentacao> AdicionarAsync(MotivoMovimentacao motivoMovimentacao)
    {
        _context.MotivoMovimentacao.Add(motivoMovimentacao);
        await _context.SaveChangesAsync();
        return motivoMovimentacao;
    }

    public async Task AtualizarAsync(MotivoMovimentacao motivoMovimentacao)
    {
        _context.Entry(motivoMovimentacao).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var motivoMovimentacao = await ObterPorIdAsync(id);
        
        if (motivoMovimentacao != null)
        {
            _context.MotivoMovimentacao.Remove(motivoMovimentacao);
            await _context.SaveChangesAsync();
        }
    }
}