using ApiHortifruti.Data.Repository.Interfaces;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;

namespace ApiHortifruti.Service;

public class ItemEntradaService : IItemEntradaService
{
    private readonly IUnityOfWork _uow;

    public ItemEntradaService(IUnityOfWork uow)
    {
        _uow = uow; // Inj. dependência
    }

    public async Task AdicionarItensEntradaAsync(int entradaId, IEnumerable<ItemEntrada> itens)
    {
        if (itens == null || !itens.Any()) // Verifica se a "lista" é nula ou vazia
            throw new InvalidOperationException("É necessário adicionar no mínimo um item à entrada.");
        
        if (itens.Any(item => item.Quantidade <= 0)) // Verifica se a quantidade de todos os itens é maior que zero
            throw new InvalidOperationException("A quantidade de todos os itens deve ser maior que zero");

        await _uow.ItensEntrada.AdicionarItensEntradaAsync(itens); // Adicionar o(s) itemEntrada

        foreach (var item in itens)
        {
            var produto = await _uow.Produto.ObterPorIdAsync(item.ProdutoId); // Obtêm o produto baseado no id dentro do item entrada

            if (produto == null) // Verifica se o produto "existe" (foi retornado)
                throw new InvalidOperationException($"O produto com ID {item.ProdutoId} não existe."); // Problema de segurança (expor id)?

            produto.QuantidadeAtual += item.Quantidade; // Soma o valor informado em item entrada e adiciona a quantidade atual em produto
            await _uow.Produto.AtualizarAsync(produto); // Faz o PUT no context do EF em produtos [REDUNDATE?]
        }

    }
}

