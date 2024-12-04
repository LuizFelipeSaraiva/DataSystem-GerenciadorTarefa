using FluentValidation;
using System;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Commands
{
    public class CriarTarefaCommandValidation : AbstractValidator<CriarTarefaCommand>
    {
        public CriarTarefaCommandValidation()
        {
            RuleFor(criarTarefaCommand => criarTarefaCommand.Titulo)
                .NotNull().WithMessage("Um título deve ser informado para a tarefa.")
                .NotEmpty().WithMessage("Um título deve ser informado para a tarefa.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(criarTarefaCommand => criarTarefaCommand.DataDeConclusao)
                .Must((criarTarefaCommand, DataDeConclusao) => DataDeConclusao.HasValue && DataDeConclusao.Value.Date > DateTime.MinValue && DataDeConclusao.Value.Date > DateTime.Now.Date)
                .WithMessage("A data de conclusão da tarefa não pode ser anterior a data de criação.");
        }       
    }
}
