using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiHortifruti.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HistoricoProdutoController : ControllerBase
{
    private readonly IHistoricoProdutoService _historicoProdutoService;

    public HistoricoProdutoController(IHistoricoProdutoService historicoProdutoService)
    {
        _historicoProdutoService = historicoProdutoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HistoricoProduto>>> ObterTodosHistoricoProduto()
    {
        var getAllHistoricoProduto = await _historicoProdutoService.ObterTodosHistoricoProdutosAsync();
        return Ok(getAllHistoricoProduto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HistoricoProduto>> ObterHistoricoProduto(int id) // Faz sentido? Ou deveria ser por produto?
    {
        var getIdHistoricoProduto = await _historicoProdutoService.ObterHistoricoProdutoPorIdAsync(id);

        if (getIdHistoricoProduto == null) return NotFound();
        return Ok(getIdHistoricoProduto);
    }

    // [HttpPost]
    // public async Task<ActionResult<HistoricoProduto>> CriarHistoricoProduto(HistoricoProduto historicoProduto)
    // {
    //     var produtoCriada = await _historicoProdutoService.CriarHistoricoProdutoAsync(historicoProduto);
    //     return CreatedAtAction(nameof(ObterHistoricoProduto), new { id = produtoCriada.Id },
    //         produtoCriada);
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> AtualizarHistoricoProduto(int id, HistoricoProduto historicoProduto)
    // {
    //     if (id != historicoProduto.Id) return BadRequest();
    //     await _historicoProdutoService.AtualizarHistoricoProdutoAsync(id, historicoProduto);
    //     return NoContent();
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeletarHistoricoProduto(int id) 
    // { 
    //     await _historicoProdutoService.DeletarHistoricoProdutoAsync(id); 
    //     return NoContent(); 
    // } 
}