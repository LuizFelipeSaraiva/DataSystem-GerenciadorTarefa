using DataSystem.GerenciadorTarefas.Application.Tarefas.Commands;
using DataSystem.GerenciadorTarefas.Domain;
using DataSystem.GerenciadorTarefas.Domain.Entities;
using DataSystem.GerenciadorTarefas.Infraestructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataSystem.GerenciadorTarefas.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<Tarefa>();
            services.AddMediatR(mediatrServiceConfiguration => mediatrServiceConfiguration.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CriarTarefaCommandHandler))));
            return services;
        }
    }
}
