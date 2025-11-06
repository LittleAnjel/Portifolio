using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;


public class ItemSaidaService : IItemSaidaService
{
    private readonly IItemSaidaRepository _itemSaidaRepository;

    public ItemSaidaService(IItemSaidaRepository itemSaidaRepository)
    {
        _itemSaidaRepository = itemSaidaRepository; // Inj. dependência
    }

    public async Task<IEnumerable<ItemSaida>> ObterTodosItemSaidasAsync()
    {
        return await _itemSaidaRepository.ObterTodosAsync();
    }

    public async Task<ItemSaida?> ObterItemSaidaPorIdAsync(int id)
    {
        return await _itemSaidaRepository.ObterPorIdAsync(id);
        
    }

    public async Task<ItemSaida> CriarItemSaidaAsync(ItemSaida itemSaida)
    {
        return await _itemSaidaRepository.AdicionarAsync(itemSaida);
    }

    public async Task AtualizarItemSaidaAsync(int id, ItemSaida itemSaida)
    {
        if (id != itemSaida.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _itemSaidaRepository.AtualizarAsync(itemSaida);
    }

    public async Task DeletarItemSaidaAsync(int id)
    {
        await _itemSaidaRepository.DeletarAsync(id);
    }
}

