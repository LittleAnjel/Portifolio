using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task<IEnumerable<Fornecedor>> ObterTodosFornecedoresAsync()
    {
        return await _fornecedorRepository.ObterTodosAsync();
    }

    public async Task<Fornecedor?> ObterFornecedorPorIdAsync(int id)
    {
        return await _fornecedorRepository.ObterPorIdAsync(id);
    }

    public async Task<Fornecedor> CriarFornecedorAsync(Fornecedor fornecedor)
    {
        return await _fornecedorRepository.AdicionarAsync(fornecedor);
    }

    public async Task AtualizarFornecedorAsync(int id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _fornecedorRepository.AtualizarAsync(fornecedor);
    }

    public async Task DeletarFornecedorAsync(int id)
    {
        await _fornecedorRepository.DeletarAsync(id);
    }
}