using DataSystem.GerenciadorTarefas.Application.Tarefas;
using DataSystem.GerenciadorTarefas.Application.Tarefas.Commands;
using DataSystem.GerenciadorTarefas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DataSystem.GerenciadorTarefas.Application.Common
{
    public class TarefaHandler
    {
        public TarefaDTO MapearDeEntidadeTarefaParaDTODeTarefa(Tarefa tarefa)
        {
            var tarefaDTO = new TarefaDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataDeConclusao = tarefa.DataDeConclusao,
                DataDeCriacao = tarefa.DataDeCriacao,
                Status = tarefa.Status
            };
            return tarefaDTO;
        }
        public IEnumerable<TarefaDTO> MapearDeEntidadeTarefaParaDTODeTarefa(IEnumerable<Tarefa> tarefas)
        {
            var listaDeTarefasDTO = new List<TarefaDTO>();
            foreach (var tarefa in tarefas)
            {
                var tarefaDTO = new TarefaDTO
                {
                    Id = tarefa.Id,
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    DataDeConclusao = tarefa.DataDeConclusao,
                    DataDeCriacao = tarefa.DataDeCriacao,
                    Status = tarefa.Status
                };
                listaDeTarefasDTO.Add(tarefaDTO);
            }
            return listaDeTarefasDTO;
        }

        public Tarefa MapearDeComandoParaEntidadeTarefa(CriarTarefaCommand comandoDeCriarTarefa)
        {
            return new Tarefa(comandoDeCriarTarefa.Titulo, comandoDeCriarTarefa.Descricao, comandoDeCriarTarefa.Status, comandoDeCriarTarefa.DataDeConclusao, DateTime.Now.Date);
        }
        public Tarefa MapearDeComandoParaEntidadeTarefa(AtualizarTarefaCommand comandoDeAtualizarTarefa)
        {
            return new Tarefa(comandoDeAtualizarTarefa.Id, comandoDeAtualizarTarefa.Titulo, comandoDeAtualizarTarefa.Descricao, comandoDeAtualizarTarefa.Status, comandoDeAtualizarTarefa.DataDeConclusao, comandoDeAtualizarTarefa.DataDeCriacao);
        }
    }
}
