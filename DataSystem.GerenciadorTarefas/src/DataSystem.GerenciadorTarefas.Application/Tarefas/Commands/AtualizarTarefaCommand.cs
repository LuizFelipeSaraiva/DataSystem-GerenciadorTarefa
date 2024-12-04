
using DataSystem.GerenciadorTarefas.Application.Common;
using DataSystem.GerenciadorTarefas.Domain;
using MediatR;
using System;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Commands
{
    public class AtualizarTarefaCommand : IRequest<TarefaDTO>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataDeConclusao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public StatusTarefa Status { get; set; }
        public void Validar()
        {
            var resultadoValidacaoAtualizarTarefaCommand = new AtualizarTarefaCommandValidation().Validate(this);
            if (!resultadoValidacaoAtualizarTarefaCommand.IsValid)
            {
                throw new ValidationException(resultadoValidacaoAtualizarTarefaCommand.Errors);
            }
        }
    }
}
