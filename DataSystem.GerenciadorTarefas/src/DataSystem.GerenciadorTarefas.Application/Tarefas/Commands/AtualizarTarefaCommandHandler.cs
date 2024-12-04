using MediatR;
using System.Threading;
using DataSystem.GerenciadorTarefas.Domain;
using System.Threading.Tasks;
using DataSystem.GerenciadorTarefas.Application.Common;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Commands
{
    public class AtualizarTarefaCommandHandler : TarefaHandler, IRequestHandler<AtualizarTarefaCommand, TarefaDTO>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public AtualizarTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<TarefaDTO> Handle(AtualizarTarefaCommand comandoAtualizarTarefa, CancellationToken cancellationToken)
        {
            comandoAtualizarTarefa.Validar();
            var entidadeTarefaAtual = await _tarefaRepository.BuscarPeloId(comandoAtualizarTarefa.Id);
            comandoAtualizarTarefa.DataDeCriacao = entidadeTarefaAtual.DataDeCriacao;

            var entidadeTarefaAtualizada = MapearDeComandoParaEntidadeTarefa(comandoAtualizarTarefa);
            entidadeTarefaAtualizada = await _tarefaRepository.Atualizar(entidadeTarefaAtualizada);
            return MapearDeEntidadeTarefaParaDTODeTarefa(entidadeTarefaAtualizada);
        }
    }
}
