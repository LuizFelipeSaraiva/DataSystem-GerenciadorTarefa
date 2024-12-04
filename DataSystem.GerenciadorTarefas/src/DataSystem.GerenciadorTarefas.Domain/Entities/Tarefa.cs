using System;

namespace DataSystem.GerenciadorTarefas.Domain.Entities
{
    public class Tarefa : Entity
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime? DataDeConclusao { get; set; }
        public StatusTarefa Status { get; private set; }

        public Tarefa() { }

        public Tarefa(string titulo, string descricao, StatusTarefa status, DateTime? dataDeConclusao, DateTime dataDeCriacao)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataDeCriacao = dataDeCriacao;
            DataDeConclusao = dataDeConclusao;
            Status = status;
        }

        public Tarefa(int id, string titulo, string descricao, StatusTarefa status, DateTime? dataDeConclusao, DateTime dataDeCriacao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataDeConclusao = dataDeConclusao;
            DataDeCriacao = dataDeCriacao;
            Status = status;
        }
    }
}
