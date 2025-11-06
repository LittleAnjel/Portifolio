using System.Data;
using ApiHortifruti.Domain;
using ApiHortifruti.Exceptions;
using ApiHortifruti.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiHortifruti.Controller;

[ApiController]
[Route("api/[controller]")]

public class FornecedorController : ControllerBase
{
    private readonly IFornecedorService _fornecedorService;
    private readonly IMapper _mapper;

    public FornecedorController(IFornecedorService fornecedorService, IMapper mapper)
    {
        _fornecedorService = fornecedorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> ObterFornecedores()
    {
        var fornecedor = await _fornecedorService.ObterTodosFornecedoresAsync();

        if (!fornecedor.Any())
        {
            throw new DBConcurrencyException("Nenhum fornecedor criado.");
        }

        return Ok(fornecedor);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Fornecedor>> ObterFornecedor(int id)
    {
        var fornecedor = await _fornecedorService.ObterFornecedorPorIdAsync(id);

        if (fornecedor == null) 
        {
            throw new NotFoundExeption("Fornecedor não existe.");
        }
        return Ok(fornecedor);
    }

    [HttpPost]
    public async Task<ActionResult<Fornecedor>> CriarFornecedor(PostFornecedorDTO postFornecedorDTO)
    {
        var fornecedor = _mapper.Map<Fornecedor>(postFornecedorDTO); // Conversão de DTO para entidade
        
        var fornecedorCriado = await _fornecedorService.CriarFornecedorAsync(fornecedor);
        return CreatedAtAction(nameof(ObterFornecedor), new { fornecedorCriado.Id },
            fornecedorCriado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarFornecedor(int id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id) return BadRequest();
        await _fornecedorService.AtualizarFornecedorAsync(id, fornecedor);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarFornecedor(int id) 
    { 
        await _fornecedorService.DeletarFornecedorAsync(id); 
        return NoContent(); 
    }
}