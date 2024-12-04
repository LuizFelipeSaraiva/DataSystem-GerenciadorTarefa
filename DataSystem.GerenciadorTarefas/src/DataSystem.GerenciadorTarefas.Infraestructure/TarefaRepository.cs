using DataSystem.GerenciadorTarefas.Domain;
using DataSystem.GerenciadorTarefas.Domain.Entities;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using static Dapper.SqlMapper;

namespace DataSystem.GerenciadorTarefas.Infraestructure
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _context;

        public TarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Criar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<Tarefa>> BuscarTodas()
        {
            const string sql = @"SELECT T.Id, T.Titulo, T.Descricao, T.DataDeCriacao, T.DataDeConclusao, T.Status FROM Tarefas T ORDER BY T.Id DESC";
            return (IList<Tarefa>) await obterConexaoBancoDadosDoContexto().QueryAsync<Tarefa>(sql);
        }

        public async Task<Tarefa> BuscarPeloId(int id)
        {
            const string sql = @"SELECT T.Id, T.Titulo, T.Descricao, T.DataDeCriacao, T.DataDeConclusao, T.Status FROM Tarefas T WHERE T.Id = @Id ORDER BY T.Id DESC";
            return await obterConexaoBancoDadosDoContexto().QueryFirstOrDefaultAsync<Tarefa>(sql, new { Id = id });
        }

        public async Task<IList<Tarefa>> BuscarPeloStatus(StatusTarefa status)
        {
            const string sql = @"SELECT T.Id, T.Titulo, T.Descricao, T.DataDeCriacao, T.DataDeConclusao, T.Status FROM Tarefas T WHERE T.Status = @Status ORDER BY T.Id DESC";
            return (IList<Tarefa>) await obterConexaoBancoDadosDoContexto().QueryAsync<Tarefa>(sql, new { Status = status });
        }

        public async Task<Tarefa> Atualizar(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task Excluir(int Id)
        {
            var tarefaRemover = _context.Tarefas.Find(Id);
            _context.Tarefas.Remove(tarefaRemover);
            await _context.SaveChangesAsync();
        }

        private DbConnection obterConexaoBancoDadosDoContexto()
        {
            return _context.Database.GetDbConnection();
        }
    }
}
