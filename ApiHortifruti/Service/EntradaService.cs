using ApiHortifruti.Data.Repository;
using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;


public class EntradaService : IEntradaService
{
    private readonly IUnityOfWork _uow;
    private readonly IItemEntradaService _itemEntradaService;

    public EntradaService(IUnityOfWork uow, IItemEntradaService itemEntradaService)
    {
        _uow = uow; // Inj. dependência
        _itemEntradaService = itemEntradaService;
    }

    public async Task<IEnumerable<Entrada>> ObterTodosEntradasAsync()
    {
        return await _uow.Entrada.ObterTodosAsync();
    }

    public async Task<Entrada?> ObterEntradaPorIdAsync(int id)
    {
        return await _uow.Entrada.ObterPorIdAsync(id);
    }

    public async Task<Entrada> CriarEntradaAsync(Entrada entrada)
    {
        await using var transaction = await _uow.BeginTransactionAsync();
        
        try // ?
        {
            var fornecedor = await _uow.Fornecedor.ObterPorIdAsync(entrada.FornecedorId);
            var motivo = await _uow.MotivoMovimentacao.ObterPorIdAsync(entrada.MotivoMovimentacaoId);
            var nota = await _uow.Entrada.ObterPorNumeroNotaAsync(entrada.NumeroNota, entrada.FornecedorId);

            if (fornecedor == null) // Verifica se o fornecedor existe
                throw new InvalidOperationException("Fornecedor não encontrado no sistema");

            if (motivo == null) // Verifica se o motivo de movimentação existe
                throw new InvalidOperationException("Motivo de movimentação não encontrado no sistema");

            if (entrada.DataCompra > DateOnly.FromDateTime(DateTime.Now)) // Verifica se a data da compra não é futura
                throw new InvalidOperationException("A data da compra não pode ser uma data futura");

            if (nota != null) // Verifica se já existe uma entrada com o mesmo número de nota para o fornecedor
                throw new InvalidOperationException("Já existe um registro com esse número de nota fiscal para o fornecedor informado");

            await _uow.Entrada.AdicionarAsync(entrada); // Adiciona a entrada
            await _itemEntradaService.AdicionarItensEntradaAsync(entrada.Id, entrada.ItemEntrada); // Valida e "cadastra" os itens da entrada e chama o serviço para atualizar os produtos

            await _uow.SaveChangesAsync(); // Salva as mudanças no contexto
            await _uow.CommitAsync(); // Confirma a transação

            return entrada;
        }
        catch (Exception exc) // ?
        {
            await transaction.RollbackAsync();
            throw new Exception("Erro ao criar a entrada e/ou seus registros subsequentes. MENSAGEM: " + exc.Message);
        }

        
    }

    public async Task AtualizarEntradaAsync(int id, Entrada entrada)
    {
        throw new NotImplementedException();
        // if (id != entrada.Id)
        // {
        //     // Lançar erro/exceção
        //     return;
        // }
        // // await _entradaRepository.AtualizarAsync(entrada);
    }

    public async Task DeletarEntradaAsync(int id)
    {
        throw new NotImplementedException();
        // await _entradaRepository.DeletarAsync(id);
    }
}

