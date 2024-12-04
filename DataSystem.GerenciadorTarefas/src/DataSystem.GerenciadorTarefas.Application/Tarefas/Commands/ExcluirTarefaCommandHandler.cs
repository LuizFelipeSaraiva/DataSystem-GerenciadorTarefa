using MediatR;
using System.Threading;
using DataSystem.GerenciadorTarefas.Domain;
using System.Threading.Tasks;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Commands
{
    public class ExcluirTarefaCommandHandler : IRequestHandler<ExcluirTarefaCommand>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ExcluirTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task Handle(ExcluirTarefaCommand comandoExcluirTarefa, CancellationToken cancellationToken)
        {
            await _tarefaRepository.Excluir(comandoExcluirTarefa.Id);
        }
    }
}
