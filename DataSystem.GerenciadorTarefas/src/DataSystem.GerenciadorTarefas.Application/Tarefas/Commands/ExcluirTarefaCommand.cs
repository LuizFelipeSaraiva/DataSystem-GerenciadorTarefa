using MediatR;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Commands
{
    public class ExcluirTarefaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
