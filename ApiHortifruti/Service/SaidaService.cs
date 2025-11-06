using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;


public class SaidaService : ISaidaService
{
    private readonly ISaidaRepository _saidaRepository;

    public SaidaService(ISaidaRepository saidaRepository)
    {
        _saidaRepository = saidaRepository; // Inj. dependência
    }

    public async Task<IEnumerable<Saida>> ObterTodosSaidasAsync()
    {
        return await _saidaRepository.ObterTodosAsync();
    }

    public async Task<Saida?> ObterSaidaPorIdAsync(int id)
    {
        return await _saidaRepository.ObterPorIdAsync(id);
        
    }

    public async Task<Saida> CriarSaidaAsync(Saida saida)
    {
        return await _saidaRepository.AdicionarAsync(saida);
    }

    public async Task AtualizarSaidaAsync(int id, Saida saida)
    {
        if (id != saida.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _saidaRepository.AtualizarAsync(saida);
    }

    public async Task DeletarSaidaAsync(int id)
    {
        await _saidaRepository.DeletarAsync(id);
    }
}

