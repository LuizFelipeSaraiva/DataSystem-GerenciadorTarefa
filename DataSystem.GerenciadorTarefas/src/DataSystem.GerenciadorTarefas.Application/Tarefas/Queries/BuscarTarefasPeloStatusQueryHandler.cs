using MediatR;
using System.Threading.Tasks;
using System.Threading;
using DataSystem.GerenciadorTarefas.Domain.Entities;
using DataSystem.GerenciadorTarefas.Domain;
using System.Collections.Generic;
using DataSystem.GerenciadorTarefas.Application.Common;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Queries
{
    public class BuscarTarefasPeloStatusQueryHandler : TarefaHandler, IRequestHandler<BuscarTarefasPeloStatusQuery, IEnumerable<TarefaDTO>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public BuscarTarefasPeloStatusQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<TarefaDTO>> Handle(BuscarTarefasPeloStatusQuery consultaBuscarTarefaPeloStatusQuery, CancellationToken cancellationToken)
        {
            IEnumerable<Tarefa> listaDeEntidadesTarefas = await _tarefaRepository.BuscarPeloStatus(consultaBuscarTarefaPeloStatusQuery.Status);
            return MapearDeEntidadeTarefaParaDTODeTarefa(listaDeEntidadesTarefas);
        }
    }
}
