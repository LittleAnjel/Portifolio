using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;

public class UnidadeMedidaService : IUnidadeMedidaService
{
    private readonly IUnidadeMedidaRepository _unidadeMedidaRepository;

    public UnidadeMedidaService(IUnidadeMedidaRepository unidadeMedidaRepository)
    {
        _unidadeMedidaRepository = unidadeMedidaRepository;
    }

    public async Task<IEnumerable<UnidadeMedida>> ObterTodosUnidadeMedidaAsync()
    {
        return await _unidadeMedidaRepository.ObterTodosAsync();
    }

    public async Task<UnidadeMedida?> ObterUnidadeMedidaPorIdAsync(int id)
    {
        return await _unidadeMedidaRepository.ObterPorIdAsync(id);
    }

    public async Task<UnidadeMedida> CriarUnidadeMedidaAsync(UnidadeMedida unidadeMedida)
    {
        return await _unidadeMedidaRepository.AdicionarAsync(unidadeMedida);
    }

    public async Task AtualizarUnidadeMedidaAsync(int id, UnidadeMedida unidadeMedida)
    {
        if (id != unidadeMedida.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _unidadeMedidaRepository.AtualizarAsync(unidadeMedida);
    }

    public async Task DeletarUnidadeMedidaAsync(int id)
    {
        await _unidadeMedidaRepository.DeletarAsync(id);
    }
}