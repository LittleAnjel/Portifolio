using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiHortifruti.Controller;

[ApiController]
[Route("api/[controller]")]

public class SaidaController : ControllerBase
{
    private readonly ISaidaService _saidaService;

    // CONSTRUTOR + INJEÇÃO DE DEPENDÊNCIA
    public SaidaController(ISaidaService saidaService)
    {
        _saidaService = saidaService;
    }

    // OPERAÇÕES
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Saida>>> ObterSaidas() // get all
    {
        var saida = await _saidaService.ObterTodosSaidasAsync();
        return Ok(saida);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Saida>> ObterSaida(int id) // get por id
    {
        var saida = await _saidaService.ObterSaidaPorIdAsync(id);

        if (saida == null) return NotFound();
        return Ok(saida);
    }

    // get produtos associados a saida (aqui [/saida/idsaida/produtos] ou em produtos [/produtos?saida=x])?

    [HttpPost]
    public async Task<ActionResult<Saida>> CriarSaida(Saida saida)
    {
        var saidaCriada = await _saidaService.CriarSaidaAsync(saida);
        return CreatedAtAction(nameof(ObterSaida), new { id = saidaCriada.Id },
            saidaCriada);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarSaida(int id, Saida saida)
    {
        if (id != saida.Id) return BadRequest();
        await _saidaService.AtualizarSaidaAsync(id, saida);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarSaida(int id) 
    { 
        await _saidaService.DeletarSaidaAsync(id); 
        return NoContent(); 
    } 
}