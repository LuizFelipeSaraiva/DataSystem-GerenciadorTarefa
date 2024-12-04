using DataSystem.GerenciadorTarefas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataSystem.GerenciadorTarefas.Domain
{
    public interface ITarefaRepository
    {
        Task<IList<Tarefa>> BuscarTodas();
        Task<Tarefa> BuscarPeloId(int id);
        Task<IList<Tarefa>> BuscarPeloStatus(StatusTarefa status);
        Task<int> Criar(Tarefa tarefa);
        Task<Tarefa> Atualizar(Tarefa tarefa);
        Task Excluir(int Id);
    }
}
