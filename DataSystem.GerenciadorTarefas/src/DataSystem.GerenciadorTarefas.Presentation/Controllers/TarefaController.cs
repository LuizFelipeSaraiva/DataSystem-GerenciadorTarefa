using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataSystem.GerenciadorTarefas.Application.Tarefas.Commands;
using DataSystem.GerenciadorTarefas.Application.Tarefas.Queries;
using DataSystem.GerenciadorTarefas.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DataSystem.GerenciadorTarefas.Presentation.Controllers
{
    [ApiController]
    [Route("/api/tarefa")]
    public class TarefaController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator = _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> BuscarTodasAsTarefas()
        {
            var listaDeTarefasDTO = await Mediator.Send(new BuscarTodasAsTarefasQuery());
            return Ok(listaDeTarefasDTO);
        }

        [HttpGet("BuscarTarefaPeloId/{id}")]
        public async Task<IActionResult> BuscarTarefaPeloId(int id)
        {
            var tarefaDTO = await Mediator.Send(new BuscarTarefaPeloIdQuery { Id = id });
            return Ok(tarefaDTO);
        }

        [HttpGet("{status}")]
        public async Task<IActionResult> BuscarTarefasPeloStatus(StatusTarefa status)
        {
            var listaDeTarefasDTO = await Mediator.Send(new BuscarTarefasPeloStatusQuery { Status = status });
            return Ok(listaDeTarefasDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa(CriarTarefaCommand criarTarefa)
        {
            await Mediator.Send(criarTarefa);
            return Ok(new { message = "Tarefa criada!" });
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarTarefa(AtualizarTarefaCommand atualizarTarefa)
        {
            var tarefaDTO = await Mediator.Send(atualizarTarefa);
            return Ok(tarefaDTO);
        }

        [HttpDelete("ExcluirTarefa/{id}")]
        public async Task<IActionResult> ExcluirTarefa(int id)
        {
            await Mediator.Send(new ExcluirTarefaCommand { Id = id });
            return Ok();
        }
    }
}
