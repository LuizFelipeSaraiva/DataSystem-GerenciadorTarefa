using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DataSystem.GerenciadorTarefas.Application.Common
{
    public class TratamentoGlobalExcecoesFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            var exception = exceptionContext.Exception;
            switch (exception)
            {
                case ValidationException e:
                    {
                        exceptionContext.Result = new ObjectResult(new { message = e.Erros, status = 400 }) { StatusCode = 400 };
                        break;
                    }
                default:
                    {
                        exceptionContext.Result = new ObjectResult(new { message = exception.Message, status = 500 }) { StatusCode = 500 };
                        break;
                    }
            }
            exceptionContext.ExceptionHandled = true;
        }
    }
}
