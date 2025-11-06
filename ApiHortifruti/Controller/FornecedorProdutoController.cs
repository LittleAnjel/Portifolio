using ApiHortifruti.Data.Repository;
using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiHortifruti.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FornecedorProdutoController : ControllerBase
{
    private readonly IFornecedorProdutoService _fornecedorProdutoService;

    public FornecedorProdutoController(IFornecedorProdutoService fornecedorProdutoService)
    {
        _fornecedorProdutoService = fornecedorProdutoService;
    }

    // Operação de consulta de todos os registro da tabela
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FornecedorProduto>>> ObterTodosFornecedorProduto()
    {
        var getAllFornecedorProduto = await _fornecedorProdutoService.ObterTodosFornecedorProdutosAsync();
        return Ok(getAllFornecedorProduto);
    }

    // Operação de consulta por ID
    [HttpGet("{fornecedorId}/{produtoId}")]
    public async Task<ActionResult<FornecedorProduto>> ObterFornecedorProduto(int fornecedorId, int produtoId)
    {
        var getIdFornecedorProduto = await _fornecedorProdutoService.ObterFornecedorProdutoPorIdAsync(fornecedorId, produtoId);

        if (getIdFornecedorProduto == null) return NotFound();
        return Ok(getIdFornecedorProduto);
    }

    // Operação de criação do registro na tabela
    [HttpPost]
    public async Task<ActionResult<FornecedorProduto>> CriarFornecedorProduto(FornecedorProduto fornecedorProduto)
    {
        var fornecedorProdutoCriada = await _fornecedorProdutoService.CriarFornecedorProdutoAsync(fornecedorProduto);

        return CreatedAtAction(nameof(ObterFornecedorProduto), new { fornecedorId = fornecedorProduto.FornecedorId, produtoId = fornecedorProduto.ProdutoId },
            fornecedorProdutoCriada);
    }

    // Operação de alteração de algum registro na tabela
    [HttpPut("{fornecedorId}/{produtoId}")] 
    public async Task<IActionResult> AtualizarFornecedorProduto(int fornecedorId, int produtoId, FornecedorProduto fornecedorProduto)
    {
        if (fornecedorId != fornecedorProduto.FornecedorId || produtoId != fornecedorProduto.ProdutoId) return BadRequest();

        await _fornecedorProdutoService.AtualizarFornecedorProdutoAsync(fornecedorId, produtoId, fornecedorProduto);
        return NoContent();
    }

    // Operação de exclusão de algum registro na tabela
    [HttpDelete("{fornecedorId}/{produtoId}")]
    public async Task<IActionResult> DeletarFornecedorProduto(int fornecedorId, int produtoId)
    {
        await _fornecedorProdutoService.DeletarFornecedorProdutoAsync(fornecedorId, produtoId);
        return NoContent();
    } 
}