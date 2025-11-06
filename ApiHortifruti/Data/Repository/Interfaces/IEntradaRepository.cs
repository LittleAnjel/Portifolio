using ApiHortifruti.Domain;

namespace ApiHortifruti.Data.Repository.Interfaces;

public interface IEntradaRepository
{
    Task<IEnumerable<Entrada>> ObterTodosAsync();
    Task<Entrada?> ObterPorIdAsync(int id);
    Task<Entrada?> ObterPorNumeroNotaAsync(string numeroNota, int fornecedorId); // Verifica se já existe uma nota fiscal com esse número para esse fornecedor
    Task AdicionarAsync(Entrada entrada);
    Task AtualizarAsync(Entrada entrada);
    Task DeletarAsync(int id);
}