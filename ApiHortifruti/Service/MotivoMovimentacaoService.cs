using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;


public class MotivoMovimentacaoService : IMotivoMovimentacaoService
{
    private readonly IMotivoMovimentacaoRepository _motivoMovimentacaoRepository;

    public MotivoMovimentacaoService(IMotivoMovimentacaoRepository motivoMovimentacaoRepository)
    {
        _motivoMovimentacaoRepository = motivoMovimentacaoRepository; // Inj. dependência
    }

    public async Task<IEnumerable<MotivoMovimentacao>> ObterTodosMotivoMovimentacaoAsync()
    {
        return await _motivoMovimentacaoRepository.ObterTodosAsync();
    }

    public async Task<MotivoMovimentacao?> ObterMotivoMovimentacaoPorIdAsync(int id)
    {
        return await _motivoMovimentacaoRepository.ObterPorIdAsync(id);
        
    }

    public async Task<MotivoMovimentacao> CriarMotivoMovimentacaoAsync(MotivoMovimentacao motivoMovimentacao)
    {
        return await _motivoMovimentacaoRepository.AdicionarAsync(motivoMovimentacao);
    }

    public async Task AtualizarMotivoMovimentacaoAsync(int id, MotivoMovimentacao motivoMovimentacao)
    {
        if (id != motivoMovimentacao.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _motivoMovimentacaoRepository.AtualizarAsync(motivoMovimentacao);
    }

    public async Task DeletarMotivoMovimentacaoAsync(int id)
    {
        await _motivoMovimentacaoRepository.DeletarAsync(id);
    }
}

