using ApiHortifruti.Domain;

namespace ApiHortifruti.Data.Repository.Interfaces;

public interface IItemSaidaRepository
{
    Task<IEnumerable<ItemSaida>> ObterTodosAsync();
    Task<ItemSaida?> ObterPorIdAsync(int id);
    Task<ItemSaida> AdicionarAsync(ItemSaida itemSaida);
    Task AtualizarAsync(ItemSaida itemSaida);
    Task DeletarAsync(int id);
}