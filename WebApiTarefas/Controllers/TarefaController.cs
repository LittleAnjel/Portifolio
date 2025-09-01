using Microsoft.AspNetCore.Mvc;
using ApiDeTarefasMySql.Domain;
using ApiDeTarefasMySql.Service;

namespace ApiDeTarefasMySql.Controllers;

[Route("api/[controller]")] 
[ApiController] 
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarefa>>> ObterTarefas()
    {
        var tarefas = await _tarefaService.ObterTodasTarefasAsync();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> ObterTarefa(int id)
    {
        var tarefa = await _tarefaService.ObterTarefaPorIdAsync(id);

        if (tarefa == null) return NotFound();
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<Tarefa>> CriarTarefa(Tarefa tarefa)
    {
        var tarefaCriada = await _tarefaService.CriarTarefaAsync(tarefa);
        return CreatedAtAction(nameof(ObterTarefa), new { id = tarefaCriada.Id },
            tarefaCriada);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTarefa(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id) return BadRequest();
        await _tarefaService.AtulizarTarefaAsync(id, tarefa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarTarefa(int id) 
    { 
        await _tarefaService.DeletarTarefaAsync(id); 
        return NoContent(); 
    } 
    
    
}