using DataSystem.GerenciadorTarefas.Domain;
using MediatR;
using System.Collections.Generic;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Queries
{
    public class BuscarTarefasPeloStatusQuery : IRequest<IEnumerable<TarefaDTO>>
    {
        public StatusTarefa Status { get; set; }
    }
}
