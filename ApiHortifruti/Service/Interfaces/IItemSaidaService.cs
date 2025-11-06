using ApiHortifruti.Domain;

namespace ApiHortifruti.Service.Interfaces;

public interface IItemSaidaService
{
    Task<IEnumerable<ItemSaida>> ObterTodosItemSaidasAsync();
    Task<ItemSaida?> ObterItemSaidaPorIdAsync(int id);
    Task<ItemSaida> CriarItemSaidaAsync(ItemSaida itemSaida);
    Task AtualizarItemSaidaAsync(int id, ItemSaida itemSaida); // Provavelmente não vai existir
    Task DeletarItemSaidaAsync(int id); // Provavelmente não vai existir
}