using MediatR;
using System.Collections.Generic;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Queries
{
    public class BuscarTodasAsTarefasQuery : IRequest<IEnumerable<TarefaDTO>> {}
}
