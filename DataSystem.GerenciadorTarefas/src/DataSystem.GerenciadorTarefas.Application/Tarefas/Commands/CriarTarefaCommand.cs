using DataSystem.GerenciadorTarefas.Application.Common;
using DataSystem.GerenciadorTarefas.Domain;
using MediatR;
using System;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Commands
{
    public class CriarTarefaCommand : IRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataDeConclusao { get; set; }
        public StatusTarefa Status { get; set; }
        public void Validar()
        {
            var resultadoValidacaoCriarTarefaCommand = new CriarTarefaCommandValidation().Validate(this);
            if (!resultadoValidacaoCriarTarefaCommand.IsValid)
            {
                throw new ValidationException(resultadoValidacaoCriarTarefaCommand.Errors);
            }
        }
    }
}
