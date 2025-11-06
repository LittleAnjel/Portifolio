using ApiHortifruti.Domain;

namespace ApiHortifruti.Service.Interfaces;

public interface IMotivoMovimentacaoService
{
    Task<IEnumerable<MotivoMovimentacao>> ObterTodosMotivoMovimentacaoAsync();
    Task<MotivoMovimentacao?> ObterMotivoMovimentacaoPorIdAsync(int id);
    Task<MotivoMovimentacao> CriarMotivoMovimentacaoAsync(MotivoMovimentacao motivoMovimentacao);
    Task AtualizarMotivoMovimentacaoAsync(int id, MotivoMovimentacao motivoMovimentacao);
    Task DeletarMotivoMovimentacaoAsync(int id);
}