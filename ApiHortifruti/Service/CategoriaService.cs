using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;


public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository; // Inj. dependência
    }

    public async Task<IEnumerable<Categoria>> ObterTodosCategoriasAsync()
    {
        return await _categoriaRepository.ObterTodosAsync();
    }

    public async Task<Categoria?> ObterCategoriaPorIdAsync(int id)
    {
        return await _categoriaRepository.ObterPorIdAsync(id);
        
    }

    public async Task<Categoria> CriarCategoriaAsync(Categoria categoria)
    {
        return await _categoriaRepository.AdicionarAsync(categoria);
    }

    public async Task AtualizarCategoriaAsync(int id, Categoria categoria)
    {
        if (id != categoria.Id)
        {
            // Lançar erro/exceção
            return;
        }
        await _categoriaRepository.AtualizarAsync(categoria);
    }

    public async Task DeletarCategoriaAsync(int id)
    {
        await _categoriaRepository.DeletarAsync(id);
    }
}

