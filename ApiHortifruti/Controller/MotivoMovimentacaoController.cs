using ApiHortifruti.Domain;
using ApiHortifruti.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiHortifruti.Controller;

[ApiController]
[Route("api/[controller]")]

public class MotivoMovimentacaoController : ControllerBase
{
    private readonly IMotivoMovimentacaoService _motivoMovimentacaoService;

    // CONSTRUTOR + INJEÇÃO DE DEPENDÊNCIA
    public MotivoMovimentacaoController(IMotivoMovimentacaoService motivoMovimentacaoService)
    {
        _motivoMovimentacaoService = motivoMovimentacaoService;
    }

    // OPERAÇÕES
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MotivoMovimentacao>>> ObterTodosMotivoMovimentacao()
    {
        var getAllMotivoMovimentacao = await _motivoMovimentacaoService.ObterTodosMotivoMovimentacaoAsync();
        return Ok(getAllMotivoMovimentacao);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MotivoMovimentacao>> ObterMotivoMovimentacao(int id)
    {
        var getIdMotivoMovimentacao = await _motivoMovimentacaoService.ObterMotivoMovimentacaoPorIdAsync(id);

        if (getIdMotivoMovimentacao == null) return NotFound();
        return Ok(getIdMotivoMovimentacao);
    }

    // get produtos associados a motivoMovimentacao (aqui [/motivoMovimentacao/idmotivoMovimentacao/produtos] ou em produtos [/produtos?motivoMovimentacao=x])?

    [HttpPost]
    public async Task<ActionResult<MotivoMovimentacao>> CriarMotivoMovimentacao(MotivoMovimentacao motivoMovimentacao)
    {
        var motivoMovimentacaoCriada = await _motivoMovimentacaoService.CriarMotivoMovimentacaoAsync(motivoMovimentacao);
        return CreatedAtAction(nameof(ObterMotivoMovimentacao), new { id = motivoMovimentacaoCriada.Id },
            motivoMovimentacaoCriada);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarMotivoMovimentacao(int id, MotivoMovimentacao motivoMovimentacao)
    {
        if (id != motivoMovimentacao.Id) return BadRequest();
        await _motivoMovimentacaoService.AtualizarMotivoMovimentacaoAsync(id, motivoMovimentacao);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarMotivoMovimentacao(int id) 
    { 
        await _motivoMovimentacaoService.DeletarMotivoMovimentacaoAsync(id); 
        return NoContent(); 
    } 
}