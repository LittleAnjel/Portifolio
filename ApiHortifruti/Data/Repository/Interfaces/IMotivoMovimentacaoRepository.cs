using ApiHortifruti.Domain;

namespace ApiHortifruti.Data.Repository.Interfaces;

public interface IMotivoMovimentacaoRepository
{
    Task<IEnumerable<MotivoMovimentacao>> ObterTodosAsync();
    Task<MotivoMovimentacao?> ObterPorIdAsync(int id);
    Task<MotivoMovimentacao> AdicionarAsync(MotivoMovimentacao motivoMovimentacao);
    Task AtualizarAsync(MotivoMovimentacao motivoMovimentacao);
    Task DeletarAsync(int id);
}