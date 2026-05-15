using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaService _service;

        public TarefasController(TarefaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _service.ListarTodos();
            return Ok(produtos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var tarefa = await _service.BuscarPorId(id);
            if (tarefa is null) return NotFound($"Tarefa com id: {id} não encontrada");

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] TarefaDto dto)
        {
            var tarefa = await _service.Criar(dto);

            return Created($"/tarefas/{tarefa.Id}", tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] TarefaDto dto)
        {
            var tarefa = await _service.Atualizar(id, dto);
            if (tarefa is null) return NotFound($"Tarefa com id: {id} não encontrada");

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletado = await _service.Deletar(id);
            return deletado ? NoContent() : NotFound($"Tarefa com id: {id} não encontrada");
        }
    }
}