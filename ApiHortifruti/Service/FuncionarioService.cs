using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task<IEnumerable<Funcionario>> ObterTodosFuncionarioAsync()
    {
        return await _funcionarioRepository.ObterTodosAsync();
    }

    public async Task<Funcionario?> ObterFuncionarioPorIdAsync(int id)
    {
        return await _funcionarioRepository.ObterPorIdAsync(id);
    }

    public async Task<Funcionario> CriarFuncionarioAsync(Funcionario funcionario)
    {
        return await _funcionarioRepository.AdicionarAsync(funcionario);
    }

    public async Task AtualizarFuncionarioAsync(int id, Funcionario funcionario)
    {
        if (id != funcionario.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _funcionarioRepository.AtualizarAsync(funcionario);
    }

    public async Task DeletarFuncionarioAsync(int id)
    {
        await _funcionarioRepository.DeletarAsync(id);
    }
}