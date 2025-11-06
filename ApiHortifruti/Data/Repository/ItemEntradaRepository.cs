using Microsoft.EntityFrameworkCore;
using ApiHortifruti.Domain;
using ApiHortifruti.Data.Repository.Interfaces;

namespace ApiHortifruti.Data.Repository;

public class ItemEntradaRepository : IItemEntradaRepository
{
    private readonly AppDbContext _context; // Inj. dep.

    // Construtor
    public ItemEntradaRepository(AppDbContext context)
    {
        _context = context;
    }

    // Métodos da interface
    public async Task AdicionarItensEntradaAsync(IEnumerable<ItemEntrada> itens)
    {
       await _context.ItemEntrada.AddRangeAsync(itens); // Adiciona no context a "lista" de itens (ou item se só tiver 1 item na list)
    }
}