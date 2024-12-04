using DataSystem.GerenciadorTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace DataSystem.GerenciadorTarefas.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AplicarRegrasDeDadosParaAEntidadeTarefa();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AplicarRegrasDeDadosParaAEntidadeTarefa()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Tarefa tarefa && tarefa.DataDeConclusao.Value.Date == DateTime.MinValue)
                    tarefa.DataDeConclusao = null;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarefa>()
                .Property(p => p.Titulo)
                .HasMaxLength(100)
                .IsRequired();

             modelBuilder.Entity<Tarefa>()
                .Property(p => p.Descricao)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .IsRequired(false);

            modelBuilder.Entity<Tarefa>()
                .Property(p => p.DataDeCriacao)
                .IsRequired(true);

            modelBuilder.Entity<Tarefa>()
                .Property(p => p.DataDeConclusao)
                .HasDefaultValue(null)
                .IsRequired(false);

            modelBuilder.Entity<Tarefa>()
                .Property(p => p.Status)
                .IsRequired(true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GerenciadorTarefas;Integrated Security=True;");
        }
    }
}
