using MediatR;
using System.Threading.Tasks;
using System.Threading;
using DataSystem.GerenciadorTarefas.Domain;
using DataSystem.GerenciadorTarefas.Application.Common;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Queries
{
    public class BuscarTarefaPeloIdQueryHandler : TarefaHandler, IRequestHandler<BuscarTarefaPeloIdQuery, TarefaDTO>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public BuscarTarefaPeloIdQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<TarefaDTO> Handle(BuscarTarefaPeloIdQuery consultaBuscarTarefaPeloId, CancellationToken cancellationToken)
        {
            var entidadeTarefa = await _tarefaRepository.BuscarPeloId(consultaBuscarTarefaPeloId.Id);
            return MapearDeEntidadeTarefaParaDTODeTarefa(entidadeTarefa);
        }
    }
}
