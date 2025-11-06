using Microsoft.EntityFrameworkCore.Storage;

namespace ApiHortifruti.Data.Repository.Interfaces;

public interface IUnityOfWork : IDisposable, IAsyncDisposable
{
    IEntradaRepository Entrada { get; }
    IItemEntradaRepository ItensEntrada { get; }
    IProdutoRepository Produto { get; }
    IFornecedorRepository Fornecedor { get; }
    IMotivoMovimentacaoRepository MotivoMovimentacao { get; }

    // Controle de persistência
    public Task<int> SaveChangesAsync();

    // Controle de transações
    public Task<IDbContextTransaction> BeginTransactionAsync();
    public Task CommitAsync();
    public Task RollbackAsync();
}
