using System.Data;
using ApiHortifruti.Domain;
using ApiHortifruti.Exceptions;
using ApiHortifruti.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiHortifruti.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UnidadeMedidaController : ControllerBase
{
    private readonly IUnidadeMedidaService _unidadeMedidaService;
    private readonly IMapper _mapper;

    public UnidadeMedidaController(IUnidadeMedidaService unidadeMedidaService, IMapper mapper)
    {
        _unidadeMedidaService = unidadeMedidaService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnidadeMedida>>> ObterTodosUnidadeMedida()
    {
        var getAllUnidadeMedida = await _unidadeMedidaService.ObterTodosUnidadeMedidaAsync();
        
        
        if (!getAllUnidadeMedida.Any())
            throw new DBConcurrencyException("Nenhuma unidade de medida criada.");
        
        return Ok(getAllUnidadeMedida);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UnidadeMedida>> ObterUnidadeMedida(int id)
    {
        var getIdUnidadeMedida = await _unidadeMedidaService.ObterUnidadeMedidaPorIdAsync(id);

        if (getIdUnidadeMedida == null)
            throw new NotFoundExeption("Unidade de medida não existe.");
        
        return Ok(getIdUnidadeMedida);
    }

    [HttpPost]
    public async Task<ActionResult<UnidadeMedida>> CriarUnidadeMedida(PostUnidadeMedidaDTO postUnidadeMedidaDTO)
    {
        var unidadeMedida = _mapper.Map<UnidadeMedida>(postUnidadeMedidaDTO); // Conversão de DTO para entidade
        
        var unidadeMedidaCriada = await _unidadeMedidaService.CriarUnidadeMedidaAsync(unidadeMedida);
        return CreatedAtAction(nameof(ObterUnidadeMedida), new { unidadeMedidaCriada.Id },
            unidadeMedidaCriada);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarUnidadeMedida(int id, UnidadeMedida unidadeMedida)
    {
        if (id != unidadeMedida.Id) return BadRequest();
        await _unidadeMedidaService.AtualizarUnidadeMedidaAsync(id, unidadeMedida);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarUnidadeMedida(int id) 
    { 
        await _unidadeMedidaService.DeletarUnidadeMedidaAsync(id); 
        return NoContent(); 
    }
}