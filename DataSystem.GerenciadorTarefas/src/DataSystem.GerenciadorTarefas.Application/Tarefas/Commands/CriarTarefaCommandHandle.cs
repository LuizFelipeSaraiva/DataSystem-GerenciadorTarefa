using MediatR;
using System.Threading.Tasks;
using System.Threading;
using DataSystem.GerenciadorTarefas.Domain;
using DataSystem.GerenciadorTarefas.Application.Common;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Commands
{
    public class CriarTarefaCommandHandler : TarefaHandler, IRequestHandler<CriarTarefaCommand>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public CriarTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task Handle(CriarTarefaCommand comandoCriarTarefar, CancellationToken cancellationToken)
        {
                comandoCriarTarefar.Validar();
                var entidadeTarefa = MapearDeComandoParaEntidadeTarefa(comandoCriarTarefar);
                await _tarefaRepository.Criar(entidadeTarefa);
        }
    }
}
