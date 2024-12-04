using FluentValidation;
using System;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas.Commands
{
    public class AtualizarTarefaCommandValidation : AbstractValidator<AtualizarTarefaCommand>
    {
        public AtualizarTarefaCommandValidation()
        {
            RuleFor(atualizarTarefaCommand => atualizarTarefaCommand.Titulo)
                .NotNull().WithMessage("Um título deve ser informado para a tarefa.")
                .NotEmpty().WithMessage("Um título deve ser informado para a tarefa.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(atualizarTarefaCommand => atualizarTarefaCommand.DataDeConclusao)
                .Must((atualizarTarefaCommand, DataDeConclusao) => DataDeConclusao.HasValue && DataDeConclusao.Value.Date > DateTime.MinValue && DataDeConclusao.Value.Date > DateTime.Now.Date)
                .WithMessage("A data de conclusão da tarefa não pode ser anterior a data de criação.");

            RuleFor(atualizarTarefaCommand => atualizarTarefaCommand.Status)
                .Must((atualizarTarefaCommand, Status) => !Status.Equals(1) && !Status.Equals(2) && !Status.Equals(3))
                .WithMessage("O status informado não é válido.");
        }       
    }
}
