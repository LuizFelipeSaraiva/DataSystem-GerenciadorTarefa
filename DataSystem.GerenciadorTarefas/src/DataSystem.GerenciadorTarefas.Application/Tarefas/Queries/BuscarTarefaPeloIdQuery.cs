using MediatR;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Queries
{
    public class BuscarTarefaPeloIdQuery : IRequest<TarefaDTO>
    {
        public int Id { get; set; }
    }
}
