using ApiHortifruti.Domain;

namespace ApiHortifruti.Service.Interfaces;

public interface IItemEntradaService
{
    Task AdicionarItensEntradaAsync(int entradaId, IEnumerable<ItemEntrada> itens); // Valida os itens de entrada (ex: existe o produto?, quantidade > 0?, preço >= 0?)
}