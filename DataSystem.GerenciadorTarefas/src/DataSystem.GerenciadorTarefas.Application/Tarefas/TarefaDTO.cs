using DataSystem.GerenciadorTarefas.Domain;
using System;

namespace DataSystem.GerenciadorTarefas.Application.Tarefas
{
    public class TarefaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeConclusao { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
