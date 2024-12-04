using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using DataSystem.GerenciadorTarefas.Domain.Entities;
using DataSystem.GerenciadorTarefas.Domain;
using DataSystem.GerenciadorTarefas.Application.Common;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Queries
{
    public class BuscarTodasAsTarefasQueryHandler : TarefaHandler, IRequestHandler<BuscarTodasAsTarefasQuery, IEnumerable<TarefaDTO>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public BuscarTodasAsTarefasQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<TarefaDTO>> Handle(BuscarTodasAsTarefasQuery consultaBuscarTodasAsTarefasQuery, CancellationToken cancellationToken)
        {
            IEnumerable<Tarefa> listaDeEntidadesTarefas = await _tarefaRepository.BuscarTodas();
            return MapearDeEntidadeTarefaParaDTODeTarefa(listaDeEntidadesTarefas);
        }
    }
}
