using ApiHortifruti.Service.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Data.Repository.Interfaces;

namespace ApiHortifruti.Service;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository; // Inj. dependência
    }

    public async Task<IEnumerable<Usuario>> ObterTodosUsuarioAsync()
    {
        return await _usuarioRepository.ObterTodosAsync();
    }

    public async Task<Usuario?> ObterUsuarioPorIdAsync(int id)
    {
        return await _usuarioRepository.ObterPorIdAsync(id);
        
    }

    public async Task<Usuario> CriarUsuarioAsync(Usuario usuario)
    {
        return await _usuarioRepository.AdicionarAsync(usuario);
    }

    public async Task AtualizarUsuarioAsync(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _usuarioRepository.AtualizarAsync(usuario);
    }

    public async Task DeletarUsuarioAsync(int id)
    {
        await _usuarioRepository.DeletarAsync(id);
    }
}
