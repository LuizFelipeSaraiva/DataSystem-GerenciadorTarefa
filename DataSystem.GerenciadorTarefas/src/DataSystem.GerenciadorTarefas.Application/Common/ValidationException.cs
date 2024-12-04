using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace DataSystem.GerenciadorTarefas.Application.Common
{
    public class ValidationException : Exception
    {
        public ValidationException() { }
        public ValidationException(IList<ValidationFailure> errosDeValidacao)
        {
            foreach (var erroValidacao in errosDeValidacao)
            {
                Erros += erroValidacao + Environment.NewLine;
            }
        }
        public string Erros { get; set; }
    }
}
